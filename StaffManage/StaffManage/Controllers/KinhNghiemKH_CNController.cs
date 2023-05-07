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
    public class KinhNghiemKH_CNController : ControllerBase
    {
        private readonly StaffDbContext _context;

        public KinhNghiemKH_CNController(StaffDbContext context)
        {
            _context = context;
        }

        // GET: api/KinhNghiemKH_CN
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KinhNghiemKH_CN>>> GetkinhNghiemKH_CN()
        {
          if (_context.kinhNghiemKH_CN == null)
          {
              return NotFound();
          }
            return await _context.kinhNghiemKH_CN.ToListAsync();
        }

        // GET: api/KinhNghiemKH_CN/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KinhNghiemKH_CN>> GetKinhNghiemKH_CN(int id)
        {
          if (_context.kinhNghiemKH_CN == null)
          {
              return NotFound();
          }
            var kinhNghiemKH_CN = await _context.kinhNghiemKH_CN.FindAsync(id);

            if (kinhNghiemKH_CN == null)
            {
                return NotFound();
            }

            return kinhNghiemKH_CN;
        }

        // PUT: api/KinhNghiemKH_CN/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKinhNghiemKH_CN(int id, KinhNghiemKH_CN kinhNghiemKH_CN)
        {
            if (id != kinhNghiemKH_CN.Mahinhthuchoidong)
            {
                return BadRequest();
            }

            _context.Entry(kinhNghiemKH_CN).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KinhNghiemKH_CNExists(id))
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

        // POST: api/KinhNghiemKH_CN
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<KinhNghiemKH_CN>> PostKinhNghiemKH_CN(KinhNghiemKH_CN kinhNghiemKH_CN)
        {
          if (_context.kinhNghiemKH_CN == null)
          {
              return Problem("Entity set 'StaffDbContext.kinhNghiemKH_CN'  is null.");
          }
            _context.kinhNghiemKH_CN.Add(kinhNghiemKH_CN);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKinhNghiemKH_CN", new { id = kinhNghiemKH_CN.Mahinhthuchoidong }, kinhNghiemKH_CN);
        }

        // DELETE: api/KinhNghiemKH_CN/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKinhNghiemKH_CN(int id)
        {
            if (_context.kinhNghiemKH_CN == null)
            {
                return NotFound();
            }
            var kinhNghiemKH_CN = await _context.kinhNghiemKH_CN.FindAsync(id);
            if (kinhNghiemKH_CN == null)
            {
                return NotFound();
            }

            _context.kinhNghiemKH_CN.Remove(kinhNghiemKH_CN);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KinhNghiemKH_CNExists(int id)
        {
            return (_context.kinhNghiemKH_CN?.Any(e => e.Mahinhthuchoidong == id)).GetValueOrDefault();
        }
    }
}
