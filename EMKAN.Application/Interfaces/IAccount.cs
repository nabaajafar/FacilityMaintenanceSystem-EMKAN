using EMKAN.Entity.ModelDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMKAN.Application.Interfaces
{
  public  interface IAccount
    {
        public string GetRole(UserDto userModel);
        public string UserStatus(UserDto userModel);
        public int SignUp(UserDto userModel);
    }
}
