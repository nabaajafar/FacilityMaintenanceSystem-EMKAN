using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMKAN.DataAccess.Model
{
    public class Building
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Building name is required")]
        [DataType(DataType.Text)]
        [Display(Name = "Building Name")]
   
        public string Name { get; set; }
        [ForeignKey("Branch")]
        public int BranchID { get; set; }
        [Required(ErrorMessage = "Number of Floor is required")]
        [Display(Name = "Number of floor")]
        public int NumberOfFloor { get; set; }
        [Required(ErrorMessage = "Number of room is required")]

        [Display(Name = "Number of room")]
        public int NumberOfRoom { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }
    }
}
