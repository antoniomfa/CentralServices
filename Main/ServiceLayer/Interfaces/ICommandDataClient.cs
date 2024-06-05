using CentralService.DataAccess.DTO;

namespace ServiceLayer.Interfaces
{
    public interface ICommandDataClient
    {
        Task SendPlatformToCommunity(PlatformReadDTO plat);
    }
}
