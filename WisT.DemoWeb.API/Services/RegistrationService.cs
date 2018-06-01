using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
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
        private ILabelStorage _labelRepo;
        private IHostingEnvironment _hostingEnvironemnt;

        public RegistrationService(IConfiguration configuration, ILabelStorage labelRepo, IHostingEnvironment hostingEnvironemnt)
        {
            _configuration = configuration;
            _labelRepo = labelRepo;
            _hostingEnvironemnt = hostingEnvironemnt;
        }

        public async Task<WisTResponse> RegisterAsync(RegistrationInfo userInfo)
        {
            WisTResponse response = WisTResponse.Registered;
            var rootPath = _hostingEnvironemnt.ContentRootPath;
            var detectConfig = _configuration["FaceClassifierPath"];
            var recognizeConfig = _configuration["TransistRateCoefficient"];
            var transistRateCoefficient = double.Parse(recognizeConfig, new NumberFormatInfo { NumberDecimalSeparator = "." });
            var pathToHaar = Path.Combine(rootPath, detectConfig);

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
                        login.AddImage(new FaceImage(image, pathToHaar));
                    }
                }
                _labelRepo.Add(login);
            }
            catch (UndetectedFaceException)
            {
                response = WisTResponse.NotDetectedFace;
                return response;
            }


     //       _imgRepo.Add(images);

            return response;
        }

    }
}
