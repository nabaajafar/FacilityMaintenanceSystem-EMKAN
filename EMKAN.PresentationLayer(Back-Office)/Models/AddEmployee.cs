using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EMKAN.PresentationLayer_Back_Office_.Models
{
    public class AddEmployee
    {
            [Required(ErrorMessage = "Please type Employee 1st name")]
            public string FirstName { get; set; }
     
            [Required(ErrorMessage = "Please type Employee 2nd name")]
            public string LastName { get; set; }
        
            [Required(ErrorMessage = "Please type Employee email")]
            public string Email { get; set; }
         
            [Required(ErrorMessage = "Please type Employee phone number")]
            [DataType(DataType.PhoneNumber)]
            [MaxLength(10, ErrorMessage = "Enter a correct phone number max 10 number")]
            [MinLength(10, ErrorMessage = "Enter a correct phone number min 10 number")]
        public string Phone { get; set; }

        //  [Required(ErrorMessage = "Please type the password")]
        [MinLength(7, ErrorMessage = "Your password must be longer than 6")]
        public string Password { get; set; }

            [Compare("Password" , ErrorMessage ="Password not match")]
            [DisplayName("Re-type the password")]
            public string RetypePassword { get; set; }

            [Required(ErrorMessage = "Please choose the Employee role")]
            public int RoleType { get; set; }

    }
    }

