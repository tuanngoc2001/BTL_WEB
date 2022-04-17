using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_Data;
namespace Web_API_v1.Areas.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserApiController : ControllerBase
    {
        private readonly ImDbContext _context;
        private readonly IMapper _mapper;

        public UserApiController(ImDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUserModel()
        {
            return await _context.im_User.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserModel(int id)
        {
            var userModel = await _context.im_User.FindAsync(id);

            if (userModel == null)
            {
                return NotFound();
            }

            return userModel;
        }

       
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserModel(int id, User userModel)
        {
            if (id != userModel.ID)
            {
                return BadRequest();
            }

            

            try
            {
                _context.im_User.Update(userModel);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserModelExists(id))
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
        public async Task<ActionResult<User>> PostUserModel(User userModel)
        {
            _context.im_User.Add(userModel);
            await _context.SaveChangesAsync();
            //tao ra phan hoi status 201
            //"trả về một resouse khi vưaf đc tạo thafnh công
            return CreatedAtAction("GetUserModel", new { id = userModel.ID }, userModel);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUserModel(int id)
        {
            var userModel = await _context.im_User.FindAsync(id);           
            if (userModel == null)
            {
                return NotFound();
            }
            _context.im_User.Remove(userModel);
            await _context.SaveChangesAsync();
            return userModel;
        }

        private bool UserModelExists(int id)
        {
            return _context.im_User.Any(e => e.ID == id);
        }
    }
}
