using DoAn_ASPNETCORE.Areas.Admin.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn_ASPNETCORE.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            JObject us = JObject.Parse(HttpContext.Session.GetString("user"));
            UserModel mem = new UserModel();
            mem.UserName = us.SelectToken("UserName").ToString();
            mem.Password = us.SelectToken("Password").ToString();
            mem.Loai = us.SelectToken("Loai").ToString();
            return View(mem);
        }
    }
}
