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
    public class ChiTietQuaTrinhCongTacController : ControllerBase
    {
        private readonly StaffDbContext _context;
        private readonly IMapper _mapper;

        public ChiTietQuaTrinhCongTacController(StaffDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/ChiTietQuaTrinhCongTacs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChiTietQuaTrinhCongTacModel>>> GetchiTietQuaTrinhCongTac()
        {
          if (_context.chiTietQuaTrinhCongTac == null)
          {
              return NotFound();
          }
            var list = await _context.chiTietQuaTrinhCongTac.ToListAsync();
            return _mapper.Map<List<ChiTietQuaTrinhCongTacModel>>(list);
        }

        // GET: api/ChiTietQuaTrinhCongTacs/5
        [HttpGet("{maquatrinhcongtac}/{macanbo}")]
        public async Task<ActionResult<ChiTietQuaTrinhCongTacModel>> GetChiTietQuaTrinhCongTac(string maquatrinhcongtac, string macanbo)
        {
          if (_context.chiTietQuaTrinhCongTac == null)
          {
              return NotFound();
          }
            var chiTietQuaTrinhCongTac = await _context.chiTietQuaTrinhCongTac.FindAsync(maquatrinhcongtac, macanbo);

            if (chiTietQuaTrinhCongTac == null)
            {
                return NotFound();
            }

            return _mapper.Map<ChiTietQuaTrinhCongTacModel>(chiTietQuaTrinhCongTac);
        }

        // PUT: api/ChiTietQuaTrinhCongTacs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{maquatrinhcongtac}/{macanbo}")]
        public async Task<IActionResult> PutChiTietQuaTrinhCongTac(string maquatrinhcongtac, string macanbo, ChiTietQuaTrinhCongTacModel chiTietQuaTrinhCongTac)
        {
            if (maquatrinhcongtac != chiTietQuaTrinhCongTac.MaQuaTrinhCongTac || macanbo != chiTietQuaTrinhCongTac.MaCanBo)
            {
                return BadRequest();
            }
            var chitiet = _mapper.Map<ChiTietQuaTrinhCongTac>(chiTietQuaTrinhCongTac);
            _context.chiTietQuaTrinhCongTac!.Update(chitiet);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChiTietQuaTrinhCongTacExists(maquatrinhcongtac, macanbo))
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

        // POST: api/ChiTietQuaTrinhCongTacs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ChiTietQuaTrinhCongTac>> PostChiTietQuaTrinhCongTac(ChiTietQuaTrinhCongTacModel chiTietQuaTrinhCongTac)
        {
          if (_context.chiTietQuaTrinhCongTac == null)
          {
              return Problem("Entity set 'StaffDbContext.chiTietQuaTrinhCongTac'  is null.");
          }
            var chitiet = _mapper.Map<ChiTietQuaTrinhCongTac>(chiTietQuaTrinhCongTac);
            _context.chiTietQuaTrinhCongTac.Add(chitiet);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ChiTietQuaTrinhCongTacExists(chiTietQuaTrinhCongTac.MaQuaTrinhCongTac, chiTietQuaTrinhCongTac.MaCanBo))
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

        // DELETE: api/ChiTietQuaTrinhCongTacs/5
        [HttpDelete("{maquatrinhcongtac}/{macanbo}")]
        public async Task<IActionResult> DeleteChiTietQuaTrinhCongTac(string maquatrinhcongtac, string macanbo)
        {
            if (_context.chiTietQuaTrinhCongTac == null)
            {
                return NotFound();
            }
            var chiTietQuaTrinhCongTac = await _context.chiTietQuaTrinhCongTac.FindAsync(maquatrinhcongtac, macanbo);
            if (chiTietQuaTrinhCongTac == null)
            {
                return NotFound();
            }

            _context.chiTietQuaTrinhCongTac.Remove(chiTietQuaTrinhCongTac);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChiTietQuaTrinhCongTacExists(string maquatrinhcongtac, string macanbo)
        {
            return (_context.chiTietQuaTrinhCongTac?.Any(e => e.Maquatrinhcongtac == maquatrinhcongtac && e.Macanbo == macanbo)).GetValueOrDefault();
        }
    }
}
