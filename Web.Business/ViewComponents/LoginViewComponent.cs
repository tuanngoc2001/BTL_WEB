using Web_Data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Web_Business.ViewComponents
{
    [ViewComponent(Name = "Login")]
    public class LoginViewComponent : ViewComponent
    {
        private readonly ImDbContext db;
        public LoginViewComponent(ImDbContext context)
        {
            db = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(
        int id)
        {
            string MyView = "Login";
            return View(MyView);
        }

    }
}
