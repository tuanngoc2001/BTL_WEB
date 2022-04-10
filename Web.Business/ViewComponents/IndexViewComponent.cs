using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Business.ViewComponents
{
    [ViewComponent(Name = "Index")]
    public class IndexViewComponent : ViewComponent
    {
        private readonly ImDbContext db;
        public IndexViewComponent(ImDbContext context)
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
        private Task<List<SanPham>> LaySanPham(string id)
        {
            return db.im_Product.Where(x => x.DanhMuc == id).Take(4).ToListAsync();
        }
    }
}
