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
    public class ChiTietChuyenNganhKH_CNController : ControllerBase
    {
        private readonly StaffDbContext _context;
        private readonly IMapper _mapper;

        public ChiTietChuyenNganhKH_CNController(StaffDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/ChiTietLinhVucNghienCuus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChiTietChuyenNganhKH_CNModel>>> GetchiTietLinhVucNghienCuu()
        {
          if (_context.chiTietChuyenNganhKH_CN == null)
          {
              return NotFound();
          }

            var chitiet = await _context.chiTietChuyenNganhKH_CN.ToListAsync(); ;
            return _mapper.Map<List<ChiTietChuyenNganhKH_CNModel>>(chitiet);
        }

        // GET: api/ChiTietLinhVucNghienCuus/5
        [HttpGet("{machuyennganh}/{macanbo}")]
        public async Task<ActionResult<ChiTietChuyenNganhKH_CNModel>> GetChiTietLinhVucNghienCuu(string machuyennganh, string macanbo)
        {
          if (_context.chiTietChuyenNganhKH_CN == null)
          {
              return NotFound();
          }
            var chiTietLinhVucNghienCuu = await _context.chiTietChuyenNganhKH_CN.FindAsync(machuyennganh, macanbo);

            if (chiTietLinhVucNghienCuu == null)
            {
                return NotFound();
            }

            return _mapper.Map<ChiTietChuyenNganhKH_CNModel>(chiTietLinhVucNghienCuu);
        }

        // PUT: api/ChiTietLinhVucNghienCuus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{machuyennganh}/{macanbo}")]
        public async Task<IActionResult> PutChiTietLinhVucNghienCuu(string machuyennganh, string macanbo, ChiTietChuyenNganhKH_CNModel chiTietLinhVucNghienCuu)
        {
            if (machuyennganh != chiTietLinhVucNghienCuu.MaChuyenNganh || macanbo != chiTietLinhVucNghienCuu.MaCanbo)
            {
                return BadRequest();
            }
            var chitiet = _mapper.Map<ChiTietChuyenNganhKH_CN>(chiTietLinhVucNghienCuu);
            _context.chiTietChuyenNganhKH_CN!.Update(chitiet);

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
        public async Task<ActionResult<ChiTietChuyenNganhKH_CNModel>> PostChiTietLinhVucNghienCuu(ChiTietChuyenNganhKH_CNModel chiTietLinhVucNghienCuu)
        {
          if (_context.chiTietChuyenNganhKH_CN == null)
          {
              return Problem("Entity set 'StaffDbContext.chiTietLinhVucNghienCuu'  is null.");
          }
            var chitiet = _mapper.Map<ChiTietChuyenNganhKH_CN>(chiTietLinhVucNghienCuu);
            _context.chiTietChuyenNganhKH_CN.Add(chitiet);
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
        public async Task<IActionResult> DeleteChiTietLinhVucNghienCuu(string machuyennganh, string macanbo)
        {
            if (_context.chiTietChuyenNganhKH_CN == null)
            {
                return NotFound();
            }
            var chiTietLinhVucNghienCuu = await _context.chiTietChuyenNganhKH_CN.FindAsync(machuyennganh, macanbo);
            if (chiTietLinhVucNghienCuu == null)
            {
                return NotFound();
            }

            _context.chiTietChuyenNganhKH_CN.Remove(chiTietLinhVucNghienCuu);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        
        private bool ChiTietLinhVucNghienCuuExists(string machuyennganh, string macanbo)
        {
            return (_context.chiTietChuyenNganhKH_CN?.Any(e => e.Machuyennganh == machuyennganh && e.Macanbo == macanbo)).GetValueOrDefault();
        }

    }
}
