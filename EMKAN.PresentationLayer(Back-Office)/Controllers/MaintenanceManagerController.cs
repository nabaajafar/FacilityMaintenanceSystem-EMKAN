using EMKAN.Application;
using EMKAN.Entity.ModelDto;
using EMKAN.PresentationLayer_Back_Office_.Models;
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
    public class MaintenanceManagerController : Controller
    {
        string BaseUrl = Startup.GetBaseUrl();//API
        string BaseMvcUrl = Startup.GetMvcBaseUrl();//MVC
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Dashboard()
        {
            return View();
        }
       
           public async Task<ActionResult> ViewServices()
      {

          ServiceModel serviceModel = new ServiceModel();
          serviceModel.ServiceList = new List<ViewServices>();
          serviceModel.WorkerList = new List<WorkerInfo>();
          List < ViewServices> serviceInfo = new List<ViewServices>();
          List<WorkerInfo> workerInfo = new List<WorkerInfo>();
            var token = HttpContext.Session.GetString("Token");
            try
            {
                using (var httpClient = new HttpClient())
                {

                    httpClient.DefaultRequestHeaders.Clear();
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var serviceResponse = await httpClient.GetAsync(BaseUrl.ToString() + "DisplayAllNewServicesForMM");
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
          return View(serviceModel);

      }

        public async Task<ActionResult> ViewAllServices()
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
                    var serviceResponse = await httpClient.GetAsync(BaseUrl.ToString() + "DisplayServices");

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
            

        
        public async Task<ActionResult> ViewEmployees()
        {
            List<DisplayEmployee> EmpInfo = new List<DisplayEmployee>();
            var token = HttpContext.Session.GetString("Token");
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Clear();
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var response = await httpClient.GetAsync(BaseUrl.ToString() + "DisplayStatusEmployee");
                    if (response.IsSuccessStatusCode)
                    {
                        var EmpResponse = response.Content.ReadAsStringAsync().Result;

                        //Deserializing the response recieved from web api and storing into the Employee list
                        EmpInfo = JsonConvert.DeserializeObject<List<DisplayEmployee>>(EmpResponse);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            ViewBag.BaseMvcUrl = BaseMvcUrl;
            return View(EmpInfo);

        }
        [HttpPost]
        public async System.Threading.Tasks.Task<JsonResult> AssignWorker(AssignModel service)
        {
            string response = "";
            var token = HttpContext.Session.GetString("Token");
            ServiceDto assignedWorker = new ServiceDto()
            {
                ID = service.ID,
                ResponsibleMaintenanceWorker = service.ResponsibleMaintenanceWorker,
                UserLogined = HttpContext.User.Identity.Name
            };
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    client.BaseAddress = new Uri(BaseUrl.ToString());
                    var request = new HttpRequestMessage(HttpMethod.Put, client.BaseAddress + "AssignWorker");

                    if (assignedWorker != null)
                    {
                        request.Content = new StringContent(JsonConvert.SerializeObject(assignedWorker), System.Text.Encoding.UTF8, "application/json");


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
            return Json("Assigned Succesfully");
            }
        }



    
}

