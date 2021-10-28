

using EMKAN.DataAccess.Model;
using EMKAN.Entity.ModelDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EMKAN.Application.Interfaces
{
   public  interface IService
    {

        public ServiceDto DisplayServiceDetails(int Id);
        public DashboardStatistics GetDashboardStatistics();
        public DashboardStatistics GetDashboardStatistics(int Id);
        public int CountClientServices();
        public int AddService(ServiceDto service);
        public Task< int> DeleteService(int id);
        public int UpdateService(ServiceDto service);
        public List<ServiceDto> DisplayServicesForBenenficiary(int Id);
        public List<ServiceDto> DisplayService();
        public List<ServiceDto> DisplayServices();
    
        public List<ServiceDto> DisplayServicesForAll();
        public List<ServiceDto> DisplayAllNewServicesForBM();
        public List<ServiceDto> DisplayAllNewServicesForMM();//only in progress
        public int UpdateServiceStatus(ServiceDto service);
        public Task<List<ServiceTypeDto>> DisplayServicesTypes();

        public List<ServiceDto> DisplayAllServices();//all status
        public Task<List<ServiceDto>> DisplayServiceWorkers(int Id);
        public int AssignWorker(ServiceDto service);
        public int AddServiceType(ServiceTypeDto service);
        public int UpdateServiceType(ServiceTypeDto service);
        public int CloseService(int ServiceID);

    }
}
