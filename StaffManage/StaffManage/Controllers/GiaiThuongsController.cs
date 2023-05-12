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
    public class GiaiThuongsController : ControllerBase
    {
        private readonly StaffDbContext _context;
        private readonly IMapper _mapper;

        public GiaiThuongsController(StaffDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/GiaiThuongs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GiaiThuongModel>>> GetgiaiThuong()
        {
          if (_context.giaiThuong == null)
          {
              return NotFound();
          }
            var list = await _context.giaiThuong.ToListAsync();
            return _mapper.Map<List<GiaiThuongModel>>(list);
        }

        // GET: api/GiaiThuongs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GiaiThuongModel>> GetGiaiThuong(int id)
        {
          if (_context.giaiThuong == null)
          {
              return NotFound();
          }
            var giaiThuong = await _context.giaiThuong.FindAsync(id);

            if (giaiThuong == null)
            {
                return NotFound();
            }

            return _mapper.Map<GiaiThuongModel>(giaiThuong);
        }

        // PUT: api/GiaiThuongs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGiaiThuong(int id, GiaiThuongModel giaiThuong)
        {
            if (id != giaiThuong.Magiaithuong)
            {
                return BadRequest();
            }

            var giaithuong = _mapper.Map<GiaiThuong>(giaiThuong);
            _context.giaiThuong!.Update(giaithuong);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GiaiThuongExists(id))
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

        // POST: api/GiaiThuongs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GiaiThuong>> PostGiaiThuong(GiaiThuongModel giaiThuong)
        {
          if (_context.giaiThuong == null)
          {
              return Problem("Entity set 'StaffDbContext.giaiThuong'  is null.");
          }
            var giaithuong = _mapper.Map<GiaiThuong>(giaiThuong);
            _context.giaiThuong.Add(giaithuong);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGiaiThuong", new { id = giaiThuong.Magiaithuong }, giaiThuong);
        }

        // DELETE: api/GiaiThuongs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGiaiThuong(int id)
        {
            if (_context.giaiThuong == null)
            {
                return NotFound();
            }
            var giaiThuong = await _context.giaiThuong.FindAsync(id);
            if (giaiThuong == null)
            {
                return NotFound();
            }

            _context.giaiThuong.Remove(giaiThuong);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GiaiThuongExists(int id)
        {
            return (_context.giaiThuong?.Any(e => e.Magiaithuong == id)).GetValueOrDefault();
        }
    }
}
