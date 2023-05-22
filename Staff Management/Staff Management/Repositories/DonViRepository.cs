using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StaffManage.Data;
using StaffManage.Models;

namespace StaffManage.Repositories
{
    public class DonViRepository : IDonViRepository
    {
        private readonly StaffDbContext _context;
        private readonly IMapper _mapper;

        public DonViRepository(StaffDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<string> AddDonVi(DonViModel donvi)
        {
            var newDonVi = _mapper.Map<DonVi>(donvi);
            _context.donVi!.Add(newDonVi);
            await _context.SaveChangesAsync();

            return newDonVi.Madonvi;
        }

        public async Task DeleteDonVi(string id)
        {
            var deleteDonVi = _context.donVi!.SingleOrDefault(a => a.Madonvi == id);
            if(deleteDonVi != null)
            {
                _context.donVi!.Remove(deleteDonVi);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<DonViModel>> GetAllDonVi()
        {
            var donvis = await _context.donVi!.ToListAsync();
            return _mapper.Map<List<DonViModel>>(donvis);
        }

        public async Task<DonViModel> GetById(string id)
        {
            var donvis = await _context.donVi!.FindAsync(id);
            return _mapper.Map<DonViModel>(donvis);
        }

        public async Task UpdateDonVi(string id, DonViModel donvi)
        {
            if(id == donvi.MaDonVi)
            {
                var updateDonVi = _mapper.Map<DonVi>(donvi);
                _context.donVi!.Update(updateDonVi);
                await _context.SaveChangesAsync();
            }
        }
    }
}
