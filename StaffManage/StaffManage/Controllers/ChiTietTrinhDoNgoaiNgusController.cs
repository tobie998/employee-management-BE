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
    public class ChiTietTrinhDoNgoaiNgusController : ControllerBase
    {
        private readonly StaffDbContext _context;
        private readonly IMapper _mapper;


        public ChiTietTrinhDoNgoaiNgusController(StaffDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/ChiTietTrinhDoNgoaiNgus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChiTietTrinhDoNgoaiNguModel>>> GetchiTietTrinhDoNgoaiNgu()
        {
          if (_context.chiTietTrinhDoNgoaiNgu == null)
          {
              return NotFound();
          }
            var list = await _context.chiTietTrinhDoNgoaiNgu.ToListAsync();
            return _mapper.Map<List<ChiTietTrinhDoNgoaiNguModel>>(list);
        }

        // GET: api/ChiTietTrinhDoNgoaiNgus/5
        [HttpGet("{mangoaingu}/{macanbo}")]
        public async Task<ActionResult<ChiTietTrinhDoNgoaiNguModel>> GetChiTietTrinhDoNgoaiNgu(int mangoaingu, string macanbo)
        {
          if (_context.chiTietTrinhDoNgoaiNgu == null)
          {
              return NotFound();
          }
            var chiTietTrinhDoNgoaiNgu = await _context.chiTietTrinhDoNgoaiNgu.FindAsync(mangoaingu, macanbo);

            if (chiTietTrinhDoNgoaiNgu == null)
            {
                return NotFound();
            }

            return _mapper.Map<ChiTietTrinhDoNgoaiNguModel>(chiTietTrinhDoNgoaiNgu);
        }

        // PUT: api/ChiTietTrinhDoNgoaiNgus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{mangoaingu}/{macanbo}")]
        public async Task<IActionResult> PutChiTietTrinhDoNgoaiNgu(int mangoaingu, string macanbo, ChiTietTrinhDoNgoaiNguModel chiTietTrinhDoNgoaiNgu)
        {
            if (mangoaingu != chiTietTrinhDoNgoaiNgu.MaNgoaiNgu || macanbo != chiTietTrinhDoNgoaiNgu.MaCanBo)
            {
                return BadRequest();
            }

            var chitiet = _mapper.Map<ChiTietTrinhDoNgoaiNgu>(chiTietTrinhDoNgoaiNgu);
            _context.chiTietTrinhDoNgoaiNgu!.Update(chitiet);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChiTietTrinhDoNgoaiNguExists(mangoaingu, macanbo))
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

        // POST: api/ChiTietTrinhDoNgoaiNgus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ChiTietTrinhDoNgoaiNgu>> PostChiTietTrinhDoNgoaiNgu(ChiTietTrinhDoNgoaiNguModel chiTietTrinhDoNgoaiNgu)
        {
          if (_context.chiTietTrinhDoNgoaiNgu == null)
          {
              return Problem("Entity set 'StaffDbContext.chiTietTrinhDoNgoaiNgu'  is null.");
          }
            var chitiet = _mapper.Map<ChiTietTrinhDoNgoaiNgu>(chiTietTrinhDoNgoaiNgu);
            _context.chiTietTrinhDoNgoaiNgu.Add(chitiet);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ChiTietTrinhDoNgoaiNguExists(chiTietTrinhDoNgoaiNgu.MaNgoaiNgu, chiTietTrinhDoNgoaiNgu.MaCanBo))
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

        // DELETE: api/ChiTietTrinhDoNgoaiNgus/5
        [HttpDelete("{mangoaingu}/{macanbo}")]
        public async Task<IActionResult> DeleteChiTietTrinhDoNgoaiNgu(int mangoaingu, string macanbo)
        {
            if (_context.chiTietTrinhDoNgoaiNgu == null)
            {
                return NotFound();
            }
            var chiTietTrinhDoNgoaiNgu = await _context.chiTietTrinhDoNgoaiNgu.FindAsync(mangoaingu, macanbo);
            if (chiTietTrinhDoNgoaiNgu == null)
            {
                return NotFound();
            }

            _context.chiTietTrinhDoNgoaiNgu.Remove(chiTietTrinhDoNgoaiNgu);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChiTietTrinhDoNgoaiNguExists(int mangoaingu, string macanbo)
        {
            return (_context.chiTietTrinhDoNgoaiNgu?.Any(e => e.Mangoaingu == mangoaingu && e.Macanbo == macanbo)).GetValueOrDefault();
        }
    }
}
