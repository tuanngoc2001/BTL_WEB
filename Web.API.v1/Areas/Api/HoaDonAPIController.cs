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
    public class HoaDonAPIController : ControllerBase
    {
        private readonly ImDbContext _context;

        public HoaDonAPIController(ImDbContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HoaDon>>> GetHoaDonModel()
        {
            return await _context.im_Invoice.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<HoaDon>> GetHoaDonModel(int id)
        {
            var hoaDonModel = await _context.im_Invoice.FindAsync(id);

            if (hoaDonModel == null)
            {
                return NotFound();
            }

            return hoaDonModel;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHoaDonModel(int id, HoaDon hoaDonModel)
        {
            if (id != hoaDonModel.ID)
            {
                return BadRequest();
            }
            //check model mà mình request
            var hoadon = new HoaDon()
            {
                ID = hoaDonModel.ID,
                User_ID = hoaDonModel.User_ID,
                HoTen = hoaDonModel.HoTen,
                Sdt = hoaDonModel.Sdt,
                ThanhTien = hoaDonModel.ThanhTien

            };
            _context.im_Invoice.Update(hoadon);
            

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

        [HttpPost]
        public async Task<ActionResult<HoaDon>> PostHoaDonModel(HoaDon hoaDonModel)
        {
            _context.im_Invoice.Add(hoaDonModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHoaDonModel", new { id = hoaDonModel.ID }, hoaDonModel);
        }


        // DELETE: api/HoaDonAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HoaDon>> DeleteHoaDonModel(int id)
        {
            var hoaDonModel = await _context.im_Invoice.FindAsync(id);
            hoaDonModel.TrangThai = 0;
            if (hoaDonModel == null)
            {
                return NotFound();
            }

            _context.im_Invoice.Update(hoaDonModel);
            await _context.SaveChangesAsync();

            return hoaDonModel;
        }

        private bool HoaDonModelExists(int id)
        {
            return _context.im_Invoice.Any(e => e.ID == id);
        }

    }
}
