using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMKAN.Entity.ModelDto
{
    public class LoginDto
    {
        [JsonProperty]
        public string Username { set; get; }
        [JsonProperty]
        public string Password { set; get; }
    }
}
