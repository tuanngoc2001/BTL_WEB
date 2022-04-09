using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DoAn_ASPNETCORE.Areas.Admin.Data;
using DoAn_ASPNETCORE.Areas.Admin.Models;
using System.IO;

namespace DoAn_ASPNETCORE.Areas.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SanPhamApiController : ControllerBase
    {
        private readonly Webbanhang _context;

        public SanPhamApiController(Webbanhang context)
        {
            _context = context;
        }

        // GET: api/SanPhamApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SanPhamModel>>> GetSanPhamModel()
        {
            return await _context.SanPhamModel.ToListAsync();
        }

        // GET: api/SanPhamApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SanPhamModel>> GetSanPhamModel(int id)
        {
            var sanPhamModel = await _context.SanPhamModel.FindAsync(id);

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
        public async Task<IActionResult> PutSanPhamModel(int id, SanPhamModel sanPhamModel)
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

        // POST: api/SanPhamApi
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SanPhamModel>> PostSanPhamModel(SanPhamModel sanPhamModel, IFormFile ful, IFormFile ful1)
        {
            _context.SanPhamModel.Add(sanPhamModel);
            await _context.SaveChangesAsync();
            //dat lai ten file hinh theo ID
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
        public async Task<ActionResult<SanPhamModel>> DeleteSanPhamModel(int id)
        {
            var sanPhamModel = await _context.SanPhamModel.FindAsync(id);
            if (sanPhamModel == null)
            {
                return NotFound();
            }

            _context.SanPhamModel.Remove(sanPhamModel);
            await _context.SaveChangesAsync();

            return sanPhamModel;
        }

        private bool SanPhamModelExists(int id)
        {
            return _context.SanPhamModel.Any(e => e.ID == id);
        }
    }
}
