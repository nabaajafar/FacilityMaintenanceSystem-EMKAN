using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMKAN.Entity.ModelDto
{
    public class TeamDto
    {
      
      
        public int ID { get; set; }
        [Required(ErrorMessage = "Team name is required")]
        [DataType(DataType.Text)]
        [Display(Name = "Team Name")]
        public string Name { get; set; }
       
        [Required(ErrorMessage = "Branch is required")]
        [Display(Name = "Branch ")]
        public int BranchID { get; set; }
        
        [Required(ErrorMessage = "Service Type is required")]
        [Display(Name = "Service Type")]
        public int ServiceTypeID { get; set; }
        public virtual ICollection<UserDto> Users { get; set; }

    }
}
