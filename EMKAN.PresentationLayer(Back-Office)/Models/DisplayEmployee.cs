using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace EMKAN.PresentationLayer_Back_Office_.Models
{
    public class DisplayEmployee
    {

          
            public int ID { get; set; }
            [DisplayName("First Name")]
            public string FirstName { get; set; }
            [DisplayName("Last Name")]
            public string LastName { get; set; }
            [DisplayName("Email - Username")]
            public string Username { get; set; }
            [DisplayName("Phone Number")]
            public string Phone { get; set; }
            [DisplayName("Job Title")]
            public string RoleName { get; set; }
        [DisplayName("Full Name")]
        public string FullName { get; set; }
        [DisplayName("Status")]
        public int Status { get; set; }
    }
    }

