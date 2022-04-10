using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Web_API_v1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DanhMucController : Controller
    {
        private readonly Webbanhang _context;

        public DanhMucController(Webbanhang context)
        {
            _context = context;
        }

        // GET: Admin/DanhMuc
        public async Task<IActionResult> Index()
        {
            return View(await _context.DanhMucModel.ToListAsync());
        }

        // GET: Admin/DanhMuc/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var danhMucModel = await _context.DanhMucModel
                .FirstOrDefaultAsync(m => m.ID_DanhMuc == id);
            if (danhMucModel == null)
            {
                return NotFound();
            }

            return View(danhMucModel);
        }

        // GET: Admin/DanhMuc/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_DanhMuc,TenDanhMuc,TrangThai")] DanhMucModel danhMucModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(danhMucModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(danhMucModel);
        }

        // GET: Admin/DanhMuc/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var danhMucModel = await _context.DanhMucModel.FindAsync(id);
            if (danhMucModel == null)
            {
                return NotFound();
            }
            return View(danhMucModel);
        }

        // POST: Admin/DanhMuc/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID_DanhMuc,TenDanhMuc,TrangThai")] DanhMucModel danhMucModel)
        {
            if (id != danhMucModel.ID_DanhMuc)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(danhMucModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DanhMucModelExists(danhMucModel.ID_DanhMuc))
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
            return View(danhMucModel);
        }

        // GET: Admin/DanhMuc/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var danhMucModel = await _context.DanhMucModel
                .FirstOrDefaultAsync(m => m.ID_DanhMuc == id);
            if (danhMucModel == null)
            {
                return NotFound();
            }

            return View(danhMucModel);
        }

        // POST: Admin/DanhMuc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var danhMucModel = await _context.DanhMucModel.FindAsync(id);
            _context.DanhMucModel.Remove(danhMucModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DanhMucModelExists(string id)
        {
            return _context.DanhMucModel.Any(e => e.ID_DanhMuc == id);
        }
    }
}
