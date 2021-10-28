using System;
using System.Collections.Generic;
using System.Text;

namespace EMKAN.Entity.ModelDto
{
   public class UserRoleDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int UserID { set; get;}
        public string Role { get; set; }
    }
}
