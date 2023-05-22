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
    public class DeTaiDuAnKHCNController : ControllerBase
    {
        private readonly StaffDbContext _context;
        private readonly IMapper _mapper;

        public DeTaiDuAnKHCNController(StaffDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/DeTaiDuAnKHCN
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeTaiDuAnKHCNModel>>> GetdeTaiDuAn()
        {
          if (_context.deTaiDuAn == null)
          {
              return NotFound();
          }
            var list = await _context.deTaiDuAn.Where(e => e.isDelete == 0).ToListAsync();
            return _mapper.Map<List<DeTaiDuAnKHCNModel>>(list);
        }

        // GET: api/DeTaiDuAnKHCN/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DeTaiDuAnKHCNModel>> GetDeTaiDuAnKHCNThamGia(string id)
        {
          if (_context.deTaiDuAn == null)
          {
              return NotFound();
          }
            var deTaiDuAnKHCNThamGia = await _context.deTaiDuAn.SingleOrDefaultAsync(cb => cb.Madetai == id && cb.isDelete == 0);

            if (deTaiDuAnKHCNThamGia == null)
            {
                return NotFound();
            }

            return _mapper.Map<DeTaiDuAnKHCNModel>(deTaiDuAnKHCNThamGia);
        }

        // PUT: api/DeTaiDuAnKHCNThamGias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeTaiDuAnKHCNThamGia(string id, DeTaiDuAnKHCNModel deTaiDuAnKHCNThamGia)
        {
            if (id != deTaiDuAnKHCNThamGia.MaDeTai)
            {
                return BadRequest();
            }

            var chitiet = _mapper.Map<DeTaiDuAnKHCN>(deTaiDuAnKHCNThamGia);
            _context.deTaiDuAn!.Update(chitiet);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeTaiDuAnKHCNThamGiaExists(id))
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

        // POST: api/DeTaiDuAnKHCNThamGias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DeTaiDuAnKHCN>> PostDeTaiDuAnKHCNThamGia(DeTaiDuAnKHCNModel deTaiDuAnKHCNThamGia)
        {
          if (_context.deTaiDuAn == null)
          {
              return Problem("Entity set 'StaffDbContext.deTaiDuAn'  is null.");
          }
            var chitiet = _mapper.Map<DeTaiDuAnKHCN>(deTaiDuAnKHCNThamGia);
            _context.deTaiDuAn.Add(chitiet);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/DeTaiDuAnKHCNThamGias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeTaiDuAnKHCNThamGia(string id)
        {
            if (_context.deTaiDuAn == null)
            {
                return NotFound();
            }
            var deTaiDuAnKHCNThamGia = await _context.deTaiDuAn.FindAsync(id);
            if (deTaiDuAnKHCNThamGia == null)
            {
                return NotFound();
            }
            deTaiDuAnKHCNThamGia.isDelete = 1;
            _context.deTaiDuAn.Update(deTaiDuAnKHCNThamGia);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DeTaiDuAnKHCNThamGiaExists(string id)
        {
            return (_context.deTaiDuAn?.Any(e => e.Madetai == id)).GetValueOrDefault();
        }
    }
}
