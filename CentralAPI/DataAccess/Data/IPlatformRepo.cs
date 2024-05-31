using CentralService.DataAccess.Models;

namespace CentralService.DataAccess.Data
{
    public interface IPlatformRepo
    {
        IEnumerable<Platform> GetAll();
        Platform GetById(int id);
        void Create(Platform platform);
        bool SaveChanges();
    }
}
