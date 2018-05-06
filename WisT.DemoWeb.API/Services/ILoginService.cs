using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WisT.DemoWeb.API.DTO;

namespace WisT.DemoWeb.API.Services
{
    public interface ILoginService
    {
        Task<WisTResponse> CheckAsync(LoginInfo userInfo);
    }
}
