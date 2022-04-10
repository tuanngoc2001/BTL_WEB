using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_API_v1.Areas.Admin.Data;
using Web_API_v1.Areas.Admin.Models;

namespace Web_API_v1.Areas.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ChiTietHoaDonApiController : ControllerBase
    {
        private readonly Webbanhang _context;

        public ChiTietHoaDonApiController(Webbanhang context)
        {
            _context = context;
        }

        // GET: api/ChiTietHoaDonApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChiTietHoaDonModel>>> GetChiTietHoaDonModel()
        {
            return await _context.ChiTietHoaDonModel.ToListAsync();
        }

        // GET: api/ChiTietHoaDonApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChiTietHoaDonModel>> GetChiTietHoaDonModel(int id)
        {
            var chiTietHoaDonModel = await _context.ChiTietHoaDonModel.FindAsync(id);

            if (chiTietHoaDonModel == null)
            {
                return NotFound();
            }

            return chiTietHoaDonModel;
        }

        // PUT: api/ChiTietHoaDonApi/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChiTietHoaDonModel(int id, ChiTietHoaDonModel chiTietHoaDonModel)
        {
            if (id != chiTietHoaDonModel.ID)
            {
                return BadRequest();
            }

            _context.Entry(chiTietHoaDonModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChiTietHoaDonModelExists(id))
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

        // POST: api/ChiTietHoaDonApi
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ChiTietHoaDonModel>> PostChiTietHoaDonModel(ChiTietHoaDonModel chiTietHoaDonModel)
        {
            _context.ChiTietHoaDonModel.Add(chiTietHoaDonModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChiTietHoaDonModel", new { id = chiTietHoaDonModel.ID }, chiTietHoaDonModel);
        }

        // DELETE: api/ChiTietHoaDonApi/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ChiTietHoaDonModel>> DeleteChiTietHoaDonModel(int id)
        {

            var chiTietHoaDonModel = await _context.ChiTietHoaDonModel.FindAsync(id);
            chiTietHoaDonModel.TrangThai = 0;
            if (chiTietHoaDonModel == null)
            {
                return NotFound();
            }

            _context.Entry(chiTietHoaDonModel).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return chiTietHoaDonModel;
        }

        private bool ChiTietHoaDonModelExists(int id)
        {
            return _context.ChiTietHoaDonModel.Any(e => e.ID == id);
        }
    }
}
