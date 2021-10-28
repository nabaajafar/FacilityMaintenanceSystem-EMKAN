using EMKAN.Application;
using EMKAN.Entity.ModelDto;
using EMKAN.PresentationLayer_Back_Office_.Interfaces;
using EMKAN.PresentationLayer_Back_Office_.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
    public class AccountController : Controller
    {
        private readonly IConfiguration _configration;
        private readonly ITokenService _tokenService;

        private string generatedToken = null;
        string BaseMvcUrl = Startup.GetMvcBaseUrl();//MVC
        string BaseUrl = Startup.GetBaseUrl();//API

        public AccountController(IConfiguration config, ITokenService tokenService)
        {
            _configration = config;
            _tokenService = tokenService;

        }
        public IActionResult LoginView()
        {
            return View();
        }


        [AllowAnonymous]
       [Route("login")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Login(UserModel userModel)
        {

            if (ModelState.IsValid)
            {
                Result result = new Result();
                var user = new UserDto
                {
                    Username = userModel.UserName,
                    Password = userModel.Password

                };
                var validUser = new UserInfo();

                IActionResult response1 = Unauthorized();
                using (var client = new HttpClient())
                {


                    client.BaseAddress = new Uri(BaseUrl);

                    var request = new HttpRequestMessage(HttpMethod.Post, client.BaseAddress + "GetCurrentUserRole");
                    if (user != null)
                    {
                        request.Content = new StringContent(
                            JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                    }

                    HttpResponseMessage responseMessage = await client.SendAsync(request);

                    if (responseMessage.IsSuccessStatusCode)
                    {
                        result = await responseMessage.Content.ReadAsAsync<Result>();
                        if (result.Status == "unactive")
                        {
                            ModelState.AddModelError("", "You are not allowed to use your account contact your admin");
                            return View("LoginView");
                        }
                        if (result.Status != "new" && result.Role != null)
                        {

                            var username = user.Username;
                            validUser = new UserInfo()
                            {
                                Role = result.Role,
                                UserName = userModel.UserName,
                                Password = userModel.Password
                            };

                            generatedToken = _tokenService.BuildToken(_configration["Jwt:Key"].ToString(), _configration["Jwt:Issuer"].ToString(),
                            validUser);

                            if (generatedToken != null)
                            {
                                HttpContext.Session.SetString("userID", result.UserID.ToString());
                                HttpContext.Session.SetString("Token", generatedToken);
                                HttpContext.Session.SetString("username", username);
                                HttpContext.Session.SetString("role", validUser.Role);
                                return RedirectToAction("dashboard");
                            }
                        }
                        if (result.Status == "new" && result.Role !=null)
                        {
                            var username = user.Username;
                            validUser = new UserInfo()
                            {
                                Role = result.Role,
                                UserName = userModel.UserName,
                                Password = userModel.Password
                            };

                            generatedToken = _tokenService.BuildToken(_configration["Jwt:Key"].ToString(), _configration["Jwt:Issuer"].ToString(),
                            validUser);

                            if (generatedToken != null)
                            {

                                HttpContext.Session.SetString("Token", generatedToken);
                                HttpContext.Session.SetString("userID", result.UserID.ToString());
                                HttpContext.Session.SetString("username", username);
                                HttpContext.Session.SetString("role", validUser.Role);
                                return RedirectToAction("changepasswordview");
                            }
                        }
                        if (result.Role == null)
                        {
                            ModelState.AddModelError("", "Your Email or password not correct");
                            return View("LoginView");
                        }


                        else
                        {


                            ModelState.AddModelError("", "You Email or password not correct");
                            return View("LoginView");
                        }
                    }
                }



            }

            return View("LoginView");
        }

        [Authorize]
        [Route("changepasswordview")]
        [HttpGet]
        public IActionResult ChangepasswordView()
        {
            string token = HttpContext.Session.GetString("Token");
            string username = HttpContext.Session.GetString("username");

            string role = HttpContext.Session.GetString("role");

            if (token == null)
            {
                return (RedirectToAction("LoginView"));
            }

            if (!_tokenService.IsTokenValid(_configration["Jwt:Key"].ToString(),
                _configration["Jwt:Issuer"].ToString(), token))
            {
                return (RedirectToAction("LoginView"));
            }
            ViewBag.BaseMvcUrl = BaseMvcUrl;
            return View();

        }
        [Authorize(Roles = "Admin,Maintenance Manager,Employee,Maintenance Worker,Building Manager ")]
        [Route("dashboard")]
        [HttpGet]
        public async Task<IActionResult> dashboard()
        {
            DashboardStatistics dashboard = new DashboardStatistics();
            string token = HttpContext.Session.GetString("Token");
            string username = HttpContext.Session.GetString("username");
            var Id = Convert.ToInt32(HttpContext.Session.GetString("userID"));
            if (token == null)
            {
                return (RedirectToAction("LoginView"));
            }

            if (!_tokenService.IsTokenValid(_configration["Jwt:Key"].ToString(),
                _configration["Jwt:Issuer"].ToString(), token))
            {
                return (RedirectToAction("LoginView"));
            }
            ViewBag.BaseMvcUrl = BaseMvcUrl;
           
            

            return View();

        }


        [Authorize]
     [Route("changeUserpassword")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> changeUserpassword(ChangePassword newpasswordInfo)
        {
            var token = HttpContext.Session.GetString("Token");

            if (ModelState.IsValid)
            {
                string username = HttpContext.Session.GetString("username");
                var PasswordInfo = new ChangePasswordDto
                {
                    Username = username,
                    Password = newpasswordInfo.Password,
                    Passwordconfirmation = newpasswordInfo.Passwordconfirmation
                };

                var result = "";
                using (var client = new HttpClient())
                {


                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    client.BaseAddress = new Uri(BaseUrl);

                    var request = new HttpRequestMessage(HttpMethod.Post, client.BaseAddress + "ChangePasswordNumber");
                    if (PasswordInfo != null)
                    {
                        request.Content = new StringContent(
                            JsonConvert.SerializeObject(PasswordInfo), Encoding.UTF8, "application/json");
                    }

                    HttpResponseMessage responseMessage = await client.SendAsync(request);

                    if (responseMessage.IsSuccessStatusCode)
                    {
                        result = await responseMessage.Content.ReadAsStringAsync();
                        if (result == "1")
                        {

                            return RedirectToAction("dashboard");
                        }

                        else
                        {


                            ModelState.AddModelError("", "Error occure while Change Password ");
                            return View("ChangePasswordView");
                        }
                    }
                }

            }
            return View("ChangePasswordView");
        }

        public IActionResult Error()
        {

            return View();
        }

        [Authorize]
      //  [Route("Logout")]
        [HttpGet]
        public IActionResult Logout()
        {

            HttpContext.Session.Clear();
            return View("LoginView");
        }
    }

}
    

