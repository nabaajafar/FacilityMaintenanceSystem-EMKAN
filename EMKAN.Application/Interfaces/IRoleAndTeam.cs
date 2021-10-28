using EMKAN.Entity.Model;
using EMKAN.Entity.ModelDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMKAN.Application.Interfaces
{
   public  interface IRoleAndTeam
    {
        public List<RoleDto> RoleList();

        public int UpdateRoleUser(UserDto user);
        public int AddRole(RoleDto role);
        public int DeleteRole(int RoleId); 
        public int UpdateRole(RoleDto role);
        public int AddUserRole(int UserID, int RoleID);
        public int DeleteUserRole(int UserID, int RoleID);
        public int AddTeam(TeamDto team);
        public int DeleteTeam(int teamId);
        public int UpdateTeam(TeamDto team);
        public int AddUserTeam(int UserID, int TeamID);
        public int DeleteUserTeam(int UserID, int TeamID);
 
    }
}
