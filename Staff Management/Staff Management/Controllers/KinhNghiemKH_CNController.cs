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
    public class KinhNghiemKH_CNController : ControllerBase
    {
        private readonly StaffDbContext _context;
        private readonly IMapper _mapper;


        public KinhNghiemKH_CNController(StaffDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/KinhNghiemKH_CN
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KinhNghiemKH_CnModel>>> GetkinhNghiemKH_CN()
        {
          if (_context.kinhNghiemKH_CN == null)
          {
              return NotFound();
          }
          var list = await _context.kinhNghiemKH_CN.Where(e => e.isDelete == 0).ToListAsync();
            return _mapper.Map<List<KinhNghiemKH_CnModel>>(list);
        }

        // GET: api/KinhNghiemKH_CN/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KinhNghiemKH_CnModel>> GetKinhNghiemKH_CN(string id)
        {
          if (_context.kinhNghiemKH_CN == null)
          {
              return NotFound();
          }
            var kinhNghiemKH_CN = await _context.kinhNghiemKH_CN.SingleOrDefaultAsync(cb => cb.Mahinhthuchoidong == id && cb.isDelete == 0);

            if (kinhNghiemKH_CN == null)
            {
                return NotFound();
            }

            return _mapper.Map<KinhNghiemKH_CnModel>(kinhNghiemKH_CN);
        }

        // PUT: api/KinhNghiemKH_CN/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKinhNghiemKH_CN(string id, KinhNghiemKH_CnModel kinhNghiemKH_CN)
        {
            if (id != kinhNghiemKH_CN.MaHinhThucHoiDong)
            {
                return BadRequest();
            }

            var chitiet = _mapper.Map<KinhNghiemKH_CN>(kinhNghiemKH_CN);
            _context.kinhNghiemKH_CN!.Update(chitiet);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KinhNghiemKH_CNExists(id))
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

        // POST: api/KinhNghiemKH_CN
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<KinhNghiemKH_CN>> PostKinhNghiemKH_CN(KinhNghiemKH_CnModel kinhNghiemKH_CN)
        {
          if (_context.kinhNghiemKH_CN == null)
          {
              return Problem("Entity set 'StaffDbContext.kinhNghiemKH_CN'  is null.");
          }
            var chitiet = _mapper.Map<KinhNghiemKH_CN>(kinhNghiemKH_CN);
            _context.kinhNghiemKH_CN.Add(chitiet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKinhNghiemKH_CN", new { id = kinhNghiemKH_CN.MaHinhThucHoiDong }, kinhNghiemKH_CN);
        }

        // DELETE: api/KinhNghiemKH_CN/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKinhNghiemKH_CN(string id)
        {
            if (_context.kinhNghiemKH_CN == null)
            {
                return NotFound();
            }
            var kinhNghiemKH_CN = await _context.kinhNghiemKH_CN.FindAsync(id);
            if (kinhNghiemKH_CN == null)
            {
                return NotFound();
            }
            kinhNghiemKH_CN.isDelete = 1;
            _context.kinhNghiemKH_CN.Update(kinhNghiemKH_CN);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KinhNghiemKH_CNExists(string id)
        {
            return (_context.kinhNghiemKH_CN?.Any(e => e.Mahinhthuchoidong == id)).GetValueOrDefault();
        }
    }
}
