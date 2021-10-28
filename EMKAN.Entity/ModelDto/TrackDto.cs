using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMKAN.Entity.ModelDto
{
    public class TrackDto
    {
       
        public int ID { get; set; }
        [Required(ErrorMessage = "State is required")]
        [Display(Name = "State")]
        public bool State { get; set; }
    
        [DataType(DataType.Text)]
        [Display(Name = "Descreption")]
        public string Description { get; set; }
        public DateTime ResponseDate { get; set; }
       
        public int ServiceID { get; set; }
        
        public int UserID { get; set; }
    }
}
