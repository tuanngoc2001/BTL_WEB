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
    public class BinhLuanController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ImDbContext _context;

        public BinhLuanController(ImDbContext context)
        {
            _context = context;
        }

        // GET: Admin/BinhLuan
        public async Task<IActionResult> Index()
        {
            var webbanhang = _context.BinhLuanModel.Include(b => b.User);
            return View(await webbanhang.ToListAsync());
        }

        // GET: Admin/BinhLuan/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var binhLuanModel = await _context.BinhLuanModel
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.id == id);
            if (binhLuanModel == null)
            {
                return NotFound();
            }

            return View(binhLuanModel);
        }

        // GET: Admin/BinhLuan/Create
        public IActionResult Create()
        {
            ViewData["User_ID"] = new SelectList(_context.UserModel, "ID", "ID");
            return View();
        }

        // POST: Admin/BinhLuan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,User_ID,SanPham_ID,NoiDung,NgayDang,TrangThai")] BinhLuan binhLuanModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(binhLuanModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["User_ID"] = new SelectList(_context.UserModel, "ID", "ID", binhLuanModel.User_ID);
            return View(binhLuanModel);
        }

        // GET: Admin/BinhLuan/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var binhLuanModel = await _context.BinhLuanModel.FindAsync(id);
            if (binhLuanModel == null)
            {
                return NotFound();
            }
            ViewData["User_ID"] = new SelectList(_context.UserModel, "ID", "ID", binhLuanModel.User_ID);
            return View(binhLuanModel);
        }

        // POST: Admin/BinhLuan/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,User_ID,SanPham_ID,NoiDung,NgayDang,TrangThai")] BinhLuanModel binhLuanModel)
        {
            if (id != binhLuanModel.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(binhLuanModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BinhLuanModelExists(binhLuanModel.id))
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
            ViewData["User_ID"] = new SelectList(_context.UserModel, "ID", "ID", binhLuanModel.User_ID);
            return View(binhLuanModel);
        }

        // GET: Admin/BinhLuan/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var binhLuanModel = await _context.BinhLuanModel
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.id == id);
            if (binhLuanModel == null)
            {
                return NotFound();
            }

            return View(binhLuanModel);
        }

        // POST: Admin/BinhLuan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var binhLuanModel = await _context.BinhLuanModel.FindAsync(id);
            _context.BinhLuanModel.Remove(binhLuanModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BinhLuanModelExists(int id)
        {
            return _context.BinhLuanModel.Any(e => e.id == id);
        }
    }
}
