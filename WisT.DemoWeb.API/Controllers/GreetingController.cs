using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WisT.DemoWeb.API.Controllers
{
    [Route("api/[controller]")]
    public class GreetingController : Controller
    {        
        [HttpGet]
        public Task<string> Get()
        {
            return Task.FromResult("Welcome to the WisT demo app!!!!");
        }
    }
}
