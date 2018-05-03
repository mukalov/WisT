using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace WisT.DemoWeb.API.DTO
{
    class RegistrationInfo
    {
        public string Login { get; set; }
        public List<IFormFile> Photoes { get; set; }
    }
}
