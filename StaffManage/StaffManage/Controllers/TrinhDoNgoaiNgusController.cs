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
    public class TrinhDoNgoaiNgusController : ControllerBase
    {
        private readonly StaffDbContext _context;

        public TrinhDoNgoaiNgusController(StaffDbContext context)
        {
            _context = context;
        }

        // GET: api/TrinhDoNgoaiNgus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrinhDoNgoaiNgu>>> GettrinhDoNgoaiNgu()
        {
          if (_context.trinhDoNgoaiNgu == null)
          {
              return NotFound();
          }
            return await _context.trinhDoNgoaiNgu.ToListAsync();
        }

        // GET: api/TrinhDoNgoaiNgus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TrinhDoNgoaiNgu>> GetTrinhDoNgoaiNgu(int id)
        {
          if (_context.trinhDoNgoaiNgu == null)
          {
              return NotFound();
          }
            var trinhDoNgoaiNgu = await _context.trinhDoNgoaiNgu.FindAsync(id);

            if (trinhDoNgoaiNgu == null)
            {
                return NotFound();
            }

            return trinhDoNgoaiNgu;
        }

        // PUT: api/TrinhDoNgoaiNgus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrinhDoNgoaiNgu(int id, TrinhDoNgoaiNgu trinhDoNgoaiNgu)
        {
            if (id != trinhDoNgoaiNgu.Mangoaingu)
            {
                return BadRequest();
            }

            _context.Entry(trinhDoNgoaiNgu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrinhDoNgoaiNguExists(id))
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

        // POST: api/TrinhDoNgoaiNgus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TrinhDoNgoaiNgu>> PostTrinhDoNgoaiNgu(TrinhDoNgoaiNgu trinhDoNgoaiNgu)
        {
          if (_context.trinhDoNgoaiNgu == null)
          {
              return Problem("Entity set 'StaffDbContext.trinhDoNgoaiNgu'  is null.");
          }
            _context.trinhDoNgoaiNgu.Add(trinhDoNgoaiNgu);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrinhDoNgoaiNgu", new { id = trinhDoNgoaiNgu.Mangoaingu }, trinhDoNgoaiNgu);
        }

        // DELETE: api/TrinhDoNgoaiNgus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrinhDoNgoaiNgu(int id)
        {
            if (_context.trinhDoNgoaiNgu == null)
            {
                return NotFound();
            }
            var trinhDoNgoaiNgu = await _context.trinhDoNgoaiNgu.FindAsync(id);
            if (trinhDoNgoaiNgu == null)
            {
                return NotFound();
            }

            _context.trinhDoNgoaiNgu.Remove(trinhDoNgoaiNgu);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrinhDoNgoaiNguExists(int id)
        {
            return (_context.trinhDoNgoaiNgu?.Any(e => e.Mangoaingu == id)).GetValueOrDefault();
        }
    }
}
