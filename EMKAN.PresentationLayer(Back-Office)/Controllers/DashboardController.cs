using EMKAN.Application;
using EMKAN.DataAccess.DbContexts;
using EMKAN.Entity.Model;
using EMKAN.Entity.ModelDto;
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
    public class DashboardController : Controller
    {
        private readonly EMKANDbContext _db;
      
        string BaseUrl = Startup.GetBaseUrl();//API
        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = " Employee ")]
        public async System.Threading.Tasks.Task<JsonResult> GetDashboardStatisticsForBeneficiary()
        {
            string username = HttpContext.Session.GetString("username");
            var Id = Convert.ToInt32(HttpContext.Session.GetString("userID"));
            DashboardStatistics dashboard = new DashboardStatistics();
            var token = HttpContext.Session.GetString("Token");
            List<UserDto> List = null;
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Clear();
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    using (var response = await httpClient.GetAsync(BaseUrl.ToString() + $"GetDashboard/{Id}"))
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
