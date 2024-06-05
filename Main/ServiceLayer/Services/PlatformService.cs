using AutoMapper;
using CentralService.DataAccess.Data;
using CentralService.DataAccess.DTO;
using CentralService.DataAccess.Models;
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

        public PlatformReadDTO Create(PlatformCreateDTO platformCreateDTO)
        {
            var platformModel = _mapper.Map<Platform>(platformCreateDTO);

            _repo.Create(platformModel);
            _repo.SaveChanges();

            var platformRead = _mapper.Map<PlatformReadDTO>(platformModel);

            return platformRead;
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
