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
    public class RoleAndTeamController : ControllerBase
    {
        private readonly IRoleAndTeam _RoleTeam;
       
        public RoleAndTeamController(IRoleAndTeam team)
        {

            _RoleTeam = team;

        }
        [HttpGet]
        [Route("api/values/ListOfRole")]
        public async Task<IActionResult> ListOfRole()
        {
            var tokenFound = Request.Headers.Keys.Contains("Authorization");
            if (tokenFound)
            {
                Request.Headers.TryGetValue("Token", out var value);
                var roleList = _RoleTeam.RoleList();
                return Ok(roleList);
            }
            else return BadRequest();
        }

        [HttpPost]
        [Route("api/values/UpdateUserRole")]
        public async Task<IActionResult> UpdateUserRole([FromBody] UserDto user)
        {
            var tokenFound = Request.Headers.Keys.Contains("Authorization");
            if (tokenFound)
            {
                if (user == null)
                {
                    return Ok();
                }
                Request.Headers.TryGetValue("Token", out var value);
                var updatedRole = _RoleTeam.UpdateRoleUser(user);
                return Ok(updatedRole);
            }
           else return BadRequest();
        }
        [HttpPost]

        public async Task<IActionResult> AddNewRole([FromBody] RoleDto role)
        {
            var tokenFound = Request.Headers.Keys.Contains("Authorization");
            if (tokenFound)
            {
                if (role == null)
                {
                    return Ok();
                }
                else
                {

                     Request.Headers.TryGetValue("Token", out var value);
                    var addedRole = _RoleTeam.AddRole(role);
                    return Ok(addedRole);
                }
            }
            else return BadRequest();

        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int role)
        {
            var tokenFound = Request.Headers.Keys.Contains("Authorization");
            if (tokenFound)
            {
                if (role == 0)
                {
                    return Ok();
                }
                else
                {

                    Request.Headers.TryGetValue("Token", out var value);
                    var deletedRole = _RoleTeam.DeleteRole(role);
                    return Ok(deletedRole);
                }
            }
            else return BadRequest();

        }
        [HttpPost("Team")]
        public async Task<IActionResult> AddNewTeam([FromBody] TeamDto team)
        {
            var tokenFound = Request.Headers.Keys.Contains("Authorization");
            if (tokenFound)
            {
                if (team == null)
                {
                    return Ok();
                }
                else
                {
                    Request.Headers.TryGetValue("Token", out var value);
                    var teamAdded = _RoleTeam.AddTeam(team);
                    return Ok(teamAdded);
                }
            }
            else return BadRequest();

        }
        [HttpPost("AddUserTeam")]
        public async Task<IActionResult> AddNewUserTeam(int UserID, int TeamID)
        {
            var tokenFound = Request.Headers.Keys.Contains("Authorization");
            if (tokenFound)
            {
                if (UserID != 0 && TeamID != 0)
                {
                    return Ok();
                }
                else
                {
                    Request.Headers.TryGetValue("Token", out var value);
                    var userTeam = _RoleTeam.AddUserTeam(UserID, TeamID);
                    return Ok(userTeam);
                }
            }
            else return BadRequest();

        }
        [HttpPost("SeleteUserTeam")]
        public async Task<IActionResult> ADeleteUserTeam(int UserID, int TeamID)
        {
            var tokenFound = Request.Headers.Keys.Contains("Authorization");
            if (tokenFound)
            {
                if (UserID != 0 && TeamID != 0)
                {
                    return Ok();
                }
                else
                {
                    Request.Headers.TryGetValue("Token", out var value);
                    var deletedUser = _RoleTeam.DeleteUserTeam(UserID, TeamID);
                    return Ok(deletedUser);
                }
            }
            else return BadRequest();

        }

    }
}
