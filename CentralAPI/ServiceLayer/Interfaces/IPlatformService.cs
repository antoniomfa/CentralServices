using CentralService.DataAccess.DTO;

namespace ServiceLayer.Interfaces
{
    public interface IPlatformService
    {
        IEnumerable<PlatformReadDTO> GetAll();
        PlatformReadDTO GetById(int id);
        void Create(PlatformCreateDTO platform);
        bool SaveChanges();
    }
}
