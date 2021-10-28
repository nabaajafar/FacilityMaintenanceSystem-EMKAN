using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EMKAN.PresentationLayer_Back_Office_.Models
{
    public class AddBuilding
    {
        [Required(ErrorMessage = "Please type buliding name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Choose Branch")]
        public int Branch { get; set; }
        [Required(ErrorMessage = "Please type number of floor")]
        [DisplayName("Number of Floors")]
        public int NumberOfFloor { get; set; }
        [Required(ErrorMessage = "Please type number of room")]
        [DisplayName("Number of Rooms")]
        public int NumberOfRoom { get; set; }
        [DisplayName("Buliding Manager")]
        [Required(ErrorMessage = "Please Choose the buliding manager " +
            "| if there is no list you have to add BM first")]
        public int BuildingManager { get; set; }
    }

}
