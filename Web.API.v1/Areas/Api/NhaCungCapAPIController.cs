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
    public class NhaCungCapAPIController : ControllerBase
    {
        private readonly Webbanhang _context;

        public NhaCungCaPAPIController(Webbanhang context)
        {
            _context = context;
        }

        // GET: api/NhaCungCaPAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NhaCungCapModel>>> GetNhaCungCapModel()
        {
            return await _context.NhaCungCapModel.ToListAsync();
        }

        // GET: api/NhaCungCaPAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NhaCungCapModel>> GetNhaCungCapModel(int id)
        {
            var nhaCungCapModel = await _context.NhaCungCapModel.FindAsync(id);

            if (nhaCungCapModel == null)
            {
                return NotFound();
            }

            return nhaCungCapModel;
        }

        // PUT: api/NhaCungCaPAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNhaCungCapModel(int id, NhaCungCapModel nhaCungCapModel)
        {
            if (id != nhaCungCapModel.ID)
            {
                return BadRequest();
            }

            _context.Entry(nhaCungCapModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NhaCungCapModelExists(id))
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

        // POST: api/NhaCungCaPAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<NhaCungCapModel>> PostNhaCungCapModel(NhaCungCapModel nhaCungCapModel)
        {
            _context.NhaCungCapModel.Add(nhaCungCapModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNhaCungCapModel", new { id = nhaCungCapModel.ID }, nhaCungCapModel);
        }

        // DELETE: api/NhaCungCaPAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<NhaCungCapModel>> DeleteNhaCungCapModel(int id)
        {
            var nhaCungCapModel = await _context.NhaCungCapModel.FindAsync(id);
            nhaCungCapModel.TrangThai = "0";
            if (nhaCungCapModel == null)
            {
                return NotFound();
            }

            _context.NhaCungCapModel.Update(nhaCungCapModel);
            await _context.SaveChangesAsync();

            return nhaCungCapModel;
        }

        private bool NhaCungCapModelExists(int id)
        {
            return _context.NhaCungCapModel.Any(e => e.ID == id);
        }
    }
}
