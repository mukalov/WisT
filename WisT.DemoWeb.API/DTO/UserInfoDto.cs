using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;

namespace WisT.DemoWeb.API.DTO
{
    public class UserInfoDto
    {
        public string Login { get; set; }
        public IFormFile Photo { get; set; }
    }
}