using CentralService.DataAccess.Models;

namespace CentralService.DataAccess.Data
{
    public class PlatformRepo : IPlatformRepo
    {
        private readonly AppDbContext _dbContext;

        public PlatformRepo(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Platform> GetAll()
        {
            return _dbContext.Platforms.ToList();
        }

        public Platform GetById(int id)
        {
            return _dbContext.Platforms.FirstOrDefault(x => x.Id == id);
        }

        public void Create(Platform platform)
        {
            if (platform == null) { throw new ArgumentNullException(nameof(platform)); }

            _dbContext.Platforms.Add(platform);
        }

        public bool SaveChanges()
        {
            return (_dbContext.SaveChanges() >= 0);
        }
    }
}
