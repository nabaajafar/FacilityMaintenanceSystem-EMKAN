using System;
using System.Collections.Generic;
using EMKAN.DataAccess.Model;
using EMKAN.Entity.Model;
using EMKAN.Entity.ModelDto;

namespace EMKAN.Application.Interfaces
{
    public interface IUser
    {
        public int GetID(string username);
        public List<UserDto> DisplayAllEmployee();
       public List<UserDto> DisplayAllClients();
        public int UpdateStatus(UserDto user);
        public User AddEmployee(UserDto user);
        public List<UserDto> DisplayEmployeesStatus();
        public List<UserDto> DisplayWorkers();
        public int UserExistence(UserDto user);
        public bool AuthenticateLogin(string email, string password);
        public User  AddUser(UserDto user);
        public int RemoveUser(EMKANRequest request);
        public int UpdateUser(UserDto user);
       // public int ReceiveRequests(UserDto user);
        public List<UserDto> ListOfBulidingManager();

    }
}
