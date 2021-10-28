using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMKAN.API5.Model
{
    public static class DbHealthCheckprovider
    {
        public static HealthCheckResult check (string connection)
        {
            return HealthCheckResult.Healthy();
        }

    }
}
