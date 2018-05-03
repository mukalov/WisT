using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using WisT.DemoWeb.API.DTO;

namespace WisT.DemoWeb.API.Controllers
{
    [Route("api/[controller]")]
    class LoginController : Controller
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

            //TO DO
        }
    }
}
