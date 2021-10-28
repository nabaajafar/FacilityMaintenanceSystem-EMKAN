using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMKAN.Entity.ModelDto
{
    public class ServiceTypeDto
    {
       
        public int ID { get; set; }
        [Required(ErrorMessage = "Service Type name is required")]
        [DataType(DataType.Text)]
        [Display(Name = "Service Tpye Name")]
        public string Name { get; set; } 
        public virtual ICollection<UserDto> Users { get; set; }
        public virtual ICollection<ServiceDto> Services { get; set; }
    }
}
