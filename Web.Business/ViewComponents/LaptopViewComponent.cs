using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Business.ViewComponents
{
    [ViewComponent(Name = "Laptop")]
    public class LaptopViewComponent : ViewComponent
    {
        private readonly ImDbContext db;
        public LaptopViewComponent(ImDbContext context)
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
        private Task<List<SanPham>> LaySanPham(int id)
        {
            return db.im_Product.Where(x => x.MaLoai == id).ToListAsync();
        }
    }
}
