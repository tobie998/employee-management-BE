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
    public class NghienCuuSinhDaHuongDanController : ControllerBase
    {
        private readonly StaffDbContext _context;
        private readonly IMapper _mapper;


        public NghienCuuSinhDaHuongDanController(StaffDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/NghienCuuSinhDaHuongDan
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NghienCuuSinhDaHuongDanModel>>> GetnghienCuuSinhDaHuongDan()
        {
          if (_context.nghienCuuSinhDaHuongDan == null)
          {
              return NotFound();
          }
            var list = await _context.nghienCuuSinhDaHuongDan.ToListAsync();
            return _mapper.Map<List<NghienCuuSinhDaHuongDanModel>>(list);
        }

        // GET: api/NghienCuuSinhDaHuongDan/5
        [HttpGet("{maNCS}/{macanbo}")]
        public async Task<ActionResult<NghienCuuSinhDaHuongDanModel>> GetNghienCuuSinhDaHuongDan(int maNCS, string macanbo)
        {
          if (_context.nghienCuuSinhDaHuongDan == null)
          {
              return NotFound();
          }
            var nghienCuuSinhDaHuongDan = await _context.nghienCuuSinhDaHuongDan.FindAsync(maNCS, macanbo);

            if (nghienCuuSinhDaHuongDan == null)
            {
                return NotFound();
            }

            return _mapper.Map<NghienCuuSinhDaHuongDanModel>(nghienCuuSinhDaHuongDan);
        }

        // PUT: api/NghienCuuSinhDaHuongDan/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{maNCS}/{macanbo}")]
        public async Task<IActionResult> PutNghienCuuSinhDaHuongDan(int maNCS, string macanbo, NghienCuuSinhDaHuongDanModel nghienCuuSinhDaHuongDan)
        {
            if (maNCS != nghienCuuSinhDaHuongDan.MaNCS || macanbo != nghienCuuSinhDaHuongDan.MaCanBo)
            {
                return BadRequest();
            }

            var chitiet = _mapper.Map<NghienCuuSinhDaHuongDan>(nghienCuuSinhDaHuongDan);
            _context.nghienCuuSinhDaHuongDan!.Update(chitiet);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NghienCuuSinhDaHuongDanExists(maNCS, macanbo))
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

        // POST: api/NghienCuuSinhDaHuongDan
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NghienCuuSinhDaHuongDan>> PostNghienCuuSinhDaHuongDan(NghienCuuSinhDaHuongDanModel nghienCuuSinhDaHuongDan)
        {
          if (_context.nghienCuuSinhDaHuongDan == null)
          {
              return Problem("Entity set 'StaffDbContext.nghienCuuSinhDaHuongDan'  is null.");
          }
            var chitiet = _mapper.Map<NghienCuuSinhDaHuongDan>(nghienCuuSinhDaHuongDan);
            _context.nghienCuuSinhDaHuongDan.Add(chitiet);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (NghienCuuSinhDaHuongDanExists(nghienCuuSinhDaHuongDan.MaNCS, nghienCuuSinhDaHuongDan.MaCanBo))
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

        // DELETE: api/NghienCuuSinhDaHuongDan/5
        [HttpDelete("{maNCS}/{macanbo}")]
        public async Task<IActionResult> DeleteNghienCuuSinhDaHuongDan(int maNCS, string macanbo)
        {
            if (_context.nghienCuuSinhDaHuongDan == null)
            {
                return NotFound();
            }
            var nghienCuuSinhDaHuongDan = await _context.nghienCuuSinhDaHuongDan.FindAsync(maNCS,macanbo);
            if (nghienCuuSinhDaHuongDan == null)
            {
                return NotFound();
            }

            _context.nghienCuuSinhDaHuongDan.Remove(nghienCuuSinhDaHuongDan);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NghienCuuSinhDaHuongDanExists(int maNCS, string macanbo)
        {
            return (_context.nghienCuuSinhDaHuongDan?.Any(e => e.MaNCS == maNCS && e.Macanbo == macanbo)).GetValueOrDefault();
        }
    }
}
