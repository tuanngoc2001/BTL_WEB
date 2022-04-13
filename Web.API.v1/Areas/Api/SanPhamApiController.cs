using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Web_Data;
namespace Web_API_v1.Areas.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SanPhamApiController : ControllerBase
    {
        private readonly ImDbContext _context;

        public SanPhamApiController(ImDbContext context)
        {
            _context = context;
        }

        // GET: api/SanPhamApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SanPham>>> GetSanPhamModel()
        {
            return await _context.im_Product.ToListAsync();
        }

        // GET: api/SanPhamApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SanPham>> GetSanPhamModel(int id)
        {
            var sanPhamModel = await _context.im_Product.FindAsync(id);

            if (sanPhamModel == null)
            {
                return NotFound();
            }

            return sanPhamModel;
        }

        // PUT: api/SanPhamApi/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSanPhamModel(int id, SanPham sanPhamModel)
        {
            if (id != sanPhamModel.ID)
            {
                return BadRequest();
            }

            _context.Entry(sanPhamModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SanPhamModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

      
        [HttpPost]
        public async Task<ActionResult<SanPham>> PostSanPhamModel(SanPham sanPhamModel, IFormFile ful, IFormFile ful1)
        {
            _context.im_Product.Add(sanPhamModel);
            await _context.SaveChangesAsync();
            //dat lai ten file hinh theo ID
            //daojn cuối là lấy ra đuoi(tách ra 2 chuỗi cách nhau bởi dấu chấm)
            string s = sanPhamModel.ID + "." + ful.FileName.Split(".")[ful.FileName.Split(".").Length - 1];
            //Di chuyen file hinh den folder khac
            var path = Path.Combine(
                Directory.GetCurrentDirectory(), "wwwroot/images/", s);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await ful.CopyToAsync(stream);
            }
            //dat lai ten file hinh theo ID
            string s1 = sanPhamModel.ID + "2nd" + "." + ful1.FileName.Split(".")[ful1.FileName.Split(".").Length - 1];
            //Di chuyen file hinh den folder khac
            //kết hợp ba chuỗi thành 1 đường dẫn
            var path1 = Path.Combine(
                Directory.GetCurrentDirectory(), "wwwroot/images/", s1);
            using (var stream1 = new FileStream(path1, FileMode.Create))
            {
                await ful1.CopyToAsync(stream1);
            }
            //Gan lai ten file hinh moi cho cot TenHinh
            sanPhamModel.Image = s;
            sanPhamModel.Image_List = s1;
            _context.Update(sanPhamModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetSanPhamModel", new { id = sanPhamModel.ID }, sanPhamModel);
        }

        // DELETE: api/SanPhamApi/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SanPham>> DeleteSanPhamModel(int id)
        {
            var sanPhamModel = await _context.im_Product.FindAsync(id);
            if (sanPhamModel == null)
            {
                return NotFound();
            }

            _context.im_Product.Remove(sanPhamModel);
            await _context.SaveChangesAsync();

            return sanPhamModel;
        }

        private bool SanPhamModelExists(int id)
        {
            return _context.im_Product.Any(e => e.ID == id);
        }
    }
}
