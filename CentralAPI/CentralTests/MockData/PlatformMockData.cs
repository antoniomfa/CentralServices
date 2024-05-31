using CentralService.DataAccess.Models;

namespace CentralTests.MockData
{
    public class PlatformMockData
    {
        public IEnumerable<Platform> Platforms => new List<Platform>()
        {
            new Platform() { Name = "PC", Brand = "AMD", Cost = "1500" },
            new Platform() { Name = "PS5", Brand = "SONY", Cost = "700" },
            new Platform() { Name = "XBOX", Brand = "MICROSOFT", Cost = "600" },
            new Platform() { Name = "SWITCH", Brand = "NINTENDO", Cost = "500" }
        };
    }
}
