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
    public class DeTaiDuAnKHCNChuTrisController : ControllerBase
    {
        private readonly StaffDbContext _context;
        private readonly IMapper _mapper;

        public DeTaiDuAnKHCNChuTrisController(StaffDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/DeTaiDuAnKHCNChuTris
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeTaiDuAnKHCNChuTriModel>>> GetdeTaiDuAnKHCNChuTri()
        {
          if (_context.deTaiDuAnKHCNChuTri == null)
          {
              return NotFound();
          }
            var list = await _context.deTaiDuAnKHCNChuTri.ToListAsync();
            return _mapper.Map<List<DeTaiDuAnKHCNChuTriModel>>(list);
        }

        // GET: api/DeTaiDuAnKHCNChuTris/5
        [HttpGet("{madetai}/{macanbo}")]
        public async Task<ActionResult<DeTaiDuAnKHCNChuTriModel>> GetDeTaiDuAnKHCNChuTri(int madetai, string macanbo)
        {
          if (_context.deTaiDuAnKHCNChuTri == null)
          {
              return NotFound();
          }
            var deTaiDuAnKHCNChuTri = await _context.deTaiDuAnKHCNChuTri.FindAsync(madetai, macanbo);

            if (deTaiDuAnKHCNChuTri == null)
            {
                return NotFound();
            }

            return _mapper.Map<DeTaiDuAnKHCNChuTriModel>(deTaiDuAnKHCNChuTri);
        }

        // PUT: api/DeTaiDuAnKHCNChuTris/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{madetai}/{macanbo}")]
        public async Task<IActionResult> PutDeTaiDuAnKHCNChuTri(int madetai, string macanbo, DeTaiDuAnKHCNChuTriModel deTaiDuAnKHCNChuTri)
        {
            if (madetai != deTaiDuAnKHCNChuTri.MaDeTai || macanbo != deTaiDuAnKHCNChuTri.MaCanBo)
            {
                return BadRequest();
            }
            var chitiet = _mapper.Map<DeTaiDuAnKHCNChuTri>(deTaiDuAnKHCNChuTri);
            _context.deTaiDuAnKHCNChuTri!.Update(chitiet);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeTaiDuAnKHCNChuTriExists(madetai, macanbo))
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

        // POST: api/DeTaiDuAnKHCNChuTris
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DeTaiDuAnKHCNChuTri>> PostDeTaiDuAnKHCNChuTri(DeTaiDuAnKHCNChuTriModel deTaiDuAnKHCNChuTri)
        {
          if (_context.deTaiDuAnKHCNChuTri == null)
          {
              return Problem("Entity set 'StaffDbContext.deTaiDuAnKHCNChuTri'  is null.");
          }
            var chitiet = _mapper.Map<DeTaiDuAnKHCNChuTri>(deTaiDuAnKHCNChuTri);
            _context.deTaiDuAnKHCNChuTri.Add(chitiet);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DeTaiDuAnKHCNChuTriExists(deTaiDuAnKHCNChuTri.MaDeTai,deTaiDuAnKHCNChuTri.MaCanBo))
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

        // DELETE: api/DeTaiDuAnKHCNChuTris/5
        [HttpDelete("{madetai}/{macanbo}")]
        public async Task<IActionResult> DeleteDeTaiDuAnKHCNChuTri(int madetai, string macanbo)
        {
            if (_context.deTaiDuAnKHCNChuTri == null)
            {
                return NotFound();
            }
            var deTaiDuAnKHCNChuTri = await _context.deTaiDuAnKHCNChuTri.FindAsync(madetai, macanbo);
            if (deTaiDuAnKHCNChuTri == null)
            {
                return NotFound();
            }

            _context.deTaiDuAnKHCNChuTri.Remove(deTaiDuAnKHCNChuTri);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DeTaiDuAnKHCNChuTriExists(int madetai, string macanbo)
        {
            return (_context.deTaiDuAnKHCNChuTri?.Any(e => e.Madetai == madetai && e.Macanbo == macanbo)).GetValueOrDefault();
        }
    }
}
