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
    public class QuaTrinhDaoTaosController : ControllerBase
    {
        private readonly StaffDbContext _context;

        public QuaTrinhDaoTaosController(StaffDbContext context)
        {
            _context = context;
        }

        // GET: api/QuaTrinhDaoTaos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuaTrinhDaoTao>>> GetquaTrinhDaoTao()
        {
          if (_context.quaTrinhDaoTao == null)
          {
              return NotFound();
          }
            return await _context.quaTrinhDaoTao.ToListAsync();
        }

        // GET: api/QuaTrinhDaoTaos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<QuaTrinhDaoTao>> GetQuaTrinhDaoTao(int id)
        {
          if (_context.quaTrinhDaoTao == null)
          {
              return NotFound();
          }
            var quaTrinhDaoTao = await _context.quaTrinhDaoTao.FindAsync(id);

            if (quaTrinhDaoTao == null)
            {
                return NotFound();
            }

            return quaTrinhDaoTao;
        }

        // PUT: api/QuaTrinhDaoTaos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuaTrinhDaoTao(int id, QuaTrinhDaoTao quaTrinhDaoTao)
        {
            if (id != quaTrinhDaoTao.Mabacdaotao)
            {
                return BadRequest();
            }

            _context.Entry(quaTrinhDaoTao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuaTrinhDaoTaoExists(id))
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

        // POST: api/QuaTrinhDaoTaos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<QuaTrinhDaoTao>> PostQuaTrinhDaoTao(QuaTrinhDaoTao quaTrinhDaoTao)
        {
          if (_context.quaTrinhDaoTao == null)
          {
              return Problem("Entity set 'StaffDbContext.quaTrinhDaoTao'  is null.");
          }
            _context.quaTrinhDaoTao.Add(quaTrinhDaoTao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuaTrinhDaoTao", new { id = quaTrinhDaoTao.Mabacdaotao }, quaTrinhDaoTao);
        }

        // DELETE: api/QuaTrinhDaoTaos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuaTrinhDaoTao(int id)
        {
            if (_context.quaTrinhDaoTao == null)
            {
                return NotFound();
            }
            var quaTrinhDaoTao = await _context.quaTrinhDaoTao.FindAsync(id);
            if (quaTrinhDaoTao == null)
            {
                return NotFound();
            }

            _context.quaTrinhDaoTao.Remove(quaTrinhDaoTao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QuaTrinhDaoTaoExists(int id)
        {
            return (_context.quaTrinhDaoTao?.Any(e => e.Mabacdaotao == id)).GetValueOrDefault();
        }
    }
}
