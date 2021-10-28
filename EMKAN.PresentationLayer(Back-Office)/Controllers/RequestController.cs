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
    [Authorize(Roles = "Employee")]
    public class RequestController : Controller
    {
        string BaseUrl = Startup.GetBaseUrl();
        string BaseMvcUrl = Startup.GetMvcBaseUrl();//MVC

      


        public async Task<ActionResult> ViewRequests()
        {
            List<ViewServices> serviceInfo = new List<ViewServices>();
            string username = HttpContext.Session.GetString("username");
            int Id = Convert.ToInt32(HttpContext.Session.GetString("userID"));
            var token = HttpContext.Session.GetString("Token");
            //var Id = getId();
            try
            {

                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    client.BaseAddress = new Uri(BaseUrl.ToString());
                    var serviceResponse
                                = await client.GetAsync(BaseUrl.ToString() + $"DisplayServicesForBenenficiary/{Id}");
                    if (serviceResponse.IsSuccessStatusCode)
                    {
                        var response = serviceResponse.Content.ReadAsStringAsync().Result;
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
        public async Task<ActionResult> CreateNewRequest(ServiceRequestCreateParameters service)
        {
            string response = "";
            var token = HttpContext.Session.GetString("Token");
            // string username = HttpContext.Session.GetString("username");

            service.UserLogined = HttpContext.User.Identity.Name;
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
            return RedirectToAction("ViewRequests");
        }
       
        public async Task<ActionResult> Create()
        {
            ServiceRequestCreateParameters serviceModel = new ServiceRequestCreateParameters();
            serviceModel.types = new List<RequestType>();
            serviceModel.branches = new List<RequestBranch>();
            List<RequestType> requestType = new List<RequestType>();
            List<RequestBranch> requestBranch = new List<RequestBranch>();
            var token = HttpContext.Session.GetString("Token");
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Clear();
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var branchResponse = await httpClient.GetAsync(BaseUrl.ToString() + "DisplayBranches");
                    var typeResponse = await httpClient.GetAsync(BaseUrl.ToString() + "DisplayServiceTypes");
                    if (branchResponse.IsSuccessStatusCode)
                    {
                        var clientResponse = branchResponse.Content.ReadAsStringAsync().Result;

                        //Deserializing the response recieved from web api and storing into the Employee list
                        requestBranch = JsonConvert.DeserializeObject<List<RequestBranch>>(clientResponse);
                    }
                    if (typeResponse.IsSuccessStatusCode)
                    {
                        var clientResponse = typeResponse.Content.ReadAsStringAsync().Result;

                        //Deserializing the response recieved from web api and storing into the Employee list
                        requestType = JsonConvert.DeserializeObject<List<RequestType>>(clientResponse);
                    }
                }
                serviceModel.types = requestType;
                serviceModel.branches = requestBranch;
            }
            catch (Exception)
            {
                throw;
            }
            ViewBag.BaseMvcUrl = BaseMvcUrl;
            return View(serviceModel);
        }


        //ajaxr request
        public async Task<ActionResult> RequestDetails(int Id)
        {
            ViewRequestDetailsDto requestView = new ViewRequestDetailsDto();
            var token = HttpContext.Session.GetString("Token");
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    client.BaseAddress = new Uri(BaseUrl.ToString());
                    var serviceResponse = await client.GetAsync(BaseUrl.ToString() + $"DisplayServiceDetails/{Id}");
                    if (serviceResponse.IsSuccessStatusCode)
                    {
                        var response = serviceResponse.Content.ReadAsStringAsync().Result;

                        //Deserializing the response recieved from web api and storing into the Employee list
                        requestView = JsonConvert.DeserializeObject<ViewRequestDetailsDto>(response);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }

            ViewBag.BaseMvcUrl = BaseMvcUrl;
            return Json(requestView);
        }
        //[Authorize]
        //public async Task<int> getId()
        //{
        //    // return _db.Users.Where(d => d.Username.Equals(username)).Select(x => x.ID).FirstOrDefault();
        //    int Id = 0;
        //    var userName = HttpContext.User.Identity.Name;
        //    try
        //    {
        //        using (var client = new HttpClient())
        //        {
        //            EMKANRequest eMKANRequest = new EMKANRequest()
        //            {
        //                UserLogined = userName
        //            };

        //            client.BaseAddress = new Uri(BaseUrl);

        //            var request = new HttpRequestMessage(HttpMethod.Post, client.BaseAddress + "GetId");
        //            if (eMKANRequest != null)
        //            {
        //                request.Content = new StringContent(
        //                    JsonConvert.SerializeObject(eMKANRequest), Encoding.UTF8, "application/json");
        //            }



        //            HttpResponseMessage response = await client.SendAsync(request);
        //            if (response.IsSuccessStatusCode)
        //            {
        //                Id = await response.Content.ReadAsAsync<int>();

        //            }

        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }


        //    return Id;


        //}
    }
}

