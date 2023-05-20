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
    public class ChiTietLinhVucNghienCuusController : ControllerBase
    {
        private readonly StaffDbContext _context;
        private readonly IMapper _mapper;

        public ChiTietLinhVucNghienCuusController(StaffDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/ChiTietLinhVucNghienCuus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChiTietLinhVucNghienCuuModel>>> GetchiTietLinhVucNghienCuu()
        {
          if (_context.chiTietLinhVucNghienCuu == null)
          {
              return NotFound();
          }

            var chitiet = await _context.chiTietLinhVucNghienCuu.ToListAsync(); ;
            return _mapper.Map<List<ChiTietLinhVucNghienCuuModel>>(chitiet);
        }

        // GET: api/ChiTietLinhVucNghienCuus/5
        [HttpGet("{machuyennganh}/{macanbo}")]
        public async Task<ActionResult<ChiTietLinhVucNghienCuuModel>> GetChiTietLinhVucNghienCuu(int machuyennganh, string macanbo)
        {
          if (_context.chiTietLinhVucNghienCuu == null)
          {
              return NotFound();
          }
            var chiTietLinhVucNghienCuu = await _context.chiTietLinhVucNghienCuu.FindAsync(machuyennganh, macanbo);

            if (chiTietLinhVucNghienCuu == null)
            {
                return NotFound();
            }

            return _mapper.Map<ChiTietLinhVucNghienCuuModel>(chiTietLinhVucNghienCuu);
        }

        // PUT: api/ChiTietLinhVucNghienCuus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{machuyennganh}/{macanbo}")]
        public async Task<IActionResult> PutChiTietLinhVucNghienCuu(int machuyennganh, string macanbo, ChiTietLinhVucNghienCuuModel chiTietLinhVucNghienCuu)
        {
            if (machuyennganh != chiTietLinhVucNghienCuu.MaChuyenNganh || macanbo != chiTietLinhVucNghienCuu.MaCanbo)
            {
                return BadRequest();
            }
            var chitiet = _mapper.Map<ChiTietLinhVucNghienCuu>(chiTietLinhVucNghienCuu);
            _context.chiTietLinhVucNghienCuu!.Update(chitiet);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChiTietLinhVucNghienCuuExists(machuyennganh, macanbo))
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

        // POST: api/ChiTietLinhVucNghienCuus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ChiTietLinhVucNghienCuu>> PostChiTietLinhVucNghienCuu(ChiTietLinhVucNghienCuuModel chiTietLinhVucNghienCuu)
        {
          if (_context.chiTietLinhVucNghienCuu == null)
          {
              return Problem("Entity set 'StaffDbContext.chiTietLinhVucNghienCuu'  is null.");
          }
            var chitiet = _mapper.Map<ChiTietLinhVucNghienCuu>(chiTietLinhVucNghienCuu);
            _context.chiTietLinhVucNghienCuu.Add(chitiet);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ChiTietLinhVucNghienCuuExists(chiTietLinhVucNghienCuu.MaChuyenNganh, chiTietLinhVucNghienCuu.MaCanbo))
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

        // DELETE: api/ChiTietLinhVucNghienCuus/5
        [HttpDelete("{machuyennganh}/{macanbo}")]
        public async Task<IActionResult> DeleteChiTietLinhVucNghienCuu(int machuyennganh, string macanbo)
        {
            if (_context.chiTietLinhVucNghienCuu == null)
            {
                return NotFound();
            }
            var chiTietLinhVucNghienCuu = await _context.chiTietLinhVucNghienCuu.FindAsync(machuyennganh, macanbo);
            if (chiTietLinhVucNghienCuu == null)
            {
                return NotFound();
            }

            _context.chiTietLinhVucNghienCuu.Remove(chiTietLinhVucNghienCuu);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        
        private bool ChiTietLinhVucNghienCuuExists(int machuyennganh, string macanbo)
        {
            return (_context.chiTietLinhVucNghienCuu?.Any(e => e.Machuyennganh == machuyennganh && e.Macanbo == macanbo)).GetValueOrDefault();
        }

    }
}
