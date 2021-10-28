using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

using EMKAN.PresentationLayer_Back_Office_.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

using Microsoft.AspNetCore.Routing;

namespace EMKAN.PresentationLayer_Back_Office_.Filter
{

    
    public class EmkanSessionFilter : ActionFilterAttribute
    {


        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            var actionName = context.ActionDescriptor.DisplayName;
            if (context.Controller.GetType() != typeof(AccountController) && context.Controller.GetType() != typeof(PingController))
            {
                if (context.HttpContext.Session == null ||
                                 !context.HttpContext.Session.TryGetValue("username", out byte[] val))
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Account" }, { "action", "LoginView" } });
                }
            }
            if (!actionName.Contains("LoginView") && !actionName.Contains("Login") && context.Controller.GetType() != typeof(PingController))
            {
                var token = context.HttpContext.Session.GetString("Token");
                context.HttpContext.Request.Headers.Add("Token", token);

            }
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
            //var actionName = context.ActionDescriptor.DisplayName;
            
            //if (!actionName.Contains("LoginView") && !actionName.Contains("Login") && context.Controller.GetType() != typeof(PingController))
            //{
            //    //  var username = context.HttpContext.Session.GetString("username");
            //    var token = context.HttpContext.Session.GetString("Token");
            //    //  var role = context.HttpContext.Session.GetString("role");
            //    context.HttpContext.Request.Headers.Add("Token", token);
            //}
        }
    }
}
