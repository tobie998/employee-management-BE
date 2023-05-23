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
    public class DonViController : ControllerBase
    {
        private readonly StaffDbContext _context;
        private readonly IMapper _mapper;

        public DonViController(StaffDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        // GET: api/DonVi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DonViModel>>> Getdonvi()
        {
          if (_context.donVi == null)
          {
              return NotFound();
          }
            var list = await _context.donVi.Where(e => e.isDelete == 0).ToListAsync();

            return _mapper.Map<List<DonViModel>>(list);
        }

        // GET: api/DonVi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DonViModel>> GetDonVi(string id)
        {
          if (_context.donVi == null)
          {
              return NotFound();
          }
            var donVi = await _context.donVi.SingleOrDefaultAsync(cb => cb.Madonvi == id && cb.isDelete == 0);

            if (donVi == null)
            {
                return NotFound();
            }

            return _mapper.Map<DonViModel>(donVi);
        }

        // PUT: api/DonVi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDonVi(string id, DonViModel donVi)
        {
            if (id != donVi.MaDonVi)
            {
                return BadRequest();
            }
            var chitiet = _mapper.Map<DonVi>(donVi);
            _context.donVi!.Update(chitiet);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DonViExists(id))
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

        // POST: api/DonVi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DonVi>> PostDonVi(DonViModel donVi)
        {
          if (_context.donVi == null)
          {
              return Problem("Entity set 'StaffDbContext.donvi'  is null.");
          }

            var chitiet = _mapper.Map<DonVi>(donVi);
            _context.donVi.Add(chitiet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDonVi", new { id = donVi.MaDonVi }, donVi);
        }

        // DELETE: api/DonVi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDonVi(string id)
        {
            if (_context.donVi == null)
            {
                return NotFound();
            }
            var donVi = await _context.donVi.FindAsync(id);
            if (donVi == null)
            {
                return NotFound();
            }
            donVi.isDelete = 1;
            _context.donVi.Update(donVi);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DonViExists(string id)
        {
            return (_context.donVi?.Any(e => e.Madonvi == id)).GetValueOrDefault();
        }
    }
}
