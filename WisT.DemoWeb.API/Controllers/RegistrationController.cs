﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using WisT.DemoWeb.API.DTO;

namespace WisT.DemoWeb.API.Controllers
{
    [Route("api/[controller]")]
    class RegistrationController
    {
        [HttpPost]
        public async Task Post(RegistrationInfo userInfo)
        {
            var images = new List<Bitmap>();
            using (var memoryStream = new MemoryStream())
            {
                foreach (var onePhoto in userInfo.Photoes)
                {
                    await onePhoto.CopyToAsync(memoryStream);
                    var image = Image.FromStream(memoryStream);
                    images.Add(new Bitmap(image));
                }
            }
            var login = userInfo.Login;

            //TO DO
        }
    }
}