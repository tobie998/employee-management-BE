using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StaffManage.Data;

namespace StaffManage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KyLuatsController : ControllerBase
    {
        private readonly StaffDbContext _context;

        public KyLuatsController(StaffDbContext context)
        {
            _context = context;
        }

        // GET: api/KyLuats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KyLuat>>> GetkyLuat()
        {
          if (_context.kyLuat == null)
          {
              return NotFound();
          }
            return await _context.kyLuat.ToListAsync();
        }

        // GET: api/KyLuats/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KyLuat>> GetKyLuat(int id)
        {
          if (_context.kyLuat == null)
          {
              return NotFound();
          }
            var kyLuat = await _context.kyLuat.FindAsync(id);

            if (kyLuat == null)
            {
                return NotFound();
            }

            return kyLuat;
        }

        // PUT: api/KyLuats/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKyLuat(int id, KyLuat kyLuat)
        {
            if (id != kyLuat.Makyluat)
            {
                return BadRequest();
            }

            _context.Entry(kyLuat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KyLuatExists(id))
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

        // POST: api/KyLuats
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<KyLuat>> PostKyLuat(KyLuat kyLuat)
        {
          if (_context.kyLuat == null)
          {
              return Problem("Entity set 'StaffDbContext.kyLuat'  is null.");
          }
            _context.kyLuat.Add(kyLuat);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKyLuat", new { id = kyLuat.Makyluat }, kyLuat);
        }

        // DELETE: api/KyLuats/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKyLuat(int id)
        {
            if (_context.kyLuat == null)
            {
                return NotFound();
            }
            var kyLuat = await _context.kyLuat.FindAsync(id);
            if (kyLuat == null)
            {
                return NotFound();
            }

            _context.kyLuat.Remove(kyLuat);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KyLuatExists(int id)
        {
            return (_context.kyLuat?.Any(e => e.Makyluat == id)).GetValueOrDefault();
        }
    }
}
