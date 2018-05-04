using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using WisT.DemoWeb.API.DTO;
using WisT.Recognizer.Contracts;
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

            //string path_haar = LoadPathFromJson("appsettings.json"); //mb there is required full path
            //var userFace = new FaceImage(image, path_haar);

            //IImageStorage imgRepo;
            //ILabelStorage labelRepo;
            //var recognizer = new Recognizer.Identifier.Recognizer(imgRepo, labelRepo); //need implementation

            //IIdentifier usersId = recognizer.GetIdentity(userFace);
            //WisTResponse.Massage = labelRepo.Get(usersId).ToString();// ToString() needs to be overloaded as a method which returns name of user

        }   

        public string LoadPathFromJson(string jsonPath)
        {
            using (StreamReader r = new StreamReader(jsonPath))
            {
                var json = r.ReadToEnd();
                var items = JsonConvert.DeserializeObject<List<SchemaInfoHaarPath>>(json);
                return items[0].FaceClassifierPath;
            }
        }
    }
}
