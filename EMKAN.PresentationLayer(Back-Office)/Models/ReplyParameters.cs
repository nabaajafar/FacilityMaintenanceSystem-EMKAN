using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMKAN.PresentationLayer_Back_Office_.Models
{
    public class ReplyParameters
    {
    
       
        public int ServiceId { set; get; }
        public DateTime MessageTime { set; get; }
        public string MessageContent { set; get; }
    }
}
