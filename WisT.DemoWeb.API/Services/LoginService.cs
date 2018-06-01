using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
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
    public class LoginService : ILoginService
    {
        private IConfiguration _configuration;
        private ILabelStorage _labelRepo;
        private IHostingEnvironment _hostingEnvironemnt;

        public LoginService(IConfiguration configuration, ILabelStorage labelRepo, IHostingEnvironment hostingEnvironemnt)
        {
            _configuration = configuration;
            _labelRepo = labelRepo;
            _hostingEnvironemnt = hostingEnvironemnt;
        }

        public async Task<WisTResponse> CheckAsync(LoginInfo userInfo)
        {
            WisTResponse response;
            var detectConfig = _configuration["FaceClassifierPath"];
            var recognizeConfig = _configuration["TransistRateCoefficient"];
            var rootPath = _hostingEnvironemnt.ContentRootPath;
            var transistRateCoefficient = double.Parse(recognizeConfig, new NumberFormatInfo { NumberDecimalSeparator = "." });
            var pathToHaar = Path.Combine(rootPath, detectConfig);

            Bitmap image;
            using (var memoryStream = new MemoryStream())
            {
                await userInfo.Photo.CopyToAsync(memoryStream);
                image = new Bitmap(Image.FromStream(memoryStream));
            }
            var _prjPath = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;

            FaceImage userFace;
            try
            {
                userFace = new FaceImage(image, pathToHaar);
                var recognizer = new Recognizer.Identifier.Recognizer(_labelRepo, transistRateCoefficient);

                IIdentifier usersId = recognizer.GetIdentity(userFace);
                if (usersId.IdentifingCode != -1)
                {
                    response = WisTResponse.Recognized;
                    response.UserName = _labelRepo.Get(usersId).Name;
                }
                else
                {
                    response = WisTResponse.NotRegistered;
                }
            }
            catch(UndetectedFaceException)
            {
                response = WisTResponse.NotDetectedFace;
            }
            return response;
        }
    }
}
