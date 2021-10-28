using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace EMKAN.PresentationLayer_Back_Office_.Controllers
{
    [Route("ping")]
    [ApiController]
    public class PingController : Controller
    {
       
        public IActionResult Get()
        {
            return Ok("Back Office Web is Working!!");
        }
    }

}

