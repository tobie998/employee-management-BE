using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StaffManage.Data;
using StaffManage.Models;

namespace StaffManage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ChiTietChucDanhsController : ControllerBase
    {
        private readonly StaffDbContext _context;
        private readonly IMapper _mapper;

        public ChiTietChucDanhsController(StaffDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/ChiTietChucDanhs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChiTietChucDanhModel>>> GetchiTietChucDanh()
        {
          if (_context.chiTietChucDanh == null)
          {
              return NotFound();
          }
            var chitiet = await _context.chiTietChucDanh.ToListAsync();
            return _mapper.Map<List<ChiTietChucDanhModel>>(chitiet);
        }

        // GET: api/ChiTietChucDanhs/5
        [HttpGet("{machucdanh}/{macanbo}")]
        public async Task<ActionResult<ChiTietChucDanhModel>> GetChiTietChucDanh(int machucdanh, string macanbo)
        {
          if (_context.chiTietChucDanh == null)
          {
              return NotFound();
          }
            var chiTietChucDanh = await _context.chiTietChucDanh.FindAsync(machucdanh, macanbo);
            if (chiTietChucDanh == null)
            {
                return NotFound();
            }

            return _mapper.Map<ChiTietChucDanhModel>(chiTietChucDanh);
        }

        // PUT: api/ChiTietChucDanhs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{machucdanh}/{macanbo}")]
        public async Task<IActionResult> PutChiTietChucDanh(int machucdanh, string macanbo, ChiTietChucDanhModel chiTietChucDanh)
        {
            if (machucdanh != chiTietChucDanh.Machucdanh || macanbo != chiTietChucDanh.Macanbo)
            {
                return BadRequest();
            }

            var chitiet = _mapper.Map<ChiTietChucDanh>(chiTietChucDanh);
            _context.chiTietChucDanh.Update(chitiet);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChiTietChucDanhExists(machucdanh, macanbo))
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

        // POST: api/ChiTietChucDanhs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ChiTietChucDanh>> PostChiTietChucDanh(ChiTietChucDanhModel chiTietChucDanh)
        {
          if (_context.chiTietChucDanh == null)
          {
              return Problem("Entity set 'StaffDbContext.chiTietChucDanh'  is null.");
          }

            var chitiet = _mapper.Map<ChiTietChucDanh>(chiTietChucDanh);
            _context.chiTietChucDanh.Add(chitiet);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ChiTietChucDanhExists(chiTietChucDanh.Machucdanh, chiTietChucDanh.Macanbo))
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

        // DELETE: api/ChiTietChucDanhs/5
        [HttpDelete("{machucdanh}/{macanbo}")]
        public async Task<IActionResult> DeleteChiTietChucDanh(int machucdanh, string macanbo)
        {
            if (_context.chiTietChucDanh == null)
            {
                return NotFound();
            }
            var chiTietChucDanh = await _context.chiTietChucDanh.FindAsync(machucdanh,macanbo);
            if (chiTietChucDanh == null)
            {
                return NotFound();
            }

            _context.chiTietChucDanh.Remove(chiTietChucDanh);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChiTietChucDanhExists(int machucdanh, string macanbo)
        {
            return (_context.chiTietChucDanh?.Any(e => e.Machucdanh == machucdanh && e.Macanbo == macanbo)).GetValueOrDefault();
        }
    }
}
