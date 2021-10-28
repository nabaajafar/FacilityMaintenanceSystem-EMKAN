using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace EMKAN.PresentationLayer_Back_Office_.Models
{
    public class DisplayAuditTrail
    {
            public int ID { get; set; }
            [DisplayName("Actor Name")]
            public string ActorName { get; set; }
            [DisplayName("Action")]
            public string ActionType { get; set; }
            // [DataType(DataType.Date)]
            [DisplayName("Date-time")]
            public DateTime ActionDate { get; set; }
        
    }
}
