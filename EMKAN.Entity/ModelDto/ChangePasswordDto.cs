using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EMKAN.Entity.ModelDto
{
    public class ChangePasswordDto

    {
        public string Username { set; get; }
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
