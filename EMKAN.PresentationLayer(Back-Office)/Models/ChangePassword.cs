using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EMKAN.PresentationLayer_Back_Office_.Models
{
    public class ChangePassword
    {
        [Required(ErrorMessage = "new password is required")]
        [MinLength(7, ErrorMessage = "Your password must be longer than 6")]
        [DataType(DataType.Password)]
        [Display(Name = "password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Your confirmation password is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password Not Match")]
        [Display(Name = "password confirmation")]
        public string Passwordconfirmation { get; set; }
    }
}
