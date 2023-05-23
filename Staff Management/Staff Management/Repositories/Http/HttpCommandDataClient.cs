using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Staff_Management.Models;
using StaffManage.Data;
using StaffManage.Models;
using StaffManage.Repositories.Http;


namespace StaffManage.Repositories.Http
{
    public class HttpCommandDataClient : ICommandDataClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly StaffDbContext _context;

        public HttpCommandDataClient(HttpClient httpClient, IConfiguration configuration, StaffDbContext context)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _context = context; 
        }

        public async Task SendStaffToLearning(CanBo canBo)
        {
            QuanLyDaoTao qli = new QuanLyDaoTao();
            qli.MaNhanSu = canBo.Macanbo;
            qli.TenNhanSu = canBo.Hoten;
            qli.DiaChi = canBo.Diachinharieng;
            var chucvu = await _context.chucVu.FirstOrDefaultAsync(a => a.Machucvu.Equals(canBo.Machucvu));
            qli.ChucVu = chucvu != null ? chucvu.Tenchucvu : "";
            qli.Email = canBo.Email;
            qli.isDelete = canBo.isDelete;

            var httpContent = new StringContent(
                JsonSerializer.Serialize(qli),
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync("https://localhost:7225/api/NhanSu/SyncData", httpContent);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("--> Sync POST to CommandService was OK!");
            }
            else
            {
                Console.WriteLine("--> Sync POST to CommandService was NOT OK!");
                Console.WriteLine($"Status code: {response.StatusCode}");
                var errorMessage = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error message: {errorMessage}");
            }
        }

        public async Task SendStaffToResearcher(CanBoNghienCuu canBo)
        {
            var httpContent = new StringContent(
                JsonSerializer.Serialize(canBo),
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync("https://localhost:7152/api/CanBoNghienCuu/SyncData", httpContent);

            if(response.IsSuccessStatusCode)
            {
                Console.WriteLine("--> Sync POST to CommandService was OK!");
            }
            else
            {
                Console.WriteLine("--> Sync POST to CommandService was NOT OK!");
                Console.WriteLine($"Status code: {response.StatusCode}");
                var errorMessage = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error message: {errorMessage}");
            }
        }
    }
}