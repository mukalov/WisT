﻿using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WisT.DemoWeb.API.DTO;
using WisT.DemoWeb.API.Services;
using Microsoft.AspNetCore.Http;

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
        public async Task<string> Post(RegistrationInfo userInfo)         
        {
            var checkResult = await _registrationService.RegisterAsync(userInfo);
            if (checkResult == WisTResponse.Registered)
            {
                return "Registered";
            }
            else
                return "NotRegistered";
        }
    }
}
