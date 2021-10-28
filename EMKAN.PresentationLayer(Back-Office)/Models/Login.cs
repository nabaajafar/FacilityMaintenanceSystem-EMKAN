using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EMKAN.PresentationLayer_Back_Office_.Models
{
    public class Login
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public String Password { get; set; }
    }
}
