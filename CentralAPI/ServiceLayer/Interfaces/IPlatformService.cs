using CentralService.DataAccess.DTO;

namespace ServiceLayer.Interfaces
{
    public interface IPlatformService
    {
        IEnumerable<PlatformReadDTO> GetAll();
        PlatformReadDTO GetById(int id);
        PlatformReadDTO Create(PlatformCreateDTO platform);
        bool SaveChanges();
    }
}
