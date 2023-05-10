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
    public class ChiTietGiaiThuongsController : ControllerBase
    {
        private readonly StaffDbContext _context;
        private readonly IMapper _mapper;

        public ChiTietGiaiThuongsController(StaffDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/ChiTietGiaiThuongs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChiTietGiaiThuongModel>>> GetchiTietGiaiThuong()
        {
          if (_context.chiTietGiaiThuong == null)
          {
              return NotFound();
          }
            var giaithuong = await _context.chiTietGiaiThuong.ToListAsync(); ;
            return _mapper.Map<List<ChiTietGiaiThuongModel>>(giaithuong);
        }

        // GET: api/ChiTietGiaiThuongs/5
        [HttpGet("{magiaithuong}/{macanbo}")]
        public async Task<ActionResult<ChiTietGiaiThuongModel>> GetChiTietGiaiThuong(int magiaithuong, string macanbo)
        {
          if (_context.chiTietGiaiThuong == null)
          {
              return NotFound();
          }
            var chiTietGiaiThuong = await _context.chiTietGiaiThuong.FindAsync(magiaithuong, macanbo);

            if (chiTietGiaiThuong == null)
            {
                return NotFound();
            }

            return _mapper.Map<ChiTietGiaiThuongModel>(chiTietGiaiThuong);
        }

        // PUT: api/ChiTietGiaiThuongs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChiTietGiaiThuong(int id, ChiTietGiaiThuongModel chiTietGiaiThuong)
        {
            if (id != chiTietGiaiThuong.Magiaithuong)
            {
                return BadRequest();
            }

            var chitiet = _mapper.Map<ChiTietGiaiThuong>(chiTietGiaiThuong);
            _context.chiTietGiaiThuong!.Update(chitiet);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChiTietGiaiThuongExists(id))
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

        // POST: api/ChiTietGiaiThuongs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ChiTietGiaiThuong>> PostChiTietGiaiThuong(ChiTietGiaiThuongModel chiTietGiaiThuong)
        {
          if (_context.chiTietGiaiThuong == null)
          {
              return Problem("Entity set 'StaffDbContext.chiTietGiaiThuong'  is null.");
          }
            var chitiet = _mapper.Map<ChiTietGiaiThuong>(chiTietGiaiThuong);
            _context.chiTietGiaiThuong.Add(chitiet);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ChiTietGiaiThuongExists(chiTietGiaiThuong.Magiaithuong))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetChiTietGiaiThuong", new { id = chiTietGiaiThuong.Magiaithuong }, chiTietGiaiThuong);
        }

        // DELETE: api/ChiTietGiaiThuongs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChiTietGiaiThuong(int id)
        {
            if (_context.chiTietGiaiThuong == null)
            {
                return NotFound();
            }
            var chiTietGiaiThuong = await _context.chiTietGiaiThuong.FindAsync(id);
            if (chiTietGiaiThuong == null)
            {
                return NotFound();
            }

            _context.chiTietGiaiThuong.Remove(chiTietGiaiThuong);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChiTietGiaiThuongExists(int id)
        {
            return (_context.chiTietGiaiThuong?.Any(e => e.Magiaithuong == id)).GetValueOrDefault();
        }
    }
}
