using System;
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
    public class ChiTietHoaDonController : Controller
    {
        private readonly ImDbContext _context;

        public ChiTietHoaDonController(ImDbContext context)
        {
            _context = context;
        }

        // GET: Admin/ChiTietHoaDon
        public async Task<IActionResult> Index() //(int searchInt)
        {
            /*
            IQueryable<int> genreQuery = from m in _context.ChiTietHoaDonModel

                                            select m.HoaDon_ID;

            var ChiTietHoaDon = from m in _context.ChiTietHoaDonModel
                       select m;

            if (searchInt.Equals(null))
            {
                ChiTietHoaDon = ChiTietHoaDon.Where(s => s.HoaDon_ID.Equals(searchInt));
            }


            var ChiTietHoaDon1 = new ChiTietHoaDonViewModel
            {
                DSCTHD = new SelectList(await genreQuery.Distinct().ToListAsync()),
                ChiTietHoaDons = await ChiTietHoaDon.ToListAsync()
            };
            */
            ViewBag.CTHD = from m in _context.im_Invoice_Detail
                           select m;
            ViewData["SanPham"] = new SelectList(_context.Set<SanPham>(), "TenSP", "TenSP");
            ViewData["SanPham1"] = new SelectList(_context.Set<SanPham>(), "Gia", "Gia");
            ViewData["HoaDon"] = new SelectList(_context.Set<HoaDon>(), "ID", "ID");
            return View();           
        }

        // GET: Admin/ChiTietHoaDon/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chiTietHoaDonModel = await _context.im_Invoice_Detail
                .Include(c => c.HoaDon)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (chiTietHoaDonModel == null)
            {
                return NotFound();
            }

            return View(chiTietHoaDonModel);
        }

        // GET: Admin/ChiTietHoaDon/Create
        public IActionResult Create()
        {
            ViewData["HoaDon_ID"] = new SelectList(_context.im_Invoice, "ID", "ID");
            ViewData["SanPham_ID"] = new SelectList(_context.im_Product, "ID", "ID");
            return View();
        }

        // POST: Admin/ChiTietHoaDon/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,HoaDon_ID,TenSP,SoLuong,Gia,KhuyenMai,ThanhTien")] ChiTietHoaDon chiTietHoaDonModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chiTietHoaDonModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HoaDon_ID"] = new SelectList(_context.im_Invoice, "ID", "ID", chiTietHoaDonModel.HoaDon_ID);
            return View(chiTietHoaDonModel);
        }

        // GET: Admin/ChiTietHoaDon/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chiTietHoaDonModel = await _context.im_Invoice_Detail.FindAsync(id);
            if (chiTietHoaDonModel == null)
            {
                return NotFound();
            }
            ViewData["HoaDon_ID"] = new SelectList(_context.im_Invoice, "ID", "ID", chiTietHoaDonModel.HoaDon_ID);
            return View(chiTietHoaDonModel);
        }

        // POST: Admin/ChiTietHoaDon/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,HoaDon_ID,TenSP,SoLuong,Gia,KhuyenMai,ThanhTien")] ChiTietHoaDon chiTietHoaDonModel)
        {
            if (id != chiTietHoaDonModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chiTietHoaDonModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChiTietHoaDonModelExists(chiTietHoaDonModel.ID))
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
            ViewData["HoaDon_ID"] = new SelectList(_context.im_Invoice, "ID", "ID", chiTietHoaDonModel.HoaDon_ID);
            return View(chiTietHoaDonModel);
        }

        // GET: Admin/ChiTietHoaDon/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chiTietHoaDonModel = await _context.im_Invoice_Detail
                .Include(c => c.HoaDon)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (chiTietHoaDonModel == null)
            {
                return NotFound();
            }

            return View(chiTietHoaDonModel);
        }

        // POST: Admin/ChiTietHoaDon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chiTietHoaDonModel = await _context.im_Invoice_Detail.FindAsync(id);
            _context.im_Invoice_Detail.Remove(chiTietHoaDonModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool ChiTietHoaDonModelExists(int id)
        {
            return _context.im_Invoice_Detail.Any(e => e.ID == id);
        }
    }
}
