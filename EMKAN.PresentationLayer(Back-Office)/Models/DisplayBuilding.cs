using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace EMKAN.PresentationLayer_Back_Office_.Models
{
    public class DisplayBuilding
    {
            [DisplayName("Buliding ID")]
            public int ID { get; set; }
            [DisplayName("Name")]
            public string Name { get; set; }
            [DisplayName("Branch")]
            public string BranchName { get; set; }
            [DisplayName("Number of floor")]
            public int NumberOfFloor { get; set; }
            [DisplayName("Number of room")]
            public string NumberOfRoom { get; set; }
            [DisplayName("Buliding Manager")]
            public string BulidingManagerName { get; set; }
        }

    
}
