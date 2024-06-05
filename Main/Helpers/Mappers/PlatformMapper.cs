using AutoMapper;
using CentralService.DataAccess.DTO;
using CentralService.DataAccess.Models;

namespace CentralService.Helpers.Mappers
{
    public class PlatformMapper : Profile
    {
        public PlatformMapper()
        {
            CreateMap<Platform, PlatformReadDTO>().ReverseMap();
            CreateMap<PlatformCreateDTO, Platform>().ReverseMap();
        }
    }
}
