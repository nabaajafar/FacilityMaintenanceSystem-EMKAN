using EMKAN.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMKAN.Application.Interfaces
{
    public interface IAuditTrails
    {
        public AuditTrail Audit(string Action, string UserID);

        }
    
}
