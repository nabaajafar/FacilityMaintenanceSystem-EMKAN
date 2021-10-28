using EMKAN.Application.Interfaces;
using EMKAN.Entity.Model;
using EMKAN.Entity.ModelDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMKAN.API5.Controllers
{
    public class BuildingAndBrachController : ControllerBase
    {
        private readonly IBuildingAndBranch _Service;
        private readonly IUser _User;
      

        public BuildingAndBrachController(IBuildingAndBranch Service, IUser user )
        {
            _Service = Service;
            _User = user;
           
        }

        [HttpPost]
        [Route("api/values/AddNewReply")]
        public async Task<IActionResult> AddNewReply([FromBody] ReplyDto reply)
        {
            var tokenFound = Request.Headers.Keys.Contains("Authorization");
            if (tokenFound)
            {
                if (reply == null)
                {
                    return Ok();
                }
                else
                {

                    Request.Headers.TryGetValue("Token", out var value);
                    var newReply = _Service.AddNewReply(reply);
                    return Ok(newReply);
                }
            }
            else return BadRequest();

        }

        [HttpGet]
        [Route("api/values/DisplayBranches")]
        public async Task<IActionResult> DisplayBranches()
        {
            var tokenFound = Request.Headers.Keys.Contains("Authorization");
            if (tokenFound)
            {
                Request.Headers.TryGetValue("Token", out var value);

                return Ok(_Service.DisplayBranches());
            }
            else return BadRequest();

        }

        [HttpPost("api/values/AddBuilding")]

        public async Task<IActionResult> AddNewBuilding([FromBody] BulidingDto buliding)
        {
            var tokenFound = Request.Headers.Keys.Contains("Authorization");
            if (tokenFound)
            {
                if (buliding == null)
                {
                    return Ok();
                }
                else
                {

                    Request.Headers.TryGetValue("Token", out var value);
                    return Ok(_Service.AddBuilding(buliding));
                }
            }
            else return BadRequest();

        }
        [HttpGet("api/values/ListOfBranches")]
        public async Task<IActionResult> ListOfBranches()
        {
            var tokenFound = Request.Headers.Keys.Contains("Authorization");
            if (tokenFound)
            {
                Request.Headers.TryGetValue("Token", out var value);
                return Ok(_Service.ListOfBranch());
            }
            else return BadRequest();
        }

        [HttpGet("api/values/ViewBuilding")]
        public async Task<IActionResult> ViewBuliding()
        {var tokenFound = Request.Headers.Keys.Contains("Authorization");
            if (tokenFound)
            {
                Request.Headers.TryGetValue("Token", out var value);
                return Ok(_Service.DisplayAllBuiding());
            }
            else
                return  BadRequest();
        }
        [HttpPost("api/values/UpdateBuilding")]
        public async Task<IActionResult> UpdateBuilding([FromBody] BulidingDto buliding)
        {
            var tokenFound = Request.Headers.Keys.Contains("Authorization");
            if (tokenFound)
            {
                if (buliding == null)
                {
                    return Ok();
                }
                else
                {

                    Request.Headers.TryGetValue("Token", out var value);
                    return Ok(_Service.UpdateBuilding(buliding));
                }
            }
            else return BadRequest();

        }
        [HttpGet("api/values/FindBuildingByID/{id}")]
        public async Task<IActionResult> FindBuildingByID(int id)
        {
            var tokenFound = Request.Headers.Keys.Contains("Authorization");
            if (tokenFound)
            {
                Request.Headers.TryGetValue("Token", out var value);

                return Ok(_Service.FindBuilding(id));
            }
            else return BadRequest();

        }

        [HttpDelete("api/values/DeletBuilding")]
        //[Route("api/values/DeletBuilding")]
        public async Task<IActionResult> DeletBuilding([FromBody] EMKANRequest eMKANRequest)
        {
            var tokenFound = Request.Headers.Keys.Contains("Authorization");
            if (tokenFound)
            {
                if (eMKANRequest.ID == 0)
                {
                    return Ok();
                }
                else
                {

                    Request.Headers.TryGetValue("Token", out var value);
                    return Ok(_Service.DeleteBuilding(eMKANRequest));
                }
            }
            else return BadRequest();

        }

        [HttpGet("api/values/DisplayTheAduitTrails")]
        //[HttpGet]
        //[Route("api/values/AuditTrailController")]
        public async Task<IActionResult> DisplayTheAduitTrails()
        {
            var tokenFound = Request.Headers.Keys.Contains("Authorization");
            if (tokenFound)
            {
                Request.Headers.TryGetValue("Token", out var value);
                return Ok(_Service.AuditTrailList());
            }
            else return BadRequest();
        }

        [HttpPost("AddBranch")]

        public async Task<IActionResult> AddNewBrach([FromBody] BranchDto branch)
        {
            var tokenFound = Request.Headers.Keys.Contains("Authorization");
            if (tokenFound)
            {
                if (branch == null)
                {
                    return Ok();
                }
                else
                {
                   Request.Headers.TryGetValue("Token", out var value);
                    return Ok(_Service.AddBranch(branch));
                }
            }
            else return BadRequest();

        }

        [HttpGet("DeleteBranch")]

        public async Task<IActionResult> DeleteBrach( int branchID)
        {
            var tokenFound = Request.Headers.Keys.Contains("Authorization");
            if (tokenFound)
            {
                if (branchID == 0)
                {
                    return Ok();
                }
                else
                {

                    Request.Headers.TryGetValue("Token", out var value);
                    return Ok(_Service.DeleteBuilding(branchID));
                }
            }
            else return BadRequest();

        }
        [HttpPut("UpdateBranch")]

        public async Task<IActionResult> UpdateBrach([FromBody] BranchDto branch)
        {
            var tokenFound = Request.Headers.Keys.Contains("Authorization");
            if (tokenFound)
            {
                if (branch == null)
                {
                    return Ok();
                }
                else
                {

                    Request.Headers.TryGetValue("Token", out var value);
                    return Ok(_Service.UpdateBranch(branch));
                }
            }
            else return BadRequest();

        }
    }
}
