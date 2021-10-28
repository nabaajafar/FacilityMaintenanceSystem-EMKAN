using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMKAN.PresentationLayer_Back_Office_.Models
{
    public class RequestDetailsParameters
    {
        public ViewServices Ticket { get; set; }
       
        public List<IFormFile> Attachments { get; set; }
    }
}
