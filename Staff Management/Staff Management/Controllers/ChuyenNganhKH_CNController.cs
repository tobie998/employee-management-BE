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
    public class ChuyenNganhKH_CNController : ControllerBase
    {
        private readonly StaffDbContext _context;
        private readonly IMapper _mapper;

        public ChuyenNganhKH_CNController(StaffDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        // GET: api/ChuyenNganhKH_CN
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChuyenNganhKH_CNModel>>> GetchuyenNganhKH_CN()
        {
          if (_context.chuyenNganhKH_CN == null)
          {
              return NotFound();
          }
            var list = await _context.chuyenNganhKH_CN.ToListAsync();
            return _mapper.Map<List<ChuyenNganhKH_CNModel>>(list);
        }

        // GET: api/ChuyenNganhKH_CN/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChuyenNganhKH_CNModel>> GetChuyenNganhKH_CN(string id)
        {
          if (_context.chuyenNganhKH_CN == null)
          {
              return NotFound();
          }
            var chuyenNganhKH_CN = await _context.chuyenNganhKH_CN.FindAsync(id);

            if (chuyenNganhKH_CN == null)
            {
                return NotFound();
            }

            return _mapper.Map<ChuyenNganhKH_CNModel>(chuyenNganhKH_CN);
        }

        // PUT: api/ChuyenNganhKH_CN/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChuyenNganhKH_CN(string id, ChuyenNganhKH_CNModel chuyenNganhKH_CN)
        {
            if (id != chuyenNganhKH_CN.Machuyennganh)
            {
                return BadRequest();
            }

            var chitiet = _mapper.Map<ChuyenNganhKH_CN>(chuyenNganhKH_CN);
            _context.chuyenNganhKH_CN.Update(chitiet);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChuyenNganhKH_CNExists(id))
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

        // POST: api/ChuyenNganhKH_CN
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ChuyenNganhKH_CN>> PostChuyenNganhKH_CN(ChuyenNganhKH_CNModel chuyenNganhKH_CN)
        {
          if (_context.chuyenNganhKH_CN == null)
          {
              return Problem("Entity set 'StaffDbContext.chuyenNganhKH_CN'  is null.");
          }
            var chitiet = _mapper.Map<ChuyenNganhKH_CN>(chuyenNganhKH_CN);
            _context.chuyenNganhKH_CN.Add(chitiet);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ChuyenNganhKH_CNExists(chuyenNganhKH_CN.Machuyennganh))
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

        // DELETE: api/ChuyenNganhKH_CN/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChuyenNganhKH_CN(string id)
        {
            if (_context.chuyenNganhKH_CN == null)
            {
                return NotFound();
            }
            var chuyenNganhKH_CN = await _context.chuyenNganhKH_CN.FindAsync(id);
            if (chuyenNganhKH_CN == null)
            {
                return NotFound();
            }

            _context.chuyenNganhKH_CN.Remove(chuyenNganhKH_CN);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChuyenNganhKH_CNExists(string id)
        {
            return (_context.chuyenNganhKH_CN?.Any(e => e.Machuyennganh == id)).GetValueOrDefault();
        }
    }
}
