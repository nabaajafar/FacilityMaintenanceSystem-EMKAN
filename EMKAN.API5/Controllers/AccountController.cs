using EMKAN.Application.Interfaces;
using EMKAN.Entity.ModelDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMKAN.API5.Controllers
{

    public class AccountController : ControllerBase
    {
        private readonly IBuildingAndBranch _loginManager;
        private readonly IUser _user;

        public AccountController(IBuildingAndBranch loginManager, IUser user)
        {
            _loginManager = loginManager;
            _user = user;

        }

        [HttpPost("api/values/ChangePasswordNumber")]

        public async Task<IActionResult> ChangePasswordNumber([FromBody] ChangePasswordDto PasswordInfo)
        {
            var tokenFound = Request.Headers.Keys.Contains("Authorization");
            if (tokenFound)
            {

               
                if (PasswordInfo.Password == null)
                {
                    return Ok(0);
                }
                else
                {
                    Request.Headers.TryGetValue("Token", out var value);
                    string passwordChangeResult = _loginManager.ChangePassword(PasswordInfo);
                    return Ok(passwordChangeResult);
                }
            }
            else return BadRequest();
        }



        [HttpPost("api/values/GetCurrentUserRole")]

        public async Task<IActionResult> GetCurrentUserRole([FromBody] UserDto userModelDto)
        {
            Result result = new Result();
            if (userModelDto == null)
            {
                return Ok(0);
            }
            else
            {

                
               
                UserRoleDto userRole = _loginManager.GetRole(userModelDto);
                if(userRole != null)
                {
                    string newUserStatus = _loginManager.UserStatus(userModelDto);
                    result.Role = userRole.Role;
                    result.UserID = userRole.UserID;
                    result.Status = newUserStatus;
                }
               
                return Ok(result);
            }
        }


        [HttpPost]
        [Route("api/values/UserSignUp")]
        public async Task<IActionResult> UserSignUp([FromBody] UserDto userSignUp)
        {
            if (userSignUp == null)
            {
                return Ok(0);
            }
            else
            {
                var userExistence = _user.UserExistence(userSignUp);
                if (userExistence == 1)
                {
                    return Ok();
                }
                else
                {
                    var SignUpUser = _loginManager.SignUp(userSignUp);
                    var role = _loginManager.GetRole(userSignUp);
                    return Ok(role);
                }
            }
        }

        [HttpPost]
        [Route("api/values/CheckUser")]
        public async Task<IActionResult> CheckUser([FromBody] UserDto userSignUp)
        {
            var tokenFound = Request.Headers.Keys.Contains("Authorization");
            if (tokenFound)
            {

                if (userSignUp == null)
                {
                    return Ok(0);
                }
                else
                {
                    Request.Headers.TryGetValue("Token", out var value);
                    var user = _user.UserExistence(userSignUp);
                    return Ok(user);
                }
            }
            else return BadRequest();
        }
    }
}

