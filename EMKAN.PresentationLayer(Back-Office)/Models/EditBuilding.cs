using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EMKAN.PresentationLayer_Back_Office_.Models
{
    public class EditBuilding
    {
       
            public int ID { get; set; }
            [Required(ErrorMessage = "Please type buliding name")]
            [DisplayName("Building Name")]
            public string Name { get; set; }
            [DisplayName("Branch")]
            [Required]
            public int Branch { get; set; }
            [Required(ErrorMessage = "Please type number of floor")]
            [DisplayName("Number of Floor")]
            public int NumberOfFloor { get; set; }
            [DisplayName("Number of Room")]
            [Required(ErrorMessage = "Please type number of room")]
            public int NumberOfRoom { get; set; }
            [DisplayName("Building Manager")]
            [Required]
            public int BulidingManager { get; set; }
        
    }
}
