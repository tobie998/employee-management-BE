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
    public class DonViController : ControllerBase
    {
        private readonly StaffDbContext _context;

        public DonViController(StaffDbContext context)
        {
            _context = context;
        }

        // GET: api/DonVi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DonVi>>> Getdonvi()
        {
          if (_context.donvi == null)
          {
              return NotFound();
          }
            return await _context.donvi.Where(e => e.isDelete == 0).ToListAsync();
        }

        // GET: api/DonVi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DonVi>> GetDonVi(int id)
        {
          if (_context.donvi == null)
          {
              return NotFound();
          }
            var donVi = await _context.donvi.SingleOrDefaultAsync(cb => cb.Madonvi == id && cb.isDelete == 0);

            if (donVi == null)
            {
                return NotFound();
            }

            return donVi;
        }

        // PUT: api/DonVi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDonVi(int id, DonVi donVi)
        {
            if (id != donVi.Madonvi)
            {
                return BadRequest();
            }

            _context.Entry(donVi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DonViExists(id))
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

        // POST: api/DonVi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DonVi>> PostDonVi(DonVi donVi)
        {
          if (_context.donvi == null)
          {
              return Problem("Entity set 'StaffDbContext.donvi'  is null.");
          }
            _context.donvi.Add(donVi);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDonVi", new { id = donVi.Madonvi }, donVi);
        }

        // DELETE: api/DonVi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDonVi(int id)
        {
            if (_context.donvi == null)
            {
                return NotFound();
            }
            var donVi = await _context.donvi.FindAsync(id);
            if (donVi == null)
            {
                return NotFound();
            }
            donVi.isDelete = 1;
            _context.donvi.Update(donVi);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DonViExists(int id)
        {
            return (_context.donvi?.Any(e => e.Madonvi == id)).GetValueOrDefault();
        }
    }
}
