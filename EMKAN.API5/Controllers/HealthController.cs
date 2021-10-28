using EMKAN.Application.Interfaces;
using EMKAN.Entity.ModelDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMKAN.API5.Controllers
{
    [Route("api/HealthCheck")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        
        private readonly IService _service;
       

        public HealthController(IService requestService)
        {

            _service = requestService;
        }

        [Route("request")]
        [HttpPost]
        public async Task<HealthCheckResult> CreateRequestHealthCheck()
        {
            var result =_service.AddService(new ServiceDto
            {
               
               Description = "I have a problem in submitting my request (program issue)",
               ID = 1,
               UserID = 1,
            });
            if (result == 0)
            {
                return HealthCheckResult.Unhealthy("Unhealthy, process doesn't work successfully!");
            }
            return HealthCheckResult.Healthy("Health, process work successfully!");
        }



    }
}
