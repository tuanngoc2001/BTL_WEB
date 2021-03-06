using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_Data;
namespace Web_API_v1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NhaCungCapController : Controller
    {
        private readonly ImDbContext _context;

        public NhaCungCapController(ImDbContext context)
        {
            _context = context;
        }

        // GET: Admin/NhaCungCap
        //public async Task<IActionResult> Index(string searchString)
        //{
        //    IQueryable<string> genreQuery = from m in _context.NhaCungCapModel select m.TenNCC;
        //    var nhacungcaps = from m in _context.NhaCungCapModel
        //                   select m;
        //    if (!string.IsNullOrEmpty(searchString))
        //    {
        //        nhacungcaps = nhacungcaps.Where(s => s.TenNCC.Contains(searchString));
        //    }

        //    var NhaCungCapViewModel = new NhaCungCapViewModel
        //    {
        //        DSNhaCungCap = new SelectList(await genreQuery.Distinct().ToListAsync()),
        //        NhaCungCaps = await nhacungcaps.ToListAsync()

        //    };
        //    return View(NhaCungCapViewModel);
        //  ;
        //}

        public async Task<IActionResult> Index()
        {

            return View();
        }

        // GET: Admin/NhaCungCap/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhaCungCapModel = await _context.im_Supplier
                .FirstOrDefaultAsync(m => m.ID == id);
            if (nhaCungCapModel == null)
            {
                return NotFound();
            }

            return View(nhaCungCapModel);
        }

        // GET: Admin/NhaCungCap/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/NhaCungCap/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,TenNCC,DiaChi,TrangThai")] NhaCungCap nhaCungCapModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nhaCungCapModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nhaCungCapModel);
        }

        // GET: Admin/NhaCungCap/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhaCungCapModel = await _context.im_Supplier.FindAsync(id);
            if (nhaCungCapModel == null)
            {
                return NotFound();
            }
            return View(nhaCungCapModel);
        }

        // POST: Admin/NhaCungCap/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,TenNCC,DiaChi,TrangThai")] NhaCungCap nhaCungCapModel)
        {
            if (id != nhaCungCapModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nhaCungCapModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhaCungCapModelExists(nhaCungCapModel.ID))
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
            return View(nhaCungCapModel);
        }

        // GET: Admin/NhaCungCap/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhaCungCapModel = await _context.im_Supplier
                .FirstOrDefaultAsync(m => m.ID == id);
            if (nhaCungCapModel == null)
            {
                return NotFound();
            }

            return View(nhaCungCapModel);
        }

        // POST: Admin/NhaCungCap/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nhaCungCapModel = await _context.im_Supplier.FindAsync(id);
            _context.im_Supplier.Remove(nhaCungCapModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NhaCungCapModelExists(int id)
        {
            return _context.im_Supplier.Any(e => e.ID == id);
        }
    }
}
