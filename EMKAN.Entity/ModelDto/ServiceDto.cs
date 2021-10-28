using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMKAN.Entity.ModelDto
{
    public class ServiceDto
    {
        public string Content { get; set; }
        public int ID { get; set; }
        public int UserID { get; set; }
        public bool IsDraft { get; set; }
        public bool IsDelete { get; set; }
        public bool IsUpdate { get; set; }
        public string WorkerFullName { get; set; }
        public string ClientFullName { get; set; }
        public string BranchName{get;set;}
        public string BuildingName { get; set; }
        public string UserLogined { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Descreption")]
        public string Description { get; set; }
     
        [DataType(DataType.DateTime)]
       
        public DateTime RequestDate { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? ResponseDate { get; set; }
        [Required(ErrorMessage = "Room number is required")]
        [Display(Name = "Room Number")]
        public int RoomNo { get; set; }
        [Required(ErrorMessage = "Floor number is required")]
        [Display(Name = "Floor Number")]
        public int FloorNo { get; set; }
       
        [Required(ErrorMessage = "Building  is required")]
        [Display(Name = "Building ")]
        public int BulidingID { get; set; }
        public int Status { get; set; }

        [Required(ErrorMessage = "Service Type is required")]
        [Display(Name = " Service Type")]
        public int ServiceTypeID { get; set; }
        public int BranchID { get; set; }
        public string WorkerFirstName { get; set; }
        public string WorkerLastName { get; set; }
        public string ServiceType { get; set; }
        public virtual ICollection<TrackDto> Tracks { get; set; }
        public int ResponsibleMaintenanceManager { get; set; }
        public int ResponsibleMaintenanceWorker { get; set; }
    }
}
