using StaffManage.Data;
using StaffManage.Models;
using System.Threading.Tasks;

namespace StaffManage.Repositories.Http
{
    public interface ICommandDataClient
    {
        Task SendStaffToResearcher(CanBoNghienCuu canBo); 
        Task SendStaffToLearning(CanBo canBo); 
    }
}