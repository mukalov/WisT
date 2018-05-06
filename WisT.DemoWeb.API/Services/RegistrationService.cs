using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using WisT.DemoWeb.API.DTO;
using WisT.DemoWeb.FilePersistence;
using WisT.Recognizer.Contracts;
using WisT.Recognizer.Identifier;

namespace WisT.DemoWeb.API.Services
{
    public class RegistrationService : IRegistrationService
    {
        private IConfiguration _configuration;

        public RegistrationService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<WisTResponse> RegisterAsync(RegistrationInfo userInfo)
        {
            WisTResponse response = WisTResponse.Registrated;
            string prjPath = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
            var detectConfig = _configuration["FaceClassifierPath"];

            var pathToHaar = prjPath + detectConfig;

            var images = new List<FaceImage>();
            var login = new Label(userInfo.Login) { Id = new Identifier(StrToId(userInfo.Login)) };
            try
            {
                using (var memoryStream = new MemoryStream())
                {
                    foreach (var onePhoto in userInfo.Photoes)
                    {
                        await onePhoto.CopyToAsync(memoryStream);
                        var image = new Bitmap(Image.FromStream(memoryStream));
                        images.Add(new FaceImage(image, pathToHaar) { Id = new Identifier(StrToId(userInfo.Login)) });
                    }
                }
            }
            catch (Exception e)
            {
                if (e.Message == "UndetectedFaceException")
                {
                    response = WisTResponse.NoDetectedFace;
                }
            }

            IImageStorage imgRepo = new ImageStorage();
            ILabelStorage labelRepo = new LabelStorage();

            imgRepo.Add(images);
            labelRepo.Add(login);

            return response;
        }

        private int StrToId(string name)
        {
            int hash = 0;
            int radix = 1;
            foreach (char c in name)
            {
                hash += radix * c;
                radix *= 10;
            }
            return hash;
        }
    }
}
