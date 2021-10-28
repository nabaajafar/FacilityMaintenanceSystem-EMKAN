using System;
using System.Collections.Generic;
using System.Linq;
using EMKAN.Application;
using EMKAN.Application.Interfaces;
using EMKAN.DataAccess.DbContexts;
using EMKAN.DataAccess.Model;
using EMKAN.Entity.Model;
using EMKAN.Entity.ModelDto;
using Microsoft.EntityFrameworkCore;

namespace EMKAN.Business.Servicess
{
    public class UserManager : IUser
    {
        private readonly EMKANDbContext _db;
        private readonly IService _Service;
        public UserManager()
        {

        }
        public UserManager(EMKANDbContext EMKANDB, IService service)
        {
            _db = EMKANDB;
            _Service = service;
        }
        public User AddUser(UserDto user)
        {
           
            User newUser = new User();
            if (user!= null)
            {
                try
                {
                    using (_db)
                    {

                        newUser.FirstName = user.FirstName;
                        newUser.LastName = user.LastName;
                        newUser.Username = user.Username;
                        newUser.ManagerID = user.ManagerID;
                        newUser.Password = user.Password;
                        newUser.Phone = user.Phone;
                        newUser.Status = 1;
                        newUser.loginStatus = 0;


                        _db.Users.Add(newUser);
                        _db.SaveChanges();
                     
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(" read " + ex);
                }
            }
           
            return newUser;

        }


        public bool AuthenticateLogin(string email, string password)
        {
            bool check = false;
            User User;
            if (email != null && password != null)
            {
                try
                {

                    using (_db)
                    {
                        User = _db.Users.FirstOrDefault(z => z.Password == password && (z.Username == email));


                    }
                    if (User == null)
                    {
                        check = false;
                    }
                    check = true;
                }

                catch (Exception)
                {
                    throw;

                }
            }
           
            return check;
        }




        public List<UserDto> DisplayAllEmployee()
        {
            int client = (int)ServiceUsers.Client;
            int admin = (int)ServiceUsers.Admin;
          
            try
            {

                var users = (from user in _db.Users
                             where user.RoleID != client && user.RoleID !=admin
                             join role in _db.Roles on user.RoleID equals role.ID
                             select new
                             {
                                 UserId = user.ID,
                                 FullName = user.FirstName + " " + user.LastName,
                                 Email = user.Username,
                                 Phone = user.Phone,
                                 RoleName = role.Name
                             });


                var userList = users.Select(x => new UserDto()
                {
                    ID = x.UserId,
                    FullName = x.FullName,
                    Username = x.Email,
                    Phone = x.Phone,
                    RoleName = x.RoleName
                }).ToList();



                return userList;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public int UserExistence(UserDto user)
        {
            var result = 0;
            if (user != null)
            {
                var userExistence = _db.Users.Any(x => x.Username == user.Username);
                if (userExistence)
                {
                    result = 1;
                }
                
            }
           return result;
        }

        
        public List<UserDto> DisplayEmployeesStatus()
        {

           // int client = (int)ServiceUsers.Client;
            //int admin = (int)ServiceUsers.Admin;
            int worker = (int)ServiceUsers.MaintenanceWorker;

            try
            {

                var users = (from user in _db.Users
                             where user.RoleID == worker //!= client && user.RoleID != admin
                             join role in _db.Roles on user.RoleID equals role.ID
                             select new
                             {
                                 UserId = user.ID,
                                 FullName = user.FirstName + " " + user.LastName,
                                 Email = user.Username,
                                 Phone = user.Phone,
                                 Status = user.Status,
                                 RoleName = role.Name
                             });


                var userList = users.Select(x => new UserDto()
                {
                    ID = x.UserId,
                 FullName = x.FullName,
                    Username = x.Email,
                    Phone = x.Phone,
                    Status = x.Status,
                    RoleName = x.RoleName
                }).ToList();



                return userList;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<UserDto> DisplayWorkers()
        {

            int worker = (int)ServiceUsers.MaintenanceWorker;

            try
            {

                var users = (from user in _db.Users
                             where user.RoleID == worker
                             join role in _db.Roles on user.RoleID equals role.ID
                             select new
                             {
                                 UserId = user.ID,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 Email = user.Username,
                                 Phone = user.Phone,
                                 Status = user.Status

                             });


                var userList = users.Select(x => new UserDto()
                {
                    ID = x.UserId,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Username = x.Email,
                    Phone = x.Phone,
                    Status = x.Status
                }).ToList();
               



                return userList;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

      


        public int RemoveUser(EMKANRequest request)
        {
            int result = 0;
            if (request != null)
            {
                try
                {
                    using (_db)
                    {
                        var User = _db.Users.Where(z => z.ID == request.ID).FirstOrDefault();
                        _db.Users.Remove(User);
                        //Get the id from username
                        var UserLogined = _db.Users.SingleOrDefault(x => x.Username == request.UserLogined);

                        //Add the trail
                        if (UserLogined != null)
                        {
                            AuditTrail auditTrail = new AuditTrail();
                            auditTrail.Actor = UserLogined.ID;
                            auditTrail.ActionType = "Removed user";
                            auditTrail.ActionDate = DateTime.Now;
                            _db.AuditTrails.Add(auditTrail);
                            _db.SaveChanges();
                            result = 1;
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }

            }
           
            return result; 
        }




        public int UpdateStatus(UserDto user)
        {
            int check = 0;
            
            if (user != null)
            {
                try
                {
                    using (_db)
                    {

                        var result = _db.Users.SingleOrDefault(b => b.ID == user.ID);
                        if (result != null)
                        {
                            if (user.Status == 1)
                            {
                                result.Status = 1;
                                //Get the id from username
                                var UserLogined = _db.Users.SingleOrDefault(x => x.Username == user.UserLogined);
                                if (UserLogined != null)
                                {
                                    //Add the trail
                                    AuditTrail auditTrail = new AuditTrail();
                                    auditTrail.Actor = UserLogined.ID;
                                    auditTrail.ActionType = "Update User Status";
                                    auditTrail.ActionDate = DateTime.Now;
                                    _db.AuditTrails.Add(auditTrail);
                                    _db.SaveChanges();
                                    check = 1;
                                }
                            }
                            else
                            {
                                result.Status = 0;

                                _db.SaveChanges();
                                check = 1;

                            }
                        }
                        else
                        {
                            check = 0;
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

        public int UpdateUser(UserDto user)
        {
            int check = 0;
            if (user != null)
            {
                try
                {
                    using (_db)
                    {
                        UserDto newUser = new UserDto();
                        newUser.FirstName = user.FirstName;
                        newUser.LastName = user.LastName;
                        newUser.Username = user.Username;
                        newUser.ManagerID = user.ManagerID;
                        newUser.Password = user.Password;
                        newUser.Phone = user.Phone;
                        newUser.Roles = user.Roles;
                        newUser.Services = user.Services;
                        newUser.ServiceTypes = newUser.ServiceTypes;
                        newUser.Teams = user.Teams;
                        _db.SaveChanges();
                        check = 1;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
           
            return check;

        }

        public List<UserDto> DisplayAllClients()
        {
            int client = (int)ServiceUsers.Client;

            try
            {

                var users = (from user in _db.Users
                             where user.RoleID == client
                             join role in _db.Roles on user.RoleID equals role.ID
                             select new
                             {
                                 UserId = user.ID,
                    
                                 Email = user.Username,
                                 Phone = user.Phone,
                                 Status = user.Status,
                                 FullName = user.FirstName + " " + user.LastName
                             });


                var userList = users.Select(x => new UserDto()
                {
                    ID = x.UserId,
                    FullName  = x.FullName,
                    Username = x.Email,
                    Phone = x.Phone,
                    Status = x.Status
                }).ToList();



                return userList;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public List<UserDto> ListOfBulidingManager()
        {
            int BulidingManager = (int)ServiceUsers.BuildingManager;

            try
            {

                var users = (from user in _db.Users
                             where user.RoleID == BulidingManager
                             join role in _db.Roles on user.RoleID equals role.ID
                             select new
                             {
                                 UserId = user.ID,
                                 FullName = user.FirstName + " " + user.LastName
                             });


                var userList = users.Select(x => new UserDto()
                {
                    ID = x.UserId,
                    FullName = x.FullName,
                }).ToList();



                return userList;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public User AddEmployee(UserDto user)
        {
            int check = 0;
            User newUser = new User();
            if (user != null)
            {
                try
                {
                    using (_db)
                    {

                        newUser.FirstName = user.FirstName;
                        newUser.LastName = user.LastName;
                        newUser.Username = user.Username;
                        newUser.ManagerID = user.ManagerID;
                        newUser.Password = user.Password;
                        newUser.Phone = user.Phone;
                        newUser.RoleID = user.RoleID;
                        newUser.Status = 1;
                        newUser.loginStatus = 0;
                        newUser.ServicesCount = 0;

                        _db.Users.Add(newUser);
                        //Get the id from username
                        var UserLogined = _db.Users.SingleOrDefault(x => x.Username == user.UserLogined);

                        //Add the trail
                        if(UserLogined != null)
                        {
                            AuditTrail auditTrail = new AuditTrail();
                            auditTrail.Actor = UserLogined.ID;
                            auditTrail.ActionType = "Added user";
                            auditTrail.ActionDate = DateTime.Now;
                            _db.AuditTrails.Add(auditTrail);
                            _db.SaveChanges();
                        }
                       

                        check = 1;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(" read " + ex);
                }
            }
         
            return newUser;
        }

        public int GetID(string username)
        {
            int check = 0;
            int Id = 0;
            if (username != null)
            {
                try
                {
                    using (_db)
                    {
                        //Id = _db.Users.Where(x => x.Username.Equals(user.Username)).Select(x => x.ID).FirstOrDefault();
                        //Get the id from username
                        var user = _db.Users.SingleOrDefault(x => x.Username == username);
                        Id = user.ID;
                        check = 1;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(" read " + ex);
                }
            }
           
            return Id;
        }
    }
    }


