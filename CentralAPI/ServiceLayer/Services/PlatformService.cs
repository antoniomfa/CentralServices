using AutoMapper;
using CentralService.DataAccess.Data;
using CentralService.DataAccess.DTO;
using ServiceLayer.Interfaces;

namespace ServiceLayer.Services
{
    public class PlatformService : IPlatformService
    {
        private readonly IPlatformRepo _repo;
        private readonly IMapper _mapper;

        public PlatformService(IPlatformRepo repo ,IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public void Create(PlatformCreateDTO platform)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PlatformReadDTO> GetAll()
        {
            var platforms = _repo.GetAll();

            return _mapper.Map<IEnumerable<PlatformReadDTO>>(platforms);
        }

        public PlatformReadDTO GetById(int id)
        {
            var platform = _repo.GetById(id);

            return _mapper.Map<PlatformReadDTO>(platform);
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
