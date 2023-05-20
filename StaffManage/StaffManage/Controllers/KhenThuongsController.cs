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
    public class KhenThuongsController : ControllerBase
    {
        private readonly StaffDbContext _context;
        private readonly IMapper _mapper;

        public KhenThuongsController(StaffDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/KhenThuongs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KhenThuongModel>>> GetkhenThuong()
        {
          if (_context.khenThuong == null)
          {
              return NotFound();
          }
            var list = await _context.khenThuong.Where(e => e.isDelete == 0).ToListAsync();
            return _mapper.Map<List<KhenThuongModel>>(list);
        }

        // GET: api/KhenThuongs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KhenThuongModel>> GetKhenThuong(int id)
        {
          if (_context.khenThuong == null)
          {
              return NotFound();
          }
            var khenThuong = await _context.khenThuong.SingleOrDefaultAsync(cb => cb.Makhenthuong == id && cb.isDelete == 0);

            if (khenThuong == null)
            {
                return NotFound();
            }

            return _mapper.Map<KhenThuongModel>(khenThuong);
        }

        // PUT: api/KhenThuongs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKhenThuong(int id, KhenThuongModel khenThuong)
        {
            if (id != khenThuong.MaKhenThuong)
            {
                return BadRequest();
            }

            var chitiet = _mapper.Map<KhenThuong>(khenThuong);
            _context.khenThuong!.Update(chitiet);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KhenThuongExists(id))
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

        // POST: api/KhenThuongs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<KhenThuong>> PostKhenThuong(KhenThuongModel khenThuong)
        {
          if (_context.khenThuong == null)
          {
              return Problem("Entity set 'StaffDbContext.khenThuong'  is null.");
          }

            var chitiet = _mapper.Map<KhenThuong>(khenThuong);
            _context.khenThuong.Add(chitiet);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/KhenThuongs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKhenThuong(int id)
        {
            if (_context.khenThuong == null)
            {
                return NotFound();
            }
            var khenThuong = await _context.khenThuong.FindAsync(id);
            if (khenThuong == null)
            {
                return NotFound();
            }
            khenThuong.isDelete = 1;
            _context.khenThuong.Update(khenThuong);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KhenThuongExists(int id)
        {
            return (_context.khenThuong?.Any(e => e.Makhenthuong == id)).GetValueOrDefault();
        }
    }
}
