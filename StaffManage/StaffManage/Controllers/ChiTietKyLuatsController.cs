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
    public class ChiTietKyLuatsController : ControllerBase
    {
        private readonly StaffDbContext _context;
        private readonly IMapper _mapper;

        public ChiTietKyLuatsController(StaffDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/ChiTietKyLuats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChiTietKyLuatModel>>> GetchiTietKyLuat()
        {
          if (_context.chiTietKyLuat == null)
          {
              return NotFound();
          }
            var list = await _context.chiTietKyLuat.ToListAsync();
            return _mapper.Map<List<ChiTietKyLuatModel>>(list);
        }

        // GET: api/ChiTietKyLuats/5
        [HttpGet("{makyluat}/{macanbo}")]
        public async Task<ActionResult<ChiTietKyLuatModel>> GetChiTietKyLuat(int makyluat, string macanbo)
        {
          if (_context.chiTietKyLuat == null)
          {
              return NotFound();
          }
            var chiTietKyLuat = await _context.chiTietKyLuat.FindAsync(makyluat, macanbo);

            if (chiTietKyLuat == null)
            {
                return NotFound();
            }

            return _mapper.Map<ChiTietKyLuatModel>(chiTietKyLuat);
        }

        // PUT: api/ChiTietKyLuats/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{makyluat}/{macanbo}")]
        public async Task<IActionResult> PutChiTietKyLuat(int makyluat, string macanbo, ChiTietKyLuat chiTietKyLuat)
        {
            if (makyluat != chiTietKyLuat.Makyluat || macanbo != chiTietKyLuat.Macanbo)
            {
                return BadRequest();
            }

            var chitiet = _mapper.Map<ChiTietKyLuat>(chiTietKyLuat);
            _context.chiTietKyLuat!.Update(chitiet);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChiTietKyLuatExists(makyluat, macanbo))
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

        // POST: api/ChiTietKyLuats
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ChiTietKyLuat>> PostChiTietKyLuat(ChiTietKyLuatModel chiTietKyLuat)
        {
          if (_context.chiTietKyLuat == null)
          {
              return Problem("Entity set 'StaffDbContext.chiTietKyLuat'  is null.");
          }

            var chitiet = _mapper.Map<ChiTietKyLuat>(chiTietKyLuat);
            _context.chiTietKyLuat.Add(chitiet);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ChiTietKyLuatExists(chiTietKyLuat.Makyluat, chiTietKyLuat.Macanbo))
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

        // DELETE: api/ChiTietKyLuats/5
        [HttpDelete("{makyluat}/{macanbo}")]
        public async Task<IActionResult> DeleteChiTietKyLuat(int makyluat, string macanbo)
        {
            if (_context.chiTietKyLuat == null)
            {
                return NotFound();
            }
            var chiTietKyLuat = await _context.chiTietKyLuat.FindAsync(makyluat, macanbo);
            if (chiTietKyLuat == null)
            {
                return NotFound();
            }

            _context.chiTietKyLuat.Remove(chiTietKyLuat);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChiTietKyLuatExists(int makyluat, string macanbo)
        {
            return (_context.chiTietKyLuat?.Any(e => e.Makyluat == makyluat && e.Macanbo == macanbo)).GetValueOrDefault();
        }
    }
}
