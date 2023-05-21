using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using StaffManage.Models;
using StaffManage.Repositories.Http;


namespace StaffManage.Repositories.Http
{
    public class HttpCommandDataClient : ICommandDataClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public HttpCommandDataClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
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