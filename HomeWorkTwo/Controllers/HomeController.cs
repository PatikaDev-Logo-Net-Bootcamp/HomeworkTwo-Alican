using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeWorkTwo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [Route("/home")]
        public IActionResult HomeEndpoint()
        {
            return Ok("Home Endpoint");
        }

        [HttpGet]
        [Route("/hidden")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult HiddenEndpoint()
        {
            return Ok();
        }

        [HttpPost]
        [Route("/login")]
        public IActionResult LoginEndpoint()
        {
            return Ok("Login Endpoint");
        }

        [HttpPost]
        [Route("/register")]
        public IActionResult RegisterEndpoint()
        {
            return Ok("Register Endpoint");
        }
    }
}
