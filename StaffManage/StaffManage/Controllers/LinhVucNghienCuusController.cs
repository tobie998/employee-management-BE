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
    public class LinhVucNghienCuusController : ControllerBase
    {
        private readonly StaffDbContext _context;

        public LinhVucNghienCuusController(StaffDbContext context)
        {
            _context = context;
        }

        // GET: api/LinhVucNghienCuus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LinhVucNghienCuu>>> GetlinhVuc()
        {
          if (_context.linhVuc == null)
          {
              return NotFound();
          }
            return await _context.linhVuc.ToListAsync();
        }

        // GET: api/LinhVucNghienCuus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LinhVucNghienCuu>> GetLinhVucNghienCuu(int id)
        {
          if (_context.linhVuc == null)
          {
              return NotFound();
          }
            var linhVucNghienCuu = await _context.linhVuc.FindAsync(id);

            if (linhVucNghienCuu == null)
            {
                return NotFound();
            }

            return linhVucNghienCuu;
        }

        // PUT: api/LinhVucNghienCuus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLinhVucNghienCuu(int id, LinhVucNghienCuu linhVucNghienCuu)
        {
            if (id != linhVucNghienCuu.Machuyennganh)
            {
                return BadRequest();
            }

            _context.Entry(linhVucNghienCuu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LinhVucNghienCuuExists(id))
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

        // POST: api/LinhVucNghienCuus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LinhVucNghienCuu>> PostLinhVucNghienCuu(LinhVucNghienCuu linhVucNghienCuu)
        {
          if (_context.linhVuc == null)
          {
              return Problem("Entity set 'StaffDbContext.linhVuc'  is null.");
          }
            _context.linhVuc.Add(linhVucNghienCuu);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLinhVucNghienCuu", new { id = linhVucNghienCuu.Machuyennganh }, linhVucNghienCuu);
        }

        // DELETE: api/LinhVucNghienCuus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLinhVucNghienCuu(int id)
        {
            if (_context.linhVuc == null)
            {
                return NotFound();
            }
            var linhVucNghienCuu = await _context.linhVuc.FindAsync(id);
            if (linhVucNghienCuu == null)
            {
                return NotFound();
            }

            _context.linhVuc.Remove(linhVucNghienCuu);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LinhVucNghienCuuExists(int id)
        {
            return (_context.linhVuc?.Any(e => e.Machuyennganh == id)).GetValueOrDefault();
        }
    }
}
