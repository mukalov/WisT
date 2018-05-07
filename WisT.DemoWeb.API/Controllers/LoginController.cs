using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WisT.DemoWeb.API.DTO;
using WisT.DemoWeb.API.Services;

namespace WisT.DemoWeb.API.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(LoginInfo userInfo)
        {
            var checkResult = await _loginService.CheckAsync(userInfo);
            if (checkResult == WisTResponse.NotDetectedFace)
                return Ok();
            if (checkResult == WisTResponse.NotRegistered)
                return BadRequest();
            else
                return NotFound();
        }
    }
}
