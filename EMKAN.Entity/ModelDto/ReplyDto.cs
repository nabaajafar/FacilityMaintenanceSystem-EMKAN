using System;
using System.Collections.Generic;
using System.Text;

namespace EMKAN.Entity.ModelDto
{
    public class ReplyDto
    {
        public int ID { set; get; }

        public int Sender { set; get; }
        public string UserLogined { get; set; }
        public int Reseiver { set; get; }

        public int ServiceId { set; get; }

        public int Status { get; set; }
        public DateTime MessageTime { set; get; }
        public string MessageContent { set; get; }
    }


    public class ReplyContent
    {
        
        public int RequestId { set; get; }

        public string Content { set; get; }

        public int Status { get; set; }
    }
}
