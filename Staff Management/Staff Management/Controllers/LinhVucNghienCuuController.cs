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
    public class LinhVucNghienCuuController : ControllerBase
    {
        private readonly StaffDbContext _context;
        private readonly IMapper _mapper;

        public LinhVucNghienCuuController(StaffDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/LinhVucNghienCuus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LinhVucNghienCuuModel>>> GetlinhVuc()
        {
          if (_context.linhVuc == null)
          {
              return NotFound();
          }
          var linhvuc = await _context.linhVuc.Where(e => e.isDelete == 0).ToListAsync();
            return _mapper.Map<List<LinhVucNghienCuuModel>>(linhvuc);
        }

        // GET: api/LinhVucNghienCuus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LinhVucNghienCuuModel>> GetLinhVucNghienCuu(string id)
        {
          if (_context.linhVuc == null)
          {
              return NotFound();
          }
            var linhVucNghienCuu = await _context.linhVuc.SingleOrDefaultAsync(cb => cb.Malinhvuc == id && cb.isDelete == 0);

            if (linhVucNghienCuu == null)
            {
                return NotFound();
            }

            return _mapper.Map<LinhVucNghienCuuModel>(linhVucNghienCuu);
        }

        // PUT: api/LinhVucNghienCuus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLinhVucNghienCuu(string id, LinhVucNghienCuuModel linhVucNghienCuu)
        {
            if (id != linhVucNghienCuu.MaLinhVuc)
            {
                return BadRequest();
            }

            var chitiet = _mapper.Map<LinhVucNghienCuu>(linhVucNghienCuu);
            _context.linhVuc!.Update(chitiet);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LinhVucNghienCuuExists(id))
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

        // POST: api/LinhVucNghienCuus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LinhVucNghienCuu>> PostLinhVucNghienCuu(LinhVucNghienCuuModel linhVucNghienCuu)
        {
          if (_context.linhVuc == null)
          {
              return Problem("Entity set 'StaffDbContext.linhVuc'  is null.");
          }
            var chitiet = _mapper.Map<LinhVucNghienCuu>(linhVucNghienCuu);
            _context.linhVuc.Add(chitiet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLinhVucNghienCuu", new { id = linhVucNghienCuu.MaLinhVuc }, linhVucNghienCuu);
        }

        // DELETE: api/LinhVucNghienCuus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLinhVucNghienCuu(string id)
        {
            if (_context.linhVuc == null)
            {
                return NotFound();
            }
            var linhVucNghienCuu = await _context.linhVuc.FindAsync(id);
            if (linhVucNghienCuu == null)
            {
                return NotFound();
            }
            linhVucNghienCuu.isDelete = 1;
            _context.linhVuc.Update(linhVucNghienCuu);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LinhVucNghienCuuExists(string id)
        {
            return (_context.linhVuc?.Any(e => e.Malinhvuc == id)).GetValueOrDefault();
        }
    }
}
