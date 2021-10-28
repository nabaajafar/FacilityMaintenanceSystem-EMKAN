using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EMKAN.PresentationLayer_Back_Office_.Models
{
    public class ServiceModel
    {
            public List<ViewServices> ServiceList { get; set; }
            [Required]
            public List<WorkerInfo> WorkerList { get; set; }
        
    }
}
