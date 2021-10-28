using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EMKAN.PresentationLayer_Back_Office_.Models
{
    public class ServiceRequestCreateParameters
    {
        public int UserID { get; set; }
        public List<IFormFile> Attachments { get; set; }
        public string Description { get; set; }
      
        public int FloorNo { get; set; }
     
        public int RoomNo { get; set; }
        public List<RequestType> types { get; set; }
        public string UserLogined { get; set; }
        public List<RequestBranch> branches { get; set; }
        public int BranchID { get; set; }

        public ReplyModel Reply { get; set; }
        public int ServiceTypeID { get; set; }

    }
    public class RequestBranch
    {
        public string City { get; set; }
        public int ID { get; set; }

    }
    public class ReplyModel
    {
        public string Content { get; set; }
    }
    public class RequestType
    {
        public string Name { get; set; }
        public int ID { get; set; }

    }
}
