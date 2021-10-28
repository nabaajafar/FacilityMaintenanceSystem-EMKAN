using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMKAN.DataAccess.Model
{
    public class ServiceType
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Service Type name is required")]
        [DataType(DataType.Text)]
        [Display(Name = "Service Type Name")]
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Service> Services { get; set; }
    }
}
