 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Learning_Management.Data;
using AutoMapper;
using Learning_Management.Models;

namespace Learning_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhanSuController : ControllerBase
    {
        private readonly LearningDBContext _context;
        private readonly IMapper _mapper;

        public NhanSuController(LearningDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/NhanSu
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NhanSuModel>>> GetNhanSu()
        {
          if (_context.NhanSu == null)
          {
              return NotFound();
          }
            var canbos = await _context.NhanSu.Where(e => e.isDelete == 0).ToListAsync();
            return _mapper.Map<List<NhanSuModel>>(canbos);
        }

        // GET: api/NhanSu/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NhanSuModel>> GetNhanSu(string id)
        {
          if (_context.NhanSu == null)
          {
              return NotFound();
          }
            var nhanSu = await _context.NhanSu.SingleOrDefaultAsync(cb => cb.Manhansu == id && cb.isDelete == 0);

            if (nhanSu == null)
            {
                return NotFound();
            }

            return _mapper.Map<NhanSuModel>(nhanSu); 
        }

        // PUT: api/NhanSu/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNhanSu(string id, NhanSuModel nhanSu)
        {
            if (id != nhanSu.MaNhanSu)
            {
                return BadRequest();
            }

            var canBo = _mapper.Map<NhanSu>(nhanSu);
            _context.NhanSu!.Update(canBo);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NhanSuExists(id))
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

        // POST: api/NhanSu
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NhanSu>> PostNhanSu(NhanSuModel nhanSu)
        {
          if (_context.NhanSu == null)
          {
              return Problem("Entity set 'LearningDBContext.NhanSu'  is null.");
          }
            var canBo = _mapper.Map<NhanSu>(nhanSu);
            _context.NhanSu.Add(canBo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (NhanSuExists(nhanSu.MaNhanSu))
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

        // DELETE: api/NhanSu/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNhanSu(string id)
        {
            if (_context.NhanSu == null)
            {
                return NotFound();
            }
            var nhanSu = await _context.NhanSu.FindAsync(id);
            if (nhanSu == null)
            {
                return NotFound();
            }
            nhanSu.isDelete = 1;
            _context.NhanSu.Update(nhanSu);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NhanSuExists(string id)
        {
            return (_context.NhanSu?.Any(e => e.Manhansu == id)).GetValueOrDefault();
        }

        [HttpPost("SyncData")]
        public async Task<ActionResult<IEnumerable<CanBo>>> SyncData(CanBo nhanSu)
        {
            var canBo = _mapper.Map<NhanSu>(nhanSu);
            if (NhanSuExists(canBo.Manhansu))
            {
                _context.NhanSu.Update(canBo);
            }
            else
            {
                _context.NhanSu.Add(canBo);
            }
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw;
            }

            return Ok();
        }
    }
}
