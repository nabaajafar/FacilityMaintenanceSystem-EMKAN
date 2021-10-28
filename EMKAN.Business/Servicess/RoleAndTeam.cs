using EMKAN.Application.Interfaces;
using EMKAN.DataAccess.DbContexts;
using EMKAN.DataAccess.Model;
using EMKAN.Entity.Model;
using EMKAN.Entity.ModelDto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EMKAN.Business.Servicess
{
    public class RoleAndTeam : IRoleAndTeam
    {
        private readonly EMKANDbContext _db;
        public RoleAndTeam(EMKANDbContext EMKANDB)
        {
            _db = EMKANDB;
        }

        public List<RoleDto> RoleList()
        {
            using (_db)
            {
                var roleList = _db.Roles.Select(r => new RoleDto() { ID = r.ID, Name = r.Name });
                return roleList.ToList();
            }
        }

        public int UpdateRoleUser(UserDto user)
        {
            var check = 0;
            if (user != null)
            {
                var UserRole = new List<Role>();
                try
                {
                    using (_db)
                    {
                        var UpdatedRole = _db.Users.SingleOrDefault(x => x.ID == user.ID);
                        if (UpdatedRole != null)
                        {
                            UpdatedRole.RoleID = user.RoleID;
                            //Get the id from username
                            var UserLogined = _db.Users.SingleOrDefault(x => x.Username == user.UserLogined);

                            //Add the trail
                            if (UserLogined != null)
                            {
                                AuditTrail auditTrail = new AuditTrail();
                                auditTrail.Actor = UserLogined.ID;
                                auditTrail.ActionType = "Updated user role";
                                auditTrail.ActionDate = DateTime.Now;
                                _db.AuditTrails.Add(auditTrail);
                                _db.SaveChanges();
                                check = 1;
                            }
                           
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw;
                    check = 0;
                }

            }
            
            return check;
        }
        public int AddRole(RoleDto role)
        {
            int result = 0;
            if (role != null)
            {
                try
                {
                    using (_db)
                    {
                        Role newRole = new Role();

                        newRole.Name = role.Name;

                        _db.Roles.Add(newRole);

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
        public int DeleteRole(int RoleID)
        {
            int result = 0;
            if (RoleID != 0)
            {
                try
                {
                    using (_db)
                    {
                        var DeletedRole = _db.Roles.SingleOrDefault(x => x.ID == RoleID);

                        if (DeletedRole != null)
                        {
                            _db.Roles.Remove(DeletedRole);
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
        public int UpdateRole(RoleDto role)
        {
            int result = 0;
            if (role != null)
            {
                try
                {
                    using (_db)
                    {
                        var UpdatedRole = _db.Roles.SingleOrDefault(x => x.ID == role.ID);
                        if (UpdatedRole != null)
                        {
                            UpdatedRole.Name = role.Name;
                            _db.Roles.Update(UpdatedRole);

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
        public int AddUserRole(int UserID, int RoleID)
        {
            int result = 0;
            var UserRole = new List<Role>();
            if (UserID != 0 && RoleID != 0)
            {
                using (_db)
                {
                    User User = new User() { ID = UserID };
                    _db.Users.Add(User);
                    _db.Users.Attach(User);

                    // 


                    Role Role = new Role() { ID = RoleID };
                    _db.Roles.Add(Role);
                    _db.Roles.Attach(Role);

                    //
                    try
                    {

                        //User.Roles = UserRole;
                        UserRole.Add(Role);
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
        public int DeleteUserRole(int UserID, int RoleID)
        {
            int result = 0;
            if (UserID != 0 && RoleID != 0)
            {
                var User = _db.Users.FirstOrDefault(u => u.ID == UserID);
                var Team = _db.Roles.FirstOrDefault(u => u.ID == RoleID);
               
                try
                {
                    using (_db)
                    {
                        var user = _db.Users.Single(x => x.ID == UserID);
                        var team = _db.Roles.Single(x => x.ID == RoleID);
                        _db.Entry(team).Collection(x => x.Users).Load();
                        team.Users.Remove(user);
                        _db.SaveChanges();
                        result = 1;
                       


                    }
                }
                catch (Exception e)
                {
                    throw;
                }
                
            }

            return result;
        }

        public int AddTeam(TeamDto team)
        {
            int result = 0;
            if (team != null)
            {
                try
                {
                    using (_db)
                    {
                        Team newTeam = new Team();

                        newTeam.Name = team.Name;
                        newTeam.ServiceTypeID = team.ServiceTypeID;


                        _db.Teams.Add(newTeam);

                        _db.SaveChanges();
                        result = 1;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
           
            return result;

        }

        public int DeleteTeam(int TeamID)
        {
            int result = 0;
            if (TeamID != 0)
            {
                try
                {
                    using (_db)
                    {
                        var DeletedTeam = _db.Teams.SingleOrDefault(x => x.ID == TeamID);

                        if (DeletedTeam != null)
                        {
                            _db.Teams.Remove(DeletedTeam);
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
        public int UpdateTeam(TeamDto team)
        {
            var result = 0;
            if (team != null)
            {
                try
                {
                    using (_db)
                    {



                        var UpdatedTeam = _db.Teams.SingleOrDefault(x => x.ID == team.ID);
                        if (UpdatedTeam != null)
                        {
                            UpdatedTeam.Name = team.Name;
                            UpdatedTeam.ServiceTypeID = team.ServiceTypeID;
                            UpdatedTeam.BranchID = team.BranchID;

                            _db.Teams.Update(UpdatedTeam);
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

        public int AddUserTeam(int UserID, int RoleID)
        {
            int result = 0;
            
            var UserRole = new List<Role>();
            if (UserID != 0 && RoleID != 0)
            {
                using (_db)
                {
                    User User = new User() { ID = UserID };
                    _db.Users.Add(User);
                    _db.Users.Attach(User);

                    // 


                    Role Role = new Role() { ID = RoleID };
                    _db.Roles.Add(Role);
                    _db.Roles.Attach(Role);

                    //
                    try
                    {


                        UserRole.Add(Role);
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
            public int DeleteUserTeam(int UserID, int TeamID)
            {
            var result = 0;
            if (UserID != 0 && TeamID != 0)
            {
                var User = _db.Users.FirstOrDefault(u => u.ID == UserID);
                var Team = _db.Teams.FirstOrDefault(u => u.ID == TeamID);
               
                try
                {
                    using (_db)
                    {
                        var user = _db.Users.Single(x => x.ID == UserID);
                        var team = _db.Teams.Single(x => x.ID == TeamID);
                        _db.Entry(team).Collection(x => x.Users).Load();
                        team.Users.Remove(user);
                        _db.SaveChanges();
                        result = 1;


                    }
                }
                catch (Exception e)
                {
                    throw;
                }

            }
            return result;

        }
  
    }
}
