using EMKAN.Application;
using EMKAN.DataAccess.DbContexts;
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
using System.Text;
using System.Threading.Tasks;

namespace EMKAN.PresentationLayer_Back_Office_.Controllers
{
    public class MaintenanceWorkerController : Controller
    {
        string BaseUrl = Startup.GetBaseUrl();
        string BaseMvcUrl = Startup.GetMvcBaseUrl();//MVC
      

        [Authorize(Roles = "Employee")]
        public async Task<ActionResult> ViewEmpServices()
        {
            string username = HttpContext.Session.GetString("username");
            int Id = Convert.ToInt32(HttpContext.Session.GetString("userID"));
            var token = HttpContext.Session.GetString("Token");
            List<ViewServices> serviceInfo = new List<ViewServices>();
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    client.BaseAddress = new Uri(BaseUrl.ToString());

                    var serviceResponse = await client.GetAsync(BaseUrl.ToString() + $"DisplayServicesForBenenficiary/{Id}");
                    if (serviceResponse.IsSuccessStatusCode)
                    {
                        var response = serviceResponse.Content.ReadAsStringAsync().Result;

                        //Deserializing the response recieved from web api and storing into the Employee list
                        serviceInfo = JsonConvert.DeserializeObject<List<ViewServices>>(response);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            ViewBag.BaseMvcUrl = BaseMvcUrl;
            return View(serviceInfo);
        }
        [Authorize(Roles = "Employee")]
        public async Task<ActionResult> CreateNewRequest(ServiceRequestCreateParameters service)
        {
            string response = "";
            var token = HttpContext.Session.GetString("Token");
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    client.BaseAddress = new Uri(BaseUrl.ToString());
                    var request = new HttpRequestMessage(HttpMethod.Post, client.BaseAddress + "AddNewService");

                    if (service != null)
                    {
                        request.Content = new StringContent(JsonConvert.SerializeObject(service), System.Text.Encoding.UTF8, "application/json");


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
            return View();
        }


        [Authorize(Roles = "Maintenance Manager , Maintenance Worker , Building Manager")]
        public async Task<ActionResult> ViewClients()
        {
            List<ViewClient> clientInfo = new List<ViewClient>();
            var token = HttpContext.Session.GetString("Token");
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Clear();
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var response = await httpClient.GetAsync(BaseUrl.ToString() + "DisplayClients");
                    if (response.IsSuccessStatusCode)
                    {
                        var clientResponse = response.Content.ReadAsStringAsync().Result;

                        //Deserializing the response recieved from web api and storing into the Employee list
                        clientInfo = JsonConvert.DeserializeObject<List<ViewClient>>(clientResponse);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            ViewBag.BaseMvcUrl = BaseMvcUrl;
            return View(clientInfo);

        }
        [HttpGet]
       [Authorize]
        public async System.Threading.Tasks.Task<JsonResult> GetDashboardStatistics()
        {
            DashboardStatistics dashboard = new DashboardStatistics();
            List<UserDto> List = null;
            var token = HttpContext.Session.GetString("Token");
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Clear();
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    using (var response = await httpClient.GetAsync(BaseUrl.ToString() + "GetDashboard"))
                    {
                        dashboard = await response.Content.ReadAsAsync<DashboardStatistics>();

                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Json(dashboard);

            }

      
        [Authorize(Roles = "Maintenance Worker ,Maintenance Manager , Building Manager ")]
        public async Task<ActionResult> ViewServices()
        {
            string username = HttpContext.Session.GetString("username");
            int Id = Convert.ToInt32(HttpContext.Session.GetString("userID"));
            var token = HttpContext.Session.GetString("Token");

            List<ViewServices> serviceInfo = new List<ViewServices>();
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    client.BaseAddress = new Uri(BaseUrl.ToString());

                    var serviceResponse = await client.GetAsync(BaseUrl.ToString() + $"DisplayServicesWorkers/{Id}");
                    if (serviceResponse.IsSuccessStatusCode)
                    {
                        var response = serviceResponse.Content.ReadAsStringAsync().Result;

                        //Deserializing the response recieved from web api and storing into the Employee list
                        serviceInfo = JsonConvert.DeserializeObject<List<ViewServices>>(response);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }

            ViewBag.BaseMvcUrl = BaseMvcUrl;
            return View(serviceInfo);
        }


        [HttpPost]
        [Authorize(Roles = "Maintenance Worker ")]
        public async System.Threading.Tasks.Task<JsonResult> AddReply(ReplyContent reply)
        {
            var token = HttpContext.Session.GetString("Token");
            ReplyDto repliedMessage = new ReplyDto()
            {
                ID = reply.RequestId,
                
                MessageContent = reply.Content,
                Status = reply.Status,
                UserLogined = HttpContext.User.Identity.Name

            };
            string response;
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    client.BaseAddress = new Uri(BaseUrl);

                    var request = new HttpRequestMessage(HttpMethod.Post, client.BaseAddress + "AddNewReply");
                    if (repliedMessage != null)
                    {
                        request.Content = new StringContent(
                            JsonConvert.SerializeObject(repliedMessage), Encoding.UTF8, "application/json");
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
            return Json("added");


        }
    }
}
