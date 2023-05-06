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
    public class ChucDanhController : ControllerBase
    {
        private readonly StaffDbContext _context;

        public ChucDanhController(StaffDbContext context)
        {
            _context = context;
        }

        // GET: api/ChucDanh
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChucDanh>>> GetchucDanh()
        {
          if (_context.chucDanh == null)
          {
              return NotFound();
          }
            return await _context.chucDanh.ToListAsync();
        }

        // GET: api/ChucDanh/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChucDanh>> GetChucDanh(int id)
        {
          if (_context.chucDanh == null)
          {
              return NotFound();
          }
            var chucDanh = await _context.chucDanh.FindAsync(id);

            if (chucDanh == null)
            {
                return NotFound();
            }

            return chucDanh;
        }

        // PUT: api/ChucDanh/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChucDanh(int id, ChucDanh chucDanh)
        {
            if (id != chucDanh.Machucdanh)
            {
                return BadRequest();
            }

            _context.Entry(chucDanh).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChucDanhExists(id))
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

        // POST: api/ChucDanh
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ChucDanh>> PostChucDanh(ChucDanh chucDanh)
        {
          if (_context.chucDanh == null)
          {
              return Problem("Entity set 'StaffDbContext.chucDanh'  is null.");
          }
            _context.chucDanh.Add(chucDanh);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChucDanh", new { id = chucDanh.Machucdanh }, chucDanh);
        }

        // DELETE: api/ChucDanh/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChucDanh(int id)
        {
            if (_context.chucDanh == null)
            {
                return NotFound();
            }
            var chucDanh = await _context.chucDanh.FindAsync(id);
            if (chucDanh == null)
            {
                return NotFound();
            }

            _context.chucDanh.Remove(chucDanh);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChucDanhExists(int id)
        {
            return (_context.chucDanh?.Any(e => e.Machucdanh == id)).GetValueOrDefault();
        }
    }
}
