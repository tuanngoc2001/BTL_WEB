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
    public class HoaDonAPIController : ControllerBase
    {
        private readonly Webbanhang _context;

        public HoaDonAPIController(Webbanhang context)
        {
            _context = context;
        }

        // GET: api/HoaDonAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HoaDonModel>>> GetHoaDonModel()
        {
            return await _context.HoaDonModel.ToListAsync();
        }

        // GET: api/HoaDonAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HoaDonModel>> GetHoaDonModel(int id)
        {
            var hoaDonModel = await _context.HoaDonModel.FindAsync(id);

            if (hoaDonModel == null)
            {
                return NotFound();
            }

            return hoaDonModel;
        }

        // PUT: api/HoaDonAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHoaDonModel(int id, HoaDonModel hoaDonModel)
        {
            if (id != hoaDonModel.ID)
            {
                return BadRequest();
            }

            _context.Entry(hoaDonModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HoaDonModelExists(id))
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

        // POST: api/HoaDonAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HoaDonModel>> PostHoaDonModel(HoaDonModel hoaDonModel)
        {
            _context.HoaDonModel.Add(hoaDonModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHoaDonModel", new { id = hoaDonModel.ID }, hoaDonModel);
        }


        // DELETE: api/HoaDonAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HoaDonModel>> DeleteHoaDonModel(int id)
        {
            var hoaDonModel = await _context.HoaDonModel.FindAsync(id);
            hoaDonModel.TrangThai = 0;
            if (hoaDonModel == null)
            {
                return NotFound();
            }

            _context.HoaDonModel.Update(hoaDonModel);
            await _context.SaveChangesAsync();

            return hoaDonModel;
        }

        private bool HoaDonModelExists(int id)
        {
            return _context.HoaDonModel.Any(e => e.ID == id);
        }

    }
}
