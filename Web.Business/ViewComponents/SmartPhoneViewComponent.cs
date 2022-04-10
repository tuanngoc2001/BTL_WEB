using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Data;

namespace Web_Business.ViewComponents
{
    [ViewComponent(Name = "SmartPhone")]
    public class SmartPhoneViewComponent : ViewComponent
    {
        private readonly ImDbContext db;
        public SmartPhoneViewComponent(ImDbContext context)
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
        private Task<List<SanPham>> LaySanPham(int id)
        {
            return db.im_Product.Where(x => x.MaLoai == id).ToListAsync();
        }
    }

}
