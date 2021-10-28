using EMKAN.DataAccess.DbContexts;
using EMKAN.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMKAN.Business.Servicess
{
    public class AuditTrails
    {
            private readonly EMKANDbContext _db;
            public AuditTrails(EMKANDbContext db)
            {
                _db = db;
            }
            public AuditTrail Audit(string Action, int UserID)
            {
            if (Action != null && UserID != null)
            {
                AuditTrail auditTrailModel = new AuditTrail()
                {
                    ActionDate = DateTime.Now,
                    ActionType = Action,
                    Actor = UserID,

                };

                _db.AuditTrails.Add(auditTrailModel);
                _db.SaveChanges();
                return auditTrailModel;
            }
            return null;
               
            }
        }
    
}
