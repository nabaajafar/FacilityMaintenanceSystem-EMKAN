using EMKAN.Application;
using EMKAN.Application.Interfaces;
using EMKAN.DataAccess.DbContexts;
using EMKAN.DataAccess.Model;
using EMKAN.Entity.ModelDto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EMKAN.Business.Servicess
{
    public class ServicesManager : IService
    {

        private readonly EMKANDbContext _db;
        public ServicesManager(EMKANDbContext EMKANDB)
        {
            _db = EMKANDB;
        }


        public int AssignWorker(ServiceDto service)
        {
            int result = 0;
            if (service != null)
            {
                try
                {
                    using (_db)
                    {
                        var workerObject = _db.Services.SingleOrDefault(b => b.ID == service.ID); //if service id (from MVC) = from Database
                        if (workerObject != null)
                        {
                            //assign worker
                            workerObject.ResponsibleMaintenanceWorker = service.ResponsibleMaintenanceWorker;
                            //Get the id from username
                            var UserLogined = _db.Users.SingleOrDefault(x => x.Username == service.UserLogined);

                            //Add the trail
                            if (UserLogined != null)
                            {
                                AuditTrail auditTrail = new AuditTrail();
                                auditTrail.Actor = UserLogined.ID;
                                auditTrail.ActionType = "Assigned worker";
                                auditTrail.ActionDate = DateTime.Now;
                                _db.AuditTrails.Add(auditTrail);
                                _db.SaveChanges();
                            }

                        }

                        result = 1;
                    }
                }
                catch (Exception e)
                {
                    throw e;

                }
            }
           
            return result;
        }
        public DashboardStatistics GetDashboardStatistics()
        {
            var UserRole = new List<Role>();

            DashboardStatistics Dashboard = new DashboardStatistics();
            int open = (int)ServiceStatus.Open;
            int closed = (int)ServiceStatus.Closed;
            int inProgress = (int)ServiceStatus.InProgress;
            int ac = (int)ServiceTypes.AC;
            int electricity = (int)ServiceTypes.Electricity;
            int water = (int)ServiceTypes.Water;
            int glass = (int)ServiceTypes.BuildingGlass;
            int client = (int)ServiceUsers.Client;
            int amman = (int)ServiceBranches.Amman;
            int jeddah = (int)ServiceBranches.Jeddah;
            int alriyadh = (int)ServiceBranches.Alriyadh;
            int alqaseem = (int)ServiceBranches.AlQaseem;
            int done = (int)ServiceStatus.Done;
            try
            {
                using (_db)
                {
                    Dashboard.OpenServicesCount = _db.Services.Where(d => d.Status == open).Count();
                    Dashboard.DoneServicesCount = _db.Services.Where(d => d.Status == done).Count();
                    Dashboard.ClosedServicesCount = _db.Services.Where(d => d.Status == closed).Count();
                    Dashboard.InProgressServicesCount = _db.Services.Where(d => d.Status == inProgress).Count();
                    Dashboard.ACServicesCount = _db.Services.Where(d => d.ServiceTypeID == ac).Count();
                    Dashboard.ElectricityServicesCount = _db.Services.Where(d => d.ServiceTypeID == electricity).Count();
                    Dashboard.BuildingGlassServicesCount = _db.Services.Where(d => d.ServiceTypeID == glass).Count();
                    Dashboard.WaterServicesCount = _db.Services.Where(d => d.ServiceTypeID == water).Count();
                    Dashboard.AlriyadhBranchServicesCount = _db.Branchs.Where(d => d.ID == alriyadh).Count();
                    Dashboard.AmmanBranchServicesCount = _db.Branchs.Where(d => d.ID == amman).Count();
                    Dashboard.AlqaseemBranchServicesCount = _db.Branchs.Where(d => d.ID == alqaseem).Count();
                    Dashboard.JeddahBranchServicesCount = _db.Branchs.Where(d => d.ID == jeddah).Count();
                    Dashboard.AllServicesCount = Dashboard.OpenServicesCount + Dashboard.ClosedServicesCount + Dashboard.InProgressServicesCount;
                    //ALL EMPLOYEES

                    var query = _db.Users.Where(x => x.RoleID != client);
                    Dashboard.AllEmployeesCount = query.Count();
                    //ALL CLIENTS 
                    
                    var query1 = _db.Users.Where(x => x.RoleID == client).Count();
                    Dashboard.AllClientsCount = query1;
                   
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Dashboard;
        }

        public DashboardStatistics GetDashboardStatistics(int Id)//for beneficiary
        {
            DashboardStatistics Dashboard = new DashboardStatistics();
            if (Id != 0)
            {
                var UserRole = new List<Role>();
               
                int closed = (int)ServiceStatus.Closed;
                int inProgress = (int)ServiceStatus.InProgress;
                int ac = (int)ServiceTypes.AC;
                int electricity = (int)ServiceTypes.Electricity;
                int water = (int)ServiceTypes.Water;
                int glass = (int)ServiceTypes.BuildingGlass;
                int done = (int)ServiceStatus.Done;
                try

                {
                    using (_db)
                    {
                        Dashboard.ClosedServicesCount = (from service in _db.Services
                                                         join user in _db.Users on service.UserID equals user.ID
                                                         where service.Status == closed && user.ID == Id
                                                         select new
                                                         {
                                                             Status = service.Status

                                                         }).Count();
                        Dashboard.InProgressServicesCount = (from service in _db.Services
                                                             join user in _db.Users on service.UserID equals user.ID
                                                             where service.Status == inProgress && user.ID == Id
                                                             select new
                                                             {
                                                                 Status = service.Status
                                                             }).Count();
                        Dashboard.DoneServicesCount = (from service in _db.Services
                                                       join user in _db.Users on service.UserID equals user.ID
                                                       where service.Status == done && user.ID == Id
                                                       select new
                                                       {
                                                           Status = service.Status
                                                       }).Count();

                        Dashboard.ACServicesCount = (from service in _db.Services
                                                     join user in _db.Users on service.UserID equals user.ID
                                                     where service.ServiceTypeID == ac && user.ID == Id
                                                     select new
                                                     {
                                                         Status = service.Status
                                                     }).Count();
                        Dashboard.ElectricityServicesCount = (from service in _db.Services
                                                              join user in _db.Users on service.UserID equals user.ID
                                                              where service.ServiceTypeID == electricity && user.ID == Id
                                                              select new
                                                              {
                                                                  Status = service.Status
                                                              }).Count();
                        Dashboard.BuildingGlassServicesCount = (from service in _db.Services
                                                                join user in _db.Users on service.UserID equals user.ID
                                                                where service.ServiceTypeID == glass && user.ID == Id
                                                                select new
                                                                {
                                                                    Status = service.Status
                                                                }).Count();
                        Dashboard.WaterServicesCount = (from service in _db.Services
                                                        join user in _db.Users on service.UserID equals user.ID
                                                        where service.ServiceTypeID == water && user.ID == Id
                                                        select new
                                                        {
                                                            Status = service.Status
                                                        }).Count();


                    }

                }
                catch (Exception)
                {
                    throw;
                }
                return Dashboard;

            }

            return Dashboard;
        }

        public int AddService(ServiceDto service)
        {
            int result = 0;
            if (service != null) {
                int ac = (int)ServiceTypes.AC;
                int electricity = (int)ServiceTypes.Electricity;
                int water = (int)ServiceTypes.Water;
                int glass = (int)ServiceTypes.BuildingGlass;

                try
                {
                    using (_db)
                    {
                        Service newService = new Service();
                        if (service.ServiceTypeID == ac)
                        {
                            newService.ServiceType = "Air Condition";
                        }
                        else if (service.ServiceTypeID == electricity)
                        {
                            newService.ServiceType = "Electricity";
                        }
                        else if (service.ServiceTypeID == water)
                        {
                            newService.ServiceType = "Water";
                        }
                        else
                        {
                            newService.ServiceType = "Building Glass";
                        }
                        //Get the id from username
                        var UserLogined = _db.Users.SingleOrDefault(x => x.Username == service.UserLogined);

                        newService.UserID = UserLogined.ID;
                        newService.ResponseDate = null;
                        newService.RequestDate = DateTime.Now;
                        newService.ServiceTypeID = service.ServiceTypeID;
                        newService.RoomNo = service.RoomNo;
                        newService.FloorNo = service.FloorNo;
                        //newService.BulidingID = service.BulidingID;
                        newService.Description = service.Description;
                        newService.BranchID = service.BranchID;
                        newService.IsDraft = service.IsDraft;

                        _db.Services.Add(newService);



                        //Add the trail
                        if (UserLogined != null)
                        {
                            AuditTrail auditTrail = new AuditTrail();
                            auditTrail.Actor = UserLogined.ID;
                            auditTrail.ActionType = "created a new request";
                            auditTrail.ActionDate = DateTime.Now;
                            _db.AuditTrails.Add(auditTrail);
                            _db.SaveChanges();
                            result = 1;
                        }
                    }
                }
                catch (Exception e)
                {
                    result = 0;
                    throw;

                }
            }

           
            return result;
            }
        public int UpdateService(ServiceDto Service)
        {
            int result = 0;
            if (Service != null)
            {
                try
                {
                    using (_db)
                    {
                        var UpdatedService = _db.Services.SingleOrDefault(x => x.ID == Service.ID);

                        if (UpdatedService != null)
                        {
                            UpdatedService.BulidingID = Service.BulidingID;
                            UpdatedService.Description = Service.Description;
                            UpdatedService.FloorNo = Service.FloorNo;
                            UpdatedService.ServiceTypeID = Service.ServiceTypeID;
                            UpdatedService.RoomNo = Service.RoomNo;
                            UpdatedService.ResponsibleMaintenanceManager = Service.ResponsibleMaintenanceManager;
                            UpdatedService.ResponsibleMaintenanceWorker = Service.ResponsibleMaintenanceWorker;
                            _db.SaveChanges();
                            result = 1;
                        }
                    }
                }
                catch (Exception)
                {

                }
            }
           
            return result;
        }
        public async Task <int> DeleteService(int ServiceID)
        {
            int result = 0;
            if (ServiceID != 0)
            {
                try
                {
                    using (_db)
                    {
                        var UpdatedService = await( _db.Services.SingleOrDefaultAsync(x => x.ID == ServiceID));

                        if (UpdatedService != null)
                        {

                            _db.SaveChanges();
                            result = 1;
                        }
                    }
                }
                catch (Exception)
                {

                }
            }
           
            return result;
        }

        public async Task<List<ServiceTypeDto>> DisplayServicesTypes()
        {

            {
                var typesList = new List<ServiceTypeDto>();

                try
                {
                    using (_db)
                    {

                        typesList = await( _db.ServiceTypes.Select(y => new ServiceTypeDto
                        {

                            Name = y.Name,
                            ID = y.ID
                        })).ToListAsync();

                    }
                }
                catch (Exception)
                {
                    throw;
                }
      
                return typesList;
            }
        }
        public int CloseService(int ServiceID)
        {
            int result = 0;
            if (ServiceID != 0)
            {
                try
                {
                    using (_db)
                    {
                        var UpdatedService = _db.Services.SingleOrDefault(x => x.ID == ServiceID);

                        if (UpdatedService != null)
                        {
                            UpdatedService.IsColesed = true;
                            _db.SaveChanges();
                            result = 1;
                        }
                    }
                }
                catch (Exception)
                {

                }
            }
           
            return result;
        }
        public List<ServiceDto> DisplayService()
        {
            var serviceList = new List<ServiceDto>();
            try
            {
                using (_db)
                {
                    var serviceResult = (from service in _db.Services

                                         join branch in _db.Branchs on service.BranchID equals branch.ID
                                         select new
                                         {
                                             RequestDate = service.RequestDate,
                                             ID = service.ID,
                                             Status = service.Status,
                                             BulidingID = service.BulidingID,
                                             FloorNo = service.FloorNo,
                                             RoomNo = service.RoomNo,
                                             Description = service.Description,
                                             ServiceType = service.ServiceType,
                                             BranchName = branch.City,
                                             ServiceTypeID = service.ServiceTypeID

                                         });



                     serviceList = serviceResult.Select(y => new ServiceDto
                    {

                        RequestDate = y.RequestDate,
                        ServiceTypeID = y.ServiceTypeID,
                        ID = y.ID,
                        BulidingID = y.BulidingID,
                        BranchName = y.BranchName,
                        FloorNo = y.FloorNo,
                        RoomNo = y.RoomNo,
                        Description = y.Description,
                        ServiceType = y.ServiceType
                    }).ToList();
                    return serviceList;
                }
            
            }
            catch (Exception)
            {

            }
            return serviceList;
        }

        public int AddServiceType(ServiceTypeDto servicetype)
        {
            int result = 0;
            if (servicetype != null)
            {
                try
                {
                    using (_db)
                    {
                        ServiceType newServiceType = new ServiceType();
                        newServiceType.Name = servicetype.Name;


                        _db.ServiceTypes.Add(newServiceType);

                        _db.SaveChanges();
                        result = 1;
                    }
                }
                catch (Exception e)
                {


                }
            }
           
            return result;

        }
        public int UpdateServiceType(ServiceTypeDto servicetype)
        {
            int result = 0;
            if (servicetype != null)
            {
                try
                {
                    using (_db)
                    {
                        var UpdatedServicType = _db.ServiceTypes.SingleOrDefault(x => x.ID == servicetype.ID);

                        UpdatedServicType.Name = servicetype.Name;


                        _db.ServiceTypes.Update(UpdatedServicType);

                        _db.SaveChanges();
                        result = 1;
                    }
                }
                catch (Exception e)
                {


                }
            }
           
            return result;

        }
        public int AddServiceTypeUser(int UserID, int ServiceTypeID)
        {
            int result = 0;
            if (UserID != 0 && ServiceTypeID != 0)
            {
                var ServiceTypeUser = new List<ServiceType>();
                using (_db)
                {
                    User User = new User() { ID = UserID };
                    _db.Users.Add(User);
                    _db.Users.Attach(User);

                    // 


                    ServiceType serviceType = new ServiceType() { ID = ServiceTypeID };
                    _db.ServiceTypes.Add(serviceType);
                    _db.ServiceTypes.Attach(serviceType);

                    //
                    try
                    {

                        User.ServiceTypes = ServiceTypeUser;
                        ServiceTypeUser.Add(serviceType);
                        _db.SaveChanges();


                        result = 1;

                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
               
            

            }
            return result;
        }
        public int DeleteServiceTypeUser(int UserID, int ServiceTypeID)
        {
            int result = 0;
            if (UserID != 0 && ServiceTypeID != 0)
            {
                var User = _db.Users.FirstOrDefault(u => u.ID == UserID);
                var serviceType = _db.ServiceTypes.FirstOrDefault(u => u.ID == ServiceTypeID);
                
                try
                {
                    using (_db)
                    {
                        var user = _db.Users.Single(x => x.ID == UserID);
                        var serviceTypes = _db.Teams.Single(x => x.ID == ServiceTypeID);
                        _db.Entry(serviceTypes).Collection(x => x.Users).Load();
                        serviceTypes.Users.Remove(user);
                        _db.SaveChanges();
                        result = 1;
                        


                    }
                }
                catch (Exception e)
                {
                    
                       throw ;
                }

            }
            return result;

        }

        public int CountClientServices()
        {
            int servicesCount = 0;
            User userServicesCount = new User();
            try
            {
                using (_db)
                {

                    var query = (from d in _db.Services
                                 join f in _db.Users
                                 on d.UserID equals f.ID select d).ToList();

                    servicesCount = query.Count();

                    userServicesCount.ServicesCount = servicesCount;
                    _db.SaveChanges();


                }


                return servicesCount;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public ServiceDto DisplayServiceDetails(int Id)
        {
            ServiceDto services = new ServiceDto();

            if (Id != 0)
            {
                services.ID = Id;
                try
                {

                    var serviceResult = (from service in _db.Services
                                         where service.ID == Id
                                         join reply in _db.Reply on service.ID equals reply.ServiceId
                                         into rp
                                         from x in rp.DefaultIfEmpty()

                                             // where service.ID == Id
                                         select new
                                         {
                                             Description = service.Description,
                                             ServiceType = service.ServiceType,

                                             Content = x.MessageContent,
                                             ServiceTypeID = service.ServiceTypeID

                                         }); ;

                    var serviceDetail = serviceResult.Select(y => new ServiceDto()
                    {

                        ServiceTypeID = y.ServiceTypeID,
                        Content = y.Content,
                        Description = y.Description,
                        ServiceType = y.ServiceType
                    }).FirstOrDefault();
                    return serviceDetail;
                }



                catch (Exception)
                {
                    throw;
                }
            }

            return services;


        }
       /// <summary>
       /// ///////////
       /// </summary>
       /// <param name="Id"></param>
       /// <returns></returns>
        public List<ServiceDto> DisplayServicesForBenenficiary(int Id)
        {
            var serviceLists = new ServiceDto();
            if (Id != 0)
            {

            }


            try
            {
                using (_db)
                {
                    int userID = _db.Users.Where(s => s.ID == Id).Select(d => d.ID).FirstOrDefault();
         
                    var serviceList = _db.Services.Where(c=>c.UserID==Id).Select(d=> new ServiceDto()
            
                    {
                        RequestDate = d.RequestDate,
                        ResponseDate = d.ResponseDate,
                        BulidingID = d.BulidingID,
                        ID = d.ID,
                        Status = d.Status,
                        FloorNo = d.FloorNo,
                        RoomNo = d.RoomNo,
                        Description = d.Description,
                        ServiceType = d.ServiceType,
                        ServiceTypeID = d.ServiceTypeID
                    }).ToList();


                    return serviceList;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<List<ServiceDto>> DisplayServiceWorkers(int Id)
        {
            var ServiceList = new List<ServiceDto>();
            try
            {
                using (_db)
                {
                    int workerID = await (_db.Users.Where(s=>s.ID==Id).Select(d=>d.ID)).FirstOrDefaultAsync();
                    var services = (from service in _db.Services
                                    where service.ResponsibleMaintenanceWorker == workerID
                                    join user in _db.Users on service.ResponsibleMaintenanceWorker equals user.ID
                                    
                                    select new
                                    {
                                        RequestDate = service.RequestDate,
                                       



                                        ID = service.ID,
                                        Status = service.Status,
                                     
                                        FloorNo = service.FloorNo,
                                        RoomNo = service.RoomNo,
                                        Description = service.Description,
                                        ServiceType = service.ServiceType,
                                        WorkerFirstName = user.FirstName,
                                        WorkerLastName = user.FirstName
                                        
                                    });


                    var serviceList = services.Select(x => new ServiceDto()
                    {
                        RequestDate = x.RequestDate,
                   
                        ID = x.ID,
                        Status = x.Status,
                        FloorNo = x.FloorNo,
                        RoomNo = x.RoomNo,
                        Description = x.Description,
                        ServiceType = x.ServiceType,
                    
                        WorkerFirstName = x.WorkerFirstName,
                        WorkerLastName = x.WorkerFirstName
                    }).ToList();


                    return serviceList;
                }
                } catch (Exception ex)
            {
                throw;
            }
        }

        public List<ServiceDto> DisplayAllServices() 
        {//all status - for manager

            var ServiceList = new List<ServiceDto>();
         
            int notAssigned = 0;
            try
            {
                using (_db)
                {

                    var services = (from service in _db.Services
                                    where service.ResponsibleMaintenanceWorker != notAssigned
                                    join user in _db.Users on service.ResponsibleMaintenanceWorker equals user.ID
                                    select new
                                    {
                                        RequestDate = service.RequestDate,
                                        ID = service.ID,
                                        Status = service.Status,
                                        BulidingID = service.BulidingID,
                                        FloorNo = service.FloorNo,
                                        RoomNo = service.RoomNo,
                                        Description = service.Description,
                                        ServiceType = service.ServiceType,
                                        WorkerFullName = user.FirstName + " " + user.LastName,
                                        FirstName = (from userObject in _db.Users where userObject.ID == service.UserID select userObject.FirstName).FirstOrDefault(),
                                        LastName = (from userObject in _db.Users where userObject.ID == service.UserID select userObject.LastName).FirstOrDefault()
                                    })  ;


                    var serviceList = services.Select(x => new ServiceDto()
                    {
                        RequestDate = x.RequestDate,
                        BulidingID = x.BulidingID,
                        ID = x.ID,
                        Status = x.Status,
                        FloorNo = x.FloorNo,
                        RoomNo = x.RoomNo,
                        Description = x.Description,
                        ServiceType = x.ServiceType,
                        WorkerFullName = x.WorkerFullName,
                        ClientFullName = x.FirstName + "  " + x.LastName
                    }).ToList();


                    return serviceList;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<ServiceDto> DisplayServices()
        {
            //all status - for all

            var ServiceList = new List<ServiceDto>();

            try
            {
                using (_db)
                {

                    var services = (from service in _db.Services
                                    join user in _db.Users on service.ResponsibleMaintenanceWorker equals user.ID
                                    join branch in _db.Branchs on service.BranchID equals branch.ID
                                    select new
                                    {
                                        RequestDate = service.RequestDate,
                                        ID = service.ID,
                                        Status = service.Status,
                                        BulidingID = service.BulidingID,
                                        FloorNo = service.FloorNo,
                                        BranchName = branch.City,
                                        RoomNo = service.RoomNo,
                                        Description = service.Description,
                                        ServiceType = service.ServiceType,
                                        WorkerFullName = user.FirstName + " " + user.LastName,
                                        FirstName = (from userObject in _db.Users where userObject.ID == service.UserID select userObject.FirstName).FirstOrDefault(),
                                        LastName = (from userObject in _db.Users where userObject.ID == service.UserID select userObject.LastName).FirstOrDefault()
                                    });


                    var serviceList = services.Select(x => new ServiceDto()
                    {
                        RequestDate = x.RequestDate,
                        BulidingID = x.BulidingID,
                        ID = x.ID,
                        Status = x.Status,
                        FloorNo = x.FloorNo,
                        RoomNo = x.RoomNo,
                        Description = x.Description,
                        BranchName=x.BranchName,
                        ServiceType = x.ServiceType,
                        WorkerFullName = x.WorkerFullName,
                        ClientFullName = x.FirstName + "  " + x.LastName
                    }).ToList();


                    return serviceList;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<ServiceDto> DisplayAllNewServicesForBM()
        {//all IP status

            var ServiceList = new List<ServiceDto>();
            int inProgress = (int)ServiceStatus.InProgress;
           

            try
            {
                using (_db)
                {

                    var services = (from service in _db.Services 
                                    where service.Status == inProgress 
                                    join branch in _db.Branchs on service.BranchID equals branch.ID
                                    select new
                                    {
                                        RequestDate = service.RequestDate,
                                        ID = service.ID,
                                        Status = service.Status,
                                        BulidingID = service.BulidingID,
                                        FloorNo = service.FloorNo,
                                        RoomNo = service.RoomNo,
                                        Description = service.Description,
                                        ServiceType = service.ServiceType,
                                        BranchName = branch.City,
                                        FirstName = (from userObject in _db.Users where userObject.ID == service.UserID select userObject.FirstName).FirstOrDefault(),
                                        LastName = (from userObject in _db.Users where userObject.ID == service.UserID select userObject.LastName).FirstOrDefault()
                                    });


                    var serviceList = services.Select(x => new ServiceDto()
                    {
                        RequestDate = x.RequestDate,
                        BulidingID = x.BulidingID,
                        ID = x.ID,
                        Status = x.Status,
                        FloorNo = x.FloorNo,
                        RoomNo = x.RoomNo,
                        Description = x.Description,
                        ServiceType = x.ServiceType,
                      BranchName= x.BranchName,
                        ClientFullName = x.FirstName + "  " + x.LastName
                    }).ToList();


                    return serviceList;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }




        public List<ServiceDto> DisplayAllNewServicesForMM()
        {//all IP status

            var ServiceList = new List<ServiceDto>();
     
            int approve = (int)ServiceStatus.Approve;

            try
            {
                using (_db)
                {

                    var services = (from service in _db.Services
                                    where service.Status == approve
                                    join branch in _db.Branchs on service.BranchID equals branch.ID
                                    select new
                                    {
                                        RequestDate = service.RequestDate,
                                        ID = service.ID,
                                        Status = service.Status,
                                        BulidingID = service.BulidingID,
                                        FloorNo = service.FloorNo,
                                        RoomNo = service.RoomNo,
                                        Description = service.Description,
                                        ServiceType = service.ServiceType,
                                        BranchName = branch.City,
                                        FirstName = (from userObject in _db.Users where userObject.ID == service.UserID select userObject.FirstName).FirstOrDefault(),
                                        LastName = (from userObject in _db.Users where userObject.ID == service.UserID select userObject.LastName).FirstOrDefault()
                                    });


                    var serviceList = services.Select(x => new ServiceDto()
                    {
                        RequestDate = x.RequestDate,
                        BulidingID = x.BulidingID,
                        ID = x.ID,
                        Status = x.Status,
                        FloorNo = x.FloorNo,
                        RoomNo = x.RoomNo,
                        Description = x.Description,
                        ServiceType = x.ServiceType,
                        BranchName = x.BranchName,
                        ClientFullName = x.FirstName + "  " + x.LastName
                    }).ToList();


                    return serviceList;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        //approve or reject
        public int UpdateServiceStatus(ServiceDto service)
        {

            int reject = (int)ServiceStatus.Reject; //3
            int approve = (int)ServiceStatus.Approve; //4

            int check = 0;
            if (service != null)
            {
                try
                {
                    using (_db)
                    {

                        var result = _db.Services.SingleOrDefault(b => b.ID == service.ID);
                        if (result != null)
                        {
                            if (service.Status == 4)
                            {
                                result.Status = approve;
                                //Get the id from username
                                var UserLogined = _db.Users.SingleOrDefault(x => x.Username == service.UserLogined);

                                //Add the trail
                                if (UserLogined != null)
                                {
                                    AuditTrail auditTrail = new AuditTrail();
                                    auditTrail.Actor = UserLogined.ID;
                                    auditTrail.ActionType = "Approved Service Status";
                                    auditTrail.ActionDate = DateTime.Now;
                                    _db.AuditTrails.Add(auditTrail);
                                    _db.SaveChanges();//approve
                                    check = 1;
                                }
                            }
                            else
                            {
                                result.Status = reject;//reject
                                                       //Get the id from username
                                var UserLogined = _db.Users.SingleOrDefault(x => x.Username == service.UserLogined);

                                //Add the trail
                                if (UserLogined != null)
                                {
                                    AuditTrail auditTrail = new AuditTrail();
                                    auditTrail.Actor = UserLogined.ID;
                                    auditTrail.ActionType = "Rejected Service Status";
                                    auditTrail.ActionDate = DateTime.Now;
                                    _db.AuditTrails.Add(auditTrail);
                                    _db.SaveChanges();
                                    check = 1;
                                }

                            }
                        }
                    }

                }
                catch (Exception)
                {
                    throw;
                }
            }
           
            return check;
        }

        public List<ServiceDto> DisplayServicesForAll()
        {

            var ServiceList = new List<ServiceDto>();

            try
            {
                using (_db)
                {

                    var services = (from service in _db.Services
                             
                                    select new
                                    {
                                        RequestDate = service.RequestDate,
                                        ID = service.ID,
                                        Status = service.Status,
                                        BulidingID = service.BulidingID,
                                        FloorNo = service.FloorNo,
                                        RoomNo = service.RoomNo,
                                        Description = service.Description,
                                        ServiceType = service.ServiceType,
                                       
                                        FirstName = (from userObject in _db.Users where userObject.ID == service.UserID select userObject.FirstName).FirstOrDefault(),
                                        LastName = (from userObject in _db.Users where userObject.ID == service.UserID select userObject.LastName).FirstOrDefault()
                                    });


                    var serviceList = services.Select(x => new ServiceDto()
                    {
                        RequestDate = x.RequestDate,
                        BulidingID = x.BulidingID,
                        ID = x.ID,
                        Status = x.Status,
                        FloorNo = x.FloorNo,
                        RoomNo = x.RoomNo,
                        Description = x.Description,
                        ServiceType = x.ServiceType,
                      
                        ClientFullName = x.FirstName + "  " + x.LastName
                    }).ToList();


                    return serviceList;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
