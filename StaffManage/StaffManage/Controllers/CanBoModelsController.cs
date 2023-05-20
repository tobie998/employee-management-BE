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
using StaffManage.RabitMQ;

namespace StaffManage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CanBoModelsController : ControllerBase
    {
        private readonly StaffDbContext _context;
        private readonly IMapper _mapper;
        private readonly IRabitMQProducer _rabitMQProducer;
        public CanBoModelsController(StaffDbContext context, IMapper mapper, IRabitMQProducer rabitMQProducer)
        {
            _context = context;
            _mapper = mapper;
            _rabitMQProducer = rabitMQProducer;
        }

        // GET: api/CanBoModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CanBoModel>>> GetCanBoModel()
        {
          if (_context.canBo == null)
          {
              return NotFound();
          }
          var canbos =  await _context.canBo.Where(e => e.isDelete == 0).ToListAsync(); ;
          return _mapper.Map<List<CanBoModel>>(canbos);
        }

        // GET: api/CanBoModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CanBoModel>> GetCanBoModel(string id)
        {
          if (_context.canBo == null)
          {
              return NotFound();
          }
            var canBo = await _context.canBo.SingleOrDefaultAsync(cb => cb.Macanbo == id && cb.isDelete == 0); 

            if (canBo == null)
            {
                return NotFound();
            }

            return _mapper.Map<CanBoModel>(canBo);
        }

        // PUT: api/CanBoModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCanBoModel(string id, CanBoModel canBoModel)
        {
            if (id != canBoModel.MaCanBo)
            {
                return BadRequest();
            }

            var canBo = _mapper.Map<CanBo>(canBoModel);
            _context.canBo!.Update(canBo);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CanBoModelExists(id))
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

        // POST: api/CanBoModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CanBo>> PostCanBoModel(CanBoModel canBoModel)
        {
          if (_context.canBo == null)
          {
              return Problem("Entity set 'CanBo'  is null.");
          }
          var canBo = _mapper.Map<CanBo>(canBoModel);
          _context.canBo.Add(canBo);
            
            try
            {
                await _context.SaveChangesAsync();

                // tạo model mới để truyền message
                /*CanBoNghienCuu canBoNghienCuu = new CanBoNghienCuu();
                canBoNghienCuu.Macanbonghiencuu = canBoModel.Macanbo;
                canBoNghienCuu.Chunhiemdetai = canBoModel.Hoten;
                var chucDanh = await _context.chiTietChucDanh.FirstOrDefaultAsync(a => a.Macanbo.Equals(canBoModel.Macanbo));
                canBoNghienCuu.Chucdanhnghenghiep = chucDanh != null ? chucDanh.Tenchucdanh : "";
                canBoNghienCuu.Hocham = canBoModel.Hocham;
                canBoNghienCuu.Dienthoai = canBoModel.Mobile;
                canBoNghienCuu.Email = canBoModel.Email;
                var donvi = await _context.donvi.FindAsync(canBoModel.Madonvi);
                canBoNghienCuu.Khoacongtac = donvi.Tendonvi;
                canBoNghienCuu.status = 1; //add
                _rabitMQProducer.SendProductMessage(canBoNghienCuu);*/
            }
            catch (DbUpdateException)
            {
                if (CanBoModelExists(canBoModel.MaCanBo))
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

        // DELETE: api/CanBoModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCanBoModel(string id)
        {
            if (_context.canBo == null)
            {
                return NotFound();
            }
            var canBoModel = await _context.canBo.FindAsync(id);
            if (canBoModel == null)
            {
                return NotFound();
            }
            var canBo = _mapper.Map<CanBo>(canBoModel);
            canBo.isDelete = 1;
            _context.canBo.Update(canBo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CanBoModelExists(string id)
        {
            return (_context.canBo?.Any(e => e.Macanbo == id)).GetValueOrDefault();
        }
    }
}
