using DoAn_ASPNETCORE.Areas.Admin.Data;
using DoAn_ASPNETCORE.Areas.Admin.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn_ASPNETCORE.Controllers
{
    public class LoginController : Controller
    {
        private readonly Webbanhang _context;

        public LoginController(Webbanhang context)
        {
            _context = context;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Login([Bind("UserName,Password")] UserModel member)

        {
            var r = _context.UserModel.Where(m => (m.UserName == member.UserName && m.Password == StringProcessing.CreateMD5Hash(member.Password))).ToList();
            var info = _context.UserModel.Where(m => m.UserName == member.UserName).ToList();
            if (r.Count == 0)
            {

                return View("Index");
            }
            //var str = JsonConvert.SerializeObject(member);
            HttpContext.Session.SetString("username", member.UserName);
            HttpContext.Session.SetInt32("id", info[0].ID);
            if (r[0].Loai == "0")
            {
                var url = Url.RouteUrl("areas", new { Controller = "SanPham", action = "Index", area = "Admin" });
                return Redirect(url);
            }
            return RedirectToAction("Index", "Pages");
        }
        public IActionResult Index()
        {
            ViewBag.Username = HttpContext.Session.GetString("username");
            return View();
        }
        [HttpPost]
        public JsonResult LoginFB(string name)
        {
            HttpContext.Session.SetString("username", name);
            return Json(new { success = "True" });
        }
        [HttpPost]
        public JsonResult LogOut()
        {
            HttpContext.Session.Clear();
            return Json(new { success = "True" });
        }

    }
}
