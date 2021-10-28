using EMKAN.Trace.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMKAN.Trace.Service
{
    public class RequestTrace : IRequestTrace
    {
        public Guid Id { get; protected set; }

        public DateTime TimeStamp { get; protected set; }

        public RequestTrace()
        {
            TimeStamp = DateTime.Now;
        }
        public void Register(Guid id)
        {
            Id = id;
        }
    }
}
