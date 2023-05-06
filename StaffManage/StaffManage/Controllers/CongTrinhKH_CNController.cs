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
    public class CongTrinhKH_CNController : ControllerBase
    {
        private readonly StaffDbContext _context;

        public CongTrinhKH_CNController(StaffDbContext context)
        {
            _context = context;
        }

        // GET: api/CongTrinhKH_CN
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CongTrinhKH_CN>>> GetcongTrinhKH_CN()
        {
          if (_context.congTrinhKH_CN == null)
          {
              return NotFound();
          }
            return await _context.congTrinhKH_CN.ToListAsync();
        }

        // GET: api/CongTrinhKH_CN/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CongTrinhKH_CN>> GetCongTrinhKH_CN(int id)
        {
          if (_context.congTrinhKH_CN == null)
          {
              return NotFound();
          }
            var congTrinhKH_CN = await _context.congTrinhKH_CN.FindAsync(id);

            if (congTrinhKH_CN == null)
            {
                return NotFound();
            }

            return congTrinhKH_CN;
        }

        // PUT: api/CongTrinhKH_CN/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCongTrinhKH_CN(int id, CongTrinhKH_CN congTrinhKH_CN)
        {
            if (id != congTrinhKH_CN.MacongtrinhKH)
            {
                return BadRequest();
            }

            _context.Entry(congTrinhKH_CN).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CongTrinhKH_CNExists(id))
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

        // POST: api/CongTrinhKH_CN
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CongTrinhKH_CN>> PostCongTrinhKH_CN(CongTrinhKH_CN congTrinhKH_CN)
        {
          if (_context.congTrinhKH_CN == null)
          {
              return Problem("Entity set 'StaffDbContext.congTrinhKH_CN'  is null.");
          }
            _context.congTrinhKH_CN.Add(congTrinhKH_CN);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCongTrinhKH_CN", new { id = congTrinhKH_CN.MacongtrinhKH }, congTrinhKH_CN);
        }

        // DELETE: api/CongTrinhKH_CN/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCongTrinhKH_CN(int id)
        {
            if (_context.congTrinhKH_CN == null)
            {
                return NotFound();
            }
            var congTrinhKH_CN = await _context.congTrinhKH_CN.FindAsync(id);
            if (congTrinhKH_CN == null)
            {
                return NotFound();
            }

            _context.congTrinhKH_CN.Remove(congTrinhKH_CN);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CongTrinhKH_CNExists(int id)
        {
            return (_context.congTrinhKH_CN?.Any(e => e.MacongtrinhKH == id)).GetValueOrDefault();
        }
    }
}
