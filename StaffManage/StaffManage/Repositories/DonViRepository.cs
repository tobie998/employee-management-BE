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

        public async Task<int> AddDonVi(DonViModel donvi)
        {
            var newDonVi = _mapper.Map<DonVi>(donvi);
            _context.donvi!.Add(newDonVi);
            await _context.SaveChangesAsync();

            return newDonVi.Madonvi;
        }

        public async Task DeleteDonVi(int id)
        {
            var deleteDonVi = _context.donvi!.SingleOrDefault(a => a.Madonvi == id);
            if(deleteDonVi != null)
            {
                _context.donvi!.Remove(deleteDonVi);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<DonViModel>> GetAllDonVi()
        {
            var donvis = await _context.donvi!.ToListAsync();
            return _mapper.Map<List<DonViModel>>(donvis);
        }

        public async Task<DonViModel> GetById(int id)
        {
            var donvis = await _context.donvi!.FindAsync(id);
            return _mapper.Map<DonViModel>(donvis);
        }

        public async Task UpdateDonVi(int id, DonViModel donvi)
        {
            if(id == donvi.Madonvi)
            {
                var updateDonVi = _mapper.Map<DonVi>(donvi);
                _context.donvi!.Update(updateDonVi);
                await _context.SaveChangesAsync();
            }
        }
    }
}
