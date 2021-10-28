using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMKAN.PresentationLayer_Back_Office_.Models
{
    public class UserInfo
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public int UserID { set; get; }
    }
}
