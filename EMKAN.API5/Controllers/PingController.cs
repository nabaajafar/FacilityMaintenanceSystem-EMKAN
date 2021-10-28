using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace EMKAN.API5.Controllers
{
    [Route("api/ping")]
    [ApiController]
    public class PingController : ControllerBase
    {
            [HttpGet]
           public IActionResult Get()
           {
               return Ok("EMKAN Api is Working!!");
           }

      
    }
}
