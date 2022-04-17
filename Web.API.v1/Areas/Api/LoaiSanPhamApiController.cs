using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_Data;
namespace Web_API_v1.Areas.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoaiSanPhamApiController : ControllerBase
    {
        private readonly ImDbContext _context;

        public LoaiSanPhamApiController(ImDbContext context)
        {
            _context = context;
        }

        // GET: api/LoaiSanPhamApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoaiSanPham>>> GetLoaiSanPhamModel()
        {
            return await _context.im_Product_Type.ToListAsync();
        }

        // GET: api/LoaiSanPhamApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LoaiSanPham>> GetLoaiSanPhamModel(int id)
        {
            var loaiSanPhamModel = await _context.im_Product_Type.FindAsync(id);
            if (loaiSanPhamModel == null)
            {
                return NotFound();
            }
            return loaiSanPhamModel;
        }

      
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoaiSanPhamModel(int id, LoaiSanPham loaiSanPhamModel)
        {
            if (id != loaiSanPhamModel.ID)
            {
                return BadRequest();
            }

            _context.im_Product_Type.Update(loaiSanPhamModel);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                if (!LoaiSanPhamModelExists(id))
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
        public async Task<ActionResult<LoaiSanPham>> PostLoaiSanPhamModel(LoaiSanPham loaiSanPhamModel)
        {
            _context.im_Product_Type.Add(loaiSanPhamModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLoaiSanPhamModel", new { id = loaiSanPhamModel.ID }, loaiSanPhamModel);
        }

        // DELETE: api/LoaiSanPhamApi/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LoaiSanPham>> DeleteLoaiSanPhamModel(int id)
        {
            var loaiSanPhamModel = await _context.im_Product_Type.SingleOrDefaultAsync(p=>p.ID==id);
            loaiSanPhamModel.TrangThai = "0";
            if (loaiSanPhamModel == null)
            {
                return NotFound();
            }

            _context.im_Product_Type.Remove(loaiSanPhamModel);
            await _context.SaveChangesAsync();

            return loaiSanPhamModel;
        }

        private bool LoaiSanPhamModelExists(int id)
        {
            return _context.im_Product_Type.Any(e => e.ID == id);
        }
    }
}
