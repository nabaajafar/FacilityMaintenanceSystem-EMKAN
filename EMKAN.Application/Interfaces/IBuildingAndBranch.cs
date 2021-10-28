using EMKAN.Entity.Model;
using EMKAN.Entity.ModelDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMKAN.Application.Interfaces
{
  public  interface IBuildingAndBranch
    {
       
        public List<BranchDto> ListOfBranch();
        public List<BulidingDto> DisplayAllBuiding();
        public BulidingDto FindBuilding(int id);
        public List<AuditTrailDto> AuditTrailList();
        public int UpdateBuilding(BulidingDto buliding);
        public int DeleteBuilding(EMKANRequest eMKANRequest);
        public List<BranchDto> DisplayBranches();
        public int AddBuilding(BulidingDto building);
        public int AddBranch(BranchDto branch);
        public int DeleteBuilding(int bulidingId);
        public int UpdateBranch(BranchDto branch);
       // public int DeleteBrach(int branchId);
        public int AddNewReply(ReplyDto reply);
        public UserRoleDto GetRole(UserDto userModel);
        public string UserStatus(UserDto userModel);
        public int SignUp(UserDto userModel);
        public string ChangePassword(ChangePasswordDto password);




    }
}
