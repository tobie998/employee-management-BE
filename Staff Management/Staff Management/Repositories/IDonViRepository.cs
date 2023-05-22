using StaffManage.Data;
using StaffManage.Models;

namespace StaffManage.Repositories
{
    public interface IDonViRepository
    {
        public Task<List<DonViModel>> GetAllDonVi();
        public Task<DonViModel> GetById(string id);
        public Task<string> AddDonVi(DonViModel donvi);
        public Task UpdateDonVi(string id,DonViModel donvi);
        public Task DeleteDonVi(string id);
    }
}
