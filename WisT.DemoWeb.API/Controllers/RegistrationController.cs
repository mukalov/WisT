using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using WisT.DemoWeb.API.DTO;
using WisT.DemoWeb.FilePersistence;
using WisT.Recognizer.Contracts;
using WisT.Recognizer.Identifier;

namespace WisT.DemoWeb.API.Controllers
{
    [Route("api/[controller]")]
    public class RegistrationController
    {
        [HttpPost]
        public async Task Post(RegistrationInfo userInfo)
        {
            string path_haar = LoadPathFromJson("appsettings.json"); //mb there is required full path

            var images = new List<FaceImage>();
            using (var memoryStream = new MemoryStream())
            {
                foreach (var onePhoto in userInfo.Photoes)
                {
                    await onePhoto.CopyToAsync(memoryStream);
                    var image = new Bitmap(Image.FromStream(memoryStream));
                    images.Add(new FaceImage(image, path_haar));
                }
            }
            var login = new Label(userInfo.Login);

            IImageStorage imgRepo = new ImageStorage();
            ILabelStorage labelRepo = new LabelStorage();

            imgRepo.Add(images);
            labelRepo.Add(login);
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
