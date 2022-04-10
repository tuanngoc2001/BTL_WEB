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
    public class UserApiController : ControllerBase
    {
        private readonly ImDbContext _context;

        public UserApiController(ImDbContext context)
        {
            _context = context;
        }

        // GET: api/UserApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUserModel()
        {
            return await _context.im_User.ToListAsync();
        }

        // GET: api/UserApi/5
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

        // PUT: api/UserApi/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserModel(int id, User userModel)
        {
            if (id != userModel.ID)
            {
                return BadRequest();
            }

            _context.Entry(userModel).State = EntityState.Modified;

            try
            {
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

        // POST: api/UserApi
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<User>> PostUserModel(User userModel)
        {
            _context.im_User.Add(userModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserModel", new { id = userModel.ID }, userModel);
        }

        // DELETE: api/UserApi/5
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
