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
    public class DeTaiDuAnKHCNThamGiasController : ControllerBase
    {
        private readonly StaffDbContext _context;

        public DeTaiDuAnKHCNThamGiasController(StaffDbContext context)
        {
            _context = context;
        }

        // GET: api/DeTaiDuAnKHCNThamGias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeTaiDuAnKHCNThamGia>>> GetdeTaiDuAn()
        {
          if (_context.deTaiDuAn == null)
          {
              return NotFound();
          }
            return await _context.deTaiDuAn.ToListAsync();
        }

        // GET: api/DeTaiDuAnKHCNThamGias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DeTaiDuAnKHCNThamGia>> GetDeTaiDuAnKHCNThamGia(int id)
        {
          if (_context.deTaiDuAn == null)
          {
              return NotFound();
          }
            var deTaiDuAnKHCNThamGia = await _context.deTaiDuAn.FindAsync(id);

            if (deTaiDuAnKHCNThamGia == null)
            {
                return NotFound();
            }

            return deTaiDuAnKHCNThamGia;
        }

        // PUT: api/DeTaiDuAnKHCNThamGias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeTaiDuAnKHCNThamGia(int id, DeTaiDuAnKHCNThamGia deTaiDuAnKHCNThamGia)
        {
            if (id != deTaiDuAnKHCNThamGia.Madetai)
            {
                return BadRequest();
            }

            _context.Entry(deTaiDuAnKHCNThamGia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeTaiDuAnKHCNThamGiaExists(id))
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

        // POST: api/DeTaiDuAnKHCNThamGias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DeTaiDuAnKHCNThamGia>> PostDeTaiDuAnKHCNThamGia(DeTaiDuAnKHCNThamGia deTaiDuAnKHCNThamGia)
        {
          if (_context.deTaiDuAn == null)
          {
              return Problem("Entity set 'StaffDbContext.deTaiDuAn'  is null.");
          }
            _context.deTaiDuAn.Add(deTaiDuAnKHCNThamGia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDeTaiDuAnKHCNThamGia", new { id = deTaiDuAnKHCNThamGia.Madetai }, deTaiDuAnKHCNThamGia);
        }

        // DELETE: api/DeTaiDuAnKHCNThamGias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeTaiDuAnKHCNThamGia(int id)
        {
            if (_context.deTaiDuAn == null)
            {
                return NotFound();
            }
            var deTaiDuAnKHCNThamGia = await _context.deTaiDuAn.FindAsync(id);
            if (deTaiDuAnKHCNThamGia == null)
            {
                return NotFound();
            }

            _context.deTaiDuAn.Remove(deTaiDuAnKHCNThamGia);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DeTaiDuAnKHCNThamGiaExists(int id)
        {
            return (_context.deTaiDuAn?.Any(e => e.Madetai == id)).GetValueOrDefault();
        }
    }
}
