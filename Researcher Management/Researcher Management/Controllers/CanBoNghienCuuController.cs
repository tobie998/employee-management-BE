using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Researcher_Management.Data;
using Researcher_Management.Models;

namespace Researcher_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CanBoNghienCuuController : ControllerBase
    {
        private readonly ResercherDBContext _context;
        private readonly IMapper _mapper;
         
        public CanBoNghienCuuController(ResercherDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Post: api/CanBoNghienCuu/SyncData
        [HttpPost("SyncData")]
        public async Task<ActionResult<IEnumerable<DataCBNC>>> SyncData(DataCBNC canBoNghienCuu)
        {
            var canBo = _mapper.Map<CanBoNghienCuu>(canBoNghienCuu);
            if (CanBoNghienCuuExists(canBo.Macanbonghiencuu))
            {
                _context.canBoNghienCuu.Update(canBo);
            }
            else
            {
                _context.canBoNghienCuu.Add(canBo);
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

            // GET: api/CanBoNghienCuu
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CanBoNghienCuuModel>>> GetcanBoNghienCuu()
        {
          if (_context.canBoNghienCuu == null)
          {
              return NotFound();
          }
            var canbos = await _context.canBoNghienCuu.Where(e => e.isDelete == 0).ToListAsync();
            return _mapper.Map<List<CanBoNghienCuuModel>>(canbos);
        }

        // GET: api/CanBoNghienCuu/5 
        [HttpGet("{id}")]
        public async Task<ActionResult<CanBoNghienCuuModel>> GetCanBoNghienCuu(string id)
        {
          if (_context.canBoNghienCuu == null)
          {
              return NotFound();
          }
            var canBoNghienCuu = await _context.canBoNghienCuu.SingleOrDefaultAsync(cb => cb.Macanbonghiencuu == id && cb.isDelete == 0);

            if (canBoNghienCuu == null)
            {
                return NotFound();
            }

            return _mapper.Map<CanBoNghienCuuModel>(canBoNghienCuu);
        }

        // PUT: api/CanBoNghienCuu/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCanBoNghienCuu(string id, CanBoNghienCuuModel canBoNghienCuu)
        {
            if (id != canBoNghienCuu.MaCanBoNghienCuu)
            {
                return BadRequest();
            }

            var canBo = _mapper.Map<CanBoNghienCuu>(canBoNghienCuu);
            _context.canBoNghienCuu!.Update(canBo);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CanBoNghienCuuExists(id))
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

        // POST: api/CanBoNghienCuu
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CanBoNghienCuu>> PostCanBoNghienCuu(CanBoNghienCuuModel canBoNghienCuu)
        {
          if (_context.canBoNghienCuu == null)
          {
              return Problem("Entity set 'ResercherDBContext.canBoNghienCuu'  is null.");
          }
            var canBo = _mapper.Map<CanBoNghienCuu>(canBoNghienCuu);
            _context.canBoNghienCuu.Add(canBo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CanBoNghienCuuExists(canBoNghienCuu.MaCanBoNghienCuu))
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

        // DELETE: api/CanBoNghienCuu/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCanBoNghienCuu(string id)
        {
            if (_context.canBoNghienCuu == null)
            {
                return NotFound();
            }
            var canBoNghienCuu = await _context.canBoNghienCuu.FindAsync(id);
            if (canBoNghienCuu == null)
            {
                return NotFound();
            }
            canBoNghienCuu.isDelete = 1;
            _context.canBoNghienCuu.Update(canBoNghienCuu);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CanBoNghienCuuExists(string id)
        {
            return (_context.canBoNghienCuu?.Any(e => e.Macanbonghiencuu == id)).GetValueOrDefault();
        }
    }
}
