using System;
using System.Collections.Generic;
using System.Text;

namespace EMKAN.Trace.Abstraction
{
    public interface IRequestTrace
    {
        Guid Id { get; }
        DateTime TimeStamp { get; }
        void Register(Guid id);
    }
}
