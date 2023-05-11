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
    public class ChiTietCongTrinhKH_CNController : ControllerBase
    {
        private readonly StaffDbContext _context;
        private readonly IMapper _mapper;

        public ChiTietCongTrinhKH_CNController(StaffDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/ChiTietCongTrinhKH_CN
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChiTietCongTrinhKH_CNModel>>> GetchiTietCongTrinhKH_CN()
        {
          if (_context.chiTietCongTrinhKH_CN == null)
          {
              return NotFound();
          }
            var list = await _context.chiTietCongTrinhKH_CN.ToListAsync();
            return _mapper.Map<List<ChiTietCongTrinhKH_CNModel>>(list);
        }

        // GET: api/ChiTietCongTrinhKH_CN/5
        [HttpGet("{macongtrinhKH}/{macanbo}")]
        public async Task<ActionResult<ChiTietCongTrinhKH_CNModel>> GetChiTietCongTrinhKH_CN(int macongtrinhKH, string macanbo)
        {
          if (_context.chiTietCongTrinhKH_CN == null)
          {
              return NotFound();
          }
            var chiTietCongTrinhKH_CN = await _context.chiTietCongTrinhKH_CN.FindAsync(macongtrinhKH, macanbo);

            if (chiTietCongTrinhKH_CN == null)
            {
                return NotFound();
            }

            return _mapper.Map<ChiTietCongTrinhKH_CNModel>(chiTietCongTrinhKH_CN);
        }

        // PUT: api/ChiTietCongTrinhKH_CN/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{macongtrinhKH}/{macanbo}")]
        public async Task<IActionResult> PutChiTietCongTrinhKH_CN(int macongtrinhKH, string macanbo, ChiTietCongTrinhKH_CNModel chiTietCongTrinhKH_CN)
        {
            if (macongtrinhKH != chiTietCongTrinhKH_CN.MacongtrinhKH || macanbo != chiTietCongTrinhKH_CN.Macanbo)
            {
                return BadRequest();
            }
            var chitiet = _mapper.Map<ChiTietCongTrinhKH_CN>(chiTietCongTrinhKH_CN);
            _context.chiTietCongTrinhKH_CN!.Update(chitiet);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChiTietCongTrinhKH_CNExists(macongtrinhKH, macanbo))
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

        // POST: api/ChiTietCongTrinhKH_CN
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ChiTietCongTrinhKH_CN>> PostChiTietCongTrinhKH_CN(ChiTietCongTrinhKH_CNModel chiTietCongTrinhKH_CN)
        {
          if (_context.chiTietCongTrinhKH_CN == null)
          {
              return Problem("Entity set 'StaffDbContext.chiTietCongTrinhKH_CN'  is null.");
          }
            var chitiet = _mapper.Map<ChiTietCongTrinhKH_CN>(chiTietCongTrinhKH_CN);
            _context.chiTietCongTrinhKH_CN.Add(chitiet);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ChiTietCongTrinhKH_CNExists(chiTietCongTrinhKH_CN.MacongtrinhKH, chiTietCongTrinhKH_CN.Macanbo))
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

        // DELETE: api/ChiTietCongTrinhKH_CN/5
        [HttpDelete("{macongtrinhKH}/{macanbo}")]
        public async Task<IActionResult> DeleteChiTietCongTrinhKH_CN(int macongtrinhKH, string macanbo)
        {
            if (_context.chiTietCongTrinhKH_CN == null)
            {
                return NotFound();
            }
            var chiTietCongTrinhKH_CN = await _context.chiTietCongTrinhKH_CN.FindAsync(macongtrinhKH, macanbo);
            if (chiTietCongTrinhKH_CN == null)
            {
                return NotFound();
            }

            _context.chiTietCongTrinhKH_CN.Remove(chiTietCongTrinhKH_CN);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChiTietCongTrinhKH_CNExists(int macongtrinhKH, string macanbo)
        {
            return (_context.chiTietCongTrinhKH_CN?.Any(e => e.MacongtrinhKH == macongtrinhKH && e.Macanbo == macanbo)).GetValueOrDefault();
        }
    }
}
