using System;
using System.Collections.Generic;
using System.Text;

namespace EMKAN.Entity.ModelDto
{
    public class AuditTrailDto
    {
        public int ID { get; set; }
        public int Actor { get; set; }

        public string ActionType { get; set; }
        public string ActorName { get; set; }

        public DateTime ActionDate { get; set; }
    }
}
