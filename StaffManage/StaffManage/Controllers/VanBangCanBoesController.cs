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
    public class VanBangCanBoesController : ControllerBase
    {
        private readonly StaffDbContext _context;

        public VanBangCanBoesController(StaffDbContext context)
        {
            _context = context;
        }

        // GET: api/VanBangCanBoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VanBangCanBo>>> GetvanBang()
        {
          if (_context.vanBang == null)
          {
              return NotFound();
          }
            return await _context.vanBang.ToListAsync();
        }

        // GET: api/VanBangCanBoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VanBangCanBo>> GetVanBangCanBo(int id)
        {
          if (_context.vanBang == null)
          {
              return NotFound();
          }
            var vanBangCanBo = await _context.vanBang.FindAsync(id);

            if (vanBangCanBo == null)
            {
                return NotFound();
            }

            return vanBangCanBo;
        }

        // PUT: api/VanBangCanBoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVanBangCanBo(int id, VanBangCanBo vanBangCanBo)
        {
            if (id != vanBangCanBo.Mavanbang)
            {
                return BadRequest();
            }

            _context.Entry(vanBangCanBo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VanBangCanBoExists(id))
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

        // POST: api/VanBangCanBoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VanBangCanBo>> PostVanBangCanBo(VanBangCanBo vanBangCanBo)
        {
          if (_context.vanBang == null)
          {
              return Problem("Entity set 'StaffDbContext.vanBang'  is null.");
          }
            _context.vanBang.Add(vanBangCanBo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVanBangCanBo", new { id = vanBangCanBo.Mavanbang }, vanBangCanBo);
        }

        // DELETE: api/VanBangCanBoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVanBangCanBo(int id)
        {
            if (_context.vanBang == null)
            {
                return NotFound();
            }
            var vanBangCanBo = await _context.vanBang.FindAsync(id);
            if (vanBangCanBo == null)
            {
                return NotFound();
            }

            _context.vanBang.Remove(vanBangCanBo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VanBangCanBoExists(int id)
        {
            return (_context.vanBang?.Any(e => e.Mavanbang == id)).GetValueOrDefault();
        }
    }
}
