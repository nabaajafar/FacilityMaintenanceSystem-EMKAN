using EMKAN.Entity.ModelDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMKAN.Application
{
   public  class DashboardStatistics
    {
        public int OpenServicesCount { get; set; }
        public int ClosedServicesCount { get; set; }
        public int InProgressServicesCount { get; set; }
        public int ACServicesCount { get; set; }
        public int ElectricityServicesCount{ get; set; }
        public int WaterServicesCount { get; set; }
        public int BuildingGlassServicesCount { get; set; }
        public int AllClientsCount { get; set; }
        public int AllEmployeesCount{ get; set; }
        public int AllUsersCount { get; set; }
        public int AllServicesCount { get; set; }
        public List<UserDto> GetEmployees { get; set; }
        public int JeddahBranchServicesCount { get; set; }
        public int DoneServicesCount { get; set; }
        public int AlriyadhBranchServicesCount { get; set; }
        public int DubaiBranchServicesCount { get; set; }
        public int CairoBranchServicesCount { get; set; }
        public int AmmanBranchServicesCount { get; set; }
        public int AlqaseemBranchServicesCount { get; set; }

    }

    public enum ServiceStatus {
    
    Open = 2,
    Closed =1,
    InProgress=0,
    Reject =3,
    Approve =4,
    Done=5
    
    }
    public enum ServiceBranches
    {
        Amman =3,
        Jeddah =1,
        AlQaseem =4,
        Alriyadh=2
     
    }
    public enum ServiceTypes
    {
        AC = 1,
        Electricity = 2,
        Water = 3,
        BuildingGlass = 4
    }
    public enum ServiceUsers
    {
        Client =2,
        MaintenanceWorker = 6,
        MaintenanceManager =3,
        Admin =1,
        BuildingManager=4,
        Employee =5
    }


}
