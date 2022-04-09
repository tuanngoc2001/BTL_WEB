using DoAn_ASPNETCORE.Areas.Admin.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn_ASPNETCORE.ViewComponents
{
    [ViewComponent(Name = "Login")]
    public class LoginViewComponent : ViewComponent
    {
        private readonly Webbanhang db;
        public LoginViewComponent(Webbanhang context)
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
