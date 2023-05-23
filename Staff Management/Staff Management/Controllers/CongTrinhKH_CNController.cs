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
    public class CongTrinhKH_CNController : ControllerBase
    {
        private readonly StaffDbContext _context;
        private readonly IMapper _mapper;

        public CongTrinhKH_CNController(StaffDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/CongTrinhKH_CN
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CongTrinhKH_CNModel>>> GetcongTrinhKH_CN()
        {
          if (_context.congTrinhKH_CN == null)
          {
              return NotFound();
          }
            var list = await _context.congTrinhKH_CN.Where(e => e.isDelete == 0).ToListAsync();
            return _mapper.Map<List<CongTrinhKH_CNModel>>(list);
        }

        // GET: api/CongTrinhKH_CN/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CongTrinhKH_CNModel>> GetCongTrinhKH_CN(string id)
        {
          if (_context.congTrinhKH_CN == null)
          {
              return NotFound();
          }
            var congTrinhKH_CN = await _context.congTrinhKH_CN.SingleOrDefaultAsync(cb => cb.MacongtrinhKH == id && cb.isDelete == 0);

            if (congTrinhKH_CN == null)
            {
                return NotFound();
            }

            return _mapper.Map<CongTrinhKH_CNModel>(congTrinhKH_CN);
        }

        // PUT: api/CongTrinhKH_CN/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCongTrinhKH_CN(string id, CongTrinhKH_CNModel congTrinhKH_CN)
        {
            if (id != congTrinhKH_CN.MaCongTrinhKH)
            {
                return BadRequest();
            }

            var chitiet = _mapper.Map<CongTrinhKH_CN>(congTrinhKH_CN);
            _context.congTrinhKH_CN!.Update(chitiet);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CongTrinhKH_CNExists(id))
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

        // POST: api/CongTrinhKH_CN
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CongTrinhKH_CN>> PostCongTrinhKH_CN(CongTrinhKH_CNModel congTrinhKH_CN)
        {
          if (_context.congTrinhKH_CN == null)
          {
              return Problem("Entity set 'StaffDbContext.congTrinhKH_CN'  is null.");
          }
            var chitiet = _mapper.Map<CongTrinhKH_CN>(congTrinhKH_CN);
            _context.congTrinhKH_CN.Add(chitiet);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/CongTrinhKH_CN/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCongTrinhKH_CN(string id)
        {
            if (_context.congTrinhKH_CN == null)
            {
                return NotFound();
            }
            var congTrinhKH_CN = await _context.congTrinhKH_CN.FindAsync(id);
            if (congTrinhKH_CN == null)
            {
                return NotFound();
            }
            congTrinhKH_CN.isDelete = 1;
            _context.congTrinhKH_CN.Update(congTrinhKH_CN);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CongTrinhKH_CNExists(string id)
        {
            return (_context.congTrinhKH_CN?.Any(e => e.MacongtrinhKH == id)).GetValueOrDefault();
        }
    }
}
