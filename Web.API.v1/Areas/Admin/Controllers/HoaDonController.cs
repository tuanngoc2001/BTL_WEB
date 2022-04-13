using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web_Data;
namespace Web_API_v1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HoaDonController : Controller
    {
        private readonly ImDbContext _context;

        public HoaDonController(ImDbContext context)
        {
            _context = context;
        }

        // GET: Admin/HoaDon
        //public async Task<IActionResult> Index(string SearchString)
        //{
        //    IQueryable<string> genreQuery = from m in _context.HoaDonModel
        //                                    select m.HoTen;

        //    var HoaDon = from m in _context.HoaDonModel
        //                            select m;

        //    if (!string.IsNullOrEmpty(SearchString))
        //    {
        //        HoaDon = HoaDon.Where(s => s.HoTen.Contains(SearchString));
        //    }



        //    var HoaDonViewModel = new HoaDonViewModel
        //    {
        //        HD = new SelectList(await genreQuery.Distinct().ToListAsync()),
        //        HoaDons = await HoaDon.ToListAsync()
        //    };

        //    return View(HoaDonViewModel);

        //}
        public async Task<IActionResult> Index()
        {
            ViewData["User_ID"] = new SelectList(_context.Set<User>(), "ID", "UserName");
            return View();
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hoaDonModel = await _context.im_Invoice
                .Include(h => h.User)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (hoaDonModel == null)
            {
                return NotFound();
            }

            return View(hoaDonModel);
        }

        // GET: Admin/HoaDon/Create
        public IActionResult Create()
        {
            ViewData["User_ID"] = new SelectList(_context.Set<User>(), "ID", "ID");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,User_ID,HoTen,Sdt,ThanhTien,TrangThai")] HoaDon hoaDonModel, [Bind("ID,HoaDon_ID,TenSP,SoLuong,Gia,KhuyenMai,ThanhTien,TrangThai")] ChiTietHoaDon chitiethoaDonModel)
        {
            var HoaDon = from m in _context.im_Invoice
                         select m;
            int size = HoaDon.Count();
            if (ModelState.IsValid)
            {
                _context.Add(hoaDonModel);
                size++;
                await _context.SaveChangesAsync();
                chitiethoaDonModel.HoaDon_ID = size;
                _context.Add(chitiethoaDonModel);
                await _context.SaveChangesAsync();
                HttpContext.Session.Remove("cart");
                var url = Url.RouteUrl(new { area = "", controller = "Pages", action = "Index" });
                return Redirect(url);
            }
            ViewData["User_ID"] = new SelectList(_context.Set<User>(), "ID", "ID", hoaDonModel.User_ID);
            return View(hoaDonModel);
        }

        // GET: Admin/HoaDon/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hoaDonModel = await _context.im_Invoice.FindAsync(id);
            if (hoaDonModel == null)
            {
                return NotFound();
            }
            ViewData["User_ID"] = new SelectList(_context.Set<User>(), "ID", "ID", hoaDonModel.User_ID);
            return View(hoaDonModel);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,User_ID,HoTen,Sdt,ThanhTien,TrangThai")] HoaDon hoaDonModel)
        {
            if (id != hoaDonModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hoaDonModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HoaDonModelExists(hoaDonModel.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["User_ID"] = new SelectList(_context.Set<User>(), "ID", "ID", hoaDonModel.User_ID);
            return View(hoaDonModel);
        }

        // GET: Admin/HoaDon/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hoaDonModel = await _context.im_Invoice
                .Include(h => h.User)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (hoaDonModel == null)
            {
                return NotFound();
            }

            return View(hoaDonModel);
        }

        // POST: Admin/HoaDon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hoaDonModel = await _context.im_Invoice.FindAsync(id);
            _context.im_Invoice.Remove(hoaDonModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HoaDonModelExists(int id)
        {
            return _context.im_Invoice.Any(e => e.ID == id);
        }
    }
}
