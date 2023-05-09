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
    public class ChucVuController : ControllerBase
    {
        private readonly StaffDbContext _context;
        private readonly IMapper _mapper;

        public ChucVuController(StaffDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/ChucVu
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChucVuModel>>> GetchucVu()
        {
          if (_context.chucVu == null)
          {
              return NotFound();
          }
            var chucvu = await _context.chucVu.ToListAsync();
            return _mapper.Map<List<ChucVuModel>>(chucvu);
        }

        // GET: api/ChucVu/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChucVuModel>> GetChucVu(int id)
        {
          if (_context.chucVu == null)
          {
              return NotFound();
          }
            var chucVu = await _context.chucVu.FindAsync(id);

            if (chucVu == null)
            {
                return NotFound();
            }

            return _mapper.Map<ChucVuModel>(chucVu);
        }

        // PUT: api/ChucVu/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChucVu(int id, ChucVuModel chucVu)
        {
            if (id != chucVu.Machucvu)
            {
                return BadRequest();
            }

            var chitiet = _mapper.Map<ChucVu>(chucVu);
            _context.chucVu!.Update(chitiet);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChucVuExists(id))
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

        // POST: api/ChucVu
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ChucVuModel>> PostChucVu(ChucVuModel chucVu)
        {
          if (_context.chucVu == null)
          {
              return Problem("Entity set 'StaffDbContext.chucVu'  is null.");
          }
            var chitiet = _mapper.Map<ChucVu>(chucVu);
            _context.chucVu.Add(chitiet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChucVu", new { id = chucVu.Machucvu }, chucVu);
        }

        // DELETE: api/ChucVu/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChucVu(int id)
        {
            if (_context.chucVu == null)
            {
                return NotFound();
            }
            var chucVu = await _context.chucVu.FindAsync(id);
            if (chucVu == null)
            {
                return NotFound();
            }

            _context.chucVu.Remove(chucVu);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChucVuExists(int id)
        {
            return (_context.chucVu?.Any(e => e.Machucvu == id)).GetValueOrDefault();
        }
    }
}
