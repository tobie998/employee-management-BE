﻿using System;
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
    public class TrinhDoNgoaiNguController : ControllerBase
    {
        private readonly StaffDbContext _context;
        private readonly IMapper _mapper;

        public TrinhDoNgoaiNguController(StaffDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/TrinhDoNgoaiNgus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrinhDoNgoaiNguModel>>> GettrinhDoNgoaiNgu()
        {
          if (_context.trinhDoNgoaiNgu == null)
          {
              return NotFound();
          }
            var list = await _context.trinhDoNgoaiNgu.Where(e => e.isDelete == 0).ToListAsync();
            return _mapper.Map<List<TrinhDoNgoaiNguModel>>(list);
        }

        // GET: api/TrinhDoNgoaiNgus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TrinhDoNgoaiNguModel>> GetTrinhDoNgoaiNgu(string id)
        {
          if (_context.trinhDoNgoaiNgu == null)
          {
              return NotFound();
          }
            var trinhDoNgoaiNgu = await _context.trinhDoNgoaiNgu.SingleOrDefaultAsync(cb => cb.Mangoaingu == id && cb.isDelete == 0);

            if (trinhDoNgoaiNgu == null)
            {
                return NotFound();
            }

            return _mapper.Map<TrinhDoNgoaiNguModel>(trinhDoNgoaiNgu);
        }

        // PUT: api/TrinhDoNgoaiNgus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrinhDoNgoaiNgu(string id, TrinhDoNgoaiNguModel trinhDoNgoaiNgu)
        {
            if (id != trinhDoNgoaiNgu.MaNgoaiNgu)
            {
                return BadRequest();
            }

            var chitiet = _mapper.Map<TrinhDoNgoaiNgu>(trinhDoNgoaiNgu);
            _context.trinhDoNgoaiNgu!.Update(chitiet);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrinhDoNgoaiNguExists(id))
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

        // POST: api/TrinhDoNgoaiNgus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TrinhDoNgoaiNgu>> PostTrinhDoNgoaiNgu(TrinhDoNgoaiNguModel trinhDoNgoaiNgu)
        {
          if (_context.trinhDoNgoaiNgu == null)
          {
              return Problem("Entity set 'StaffDbContext.trinhDoNgoaiNgu'  is null.");
          }
            var chitiet = _mapper.Map<TrinhDoNgoaiNgu>(trinhDoNgoaiNgu);
            _context.trinhDoNgoaiNgu.Add(chitiet);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/TrinhDoNgoaiNgus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrinhDoNgoaiNgu(string id)
        {
            if (_context.trinhDoNgoaiNgu == null)
            {
                return NotFound();
            }
            var trinhDoNgoaiNgu = await _context.trinhDoNgoaiNgu.FindAsync(id);
            if (trinhDoNgoaiNgu == null)
            {
                return NotFound();
            }
            trinhDoNgoaiNgu.isDelete = 1;
            _context.trinhDoNgoaiNgu.Update(trinhDoNgoaiNgu);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrinhDoNgoaiNguExists(string id)
        {
            return (_context.trinhDoNgoaiNgu?.Any(e => e.Mangoaingu == id)).GetValueOrDefault();
        }
    }
}
