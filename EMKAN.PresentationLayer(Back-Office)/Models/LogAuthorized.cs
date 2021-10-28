using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace EMKAN.PresentationLayer_Back_Office_.Models
{
    public class LogAuthorized :  ActionFilterAttribute, IActionFilter
    {
        public string Roles { get; set; } = "";
        public override void OnActionExecuting(ActionExecutingContext context)
        {

            string token = context.HttpContext.Session.GetString("TokenNumber");
            if (token != null)
            {
                var roles = TokenManager.ValidateToken(token).Item2;

                // Do something before the action executes.
                var user = new GenericPrincipal(new ClaimsIdentity(""), roles.Split(","));
                context.HttpContext.User = user;
                //Add Validation code here

                var pageRole = Roles.Split(",");
                bool result = false;
                foreach (string i in pageRole)
                {
                    if (user.IsInRole(i))
                    {
                        result = true;
                    }
                }
                if (result == false)
                {
                    context.Result = new RedirectToRouteResult(
                new RouteValueDictionary
                {
                    {"controller", "Home"},
                    {"action", "index"}
                }
             );
                }
                base.OnActionExecuting(context);
            }
            else
            {
                context.Result = new RedirectToRouteResult(
                new RouteValueDictionary
                {
                    {"controller", "Home"},
                    {"action", "Login"}
                }
             );
            }
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            // Do something after the action executes.

        }
    }
}
