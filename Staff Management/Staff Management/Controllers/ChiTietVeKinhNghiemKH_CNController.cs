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
    public class ChiTietVeKinhNghiemKH_CNController : ControllerBase
    {
        private readonly StaffDbContext _context;
        private readonly IMapper _mapper;

        public ChiTietVeKinhNghiemKH_CNController(StaffDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/ChiTietVeKinhNghiemKH_CN
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChiTietVeKinhNghiemKH_CnModel>>> GetchiTietVeKinhNghiemKH_CN()
        {
          if (_context.chiTietVeKinhNghiemKH_CN == null)
          {
              return NotFound();
          }
          var list = await _context.chiTietVeKinhNghiemKH_CN.ToListAsync();
            return _mapper.Map<List<ChiTietVeKinhNghiemKH_CnModel>>(list);
        }

        // GET: api/ChiTietVeKinhNghiemKH_CN/5
        [HttpGet("{mahinhthuchoidong}/{macanbo}")]
        public async Task<ActionResult<ChiTietVeKinhNghiemKH_CnModel>> GetChiTietVeKinhNghiemKH_CN(string mahinhthuchoidong, string macanbo)
        {
          if (_context.chiTietVeKinhNghiemKH_CN == null)
          {
              return NotFound();
          }
            var chiTietVeKinhNghiemKH_CN = await _context.chiTietVeKinhNghiemKH_CN.FindAsync(mahinhthuchoidong,macanbo);

            if (chiTietVeKinhNghiemKH_CN == null)
            {
                return NotFound();
            }

            return _mapper.Map<ChiTietVeKinhNghiemKH_CnModel>(chiTietVeKinhNghiemKH_CN);
        }

        // PUT: api/ChiTietVeKinhNghiemKH_CN/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{mahinhthuchoidong}/{macanbo}")]
        public async Task<IActionResult> PutChiTietVeKinhNghiemKH_CN(string mahinhthuchoidong, string macanbo, ChiTietVeKinhNghiemKH_CnModel chiTietVeKinhNghiemKH_CN)
        {
            if (mahinhthuchoidong != chiTietVeKinhNghiemKH_CN.MaHinhThucHoiDong || macanbo!= chiTietVeKinhNghiemKH_CN.MaCanBo)
            {
                return BadRequest();
            }

            var chitiet = _mapper.Map<ChiTietVeKinhNghiemKH_CN>(chiTietVeKinhNghiemKH_CN);
            _context.chiTietVeKinhNghiemKH_CN!.Update(chitiet);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChiTietVeKinhNghiemKH_CNExists(mahinhthuchoidong, macanbo))
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

        // POST: api/ChiTietVeKinhNghiemKH_CN
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ChiTietVeKinhNghiemKH_CN>> PostChiTietVeKinhNghiemKH_CN(ChiTietVeKinhNghiemKH_CnModel chiTietVeKinhNghiemKH_CN)
        {
          if (_context.chiTietVeKinhNghiemKH_CN == null)
          {
              return Problem("Entity set 'StaffDbContext.chiTietVeKinhNghiemKH_CN'  is null.");
          }

            var chitiet = _mapper.Map<ChiTietVeKinhNghiemKH_CN>(chiTietVeKinhNghiemKH_CN);
            _context.chiTietVeKinhNghiemKH_CN.Add(chitiet);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ChiTietVeKinhNghiemKH_CNExists(chiTietVeKinhNghiemKH_CN.MaHinhThucHoiDong, chiTietVeKinhNghiemKH_CN.MaCanBo))
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

        // DELETE: api/ChiTietVeKinhNghiemKH_CN/5
        [HttpDelete("{mahinhthuchoidong}/{macanbo}")]
        public async Task<IActionResult> DeleteChiTietVeKinhNghiemKH_CN(string mahinhthuchoidong, string macanbo)
        {
            if (_context.chiTietVeKinhNghiemKH_CN == null)
            {
                return NotFound();
            }
            var chiTietVeKinhNghiemKH_CN = await _context.chiTietVeKinhNghiemKH_CN.FindAsync(mahinhthuchoidong,macanbo);
            if (chiTietVeKinhNghiemKH_CN == null)
            {
                return NotFound();
            }

            _context.chiTietVeKinhNghiemKH_CN.Remove(chiTietVeKinhNghiemKH_CN);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChiTietVeKinhNghiemKH_CNExists(string mahinhthuchoidong, string macanbo)
        {
            return (_context.chiTietVeKinhNghiemKH_CN?.Any(e => e.Mahinhthuchoidong == mahinhthuchoidong && e.Macanbo == macanbo)).GetValueOrDefault();
        }
    }
}
