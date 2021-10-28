using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EMKAN.Entity.ModelDto
{
    public class RoleDto
    {
       

        public int ID { get; set; }
        [Required(ErrorMessage = "Role name is required")]
        [DataType(DataType.Text)]
        [Display(Name = "Role Name")]
        public string Name { get; set; }
        public virtual ICollection<UserDto> Users { get; set; }
        
    }
}
