using Blazor.UMS.Server.Data;
using Blazor.UMS.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blazor.UMS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        #region Ctor
        private readonly ApplicationDBContext _context;
        public UserController(ApplicationDBContext context)
        {
            this._context = context;
        }
        #endregion

        #region End Points

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _context.Users.ToListAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(a => a.Id == id);
            return Ok(user);
        }

        /// <summary>
        /// Add new user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(User user)
        {
            _context.Add(user);
            await _context.SaveChangesAsync();
            return Ok(user.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Put(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = new User { Id = id };
            _context.Remove(user);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        #endregion

    }
}
