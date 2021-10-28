using EMKAN.Application;
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
   
    public class BuildingManagerController : Controller
    {
        string BaseUrl = Startup.GetBaseUrl();//API
        string BaseMvcUrl = Startup.GetMvcBaseUrl();//MVC
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Maintenance Manager,Maintenance Worker,Building Manager,Employee")]
        public async Task<ActionResult> ViewAllServices()
        {
            ServiceModel serviceModel = new ServiceModel();
            serviceModel.ServiceList = new List<ViewServices>();
            serviceModel.WorkerList = new List<WorkerInfo>();
            List<ViewServices> serviceInfo = new List<ViewServices>();
            List<WorkerInfo> workerInfo = new List<WorkerInfo>();
            var token = HttpContext.Session.GetString("Token");
            try
            {
               
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Clear();
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var serviceResponse = await httpClient.GetAsync(BaseUrl.ToString() + "DisplayServicesForAll");
                    var workerResponse = await httpClient.GetAsync(BaseUrl.ToString() + "DisplayWorkers");
                    if (serviceResponse.IsSuccessStatusCode)
                    {
                        var clientResponse = serviceResponse.Content.ReadAsStringAsync().Result;

                        //Deserializing the response recieved from web api and storing into the Employee list
                        serviceInfo = JsonConvert.DeserializeObject<List<ViewServices>>(clientResponse);
                    }
                    if (workerResponse.IsSuccessStatusCode)
                    {
                        var clientResponse = workerResponse.Content.ReadAsStringAsync().Result;

                        //Deserializing the response recieved from web api and storing into the Employee list
                        workerInfo = JsonConvert.DeserializeObject<List<WorkerInfo>>(clientResponse);
                    }
                }
                serviceModel.ServiceList = serviceInfo;
                serviceModel.WorkerList = workerInfo;
                ViewBag.BaseMvcUrl = BaseMvcUrl;
            }
            catch (Exception)
            {
                throw;
            }
            return View(serviceInfo);

        }

        [HttpGet]
        [Authorize]
        public async System.Threading.Tasks.Task<JsonResult> GetDashboardStatistics()
        {
            DashboardStatistics dashboard = new DashboardStatistics();
            var token = HttpContext.Session.GetString("Token");

            List<UserDto> List = null;
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



        

        [HttpPost]
        [Authorize(Roles = "Building Manager")]
        public async System.Threading.Tasks.Task<JsonResult> UpdateStatus(UpdateStatus userStatus)
        {
            string response = "";
            var token = HttpContext.Session.GetString("Token");
            ServiceDto service = new ServiceDto()
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
                    var request = new HttpRequestMessage(HttpMethod.Put, client.BaseAddress + "UpdateServiceStatus");

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
            return Json("Updated Succesfully");
        }
        [Authorize]
        public async Task<ActionResult> ViewServices()
        {

            ServiceModel serviceModel = new ServiceModel();
            serviceModel.ServiceList = new List<ViewServices>();
            var token = HttpContext.Session.GetString("Token");

            List<ViewServices> serviceInfo = new List<ViewServices>();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Clear();
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var serviceResponse = await httpClient.GetAsync(BaseUrl.ToString() + "DisplayAllNewServicesForBM");

                    if (serviceResponse.IsSuccessStatusCode)
                    {
                        var clientResponse = serviceResponse.Content.ReadAsStringAsync().Result;

                        //Deserializing the response recieved from web api and storing into the Employee list
                        serviceInfo = JsonConvert.DeserializeObject<List<ViewServices>>(clientResponse);
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

    }
}
