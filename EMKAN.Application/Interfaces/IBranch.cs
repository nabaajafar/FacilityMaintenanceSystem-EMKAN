using EMKAN.Entity.ModelDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMKAN.Application.Interfaces
{
  public interface IBranch
    {

        public List<BranchDto> DisplayBranches();
    }
}
