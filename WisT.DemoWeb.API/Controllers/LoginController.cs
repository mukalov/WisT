using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using WisT.DemoWeb.API.DTO;
using WisT.Recognizer.Identifier;

namespace WisT.DemoWeb.API.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        [HttpPost]
        public async Task Post(LoginInfo userInfo)
        {
            Bitmap image;
            using (var memoryStream = new MemoryStream())
            {
                    await userInfo.Photo.CopyToAsync(memoryStream);
                    image = new Bitmap(Image.FromStream(memoryStream));
            }

            var userFace = new FaceImage(image);

            //-------------------------------------------------------------------------------
            //IImageStorage imgRepo;
            //ILabelStorage labelRepo;
            //var recognizer = new Recognizer.Identifier.Recognizer(imgRepo, labelRepo); //need implementation

            //IIdentifier usersId = recognizer.GetIdentity(userFace);
            //if (usersId.IdentifingCode != -1)
            //{
            //    WisTResponse.Massage = WisTResponse.GreetingMassage + labelRepo.Get(usersId).Name;
            //}
            //else
            //{
            //    WisTResponse.Massage = WisTResponse.RefuseMassage;
            //}
            //-------------------------------------------------------------------------------
        }


    }
}
