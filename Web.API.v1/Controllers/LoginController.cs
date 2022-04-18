using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Web_Data;
using Web_API_v1.Areas.Admin;
using Microsoft.AspNetCore.Identity;

namespace Web_API_v1.Controllers
{
    public class LoginController : Controller
    {
        private readonly ImDbContext _context;

        public LoginController(ImDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Login( User member)

        {
            if(member.UserName == null || member.Password == null)
                return View("Index");
            var r = _context.im_User.Where(m => (m.UserName == member.UserName && m.Password == StringProcessing.CreateMD5Hash(member.Password))).ToList();
            var info = _context.im_User.Where(m => m.UserName == member.UserName).ToList();
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
        public JsonResult LogOut()
        {
            HttpContext.Session.Clear();
            return Json(new { success = "True" });
        }
        public void SignIn(string ReturnUrl= "/",string type = "")
        {
            
        }
    }
}
