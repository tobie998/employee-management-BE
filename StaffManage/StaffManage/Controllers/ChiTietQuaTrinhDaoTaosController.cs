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
    public class ChiTietQuaTrinhDaoTaosController : ControllerBase
    {
        private readonly StaffDbContext _context;
        private readonly IMapper _mapper;

        public ChiTietQuaTrinhDaoTaosController(StaffDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/ChiTietQuaTrinhDaoTaos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChiTietQuaTrinhDaoTaoModel>>> GetchiTietQuaTrinhDaoTao()
        {
          if (_context.chiTietQuaTrinhDaoTao == null)
          {
              return NotFound();
          }
          var chitiet = await _context.chiTietQuaTrinhDaoTao.ToListAsync();
            return _mapper.Map<List<ChiTietQuaTrinhDaoTaoModel>>(chitiet);
        }

        // GET: api/ChiTietQuaTrinhDaoTaos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChiTietQuaTrinhDaoTaoModel>> GetChiTietQuaTrinhDaoTao(int id)
        {
          if (_context.chiTietQuaTrinhDaoTao == null)
          {
              return NotFound();
          }
            var chiTietQuaTrinhDaoTao = await _context.chiTietQuaTrinhDaoTao.FindAsync(id);

            if (chiTietQuaTrinhDaoTao == null)
            {
                return NotFound();
            }

            return _mapper.Map<ChiTietQuaTrinhDaoTaoModel>(chiTietQuaTrinhDaoTao);
        }

        // PUT: api/ChiTietQuaTrinhDaoTaos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChiTietQuaTrinhDaoTao(int id, ChiTietQuaTrinhDaoTaoModel chiTietQuaTrinhDaoTao)
        {
            if (id != chiTietQuaTrinhDaoTao.Mabacdaotao)
            {
                return BadRequest();
            }

            var chitiet = _mapper.Map<ChiTietQuaTrinhDaoTao>(chiTietQuaTrinhDaoTao);
            _context.chiTietQuaTrinhDaoTao.Add(chitiet);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChiTietQuaTrinhDaoTaoExists(id))
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

        // POST: api/ChiTietQuaTrinhDaoTaos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ChiTietQuaTrinhDaoTao>> PostChiTietQuaTrinhDaoTao(ChiTietQuaTrinhDaoTaoModel chiTietQuaTrinhDaoTao)
        {
          if (_context.chiTietQuaTrinhDaoTao == null)
          {
              return Problem("Entity set 'StaffDbContext.chiTietQuaTrinhDaoTao'  is null.");
          }
            //_context.chiTietQuaTrinhDaoTao.Add(chiTietQuaTrinhDaoTao);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ChiTietQuaTrinhDaoTaoExists(chiTietQuaTrinhDaoTao.Mabacdaotao))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetChiTietQuaTrinhDaoTao", new { id = chiTietQuaTrinhDaoTao.Mabacdaotao }, chiTietQuaTrinhDaoTao);
        }

        // DELETE: api/ChiTietQuaTrinhDaoTaos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChiTietQuaTrinhDaoTao(int id)
        {
            if (_context.chiTietQuaTrinhDaoTao == null)
            {
                return NotFound();
            }
            var chiTietQuaTrinhDaoTao = await _context.chiTietQuaTrinhDaoTao.FindAsync(id);
            if (chiTietQuaTrinhDaoTao == null)
            {
                return NotFound();
            }

            _context.chiTietQuaTrinhDaoTao.Remove(chiTietQuaTrinhDaoTao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChiTietQuaTrinhDaoTaoExists(int id)
        {
            return (_context.chiTietQuaTrinhDaoTao?.Any(e => e.Mabacdaotao == id)).GetValueOrDefault();
        }
    }
}
