using DoAn_ASPNETCORE.Areas.Admin.Data;
using DoAn_ASPNETCORE.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DoAn_ASPNETCORE.ViewComponents
{
    [ViewComponent(Name = "SmartPhone")]
    public class SmartPhoneViewComponent : ViewComponent
    {
        private readonly Webbanhang db;
        public SmartPhoneViewComponent(Webbanhang context)
        {
            db = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(
        int id)
        {
            string MyView = "Smartphone";

            var items = await LaySanPham(id);

            return View(MyView, items);
        }
        private Task<List<SanPhamModel>> LaySanPham(int id)
        {
            return db.SanPhamModel.Where(x => x.MaLoai == id).ToListAsync();
        }
    }

}
