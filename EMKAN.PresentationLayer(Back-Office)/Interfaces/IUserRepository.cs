using EMKAN.PresentationLayer_Back_Office_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMKAN.PresentationLayer_Back_Office_.Interfaces
{
    public interface IUserRepository
    {

        UserInfo GetUser(UserModel userModel);
    }
}


