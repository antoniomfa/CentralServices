using CentralService.DataAccess.DTO;
using Microsoft.Extensions.Configuration;
using ServiceLayer.Interfaces;
using System.Text;
using System.Text.Json;

namespace ServiceLayer.Services
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

        public async Task SendPlatformToCommunity(PlatformReadDTO plat)
        {
            var httpContent = new StringContent(
                JsonSerializer.Serialize(plat), Encoding.UTF8, "application/json");

            //var response = await _httpClient.PostAsync($"{_configuration["CommunityService"]}", httpContent);
            var response = await _httpClient.PostAsync($"https://localhost:6001/api/c/platforms", httpContent);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("-- > Sync POST to Community Service was OK!");
            }
            else
            {
                Console.WriteLine("-- > Sync POST to Community Service was NOT OK...");
            }
        }
    }
}
