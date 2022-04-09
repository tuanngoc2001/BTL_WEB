using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DoAn_ASPNETCORE.Areas.Admin.Data;
using DoAn_ASPNETCORE.Areas.Admin.Models;

namespace DoAn_ASPNETCORE.Areas.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoaiSanPhamApiController : ControllerBase
    {
        private readonly Webbanhang _context;

        public LoaiSanPhamApiController(Webbanhang context)
        {
            _context = context;
        }

        // GET: api/LoaiSanPhamApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoaiSanPhamModel>>> GetLoaiSanPhamModel()
        {
            return await _context.LoaiSanPhamModel.ToListAsync();
        }

        // GET: api/LoaiSanPhamApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LoaiSanPhamModel>> GetLoaiSanPhamModel(int id)
        {
            var loaiSanPhamModel = await _context.LoaiSanPhamModel.FindAsync(id);
            if (loaiSanPhamModel == null)
            {
                return NotFound();
            }
            return loaiSanPhamModel;
        }

        // PUT: api/LoaiSanPhamApi/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoaiSanPhamModel(int id, LoaiSanPhamModel loaiSanPhamModel)
        {
            if (id != loaiSanPhamModel.ID)
            {
                return BadRequest();
            }

            _context.Entry(loaiSanPhamModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
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

        // POST: api/LoaiSanPhamApi
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<LoaiSanPhamModel>> PostLoaiSanPhamModel(LoaiSanPhamModel loaiSanPhamModel)
        {
            _context.LoaiSanPhamModel.Add(loaiSanPhamModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLoaiSanPhamModel", new { id = loaiSanPhamModel.ID }, loaiSanPhamModel);
        }

        // DELETE: api/LoaiSanPhamApi/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LoaiSanPhamModel>> DeleteLoaiSanPhamModel(int id)
        {
            var loaiSanPhamModel = await _context.LoaiSanPhamModel.FindAsync(id);
            loaiSanPhamModel.TrangThai = "0";
            if (loaiSanPhamModel == null)
            {
                return NotFound();
            }

            _context.Entry(loaiSanPhamModel).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return loaiSanPhamModel;
        }

        private bool LoaiSanPhamModelExists(int id)
        {
            return _context.LoaiSanPhamModel.Any(e => e.ID == id);
        }
    }
}
