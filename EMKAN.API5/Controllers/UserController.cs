using EMKAN.API5.Model;
using EMKAN.Application.Interfaces;
using EMKAN.DataAccess.DbContexts;
using EMKAN.DataAccess.Model;
using EMKAN.Entity.ModelDto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EMKAN.API5.Controllers
{

    public class UserController : ControllerBase
    {

        IUser _user;
        public UserController(IUser user)
        {
          user =_user;
        }

        private readonly EMKANDbContext _db;
        public UserController(EMKANDbContext db)
        {
            _db = db;
        }


     
        [HttpPost]
        [Route("api/values/SaveData")]

        public async Task<IActionResult> AddNewUser([FromBody] UserDto user)
        {
            var tokenFound = Request.Headers.Keys.Contains("Authorization");
            if (tokenFound)
            {
                if (user == null)
                {
                    return Ok();
                }

                Request.Headers.TryGetValue("Token", out var value);
                return Ok(_user.AddUser(user));
            }
            else return BadRequest(); 
        }

       
        
        
        
    }
}
