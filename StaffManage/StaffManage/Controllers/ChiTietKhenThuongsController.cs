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
    public class ChiTietKhenThuongsController : ControllerBase
    {
        private readonly StaffDbContext _context;
        private readonly IMapper _mapper;

        public ChiTietKhenThuongsController(StaffDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/ChiTietKhenThuongs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChiTietKhenThuongModel>>> GetchiTietKhenThuong()
        {
          if (_context.chiTietKhenThuong == null)
          {
              return NotFound();
          }
            var list = await _context.chiTietKhenThuong.ToListAsync();
            return _mapper.Map<List<ChiTietKhenThuongModel>>(list);
        }

        // GET: api/ChiTietKhenThuongs/5
        [HttpGet("{makhenthuong}/{macanbo}")]
        public async Task<ActionResult<ChiTietKhenThuongModel>> GetChiTietKhenThuong(int makhenthuong, string macanbo)
        {
          if (_context.chiTietKhenThuong == null)
          {
              return NotFound();
          }
            var chiTietKhenThuong = await _context.chiTietKhenThuong.FindAsync(makhenthuong, macanbo);

            if (chiTietKhenThuong == null)
            {
                return NotFound();
            }

            return _mapper.Map<ChiTietKhenThuongModel>(chiTietKhenThuong);
        }

        // PUT: api/ChiTietKhenThuongs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{makhenthuong}/{macanbo}")]
        public async Task<IActionResult> PutChiTietKhenThuong(int makhenthuong, string macanbo, ChiTietKhenThuongModel chiTietKhenThuong)
        {
            if (makhenthuong != chiTietKhenThuong.MaKhenThuong || macanbo != chiTietKhenThuong.MaCanBo)
            {
                return BadRequest();
            }

            var chitiet = _mapper.Map<ChiTietKhenThuong>(chiTietKhenThuong);
            _context.chiTietKhenThuong!.Update(chitiet);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChiTietKhenThuongExists(makhenthuong, macanbo))
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

        // POST: api/ChiTietKhenThuongs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ChiTietKhenThuong>> PostChiTietKhenThuong(ChiTietKhenThuongModel chiTietKhenThuong)
        {
          if (_context.chiTietKhenThuong == null)
          {
              return Problem("Entity set 'StaffDbContext.chiTietKhenThuong'  is null.");
          }
            var chitiet = _mapper.Map<ChiTietKhenThuong>(chiTietKhenThuong);
            _context.chiTietKhenThuong.Add(chitiet);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ChiTietKhenThuongExists(chiTietKhenThuong.MaKhenThuong, chiTietKhenThuong.MaCanBo))
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

        // DELETE: api/ChiTietKhenThuongs/5
        [HttpDelete("{makhenthuong}/{macanbo}")]
        public async Task<IActionResult> DeleteChiTietKhenThuong(int makhenthuong, string macanbo)
        {
            if (_context.chiTietKhenThuong == null)
            {
                return NotFound();
            }
            var chiTietKhenThuong = await _context.chiTietKhenThuong.FindAsync(makhenthuong, macanbo);
            if (chiTietKhenThuong == null)
            {
                return NotFound();
            }

            _context.chiTietKhenThuong.Remove(chiTietKhenThuong);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChiTietKhenThuongExists(int makhenthuong, string macanbo)
        {
            return (_context.chiTietKhenThuong?.Any(e => e.Makhenthuong == makhenthuong && e.Macanbo == macanbo)).GetValueOrDefault();
        }
    }
}
