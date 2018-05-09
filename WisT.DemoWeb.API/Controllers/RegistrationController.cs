using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WisT.DemoWeb.API.DTO;
using WisT.DemoWeb.API.Services;

namespace WisT.DemoWeb.API.Controllers
{
    [Route("api/[controller]")]
    public class RegistrationController : Controller
    {
        private IRegistrationService _registrationService;

        public RegistrationController(IRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(RegistrationInfo userInfo)
        {
            var checkResult = await _registrationService.RegisterAsync(userInfo);
            if (checkResult.Registered)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
