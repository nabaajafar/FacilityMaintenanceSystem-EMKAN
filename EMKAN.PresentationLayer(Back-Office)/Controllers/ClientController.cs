using EMKAN.Entity.Model;
using EMKAN.Entity.ModelDto;
using EMKAN.PresentationLayer_Back_Office_.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace EMKAN.PresentationLayer_Back_Office_.Controllers
{
    public class ClientController : Controller
    {
        string BaseUrl = Startup.GetBaseUrl();//API
        string BaseMvcUrl = Startup.GetMvcBaseUrl();//MVC
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Maintenance Manager")]

        [HttpPost]
        public async System.Threading.Tasks.Task<JsonResult> UpdateStatus(UpdateStatus userStatus)
        {
            string response = "";
            var token = HttpContext.Session.GetString("Token");
            UserDto user = new UserDto()
            {
                ID = userStatus.ID,
                Status = userStatus.Status,
                UserLogined = HttpContext.User.Identity.Name
            };
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    client.BaseAddress = new Uri(BaseUrl.ToString());
                    var request = new HttpRequestMessage(HttpMethod.Put, client.BaseAddress + "UpdateStatus");

                    if (user != null)
                    {
                        request.Content = new StringContent(JsonConvert.SerializeObject(user), System.Text.Encoding.UTF8, "application/json");


                    }

                    HttpResponseMessage responseMessage = await client.SendAsync(request);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        response = await responseMessage.Content.ReadAsStringAsync();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return Json("Updated Succesfully");
        }

}
}
