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
    public class CongTrinhVaKetQuaNghienCuuDuocApDungsController : ControllerBase
    {
        private readonly StaffDbContext _context;
        private readonly IMapper _mapper;

        public CongTrinhVaKetQuaNghienCuuDuocApDungsController(StaffDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/CongTrinhVaKetQuaNghienCuuDuocApDungs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CongTrinhVaKetQuaNghienCuuDuocApDungModel>>> GetcongTrinhVaKetQuaNghienCuuDuocApDung()
        {
            if (_context.congTrinhVaKetQuaNghienCuuDuocApDung == null)
            {
                return NotFound();
            }
            var list = await _context.congTrinhVaKetQuaNghienCuuDuocApDung.ToListAsync();
            return _mapper.Map<List<CongTrinhVaKetQuaNghienCuuDuocApDungModel>>(list);
        }

        // GET: api/CongTrinhVaKetQuaNghienCuuDuocApDungs/5
        [HttpGet("{macongtrinhnghiencuu}/{macanbo}")]
        public async Task<ActionResult<CongTrinhVaKetQuaNghienCuuDuocApDungModel>> GetCongTrinhVaKetQuaNghienCuuDuocApDung(int macongtrinhnghiencuu, string macanbo)
        {
            if (_context.congTrinhVaKetQuaNghienCuuDuocApDung == null)
            {
                return NotFound();
            }
            var congTrinhVaKetQuaNghienCuuDuocApDung = await _context.congTrinhVaKetQuaNghienCuuDuocApDung.FindAsync(macongtrinhnghiencuu, macanbo);

            if (congTrinhVaKetQuaNghienCuuDuocApDung == null)
            {
                return NotFound();
            }

            return _mapper.Map<CongTrinhVaKetQuaNghienCuuDuocApDungModel>(congTrinhVaKetQuaNghienCuuDuocApDung);
        }

        // PUT: api/CongTrinhVaKetQuaNghienCuuDuocApDungs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{macongtrinhnghiencuu}/{macanbo}")]
        public async Task<IActionResult> PutCongTrinhVaKetQuaNghienCuuDuocApDung(int macongtrinhnghiencuu, string macanbo, CongTrinhVaKetQuaNghienCuuDuocApDungModel congTrinhVaKetQuaNghienCuuDuocApDung)
        {
            if (macongtrinhnghiencuu != congTrinhVaKetQuaNghienCuuDuocApDung.Macongtrinhnghiencuu || macanbo != congTrinhVaKetQuaNghienCuuDuocApDung.Macanbo)
            {
                return BadRequest();
            }

            var chitiet = _mapper.Map<CongTrinhVaKetQuaNghienCuuDuocApDung>(congTrinhVaKetQuaNghienCuuDuocApDung);
            _context.congTrinhVaKetQuaNghienCuuDuocApDung!.Update(chitiet);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CongTrinhVaKetQuaNghienCuuDuocApDungExists(macongtrinhnghiencuu,macanbo))
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

        // POST: api/CongTrinhVaKetQuaNghienCuuDuocApDungs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CongTrinhVaKetQuaNghienCuuDuocApDung>> PostCongTrinhVaKetQuaNghienCuuDuocApDung(CongTrinhVaKetQuaNghienCuuDuocApDungModel congTrinhVaKetQuaNghienCuuDuocApDung)
        {
            if (_context.congTrinhVaKetQuaNghienCuuDuocApDung == null)
            {
                return Problem("Entity set 'StaffDbContext.congTrinhVaKetQuaNghienCuuDuocApDung'  is null.");
            }
            var chitiet = _mapper.Map<CongTrinhVaKetQuaNghienCuuDuocApDung>(congTrinhVaKetQuaNghienCuuDuocApDung);
            _context.congTrinhVaKetQuaNghienCuuDuocApDung.Add(chitiet);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CongTrinhVaKetQuaNghienCuuDuocApDungExists(congTrinhVaKetQuaNghienCuuDuocApDung.Macongtrinhnghiencuu, congTrinhVaKetQuaNghienCuuDuocApDung.Macanbo))
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

        // DELETE: api/CongTrinhVaKetQuaNghienCuuDuocApDungs/5
        [HttpDelete("{macongtrinhnghiencuu}/{macanbo}")]
        public async Task<IActionResult> DeleteCongTrinhVaKetQuaNghienCuuDuocApDung(int macongtrinhnghiencuu, string macanbo)
        {
            if (_context.congTrinhVaKetQuaNghienCuuDuocApDung == null)
            {
                return NotFound();
            }
            var congTrinhVaKetQuaNghienCuuDuocApDung = await _context.congTrinhVaKetQuaNghienCuuDuocApDung.FindAsync(macongtrinhnghiencuu, macanbo);
            if (congTrinhVaKetQuaNghienCuuDuocApDung == null)
            {
                return NotFound();
            }

            _context.congTrinhVaKetQuaNghienCuuDuocApDung.Remove(congTrinhVaKetQuaNghienCuuDuocApDung);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CongTrinhVaKetQuaNghienCuuDuocApDungExists(int macongtrinhnghiencuu, string macanbo)
        {
            return (_context.congTrinhVaKetQuaNghienCuuDuocApDung?.Any(e => e.Macongtrinhnghiencuu == macongtrinhnghiencuu && e.Macanbo == macanbo)).GetValueOrDefault();
        }
    }
}
