using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WisT.DemoWeb.API.DTO;

namespace WisT.DemoWeb.API.Controllers
{
    [Route("api/[controller]")]
    public class GreetingController : Controller
    {
        [HttpGet]
        public Task<string> Get()
        {
            return Task.FromResult(WisTResponse.Massage);
        }
    }
}
