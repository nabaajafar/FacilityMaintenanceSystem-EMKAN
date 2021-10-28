using EMKAN.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace EMKAN.API5.Model
{
    public class Authorization : AuthorizationFilterAttribute
    {
        public string Roles { get; set; } = "";

       /* public override void OnAuthorization(HttpActionContext actionContext)
        {
            string auth = actionContext.Request.Headers.Authorization.Parameter;
            var resultFromValidate = TokenManager.ValidateToken(auth);

            string username = resultFromValidate.Item1;
            string result = resultFromValidate.Item2;
            if ((result.Contains(Roles) || Roles.Contains(result) || string.IsNullOrEmpty(Roles)) && username != null)
            {
                return;
            }
            else
            {
                //throw new UnauthorizedAccessException();
                //actionContext.Response = new HttpResponseMessage((HttpStatusCode)401) { ReasonPhrase = "Unauthorized user" };
                MessageResponse respone = new MessageResponse();
                respone.Result = false;
                respone.Message = "Unauthorization user";

                HttpResponseMessage responseMessage = new HttpResponseMessage(HttpStatusCode.Forbidden)
                {
                    Content = new StringContent("{\"Result\":\"false\", \"Message\":\"Unauthorization user\"}")
                };
                responseMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                actionContext.Response = responseMessage;
            }
        }*/


    }
}
