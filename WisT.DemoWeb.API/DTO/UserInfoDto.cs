using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace WisT.DemoWeb.API.DTO
{
    public class UserInfoDto
    {
        public string Login { get; set; }
        public List<IFormFile> Photoes { get; set; }
    }
}
