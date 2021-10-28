using EMKAN.API5.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMKAN.API5.Filter
{
    public class EmkanSessionApiFilter : ActionFilterAttribute
    {


        public override void OnActionExecuting(ActionExecutingContext context)
        {

           
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
            if (context.Controller.GetType() != typeof(AccountController) && context.Controller.GetType() != typeof(PingController))
            {
                var tokenFound = context.HttpContext.Request.Headers.Keys.Contains("Authorization");
                if (tokenFound)
                {
                    context.HttpContext.Request.Headers.TryGetValue("Token", out var value);
                }
              
            }

        }
    }
}
