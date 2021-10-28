using EMKAN.Entity.Model;
using EMKAN.Entity.ModelDto;
using EMKAN.PresentationLayer_Back_Office_.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace EMKAN.PresentationLayer_Back_Office_.Controllers
{
    public class EmployeeController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
        private readonly ILogger<EmployeeController> _logger;
        string BaseUrl = Startup.GetBaseUrl();

        public EmployeeController(ILogger<EmployeeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        [Authorize(Roles = " Admin ")]
        public async Task<ActionResult> ViewEmployee()
        {
            var token = HttpContext.Session.GetString("Token");
            
            List<DisplayEmployee> EmpInfo = new List<DisplayEmployee>();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Clear();
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                   
                    var response = await httpClient.GetAsync(BaseUrl.ToString() + "DisplayEmployee");
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
            return View(EmpInfo);

        }

        [Authorize(Roles = " Admin ")]
        public async Task<ActionResult> AddAsync()
        {
            List<RoleDto> roles = null;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(BaseUrl);
            var token = HttpContext.Session.GetString("Token");
            try
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage Res = await client.GetAsync("ListOfRole");
                if (Res.IsSuccessStatusCode)
                {
                    var RoleResponse = Res.Content.ReadAsStringAsync().Result;
                    roles = JsonConvert.DeserializeObject<List<RoleDto>>(RoleResponse);


                }
            }
            catch (Exception)
            {
                throw;
            }
            ViewBag.Role = roles;

            
            return View();
        }
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(int id)
        {
            
            var userName = HttpContext.User.Identity.Name;
            var token = HttpContext.Session.GetString("Token");
            try {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    EMKANRequest eMKANRequest = new EMKANRequest()
                    {
                        ID = id,
                        UserLogined = userName
                    };

                    client.BaseAddress = new Uri(BaseUrl);

                    var request = new HttpRequestMessage(HttpMethod.Delete, client.BaseAddress + "RemoveUser");
                    if (eMKANRequest != null)
                    {
                        request.Content = new StringContent(
                            JsonConvert.SerializeObject(eMKANRequest), Encoding.UTF8, "application/json");
                    }



                    HttpResponseMessage response = await client.SendAsync(request);
                    if (response.IsSuccessStatusCode)
                    {
                        return Json("Success");
                    }
                    return Json("Error");
                }
                }    catch (Exception)
            {
                return Json("Error");
                
            }
            
           // return RedirectToAction("ViewEmployee");

            }


        [HttpPost]
        [Authorize(Roles = " Admin ")]
        public async Task<ActionResult> AddAsyncWithCheck(AddEmployee addEmployee)
        {
            string response;
            var token = HttpContext.Session.GetString("Token");
            try
            {
                if (ModelState.IsValid)
                {


                    using (var client = new HttpClient())
                    {
                        UserDto user = new UserDto()
                        {
                            FirstName = addEmployee.FirstName,
                            LastName = addEmployee.LastName,
                            Username = addEmployee.Email,
                            Phone = addEmployee.Phone,
                            Password = addEmployee.Password,
                            RoleID = addEmployee.RoleType,
                            Status = 1,
                            UserLogined = HttpContext.User.Identity.Name
                        };

                        client.BaseAddress = new Uri(BaseUrl);
                        client.DefaultRequestHeaders.Clear();
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                        var request = new HttpRequestMessage(HttpMethod.Post, client.BaseAddress + "AddEmployeeWithCheck");
                        if (user != null)
                        {
                            request.Content = new StringContent(
                                JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                        }

                        HttpResponseMessage responseMessage = await client.SendAsync(request);
                        //HttpResponseMessage Res = await client.PostAsync("ServiceController/AddEmployeeR", a);
                        if (responseMessage.IsSuccessStatusCode)
                        {
                            response = await responseMessage.Content.ReadAsStringAsync();
                            if (response == "0")
                            {
                                ModelState.AddModelError("", "This email already used");
                                return RedirectToAction("Add", "Employee");
                            }
                            else
                            {
                                return RedirectToAction("ViewEmployee", "Employee");
                            }
                        }
                    }
                }
                return View("add", "Employee");

            }
            catch (Exception)
            {
                throw;
            }


        }
        [Authorize(Roles = " Admin ")]
        public async Task<ActionResult> EditAsync(int id)
        {

            List<RoleDto> roles = null;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(BaseUrl);
            var token = HttpContext.Session.GetString("Token");
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            try
            {
                HttpResponseMessage Res = await client.GetAsync("ListOfRole");
                if (Res.IsSuccessStatusCode)
                {
                    var RoleResponse = Res.Content.ReadAsStringAsync().Result;
                    roles = JsonConvert.DeserializeObject<List<RoleDto>>(RoleResponse);


                }
            }
            catch (Exception)
            {
                throw;
            }
            ViewBag.Role = roles;
            return View();

        }
        [HttpPost]
        [Authorize(Roles = " Admin ")]
        public async Task<ActionResult> EditAsync(EditEmployeeRole editEmployeeRole)
        {
            var token = HttpContext.Session.GetString("Token");
            try
            {
                using (var client = new HttpClient())
                {
                    UserDto user = new UserDto()
                    {
                        ID = editEmployeeRole.ID,
                        RoleID = editEmployeeRole.RoleType,
                        UserLogined = HttpContext.User.Identity.Name
                    };
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    client.BaseAddress = new Uri(BaseUrl);

                    var request = new HttpRequestMessage(HttpMethod.Post, client.BaseAddress + "UpdateUserRole");
                    if (user != null)
                    {
                        request.Content = new StringContent(
                            JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                    }
                    HttpResponseMessage response = await client.SendAsync(request);
                    if (response.IsSuccessStatusCode)
                    {

                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return RedirectToAction("ViewEmployee", "Employee");

        }

        [Authorize(Roles = " Admin ")]
        public async Task<ActionResult> AddBuilding()
        {
            List<BranchDto> branches = null;
            List<UserDto> buildingManager = null;
            HttpClient client = new HttpClient();
            var token = HttpContext.Session.GetString("Token");
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            client.BaseAddress = new Uri(BaseUrl);
            try
            {
                //  client.DefaultRequestHeaders.Clear();
                HttpResponseMessage Res = await client.GetAsync("ListOfBranches");
                HttpResponseMessage Res2 = await client.GetAsync("ListOfBuildingManager");
                if (Res.IsSuccessStatusCode)
                {
                    var BranchResponse = Res.Content.ReadAsStringAsync().Result;
                    branches = JsonConvert.DeserializeObject<List<BranchDto>>(BranchResponse);


                }
                if (Res2.IsSuccessStatusCode)
                {
                    var BuildingManagerResponse = Res2.Content.ReadAsStringAsync().Result;
                    buildingManager = JsonConvert.DeserializeObject<List<UserDto>>(BuildingManagerResponse);


                }
            }
            catch (Exception)
            {
                throw;
            }
            ViewBag.Branch = branches;
            ViewBag.Manager = buildingManager;
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> CheckUser(string username)
        {
            bool isUserFound = true;
            string response;
            var token = HttpContext.Session.GetString("Token");
            try
            {



                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    UserDto user = new UserDto()
                    {

                        Username = username,

                    };

                    client.BaseAddress = new Uri(BaseUrl);

                    var request = new HttpRequestMessage(HttpMethod.Post, client.BaseAddress + "CheckUser");
                    if (user != null)
                    {
                        request.Content = new StringContent(
                            JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                    }

                    HttpResponseMessage responseMessage = await client.SendAsync(request);
                    //HttpResponseMessage Res = await client.PostAsync("ServiceController/AddEmployeeR", a);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        response = await responseMessage.Content.ReadAsStringAsync();
                        if (response == "0")
                        {

                            isUserFound = false;
                        }

                    }
                }
            }



            catch (Exception)
            {
                throw;
            }
            return Json(isUserFound);

        }

        [HttpPost]
        [Authorize(Roles = " Admin ")]
        public async Task<IActionResult> AddBuilding(AddBuilding addBuliding)
        {
            var token = HttpContext.Session.GetString("Token");
            try
            {
                using (var client = new HttpClient())
                {
                    BulidingDto build = new BulidingDto()
                    {
                        Name = addBuliding.Name,
                        BranchID = addBuliding.Branch,
                        NumberOfFloor = addBuliding.NumberOfFloor,
                        NumberOfRoom = addBuliding.NumberOfRoom,
                        UserID = addBuliding.BuildingManager,
                        UserLogined = HttpContext.User.Identity.Name
                    };

                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    client.BaseAddress = new Uri(BaseUrl);

                    var request = new HttpRequestMessage(HttpMethod.Post, client.BaseAddress + "AddBuilding");
                    if (build != null)
                    {
                        request.Content = new StringContent(
                            JsonConvert.SerializeObject(build), Encoding.UTF8, "application/json");
                    }



                    HttpResponseMessage response = await client.SendAsync(request);
                    if (response.IsSuccessStatusCode)
                    {

                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return RedirectToAction("ViewAllBuilding", "Employee");
        }

        [Authorize(Roles = " Admin ")]
        public async Task<ActionResult> EditBuilding(int id)
        {
            BulidingDto building = new BulidingDto();
            List<BranchDto> branches = null;
            List<UserDto> buildingManager = null;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(BaseUrl);
            var token = HttpContext.Session.GetString("Token");
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            try
            {
                //  client.DefaultRequestHeaders.Clear();
                HttpResponseMessage Res = await client.GetAsync("ListOfBranches");
                HttpResponseMessage Res2 = await client.GetAsync("ListOfBuildingManager");
                HttpResponseMessage Res3 = await client.GetAsync($"FindBuildingByID/{id}");
                if (Res.IsSuccessStatusCode)
                {
                    var BranchResponse = Res.Content.ReadAsStringAsync().Result;
                    branches = JsonConvert.DeserializeObject<List<BranchDto>>(BranchResponse);
                }
                if (Res2.IsSuccessStatusCode)
                {
                    var BuildingManagerResponse = Res2.Content.ReadAsStringAsync().Result;
                    buildingManager = JsonConvert.DeserializeObject<List<UserDto>>(BuildingManagerResponse);
                }
                if (Res3.IsSuccessStatusCode)
                {
                    var Building = Res3.Content.ReadAsStringAsync().Result;
                    building = JsonConvert.DeserializeObject<BulidingDto>(Building);
                }

                ViewBag.Branch = branches;
                ViewBag.BranchVal = building.BranchID;
                ViewBag.Manager = buildingManager;
                ViewBag.ManagerVal = building.UserID;
                ViewBag.BuildingFloorNumber = building.NumberOfFloor;
                ViewBag.BuildingRoomNumber = building.NumberOfRoom;
                ViewBag.BuildingName = building.Name;
            }
            catch (Exception)
            {
                throw;
            }
            return View();
        }
        [HttpPost]
        [Authorize(Roles = " Admin ")]
        public async Task<ActionResult> EditBuilding(EditBuilding editBuilding)
        {
            var token = HttpContext.Session.GetString("Token");
            try
            {
                using (var client = new HttpClient())
                {
                    BulidingDto build = new BulidingDto()
                    {
                        ID = editBuilding.ID,
                        Name = editBuilding.Name,
                        BranchID = editBuilding.Branch,
                        NumberOfFloor = editBuilding.NumberOfFloor,
                        NumberOfRoom = editBuilding.NumberOfRoom,
                        UserID = editBuilding.BulidingManager,
                        //audit
                        UserLogined = HttpContext.User.Identity.Name
                    };
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    client.BaseAddress = new Uri(BaseUrl);

                    var request = new HttpRequestMessage(HttpMethod.Post, client.BaseAddress + "UpdateBuilding");
                    if (build != null)
                    {
                        request.Content = new StringContent(
                            JsonConvert.SerializeObject(build), Encoding.UTF8, "application/json");
                    }
                    HttpResponseMessage response = await client.SendAsync(request);
                    if (response.IsSuccessStatusCode)
                    {

                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return RedirectToAction("ViewAllBuilding", "Employee");
        }

        [Authorize(Roles = " Admin ")]
        public async Task<ActionResult> ViewAllBuilding()
        {
            List<DisplayBuilding> BulidingInfo = new List<DisplayBuilding>();
            var token = HttpContext.Session.GetString("Token");
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Clear();
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var response = await httpClient.GetAsync(BaseUrl.ToString() + "ViewBuilding");
                    if (response.IsSuccessStatusCode)
                    {
                        var BulidingResponse = response.Content.ReadAsStringAsync().Result;

                        //Deserializing the response recieved from web api and storing into the Employee list
                        BulidingInfo = JsonConvert.DeserializeObject<List<DisplayBuilding>>(BulidingResponse);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return View(BulidingInfo);
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteBuilding(int id)
        {
            var userName = HttpContext.User.Identity.Name;
            var token = HttpContext.Session.GetString("Token");
            try
            {
                using (var client = new HttpClient())
                {
                    EMKANRequest eMKANRequest = new EMKANRequest()
                    {
                        ID = id,
                        UserLogined = userName
                    };

                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    client.BaseAddress = new Uri(BaseUrl);

                    var request = new HttpRequestMessage(HttpMethod.Delete, client.BaseAddress + "DeletBuilding");
                    if (eMKANRequest != null)
                    {
                        request.Content = new StringContent(
                            JsonConvert.SerializeObject(eMKANRequest), Encoding.UTF8, "application/json");
                    }



                    HttpResponseMessage response = await client.SendAsync(request);
                    if (response.IsSuccessStatusCode)
                    {
                        return Json("Success");
                    }
                    return Json("Error");
                }
            }
            catch (Exception)
            {
                return Json("Error");
               
            }

          
        }
        [Authorize(Roles = " Admin ")]
        public async Task<IActionResult> ViewAduitTrail()
        {
            List<DisplayAuditTrail> auditInfo = new List<DisplayAuditTrail>();
            var token = HttpContext.Session.GetString("Token");
            try
            {
                using (var httpClient = new HttpClient())
                {

                    httpClient.DefaultRequestHeaders.Clear();
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var response = await httpClient.GetAsync(BaseUrl.ToString() + "DisplayTheAduitTrails");
                    if (response.IsSuccessStatusCode)
                    {
                        var aduitResponse = response.Content.ReadAsStringAsync().Result;
                        auditInfo = JsonConvert.DeserializeObject<List<DisplayAuditTrail>>(aduitResponse);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return View(auditInfo);

        }
        [HttpPost]
        [Authorize(Roles = "Maintenance Manager")]
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
