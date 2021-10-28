using EMKAN.Application;
using EMKAN.Application.Interfaces;
using EMKAN.Entity.Model;
using EMKAN.Entity.ModelDto;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace EMKAN.API5.Controllers
{
    
    public class ServiceController : ControllerBase
    {
        private readonly IService _Service;
        private readonly IUser _User;

        public ServiceController(IService Service, IUser User)
        {
            _Service = Service;
            _User = User;

        }

        [HttpGet]
        [Route("api/values/DisplayServiceTypes")]
        public async Task<IActionResult> DisplayServicesTypes()
        {
            var tokenFound = Request.Headers.Keys.Contains("Authorization");
            if (tokenFound)
            {
                Request.Headers.TryGetValue("Token", out var value);
                return Ok(await _Service.DisplayServicesTypes());
            }
            else
                return BadRequest();
           

        }
        [HttpGet]
        [Route("api/values/DisplayService")]

        public async Task<IActionResult> DisplayService()
        {
            var tokenFound = Request.Headers.Keys.Contains("Authorization");
            if (tokenFound)
            {
                Request.Headers.TryGetValue("Token", out var value);
                return Ok(_Service.DisplayService());
            }
            else return BadRequest();

        }
        [HttpGet]
        [Route("api/values/DisplayServicesWorkers/{Id}")]

        public async Task<IActionResult> DisplayServicesWorker(int Id)
        {
            var tokenFound = Request.Headers.Keys.Contains("Authorization");
            if (tokenFound)
            {

                Request.Headers.TryGetValue("Token", out var value);
                return Ok(await _Service.DisplayServiceWorkers(Id));
            }
            else
            {
                return BadRequest();
            }

        }
        [HttpPost]
        [Route("api/values/AddEmployeeR")]

        public async Task<IActionResult> AddEmployeeR([FromBody] UserDto user)
        {
            var tokenFound = Request.Headers.Keys.Contains("Authorization");
            if (tokenFound)
            {
                if (user == null)
                {
                    return Ok();
                }

                Request.Headers.TryGetValue("Token", out var value);
                return Ok(_User.AddEmployee(user));
            }
            else return BadRequest();

        }


        [HttpGet]
        [Route("api/values/DisplayEmployee")]

        public async Task<IActionResult> DisplayEmployee()
        {

           var tokenFound = Request.Headers.Keys.Contains("Authorization") ;
            if (tokenFound)
            {
                Request.Headers.TryGetValue("Token", out var value);
                return Ok(_User.DisplayAllEmployee());
            }
            else
            {
                return BadRequest();
            }

            

        }

        [HttpGet]
        [Route("api/values/DisplayServicesForAll")]

        public async Task<IActionResult> DisplayServicesForAll()
        {
            var tokenFound = Request.Headers.Keys.Contains("Authorization");
            if (tokenFound)
            {
                Request.Headers.TryGetValue("Token", out var value);
                return Ok(_Service.DisplayServicesForAll());
            }
            else return BadRequest();

        }
        [HttpGet]
        [Route("api/values/DisplayServices")]

        public async Task<IActionResult> DisplayServices()
        {
            var tokenFound = Request.Headers.Keys.Contains("Authorization");
            if (tokenFound)
            {
                Request.Headers.TryGetValue("Token", out var value);

                return Ok(_Service.DisplayServices());
            }
            else return BadRequest();

        }
        [HttpPut]
        [Route("api/values/UpdateStatus")]

        public async Task<IActionResult> UpdateStatus([FromBody] UserDto user)
        {
            var tokenFound = Request.Headers.Keys.Contains("Authorization");
            if (tokenFound)
            {
                if (user == null)
                {
                    return Ok();
                }
                Request.Headers.TryGetValue("Token", out var value);

                return Ok(_User.UpdateStatus(user));
            }
            else return BadRequest();
        }
        [HttpPut]
        [Route("api/values/ModifyInfo")]

        public async Task<IActionResult> UpdateUser([FromBody] UserDto user)
        {
            var tokenFound = Request.Headers.Keys.Contains("Authorization");
            if (tokenFound)
            {
                if (user == null)
                {
                    return Ok();
                }

                Request.Headers.TryGetValue("Token", out var value);
                return Ok(_User.UpdateUser(user));
            }
            else return BadRequest();
        }
        [HttpGet]
        [Route("api/values/DisplayStatusEmployee")]

        public async Task<IActionResult> DisplayStatusEmployee()
        {
            var tokenFound = Request.Headers.Keys.Contains("Authorization");
            if (tokenFound)
            {
                Request.Headers.TryGetValue("Token", out var value);

                return Ok(_User.DisplayEmployeesStatus());
            }
            else return BadRequest();

        }
        [HttpGet]
        [Route("api/values/DisplayWorkers")]

        public async Task<IActionResult> DisplayWorkers()
        {
            var tokenFound = Request.Headers.Keys.Contains("Authorization");
            if (tokenFound)
            {
                Request.Headers.TryGetValue("Token", out var value);
                return Ok(_User.DisplayWorkers());
            }
            else return BadRequest();

        }
        [HttpGet]
        [Route("api/values/DisplayClients")]

        public async Task<IActionResult> DisplayClients()
        {
            var tokenFound = Request.Headers.Keys.Contains("Authorization");
            if (tokenFound)
            {
                Request.Headers.TryGetValue("Token", out var value);
                return Ok(_User.DisplayAllClients());
            }
            else return BadRequest();

        }
        [HttpDelete]
        [Route("api/values/RemoveUser")]

        public async Task<IActionResult> RemoveUser([FromBody] EMKANRequest request)
        {
            var tokenFound = Request.Headers.Keys.Contains("Authorization");
            if (tokenFound)
            {
                Request.Headers.TryGetValue("Token", out var value);
                return Ok(_User.RemoveUser(request));
            }
            else return BadRequest();
        }

        [HttpGet]
        [Route("api/values/DisplayAllNewServicesForBM")]

        public async Task<IActionResult> DisplayAllNewServicesForBM()
        {
            var tokenFound = Request.Headers.Keys.Contains("Authorization");
            if (tokenFound)
            {
                Request.Headers.TryGetValue("Token", out var value);

                return Ok(_Service.DisplayAllNewServicesForBM());
            }
            return BadRequest();

        }
        [HttpGet]
        [Route("api/values/DisplayAllNewServicesForMM")]

        public async Task<IActionResult> DisplayAllNewServicesForMM()
        {
            var tokenFound = Request.Headers.Keys.Contains("Authorization");
            if (tokenFound)
            {
                Request.Headers.TryGetValue("Token", out var value);
                return Ok(_Service.DisplayAllNewServicesForMM());
            }
            else return BadRequest();

        }
        [HttpPut]
        [Route("api/values/UpdateServiceStatus")]

        public async Task<IActionResult> UpdateServiceStatus([FromBody] ServiceDto service)
        {
            var tokenFound = Request.Headers.Keys.Contains("Authorization");
            if (tokenFound)
            {
                if (service == null)
                {
                    return Ok();
                }

                Request.Headers.TryGetValue("Token", out var value);
                return Ok(_Service.UpdateServiceStatus(service));
            }
            return BadRequest();
        }
        [HttpPut]
        [Route("[action]")]
        [Route("api/values/AssignWorker")]


        public async Task<IActionResult> AssignWorker([FromBody] ServiceDto service)
        {
            var tokenFound = Request.Headers.Keys.Contains("Authorization");
            if (tokenFound)
            {
                Request.Headers.TryGetValue("Token", out var value);
                return Ok(_Service.AssignWorker(service));
            }
            else return BadRequest();

        }


        [HttpGet]
        [Route("[action]")]
        [Route("api/values/GetDashboard")]


        public async Task<IActionResult>  GetDashboard()
        {
            var tokenFound = Request.Headers.Keys.Contains("Authorization");
            if (tokenFound)
            {
                Request.Headers.TryGetValue("Token", out var value);
                return Ok(_Service.GetDashboardStatistics());
            }
            return BadRequest();

        }
        [HttpGet]
        [Route("[action]")]
        [Route("api/values/GetDashboard/{id}")]


        public async Task<IActionResult> GetDashboard(int id)
        {
            var tokenFound = Request.Headers.Keys.Contains("Authorization");
            if (tokenFound)
            {
                Request.Headers.TryGetValue("Token", out var value);

                return Ok(_Service.GetDashboardStatistics(id));
            }
            return BadRequest();

        }


    
        [HttpGet]
        [Route("api/values/DisplayServiceDetails/{Id}")]
        public async Task<ActionResult> DisplayServiceDetails(int Id)
        {
            var tokenFound = Request.Headers.Keys.Contains("Authorization");
            if (tokenFound)
            {

                Request.Headers.TryGetValue("Token", out var value);
                return Ok(_Service.DisplayServiceDetails(Id));
            }
            else return BadRequest();
        }
       
        [HttpGet]
        [Route("api/values/DisplayServicesForBenenficiary/{Id}")]

        public async Task<IActionResult> DisplayServicesForBenenficiary(int Id)
        {
            var tokenFound = Request.Headers.Keys.Contains("Authorization");
            if (tokenFound)
            {
                Request.Headers.TryGetValue("Token", out var value);
                return Ok(_Service.DisplayServicesForBenenficiary(Id));
            }
            else return BadRequest();
        }

        [HttpPost]

        [Route("api/values/AddNewService")]

        public async Task<IActionResult> AddNewService([FromBody] ServiceDto service)
        {
            var tokenFound = Request.Headers.Keys.Contains("Authorization");
            if (tokenFound)
            {
                if (service == null)
                {
                    return Ok();
                }

                Request.Headers.TryGetValue("Token", out var value);
                return Ok(_Service.AddService(service));
            }
            else return BadRequest();
        }


        [HttpPut("Update")]

        public async Task<IActionResult> UpdateService( ServiceDto service)
        {
            var tokenFound = Request.Headers.Keys.Contains("Authorization");
            if (tokenFound)
            {
                if (service == null)
                {
                    return Ok();
                }

                Request.Headers.TryGetValue("Token", out var value);
                return Ok(_Service.UpdateService(service));
            }
            return BadRequest();
        }
        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteService(int  service)
        {
            var tokenFound = Request.Headers.Keys.Contains("Authorization");
            if (tokenFound)
            {
                if (service == 0)
                {
                    return Ok();
                }

                Request.Headers.TryGetValue("Token", out var value);
                return Ok(await _Service.DeleteService(service));
            }
            else return BadRequest();
        }
        [HttpPut("{serviceId}")]

        public async Task<IActionResult> CloseService(int service)
        {
            var tokenFound = Request.Headers.Keys.Contains("Authorization");
            if (tokenFound)
            {
                if (service == 0)
                {
                    return Ok();
                }

                Request.Headers.TryGetValue("Token", out var value);
                return Ok(_Service.CloseService(service));
            }
            else return BadRequest();
        }
     
      
        [HttpGet]
        [Route("api/values/ListOfBuildingManager")]
        public async Task<IActionResult> ListOfBulidingManager()
        {
            var tokenFound = Request.Headers.Keys.Contains("Authorization");
            if (tokenFound)
            {

                Request.Headers.TryGetValue("Token", out var value);
                var managerList = _User.ListOfBulidingManager();
                return Ok(managerList);
            }
            else return BadRequest();
        }
        [HttpPost]
        [Route("api/values/AddEmployeeWithCheck")]
        public async Task<ActionResult> AddEmployeeWithCheck([FromBody] UserDto user)
        {
            var tokenFound = Request.Headers.Keys.Contains("Authorization");
            if (tokenFound)
            {
                var userExistence = _User.UserExistence(user);
                if (userExistence == 1)
                {
                    return Ok("0");
                }
                else
                {
                    Request.Headers.TryGetValue("Token", out var value);
                    var addedEmployee = _User.AddEmployee(user);
                    return Ok(addedEmployee);
                }
            }
            else return BadRequest();
        }
        [HttpPost]
        [Route("api/values/GetId")]
        public async Task<ActionResult> GetId([FromBody] EMKANRequest eMKANRequest)
        {
            var tokenFound = Request.Headers.Keys.Contains("Authorization");
            if (tokenFound)
            {
                Request.Headers.TryGetValue("Token", out var value);
                var Id = _User.GetID(eMKANRequest.UserLogined);
                return Ok(Id);
            }
            else return BadRequest();
        }

    }
}
