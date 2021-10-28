using EMKAN.DataAccess.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using EMKAN.Entity.ModelDto;
using EMKAN.Application;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;

namespace EMKAN.PresentationLayer_Back_Office_.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        string BaseUrl = Startup.GetBaseUrl();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        [HttpGet]
        public async System.Threading.Tasks.Task<JsonResult> GetDashboardStatistics()
        {
            DashboardStatistics dashboard = new DashboardStatistics();
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
           
        }
    
}
