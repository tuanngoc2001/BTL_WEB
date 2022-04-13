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
    public class BinhLuanController : Controller
    {
        private readonly ImDbContext _context;

        public BinhLuanController(ImDbContext context)
        {
            _context = context;
        }

       
        public async Task<IActionResult> Index()
        {
            var webbanhang = _context.im_Comment.Include(b => b.User);
            return View(await webbanhang.ToListAsync());
        }

        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var binhLuanModel = await _context.im_Comment
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.id == id);
            if (binhLuanModel == null)
            {
                return NotFound();
            }

            return View(binhLuanModel);
        }

        //chưa hiểu
        public IActionResult Create()
        {
            ViewData["User_ID"] = new SelectList(_context.im_User, "ID", "ID");
            return View();
        }

        //day nua
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,User_ID,SanPham_ID,NoiDung,NgayDang,TrangThai")] BinhLuan binhLuanModel)
        {
            //quá trình 
            if (ModelState.IsValid)
            {
                _context.Add(binhLuanModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["User_ID"] = new SelectList(_context.im_User, "ID", "ID", binhLuanModel.User_ID);
            return View(binhLuanModel);
        }

       
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var binhLuanModel = await _context.im_Comment.FindAsync(id);
            if (binhLuanModel == null)
            {
                return NotFound();
            }
            ViewData["User_ID"] = new SelectList(_context.im_User, "ID", "ID", binhLuanModel.User_ID);
            return View(binhLuanModel);
        }

        // POST: Admin/BinhLuan/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,User_ID,SanPham_ID,NoiDung,NgayDang,TrangThai")] BinhLuan binhLuanModel)
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
            ViewData["User_ID"] = new SelectList(_context.im_User, "ID", "ID", binhLuanModel.User_ID);
            return View(binhLuanModel);
        }

        // GET: Admin/BinhLuan/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var binhLuanModel = await _context.im_Comment
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
            var binhLuanModel = await _context.im_Comment.FindAsync(id);
            _context.im_Comment.Remove(binhLuanModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BinhLuanModelExists(int id)
        {
            return _context.im_Comment.Any(e => e.id == id);
        }
    }
}
