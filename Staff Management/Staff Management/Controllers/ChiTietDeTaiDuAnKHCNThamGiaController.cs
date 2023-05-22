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
    public class ChiTietDeTaiDuAnKHCNThamGiaController : ControllerBase
    {
        private readonly StaffDbContext _context;
        private readonly IMapper _mapper;

        public ChiTietDeTaiDuAnKHCNThamGiaController(StaffDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/ChiTietDeTaiDuAnKHCNThamGias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChiTietDeTaiDuAnKHCNThamGiaModel>>> GetchiTietDeTaiDuAnKHCNThamGia()
        {
          if (_context.chiTietDeTaiDuAnKHCNThamGia == null)
          {
              return NotFound();
          }
             
            var list = await _context.chiTietDeTaiDuAnKHCNThamGia.ToListAsync();
            return _mapper.Map<List<ChiTietDeTaiDuAnKHCNThamGiaModel>>(list);
        }

        // GET: api/ChiTietDeTaiDuAnKHCNThamGias/5
        [HttpGet("{madetai}/{macanbo}")]
        public async Task<ActionResult<ChiTietDeTaiDuAnKHCNThamGiaModel>> GetChiTietDeTaiDuAnKHCNThamGia(string madetai, string macanbo)
        {
          if (_context.chiTietDeTaiDuAnKHCNThamGia == null)
          {
              return NotFound();
          }
            var chiTietDeTaiDuAnKHCNThamGia = await _context.chiTietDeTaiDuAnKHCNThamGia.FindAsync(madetai, macanbo);

            if (chiTietDeTaiDuAnKHCNThamGia == null)
            {
                return NotFound();
            }

            return _mapper.Map<ChiTietDeTaiDuAnKHCNThamGiaModel>(chiTietDeTaiDuAnKHCNThamGia);
        }

        // PUT: api/ChiTietDeTaiDuAnKHCNThamGias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{madetai}/{macanbo}")]
        public async Task<IActionResult> PutChiTietDeTaiDuAnKHCNThamGia(string madetai, string macanbo, ChiTietDeTaiDuAnKHCNThamGiaModel chiTietDeTaiDuAnKHCNThamGia)
        {
            if (madetai != chiTietDeTaiDuAnKHCNThamGia.MaDeTai || macanbo != chiTietDeTaiDuAnKHCNThamGia.MaCanBo)
            {
                return BadRequest();
            }

            var chitiet = _mapper.Map<ChiTietDeTaiDuAnKHCNThamGia>(chiTietDeTaiDuAnKHCNThamGia);
            _context.chiTietDeTaiDuAnKHCNThamGia!.Update(chitiet);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChiTietDeTaiDuAnKHCNThamGiaExists(madetai, macanbo))
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

        // POST: api/ChiTietDeTaiDuAnKHCNThamGias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ChiTietDeTaiDuAnKHCNThamGia>> PostChiTietDeTaiDuAnKHCNThamGia(ChiTietDeTaiDuAnKHCNThamGiaModel chiTietDeTaiDuAnKHCNThamGia)
        {
          if (_context.chiTietDeTaiDuAnKHCNThamGia == null)
          {
              return Problem("Entity set 'StaffDbContext.chiTietDeTaiDuAnKHCNThamGia'  is null.");
          }

            var chitiet = _mapper.Map<ChiTietDeTaiDuAnKHCNThamGia>(chiTietDeTaiDuAnKHCNThamGia);
            _context.chiTietDeTaiDuAnKHCNThamGia.Add(chitiet);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ChiTietDeTaiDuAnKHCNThamGiaExists(chiTietDeTaiDuAnKHCNThamGia.MaDeTai, chiTietDeTaiDuAnKHCNThamGia.MaCanBo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        // DELETE: api/ChiTietDeTaiDuAnKHCNThamGias/5
        [HttpDelete("{madetai}/{macanbo}")]
        public async Task<IActionResult> DeleteChiTietDeTaiDuAnKHCNThamGia(string madetai, string macanbo)
        {
            if (_context.chiTietDeTaiDuAnKHCNThamGia == null)
            {
                return NotFound();
            }
            var chiTietDeTaiDuAnKHCNThamGia = await _context.chiTietDeTaiDuAnKHCNThamGia.FindAsync(madetai,macanbo);
            if (chiTietDeTaiDuAnKHCNThamGia == null)
            {
                return NotFound();
            }

            _context.chiTietDeTaiDuAnKHCNThamGia.Remove(chiTietDeTaiDuAnKHCNThamGia);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChiTietDeTaiDuAnKHCNThamGiaExists(string madetai, string macanbo)
        {
            return (_context.chiTietDeTaiDuAnKHCNThamGia?.Any(e => e.Madetai == madetai && e.Macanbo == macanbo)).GetValueOrDefault();
        }
    }
}
