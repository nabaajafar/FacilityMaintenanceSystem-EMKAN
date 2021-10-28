using EMKAN.PresentationLayer_Back_Office_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMKAN.PresentationLayer_Back_Office_.Interfaces
{
  public interface ITokenService
    {
        string BuildToken(string key, string issuer, UserInfo user);
        //string GenerateJSONWebToken(string key, string issuer, UserDTO user);
        bool IsTokenValid(string key, string issuer, string token);
    }
}
