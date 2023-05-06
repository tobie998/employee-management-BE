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
    public class ChucVuController : ControllerBase
    {
        private readonly StaffDbContext _context;

        public ChucVuController(StaffDbContext context)
        {
            _context = context;
        }

        // GET: api/ChucVu
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChucVu>>> GetchucVu()
        {
          if (_context.chucVu == null)
          {
              return NotFound();
          }
            return await _context.chucVu.ToListAsync();
        }

        // GET: api/ChucVu/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChucVu>> GetChucVu(int id)
        {
          if (_context.chucVu == null)
          {
              return NotFound();
          }
            var chucVu = await _context.chucVu.FindAsync(id);

            if (chucVu == null)
            {
                return NotFound();
            }

            return chucVu;
        }

        // PUT: api/ChucVu/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChucVu(int id, ChucVu chucVu)
        {
            if (id != chucVu.Machucvu)
            {
                return BadRequest();
            }

            _context.Entry(chucVu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChucVuExists(id))
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

        // POST: api/ChucVu
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ChucVu>> PostChucVu(ChucVu chucVu)
        {
          if (_context.chucVu == null)
          {
              return Problem("Entity set 'StaffDbContext.chucVu'  is null.");
          }
            _context.chucVu.Add(chucVu);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChucVu", new { id = chucVu.Machucvu }, chucVu);
        }

        // DELETE: api/ChucVu/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChucVu(int id)
        {
            if (_context.chucVu == null)
            {
                return NotFound();
            }
            var chucVu = await _context.chucVu.FindAsync(id);
            if (chucVu == null)
            {
                return NotFound();
            }

            _context.chucVu.Remove(chucVu);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChucVuExists(int id)
        {
            return (_context.chucVu?.Any(e => e.Machucvu == id)).GetValueOrDefault();
        }
    }
}
