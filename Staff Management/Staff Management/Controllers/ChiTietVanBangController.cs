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
    public class ChiTietVanBangController : ControllerBase
    {
        private readonly StaffDbContext _context;
        private readonly IMapper _mapper;

        public ChiTietVanBangController(StaffDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/ChiTietVanBang
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChiTietVanBangModel>>> GetchiTietVanBang()
        {
          if (_context.chiTietVanBang == null)
          {
              return NotFound();
          }
            var list = await _context.chiTietVanBang.ToListAsync();
            return _mapper.Map<List<ChiTietVanBangModel>>(list);
        }

        // GET: api/ChiTietVanBang/5
        [HttpGet("{mavanbang}/{macanbo}")]
        public async Task<ActionResult<ChiTietVanBangModel>> GetChiTietVanBang(string mavanbang, string macanbo)
        {
          if (_context.chiTietVanBang == null)
          {
              return NotFound();
          }
            var chiTietVanBang = await _context.chiTietVanBang.FindAsync(mavanbang, macanbo);

            if (chiTietVanBang == null)
            {
                return NotFound();
            }

            return _mapper.Map<ChiTietVanBangModel>(chiTietVanBang);
        }

        // PUT: api/ChiTietVanBang/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{mavanbang}/{macanbo}")]
        public async Task<IActionResult> PutChiTietVanBang(string mavanbang, string macanbo, ChiTietVanBangModel chiTietVanBang)
        {
            if (mavanbang != chiTietVanBang.MaVanBang || macanbo != chiTietVanBang.MaCanBo)
            {
                return BadRequest();
            }
            var chitiet = _mapper.Map<ChiTietVanBang>(chiTietVanBang);
            _context.chiTietVanBang!.Update(chitiet);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChiTietVanBangExists(mavanbang, macanbo))
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

        // POST: api/ChiTietVanBang
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ChiTietVanBang>> PostChiTietVanBang(ChiTietVanBangModel chiTietVanBang)
        {
          if (_context.chiTietVanBang == null)
          {
              return Problem("Entity set 'StaffDbContext.chiTietVanBang'  is null.");
          }
            var chitiet = _mapper.Map<ChiTietVanBang>(chiTietVanBang);
            _context.chiTietVanBang.Add(chitiet);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ChiTietVanBangExists(chiTietVanBang.MaVanBang, chiTietVanBang.MaCanBo))
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

        // DELETE: api/ChiTietVanBang/5
        [HttpDelete("{mavanbang}/{macanbo}")]
        public async Task<IActionResult> DeleteChiTietVanBang(string mavanbang, string macanbo)
        {
            if (_context.chiTietVanBang == null)
            {
                return NotFound();
            }
            var chiTietVanBang = await _context.chiTietVanBang.FindAsync(mavanbang, macanbo);
            if (chiTietVanBang == null)
            {
                return NotFound();
            }

            _context.chiTietVanBang.Remove(chiTietVanBang);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChiTietVanBangExists(string mavanbang, string macanbo)
        {
            return (_context.chiTietVanBang?.Any(e => e.Mavanbang == mavanbang && e.Macanbo == macanbo)).GetValueOrDefault();
        }
    }
}
