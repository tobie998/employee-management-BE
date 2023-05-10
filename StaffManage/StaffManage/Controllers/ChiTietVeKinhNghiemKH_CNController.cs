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
        public async Task<ActionResult<ChiTietVeKinhNghiemKH_CnModel>> GetChiTietVeKinhNghiemKH_CN(int mahinhthuchoidong, string macanbo)
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
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChiTietVeKinhNghiemKH_CN(int id, ChiTietVeKinhNghiemKH_CnModel chiTietVeKinhNghiemKH_CN)
        {
            if (id != chiTietVeKinhNghiemKH_CN.Mahinhthuchoidong)
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
                if (!ChiTietVeKinhNghiemKH_CNExists(id))
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
                if (ChiTietVeKinhNghiemKH_CNExists(chiTietVeKinhNghiemKH_CN.Mahinhthuchoidong))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetChiTietVeKinhNghiemKH_CN", new { id = chiTietVeKinhNghiemKH_CN.Mahinhthuchoidong }, chiTietVeKinhNghiemKH_CN);
        }

        // DELETE: api/ChiTietVeKinhNghiemKH_CN/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChiTietVeKinhNghiemKH_CN(int id)
        {
            if (_context.chiTietVeKinhNghiemKH_CN == null)
            {
                return NotFound();
            }
            var chiTietVeKinhNghiemKH_CN = await _context.chiTietVeKinhNghiemKH_CN.FindAsync(id);
            if (chiTietVeKinhNghiemKH_CN == null)
            {
                return NotFound();
            }

            _context.chiTietVeKinhNghiemKH_CN.Remove(chiTietVeKinhNghiemKH_CN);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChiTietVeKinhNghiemKH_CNExists(int id)
        {
            return (_context.chiTietVeKinhNghiemKH_CN?.Any(e => e.Mahinhthuchoidong == id)).GetValueOrDefault();
        }
    }
}
