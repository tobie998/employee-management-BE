using StaffManage.Data;
using StaffManage.Models;

namespace StaffManage.Repositories
{
    public interface IAccountRepository
    {
        public ApplicationUser SignInAsync(string account, string password);

    }
}
