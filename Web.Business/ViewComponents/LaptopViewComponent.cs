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
    [ViewComponent(Name = "Laptop")]
    public class LaptopViewComponent : ViewComponent
    {
        private readonly Webbanhang db;
        public LaptopViewComponent(Webbanhang context)
        {
            db = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(
        int id)
        {
            string MyView = "Laptop";

            var items = await LaySanPham(id);

            return View(MyView, items);
        }
        private Task<List<SanPhamModel>> LaySanPham(int id)
        {
            return db.SanPhamModel.Where(x => x.MaLoai == id).ToListAsync();
        }
    }
}
