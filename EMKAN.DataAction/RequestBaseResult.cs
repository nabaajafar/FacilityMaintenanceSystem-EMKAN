using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMKAN.DataAction
{
    public class RequestBaseResult
    {
       
            public int ID { get; set; }

            public int UserID { get; set; }
            public bool IsDraft { get; set; }

            public int Status { get; set; }

            public string Description { get; set; }

            public DateTime ResponseDate { get; set; }
            public DateTime RequestDate { get; set; }

            public int RoomNo { get; set; }

            public int FloorNo { get; set; }

            public int BulidingID { get; set; }

            public int BranchID { get; set; }

            public int ServiceTypeID { get; set; }
            public string ServiceType { get; set; }

            public int ResponsibleMaintenanceWorker { get; set; }
        }
}
