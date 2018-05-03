using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using WisT.DemoWeb.API.DTO;

namespace WisT.DemoWeb.API.Controllers
{
    [Route("api/[controller]")]
    public class UploadUserInfoController : Controller
    {
        [HttpPost]
        public async Task Post(UserInfoDto userInfo)
        {
            using (var memoryStream = new MemoryStream())
            {
                await userInfo.Photo.CopyToAsync(memoryStream);
                var image = Image.FromStream(memoryStream);
                var bitmap = new Bitmap(image);
            }
            var login = userInfo.Login;
        }
    }
}