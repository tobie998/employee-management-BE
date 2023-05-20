using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StaffManage.Data;
using StaffManage.Models;

namespace StaffManage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuaTrinhDaoTaosController : ControllerBase
    {
        private readonly StaffDbContext _context;
        private readonly IMapper _mapper;

        public QuaTrinhDaoTaosController(StaffDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/QuaTrinhDaoTaos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuaTrinhDaoTaoModel>>> GetquaTrinhDaoTao()
        {
          if (_context.quaTrinhDaoTao == null)
          {
              return NotFound();
          }
          var list = await _context.quaTrinhDaoTao.Where(e => e.isDelete == 0).ToListAsync();
            return _mapper.Map<List<QuaTrinhDaoTaoModel>>(list);
        }

        // GET: api/QuaTrinhDaoTaos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<QuaTrinhDaoTaoModel>> GetQuaTrinhDaoTao(int id)
        {
          if (_context.quaTrinhDaoTao == null)
          {
              return NotFound();
          }
            var quaTrinhDaoTao = await _context.quaTrinhDaoTao.SingleOrDefaultAsync(cb => cb.Mabacdaotao == id && cb.isDelete == 0);

            if (quaTrinhDaoTao == null)
            {
                return NotFound();
            }

            return _mapper.Map<QuaTrinhDaoTaoModel>(quaTrinhDaoTao);
        }

        // PUT: api/QuaTrinhDaoTaos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuaTrinhDaoTao(int id, QuaTrinhDaoTaoModel quaTrinhDaoTao)
        {
            if (id != quaTrinhDaoTao.MaBacDaoTao)
            {
                return BadRequest();
            }

            var chitiet = _mapper.Map<QuaTrinhDaoTao>(quaTrinhDaoTao);
            _context.quaTrinhDaoTao!.Update(chitiet);

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
        public async Task<ActionResult<QuaTrinhDaoTao>> PostQuaTrinhDaoTao(QuaTrinhDaoTaoModel quaTrinhDaoTao)
        {
          if (_context.quaTrinhDaoTao == null)
          {
              return Problem("Entity set 'StaffDbContext.quaTrinhDaoTao'  is null.");
          }
            var chitiet = _mapper.Map<QuaTrinhDaoTao>(quaTrinhDaoTao);
            _context.quaTrinhDaoTao.Add(chitiet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuaTrinhDaoTao", new { id = quaTrinhDaoTao.MaBacDaoTao }, quaTrinhDaoTao);
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
            quaTrinhDaoTao.isDelete = 1;
            _context.quaTrinhDaoTao.Update(quaTrinhDaoTao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QuaTrinhDaoTaoExists(int id)
        {
            return (_context.quaTrinhDaoTao?.Any(e => e.Mabacdaotao == id)).GetValueOrDefault();
        }
    }
}
