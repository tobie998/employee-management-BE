using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StaffManage.Data;
using StaffManage.Models;

namespace StaffManage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ChiTietChucVusController : ControllerBase
    {
        private readonly StaffDbContext _context;
        private readonly IMapper _mapper;

        public ChiTietChucVusController(StaffDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/ChiTietChucVus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChiTietChucVuModel>>> GetchiTietChucVu()
        {
          if (_context.chiTietChucVu == null)
          {
              return NotFound();
          }
          var chitiet = await _context.chiTietChucVu.ToListAsync();
            return _mapper.Map<List<ChiTietChucVuModel>>(chitiet);
        }

        // GET: api/ChiTietChucVus/5
        [HttpGet("{machucvu}/{macanbo}")]
        public async Task<ActionResult<ChiTietChucVuModel>> GetChiTietChucVu(int machucvu, string macanbo)
        {
          if (_context.chiTietChucVu == null)
          {
              return NotFound();
          }
            var chiTietChucVu = await _context.chiTietChucVu.FindAsync(machucvu, macanbo);

            if (chiTietChucVu == null)
            {
                return NotFound();
            }

            return _mapper.Map<ChiTietChucVuModel>(chiTietChucVu);
        }

        // PUT: api/ChiTietChucVus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{machucvu}/{macanbo}")]
        public async Task<IActionResult> PutChiTietChucVu(int machucvu, string macanbo, ChiTietChucVuModel chiTietChucVu)
        {
            if (machucvu != chiTietChucVu.Machucvu || macanbo != chiTietChucVu.Macanbo)
            {
                return BadRequest();
            }

            var chitiet = _mapper.Map<ChiTietChucVu>(chiTietChucVu);
            _context.chiTietChucVu!.Update(chitiet);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChiTietChucVuExists(machucvu,macanbo))
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

        // POST: api/ChiTietChucVus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ChiTietChucVu>> PostChiTietChucVu(ChiTietChucVuModel chiTietChucVu)
        {
          if (_context.chiTietChucVu == null)
          {
              return Problem("Entity set 'StaffDbContext.chiTietChucVu'  is null.");
          }

            var chitiet = _mapper.Map<ChiTietChucVu>(chiTietChucVu);
            _context.chiTietChucVu.Add(chitiet);
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ChiTietChucVuExists(chiTietChucVu.Machucvu, chiTietChucVu.Macanbo))
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

        // DELETE: api/ChiTietChucVus/5
        [HttpDelete("{machucvu}/{macanbo}")]
        public async Task<IActionResult> DeleteChiTietChucVu(int machucvu, string macanbo)
        {
            if (_context.chiTietChucVu == null)
            {
                return NotFound();
            }
            var chiTietChucVu = await _context.chiTietChucVu.FindAsync(machucvu,macanbo);
            if (chiTietChucVu == null)
            {
                return NotFound();
            }

            _context.chiTietChucVu.Remove(chiTietChucVu);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChiTietChucVuExists(int machucvu, string macanbo)
        {
            return (_context.chiTietChucVu?.Any(e => e.Machucvu == machucvu && e.Macanbo == macanbo)).GetValueOrDefault();
        }
    }
}
