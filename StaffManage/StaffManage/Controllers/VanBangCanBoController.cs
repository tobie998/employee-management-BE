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
    public class VanBangCanBoController : ControllerBase
    {
        private readonly StaffDbContext _context;
        private readonly IMapper _mapper;

        public VanBangCanBoController(StaffDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/VanBangCanBoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VanBangCanBoModel>>> GetvanBang()
        {
          if (_context.vanBang == null)
          {
              return NotFound();
          }
            var list = await _context.vanBang.Where(e => e.isDelete == 0).ToListAsync();
            return _mapper.Map<List<VanBangCanBoModel>>(list);
        }

        // GET: api/VanBangCanBoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VanBangCanBoModel>> GetVanBangCanBo(int id)
        {
          if (_context.vanBang == null)
          {
              return NotFound();
          }
            var vanBangCanBo = await _context.vanBang.SingleOrDefaultAsync(cb => cb.Mavanbang == id && cb.isDelete == 0);

            if (vanBangCanBo == null)
            {
                return NotFound();
            }

            return _mapper.Map<VanBangCanBoModel>(vanBangCanBo);
        }

        // PUT: api/VanBangCanBoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVanBangCanBo(int id, VanBangCanBoModel vanBangCanBo)
        {
            if (id != vanBangCanBo.MaVanBang)
            {
                return BadRequest();
            }
            var chitiet = _mapper.Map<VanBangCanBo>(vanBangCanBo);
            _context.vanBang!.Update(chitiet);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VanBangCanBoExists(id))
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

        // POST: api/VanBangCanBoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VanBangCanBo>> PostVanBangCanBo(VanBangCanBoModel vanBangCanBo)
        {
          if (_context.vanBang == null)
          {
              return Problem("Entity set 'StaffDbContext.vanBang'  is null.");
          }
            var chitiet = _mapper.Map<VanBangCanBo>(vanBangCanBo);
            _context.vanBang.Add(chitiet);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/VanBangCanBoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVanBangCanBo(int id)
        {
            if (_context.vanBang == null)
            {
                return NotFound();
            }
            var vanBangCanBo = await _context.vanBang.FindAsync(id);
            if (vanBangCanBo == null)
            {
                return NotFound();
            }
            vanBangCanBo.isDelete = 1;
            _context.vanBang.Update(vanBangCanBo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VanBangCanBoExists(int id)
        {
            return (_context.vanBang?.Any(e => e.Mavanbang == id)).GetValueOrDefault();
        }
    }
}
