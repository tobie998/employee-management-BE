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
    public class KhenThuongsController : ControllerBase
    {
        private readonly StaffDbContext _context;

        public KhenThuongsController(StaffDbContext context)
        {
            _context = context;
        }

        // GET: api/KhenThuongs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KhenThuong>>> GetkhenThuong()
        {
          if (_context.khenThuong == null)
          {
              return NotFound();
          }
            return await _context.khenThuong.ToListAsync();
        }

        // GET: api/KhenThuongs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KhenThuong>> GetKhenThuong(int id)
        {
          if (_context.khenThuong == null)
          {
              return NotFound();
          }
            var khenThuong = await _context.khenThuong.FindAsync(id);

            if (khenThuong == null)
            {
                return NotFound();
            }

            return khenThuong;
        }

        // PUT: api/KhenThuongs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKhenThuong(int id, KhenThuong khenThuong)
        {
            if (id != khenThuong.Makhenthuong)
            {
                return BadRequest();
            }

            _context.Entry(khenThuong).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KhenThuongExists(id))
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

        // POST: api/KhenThuongs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<KhenThuong>> PostKhenThuong(KhenThuong khenThuong)
        {
          if (_context.khenThuong == null)
          {
              return Problem("Entity set 'StaffDbContext.khenThuong'  is null.");
          }
            _context.khenThuong.Add(khenThuong);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKhenThuong", new { id = khenThuong.Makhenthuong }, khenThuong);
        }

        // DELETE: api/KhenThuongs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKhenThuong(int id)
        {
            if (_context.khenThuong == null)
            {
                return NotFound();
            }
            var khenThuong = await _context.khenThuong.FindAsync(id);
            if (khenThuong == null)
            {
                return NotFound();
            }

            _context.khenThuong.Remove(khenThuong);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KhenThuongExists(int id)
        {
            return (_context.khenThuong?.Any(e => e.Makhenthuong == id)).GetValueOrDefault();
        }
    }
}
