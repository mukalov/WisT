using Microsoft.Extensions.Configuration;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using WisT.DemoWeb.API.DTO;
using WisT.DemoWeb.FilePersistence;
using WisT.Recognizer.Contracts;
using WisT.Recognizer.Identifier;

namespace WisT.DemoWeb.API.Services
{
    public class LoginService : ILoginService
    {
        private IConfiguration _configuration;
        private IImageStorage _imgRepo;
        private ILabelStorage _labelRepo;

        public LoginService(IConfiguration configuration, IImageStorage imgRepo, ILabelStorage labelRepo)
        {
            _configuration = configuration;
            _imgRepo = imgRepo;
            _labelRepo = labelRepo;
        }

        public async Task<WisTResponse> CheckAsync(LoginInfo userInfo)
        {
            WisTResponse response;

            string prjPath = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
            var detectConfig = _configuration["FaceClassifierPath"];
            var recognizeConfig = _configuration["TransistRateCoefficient"];

            var transistRateCoefficient = double.Parse(recognizeConfig);
            var pathToHaar = prjPath + detectConfig;

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
                var recognizer = new Recognizer.Identifier.Recognizer(_imgRepo, _labelRepo, transistRateCoefficient);

                IIdentifier usersId = recognizer.GetIdentity(userFace);
                if (usersId.IdentifingCode != -1)
                {
                    response = WisTResponse.Recognized;
                }
                else
                {
                    response= WisTResponse.NoRegistrated;
                }
            }
            catch
            {
                response = WisTResponse.NoDetectedFace;
            }
            return response;
        }
    }
}
