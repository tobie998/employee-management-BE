using StaffManage.Data;
using StaffManage.Models;

namespace StaffManage.Repositories
{
    public interface IDonViRepository
    {
        public Task<List<DonViModel>> GetAllDonVi();
        public Task<DonViModel> GetById(int id);
        public Task<int> AddDonVi(DonViModel donvi);
        public Task UpdateDonVi(int id,DonViModel donvi);
        public Task DeleteDonVi(int id);
    }
}
