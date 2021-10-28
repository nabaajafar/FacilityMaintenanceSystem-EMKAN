using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMKAN.DataAccess.Model
{
    public class Team
    {
        [Key]

        public int ID { get; set; }
        [Required(ErrorMessage = "Team name is required")]
        [DataType(DataType.Text)]
        [Display(Name = "Team Name")]
        public string Name { get; set; }
        [ForeignKey("Branch")]
        [Required(ErrorMessage = "Branch is required")]
        [Display(Name = "Branch ")]
        public int BranchID { get; set; }
        [ForeignKey("ServiceType")]
        [Required(ErrorMessage = "Service Type is required")]
        [Display(Name = "Service Type")]
        public int ServiceTypeID { get; set; }
        public virtual ICollection<User> Users { get; set; }


    }
}
