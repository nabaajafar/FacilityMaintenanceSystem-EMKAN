
using EMKAN.DataAccess.DbContexts;
using EMKAN.Entity.ModelDto;
using EMKAN.DataAccess.Model;
using System;
using System.Linq;
using EMKAN.Application.Interfaces;
using System.Collections.Generic;
using EMKAN.Entity.Model;

namespace EMKAN.Business.Servicess
{
    public class BuildingAndBranch : IBuildingAndBranch
    {
        private readonly EMKANDbContext _db;
        public BuildingAndBranch(EMKANDbContext db)
        {
            _db = db;
        }
      





        public int UpdateBuilding(BulidingDto buliding)
        {
            int result = 0;
            if (buliding != null)
            {
              
                try
                {
                    using (_db)
                    {
                        var UpdatedBuilding = _db.Bulidings.SingleOrDefault(x => x.ID == buliding.ID);

                        UpdatedBuilding.Name = buliding.Name;
                        UpdatedBuilding.NumberOfFloor = buliding.NumberOfFloor;
                        UpdatedBuilding.NumberOfRoom = buliding.NumberOfRoom;
                        UpdatedBuilding.BranchID = buliding.BranchID;
                        UpdatedBuilding.UserID = buliding.UserID;

                        _db.Bulidings.Update(UpdatedBuilding);

                        //Get the id from username
                        var UserLogined = _db.Users.SingleOrDefault(x => x.Username == buliding.UserLogined);

                        //Add the trail

                        if (UserLogined != null)
                        {
                            AuditTrail auditTrail = new AuditTrail();
                            auditTrail.Actor = UserLogined.ID;
                            auditTrail.ActionType = "Edit Buliding info.";
                            auditTrail.ActionDate = DateTime.Now;
                            _db.AuditTrails.Add(auditTrail);

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
        public int AddBuilding(BulidingDto buliding)
        {
            int result = 0;
            if (buliding != null)
            {
               
                try
                {
                    using (_db)
                    {
                        Building newBulding = new Building();
                        newBulding.Name = buliding.Name;
                        newBulding.NumberOfFloor = buliding.NumberOfFloor;
                        newBulding.NumberOfRoom = buliding.NumberOfRoom;
                        newBulding.BranchID = buliding.BranchID;
                        newBulding.UserID = buliding.UserID;

                        _db.Bulidings.Add(newBulding);


                        //Get the id from username
                        var UserLogined = _db.Users.SingleOrDefault(x => x.Username == buliding.UserLogined);

                        //Add the trail
                        if (UserLogined != null)
                        {
                            AuditTrail auditTrail = new AuditTrail();
                            auditTrail.Actor = UserLogined.ID;
                            auditTrail.ActionType = "Add new Buliding";
                            auditTrail.ActionDate = DateTime.Now;
                            _db.AuditTrails.Add(auditTrail);
                            _db.SaveChanges();
                            result = 1;
                        }

                    }
                }
                catch (Exception ex)
                {

                }
               
            }
            return result;

        }
        public int DeleteBuilding(EMKANRequest eMAKANRequest)
        {
            int result = 0;
            if (eMAKANRequest != null)
            {
                try
                {
                    using (_db)
                    {
                        var DeletedBuilding = _db.Bulidings.SingleOrDefault(x => x.ID == eMAKANRequest.ID);

                        if (DeletedBuilding != null)
                        {
                            _db.Bulidings.Remove(DeletedBuilding);

                            //Get the id from username
                            var UserLogined = _db.Users.SingleOrDefault(x => x.Username == eMAKANRequest.UserLogined);

                            //Add the trail
                            if (UserLogined != null)
                            {
                                AuditTrail auditTrail = new AuditTrail();
                                auditTrail.Actor = UserLogined.ID;
                                auditTrail.ActionType = "Delete Buliding info.";
                                auditTrail.ActionDate = DateTime.Now;
                                _db.AuditTrails.Add(auditTrail);

                                _db.SaveChanges();
                                result = 1;
                            }

                        }
                    }
                }
                catch (Exception)
                {

                }

            }
           
            return result;

        }
        public int DeleteBuilding(int bulidingId)
        {
            int result = 0;
            if (bulidingId != null)
            {
                try
                {
                    using (_db)
                    {
                        var DeletedBuilding = _db.Bulidings.SingleOrDefault(x => x.ID == bulidingId);

                        if (DeletedBuilding != null)
                        {
                            _db.Bulidings.Remove(DeletedBuilding);
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
        public int AddBranch(BranchDto branch)
        {
            int result = 0;
            if (branch != null)
            {
                try
                {
                    using (_db)
                    {
                        Branch newBranch = new Branch();
                        newBranch.City = branch.City;
                        newBranch.Country = branch.Country;
                        newBranch.Street = branch.Street;

                        _db.Branchs.Add(newBranch);

                        _db.SaveChanges();
                        result = 1;
                    }
                }
                catch (Exception)
                {

                }
            }
           
            return result;

        }

        public List<BranchDto> DisplayBranches()
        {
          
           
            {
                var brancheList = new List<BranchDto>();

                try
                {
                    using (_db)
                    {


                        brancheList = _db.Branchs.Select(y => new BranchDto
                        {
                          
                            ID = y.ID,
                          City = y.City
                        }).ToList();

                    }
                }
                catch (Exception)
                {

                }
                return brancheList;
            }
        }
            public int UpdateBranch(BranchDto branch)
        {
            int result = 0;
            if (branch != null)
            {
                try
                {
                    using (_db)
                    {
                        var UpdatedBranch = _db.Branchs.SingleOrDefault(x => x.ID == branch.ID);

                        UpdatedBranch.City = branch.City;
                        UpdatedBranch.Country = branch.Country;
                        UpdatedBranch.Street = branch.Street;

                        _db.Branchs.Update(UpdatedBranch);

                        _db.SaveChanges();
                        result = 1;
                    }
                }
                catch (Exception)
                {

                }
            }
           
            return result;

        }
        public int DeleteBranch(int branchId)
        {
            int result = 0;
            if (branchId != null)
            {
                try
                {
                    using (_db)
                    {
                        var DeletedBrach = _db.Branchs.SingleOrDefault(x => x.ID == branchId);

                        if (DeletedBrach != null)
                        {
                            _db.Branchs.Remove(DeletedBrach);
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

       

        public int AddNewReply(ReplyDto reply)
        {
            int check= 0;
            if (reply != null)
            {
                try
                {



                    var newReply = new Reply
                    {
                        ServiceId = reply.ID,
                        MessageContent = reply.MessageContent,
                        MessageTime = DateTime.Now

                    };



                    var updatedService = _db.Services.SingleOrDefault(x => x.ID == reply.ID);
                    if (updatedService != null)
                    {
                        updatedService.Status = reply.Status;
                        updatedService.ResponseDate = DateTime.Now;
                        _db.Services.Update(updatedService);
                        _db.Reply.Add(newReply);

                    }
                  
                    //Get the id from username
                    var UserLogined = _db.Users.SingleOrDefault(x => x.Username == reply.UserLogined);

                    //Add the trail
                    if (UserLogined != null)
                    {
                        AuditTrail auditTrail = new AuditTrail();
                        auditTrail.Actor = UserLogined.ID;
                        auditTrail.ActionType = "Added a reply";
                        auditTrail.ActionDate = DateTime.Now;
                        _db.AuditTrails.Add(auditTrail);
                        _db.SaveChanges();
                        check = 1;
                    }
                }
                catch (Exception)
                {
                    throw;
                    check = 0;
                }

            }
           
            return check;
        }

       


        public List<BranchDto> ListOfBranch()
        {
            try
            {

                var branches = (from branch in _db.Branchs
                                select new
                                {
                                    ID = branch.ID,
                                    Location = branch.Country + "-" + branch.City + "-" + branch.Street
                                });


                var branchList = branches.Select(x => new BranchDto()
                {
                    ID = x.ID,
                    Location = x.Location,
                }).ToList();



                return branchList;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public List<BulidingDto> DisplayAllBuiding()
        {
            try
            {

                var builidings = (from buliding in _db.Bulidings
                                  join branch in _db.Branchs on buliding.BranchID equals branch.ID
                                  join user in _db.Users on buliding.UserID equals user.ID
                                  select new
                                  {
                                      ID = buliding.ID,
                                      Name = buliding.Name,
                                      BranchName = branch.Country + "-" + branch.City + "-" + branch.Street,
                                      NumberOfFloor = buliding.NumberOfFloor,
                                      NumberOfRoom = buliding.NumberOfRoom,
                                      BulidingManagerName = user.FirstName + " " + user.LastName
                                  });


                var builidingList = builidings.Select(x => new BulidingDto()
                {
                    ID = x.ID,
                    Name = x.Name,
                    BranchName = x.BranchName,
                    NumberOfFloor = x.NumberOfFloor,
                    NumberOfRoom = x.NumberOfRoom,
                    BulidingManagerName = x.BulidingManagerName
                }).ToList();



                return builidingList;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public BulidingDto FindBuilding(int id)
        {

            if (id != 0)
            {
                try
                {

                    var builidings = (from buliding in _db.Bulidings
                                      join branch in _db.Branchs on buliding.BranchID equals branch.ID
                                      join user in _db.Users on buliding.UserID equals user.ID
                                      where buliding.ID == id
                                      select new
                                      {
                                          Name = buliding.Name,
                                          BranchID = buliding.BranchID,
                                          BranchName = branch.Country + "-" + branch.City + "-" + branch.Street,
                                          NumberOfFloor = buliding.NumberOfFloor,
                                          NumberOfRoom = buliding.NumberOfRoom,
                                          BulidingManagerID = buliding.UserID,
                                          BulidingManagerName = user.FirstName + " " + user.LastName
                                      });


                    var builidingObj = builidings.Select(x => new BulidingDto()
                    {
                        Name = x.Name,
                        BranchID = x.BranchID,
                        BranchName = x.BranchName,
                        NumberOfFloor = x.NumberOfFloor,
                        NumberOfRoom = x.NumberOfRoom,
                        UserID = x.BulidingManagerID,
                        BulidingManagerName = x.BulidingManagerName
                    }).FirstOrDefault();



                    return builidingObj;

                }

                catch (Exception ex)
                {
                    throw;
                }

            }

            return null;
            
        }

        public List<AuditTrailDto> AuditTrailList()
        {
            try
            {

                var audits = (from auditTrail in _db.AuditTrails
                              join user in _db.Users on auditTrail.Actor equals user.ID
                              select new
                              {
                                  ID = auditTrail.ID,
                                  Actor = auditTrail.Actor,
                                  ActorName = user.FirstName + " " + user.LastName,
                                  ActionType = auditTrail.ActionType,
                                  ActionDate = auditTrail.ActionDate,
                              });


                var auditList = audits.Select(x => new AuditTrailDto()
                {
                    ID = x.ID,
                    Actor = x.Actor,
                    ActorName = x.ActorName,
                    ActionType = x.ActionType,
                    ActionDate = x.ActionDate,
                }).ToList();

                return auditList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }




        public string ChangePassword(ChangePasswordDto newPasswordModel)
        {
            if (newPasswordModel != null)
            {
                var userObj = _db.Users.Where(x => x.Username.ToLower() == newPasswordModel.Username.ToLower()).FirstOrDefault();
                if (userObj != null)
                {
                    userObj.Password = newPasswordModel.Password;
                    userObj.loginStatus = 1;

                    _db.Users.Update(userObj);
                    _db.SaveChanges();
                    return "1";

                }
                else
                {
                    return "0";
                }

            }
            return "0";

        }
        public string UserStatus(UserDto userModel)
        {
            string status = "";
           
            if (userModel != null)
            {
                var userObj = _db.Users.SingleOrDefault(x => x.Username.ToLower() == userModel.Username.ToLower());
                if (userObj != null)
                {
                    if (userObj.loginStatus == 0)
                    {
                        status = "new";

                    }
                    if (userObj.Status == 0)
                    {
                        status = "unactive";
                    }
                    if (userObj.Status == 1 && userObj.loginStatus == 1)
                    {
                        status = "normal";
                    }
                }

            }

            return status;
        }
        public UserRoleDto GetRole(UserDto userModel)
        {
            UserRoleDto userRole = new UserRoleDto();
            if (userModel != null)
            {
                var user = _db.Users.Where(x => x.Username == userModel.Username).Any();

                var userObj = _db.Users.SingleOrDefault(x => x.Username.ToLower() == userModel.Username.ToLower() && x.Password == userModel.Password);

               
                if (userObj != null)
                {
                    var roleObj = _db.Roles.Where(x => x.ID == userObj.RoleID).FirstOrDefault();
                    if (roleObj != null)
                    {
                        UserRoleDto userInfo = new UserRoleDto()
                        {
                            UserName = userObj.Username,
                            Password = userObj.Password,
                            UserID = userObj.ID,
                            Role = roleObj.Name
                        };
                        userRole = userInfo;
                    }
                    else
                    {
                        UserRoleDto userInfo = new UserRoleDto()
                        {
                            UserName = userObj.Username,
                            Password = userObj.Password,
                            Role = string.Empty
                        };
                        userRole = userInfo;
                    }
                }
            }
           
            return userRole;
        }



        public int SignUp(UserDto userModel)
        {
            int result = 0;
            if (userModel != null)
            {
                var user = new User
                {
                    FirstName = userModel.FirstName,
                    LastName = userModel.LastName,
                    Password = userModel.Password,
                    Phone = userModel.Phone,
                    RoleID = 2,
                    Username = userModel.Username,
                    Status = 1,
                    loginStatus = 1


                };
                _db.Users.Add(user);
                _db.SaveChanges();
                result = 1;
                return result ;
            }

            return result;

        }


    }
}

