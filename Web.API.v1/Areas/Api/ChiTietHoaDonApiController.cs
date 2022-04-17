using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_Business.ViewComponents;
using Web_Data;
namespace Web_API_v1.Areas.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController] 
    public class ChiTietHoaDonApiController : ControllerBase
    {
        private readonly ImDbContext _context;
        private readonly IMapper _mapper;

        public ChiTietHoaDonApiController(ImDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChiTietHoaDon>>> GetChiTietHoaDonModel()
        {
            return await _context.im_Invoice_Detail.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ChiTietHoaDon>> GetChiTietHoaDonModel(int id)
        {
            var chiTietHoaDonModel = await _context.im_Invoice_Detail.FindAsync(id);

            if (chiTietHoaDonModel == null)
            {
                return NotFound();
            }

            return chiTietHoaDonModel;
        }

       
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChiTietHoaDonModel(int id, ChiTietHoaDon chiTietHoaDonModel)
        {
            if (id != chiTietHoaDonModel.ID)
            {
                return BadRequest();
            }
            
            try
            {
                
                _context.im_Invoice_Detail.Update(chiTietHoaDonModel);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                if (!ChiTietHoaDonModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw ;
                }
            }

            return NoContent();
        }

       
        [HttpPost]
        public async Task<ActionResult<ChiTietHoaDon>> PostChiTietHoaDonModel(ChiTietHoaDon chiTietHoaDonModel)
        {
            _context.im_Invoice_Detail.Add(chiTietHoaDonModel);
            await _context.SaveChangesAsync();
            //trả về một status code 201 resouse thành công
            return CreatedAtAction("GetChiTietHoaDonModel", new { id = chiTietHoaDonModel.ID }, chiTietHoaDonModel);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ChiTietHoaDon>> DeleteChiTietHoaDonModel(int id)
        {

            var chiTietHoaDonModel = await _context.im_Invoice_Detail.FindAsync(id);
            chiTietHoaDonModel.TrangThai = 0;
            if (chiTietHoaDonModel == null)
            {
                return NotFound();
            }

            _context.im_Invoice_Detail.Remove(chiTietHoaDonModel);
             await _context.SaveChangesAsync();

            return chiTietHoaDonModel;
        }

        private bool ChiTietHoaDonModelExists(int id)
        {
            return _context.im_Invoice_Detail.Any(e => e.ID == id);
        }
    }
}
