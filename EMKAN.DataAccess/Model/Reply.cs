using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EMKAN.DataAccess.Model
{
    public class Reply
    {
        [Key]
        public int Id { set; get; }
  
        [ForeignKey("Service")]
        public int ServiceId { set; get; }
        public DateTime MessageTime { set; get; }
        public string MessageContent { set; get; }
    }
}
