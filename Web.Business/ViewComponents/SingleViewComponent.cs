using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Data;

namespace Web_Business.ViewComponents
{
    [ViewComponent(Name = "Single")]
    public class SingleViewComponent : ViewComponent
    {
        private readonly ImDbContext db;
        public SingleViewComponent(ImDbContext context)
        {
            db = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(
       int id)
        {
            string MyView = "Single";

            var items = await LayRecent(id);

            return View(MyView, items);

        }
        //   public async Task<IViewComponentResult> InvokeAsync(
        //string id)
        //   {
        //       string MyView1 = "Best";
        //       var items1 = await LayBestSeller(id);
        //       return View(MyView1, items1);
        //}
        private Task<List<SanPham>> LayRecent(int id)
        {
            return db.im_Product.Where(x => x.MaLoai == id).ToListAsync();
        }
        //private Task<List<SanPhamModel>> LayBestSeller(string id)
        //{
        //    return db.SanPhamModel.Where(x => x.DanhMuc == id).ToListAsync();
        //}
    }
}
