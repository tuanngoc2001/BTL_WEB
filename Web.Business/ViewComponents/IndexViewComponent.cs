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
    [ViewComponent(Name = "Index")]
    public class IndexViewComponent : ViewComponent
    {
        private readonly Webbanhang db;
        public IndexViewComponent(Webbanhang context)
        {
            db = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(
        string id)
        {
            string MyView = "Default";
            switch (id)
            {
                case "DM1":
                    MyView = "NewProduct"; break;
                case "DM2":
                    MyView = "LastesProduct"; break;
                default:
                    MyView = "BestSeller"; break;
            }

            var items = await LaySanPham(id);
            return View(MyView, items);
        }
        private Task<List<SanPhamModel>> LaySanPham(string id)
        {
            return db.SanPhamModel.Where(x => x.DanhMuc == id).Take(4).ToListAsync();
        }
    }
}
