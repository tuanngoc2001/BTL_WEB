using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Web_API_v1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoaiSanPhamController : Controller
    {
        private readonly Webbanhang _context;

        public LoaiSanPhamController(Webbanhang context)
        {
            _context = context;
        }

        // GET: Admin/LoaiSanPham
        public async Task<IActionResult> Index(/*string SearchString*/)
        {

            //IQueryable<string> genreQuery = from m in _context.LoaiSanPhamModel

            //                                select m.TenLoai;
            //var webbanhang = from m in _context.LoaiSanPhamModel
            //                 select m;

            //if (!string.IsNullOrEmpty(SearchString))
            //{
            //    webbanhang = webbanhang.Where(s => s.TenLoai.Contains(SearchString));
            //}

            ////if (!string.IsNullOrEmpty(Loaisp))
            ////{
            ////    webbanhang = webbanhang.Where(x => x.MaNCC.TenNCC ==Loaisp);
            ////}

            //var movieGenreVM = new ViewModel
            //{
            //    DSLoaisp= new SelectList(await genreQuery.Distinct().ToListAsync()),
            //    LoaiSP = await webbanhang.ToListAsync()
            //};
            ViewData["NhaCungCap"] = new SelectList(_context.Set<NhaCungCapModel>(), "ID", "ID");
            return View();

        }

        // GET: Admin/LoaiSanPham/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiSanPhamModel = await _context.LoaiSanPhamModel
                .Include(l => l.MaNCC)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (loaiSanPhamModel == null)
            {
                return NotFound();
            }

            return View(loaiSanPhamModel);
        }

        // GET: Admin/LoaiSanPham/Create
        public IActionResult Create()
        {
            ViewData["NhaCungCap"] = new SelectList(_context.Set<NhaCungCapModel>(), "ID", "ID");
            return View();
        }

        // POST: Admin/LoaiSanPham/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,TenLoai,NhaCungCap,TrangThai")] LoaiSanPhamModel loaiSanPhamModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loaiSanPhamModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NhaCungCap"] = new SelectList(_context.Set<NhaCungCapModel>(), "ID", "ID", loaiSanPhamModel.NhaCungCap);
            return View(loaiSanPhamModel);
        }

        // GET: Admin/LoaiSanPham/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiSanPhamModel = await _context.LoaiSanPhamModel.FindAsync(id);
            if (loaiSanPhamModel == null)
            {
                return NotFound();
            }
            ViewData["NhaCungCap"] = new SelectList(_context.Set<NhaCungCapModel>(), "ID", "ID", loaiSanPhamModel.NhaCungCap);
            return View(loaiSanPhamModel);
        }

        // POST: Admin/LoaiSanPham/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,TenLoai,NhaCungCap,TrangThai")] LoaiSanPhamModel loaiSanPhamModel)
        {
            if (id != loaiSanPhamModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loaiSanPhamModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoaiSanPhamModelExists(loaiSanPhamModel.ID))
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
            ViewData["NhaCungCap"] = new SelectList(_context.Set<NhaCungCapModel>(), "ID", "ID", loaiSanPhamModel.NhaCungCap);
            return View(loaiSanPhamModel);
        }

        // GET: Admin/LoaiSanPham/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiSanPhamModel = await _context.LoaiSanPhamModel
                .Include(l => l.MaNCC)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (loaiSanPhamModel == null)
            {
                return NotFound();
            }

            return View(loaiSanPhamModel);
        }

        // POST: Admin/LoaiSanPham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loaiSanPhamModel = await _context.LoaiSanPhamModel.FindAsync(id);
            _context.LoaiSanPhamModel.Remove(loaiSanPhamModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoaiSanPhamModelExists(int id)
        {
            return _context.LoaiSanPhamModel.Any(e => e.ID == id);
        }
    }
}
