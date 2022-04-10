using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Web_Data;
namespace Web_API_v1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            JObject us = JObject.Parse(HttpContext.Session.GetString("user"));
            User mem = new User();
            mem.UserName = us.SelectToken("UserName").ToString();
            mem.Password = us.SelectToken("Password").ToString();
            mem.Loai = us.SelectToken("Loai").ToString();
            return View(mem);
        }
    }
}
