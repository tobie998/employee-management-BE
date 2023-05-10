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
    public class ChucDanhController : ControllerBase
    {
        private readonly StaffDbContext _context;
        private readonly IMapper _mapper;

        public ChucDanhController(StaffDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/ChucDanh
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChucDanhModel>>> GetchucDanh()
        {
          if (_context.chucDanh == null)
          {
              return NotFound();
          }
          var list = await _context.chucDanh.ToListAsync();
            return _mapper.Map<List<ChucDanhModel>>(list);
        }

        // GET: api/ChucDanh/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChucDanhModel>> GetChucDanh(int id)
        {
          if (_context.chucDanh == null)
          {
              return NotFound();
          }
            var chucDanh = await _context.chucDanh.FindAsync(id);

            if (chucDanh == null)
            {
                return NotFound();
            }

            return _mapper.Map<ChucDanhModel>(chucDanh);
        }

        // PUT: api/ChucDanh/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChucDanh(int id, ChucDanhModel chucDanh)
        {
            if (id != chucDanh.Machucdanh)
            {
                return BadRequest();
            }

            var chitiet = _mapper.Map<ChucDanh>(chucDanh);
            _context.chucDanh!.Update(chitiet);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChucDanhExists(id))
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

        // POST: api/ChucDanh
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ChucDanh>> PostChucDanh(ChucDanhModel chucDanh)
        {
          if (_context.chucDanh == null)
          {
              return Problem("Entity set 'StaffDbContext.chucDanh'  is null.");
          }
            var chitiet = _mapper.Map<ChucDanh>(chucDanh);
            _context.chucDanh.Add(chitiet);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChucDanh", new { id = chucDanh.Machucdanh }, chucDanh);
        }

        // DELETE: api/ChucDanh/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChucDanh(int id)
        {
            if (_context.chucDanh == null)
            {
                return NotFound();
            }
            var chucDanh = await _context.chucDanh.FindAsync(id);
            if (chucDanh == null)
            {
                return NotFound();
            }

            _context.chucDanh.Remove(chucDanh);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChucDanhExists(int id)
        {
            return (_context.chucDanh?.Any(e => e.Machucdanh == id)).GetValueOrDefault();
        }
    }
}
