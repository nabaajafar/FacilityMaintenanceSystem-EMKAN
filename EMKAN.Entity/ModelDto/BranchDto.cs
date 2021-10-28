using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMKAN.Entity.ModelDto
{
    public class BranchDto
    {
       
        public int ID { get; set; }
        [Required]
        [Display (Name = "Branch Country")]
        public string Country { get; set; }
        [Required]
        [Display(Name = "Branch City")]
        public string City { get; set; }
        [Required]
        [Display(Name = "Branch Street")]
        public string Street { get; set; }
        public string Location { get; set; }
    }
}
