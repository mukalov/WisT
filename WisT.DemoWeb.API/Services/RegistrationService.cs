using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using WisT.DemoWeb.API.DTO;
using WisT.Recognizer.Contracts;
using WisT.Recognizer.Identifier;
using WisT.Recognizer.Identifier.Exceptions;

namespace WisT.DemoWeb.API.Services
{
    public class RegistrationService : IRegistrationService
    {
        private IConfiguration _configuration;
        private IImageStorage _imgRepo;
        private ILabelStorage _labelRepo;

        public RegistrationService(IConfiguration configuration, IImageStorage imgRepo, ILabelStorage labelRepo)
        {
            _configuration = configuration;
            _imgRepo = imgRepo;
            _labelRepo = labelRepo;
        }

        public async Task<WisTResponse> RegisterAsync(RegistrationInfo userInfo)
        {
            WisTResponse response = WisTResponse.Registered;
            string prjPath = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
            var detectConfig = _configuration["FaceClassifierPath"];

            var pathToHaar = prjPath + detectConfig;

            var images = new List<FaceImage>();
            var login = new Label(userInfo.Login);
            try
            {
                using (var memoryStream = new MemoryStream())
                {
                    foreach (var onePhoto in userInfo.Photoes)
                    {
                        await onePhoto.CopyToAsync(memoryStream);
                        var image = new Bitmap(Image.FromStream(memoryStream));
                        images.Add(new FaceImage(image, pathToHaar) { Id = login.Id});
                    }
                }
            }
            catch (UndetectedFaceException)
            {
                response = WisTResponse.NotDetectedFace;
            }

            _imgRepo.Add(images);
            _labelRepo.Add(login);

            return response;
        }

    }
}
