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
    public class KyLuatsController : ControllerBase
    {
        private readonly StaffDbContext _context;
        private readonly IMapper _mapper;

        public KyLuatsController(StaffDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/KyLuats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KyLuatModel>>> GetkyLuat()
        {
          if (_context.kyLuat == null)
          {
              return NotFound();
          }
            var list = await _context.kyLuat.Where(e => e.isDelete == 0).ToListAsync();
            return _mapper.Map<List<KyLuatModel>>(list);
        }

        // GET: api/KyLuats/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KyLuatModel>> GetKyLuat(int id)
        {
          if (_context.kyLuat == null)
          {
              return NotFound();
          }
            var kyLuat = await _context.kyLuat.SingleOrDefaultAsync(cb => cb.Makyluat == id && cb.isDelete == 0);

            if (kyLuat == null)
            {
                return NotFound();
            }

            return _mapper.Map<KyLuatModel>(kyLuat);
        }

        // PUT: api/KyLuats/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKyLuat(int id, KyLuatModel kyLuat)
        {
            if (id != kyLuat.MaKyLuat)
            {
                return BadRequest();
            }

            var chitiet = _mapper.Map<KyLuat>(kyLuat);
            _context.kyLuat!.Update(chitiet);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KyLuatExists(id))
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

        // POST: api/KyLuats
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<KyLuat>> PostKyLuat(KyLuatModel kyLuat)
        {
          if (_context.kyLuat == null)
          {
              return Problem("Entity set 'StaffDbContext.kyLuat'  is null.");
          }
            var chitiet = _mapper.Map<KyLuat>(kyLuat);
            _context.kyLuat.Add(chitiet);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/KyLuats/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKyLuat(int id)
        {
            if (_context.kyLuat == null)
            {
                return NotFound();
            }
            var kyLuat = await _context.kyLuat.FindAsync(id);
            if (kyLuat == null)
            {
                return NotFound();
            }
            kyLuat.isDelete = 1;
            _context.kyLuat.Update(kyLuat);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KyLuatExists(int id)
        {
            return (_context.kyLuat?.Any(e => e.Makyluat == id)).GetValueOrDefault();
        }
    }
}
