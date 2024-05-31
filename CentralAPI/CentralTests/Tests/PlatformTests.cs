using Moq;
using CentralService.DataAccess.Data;
using CentralService.DataAccess.Models;
using CentralServiceAPI.Controllers;
using CentralTests.MockData;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;
using ServiceLayer.Services;
using AutoMapper;
using CentralService.DataAccess.DTO;

namespace CentralTests.Tests
{
    public class PlatformTests 
    {
        private Mock<IPlatformRepo> PlatformRepo;
        private IPlatformService PlateformService;
        private PlatformsController Controller;
        private IMapper _mapper;

        public PlatformTests()
        {
            IEnumerable<Platform> platforms = new PlatformMockData().Platforms;

            PlatformRepo = new Mock<IPlatformRepo>();           

            PlatformRepo.Setup(x => x.GetAll()).Returns(platforms);

            // Mappers
            var config = new MapperConfiguration(x =>
            {
                x.CreateMap<Platform, PlatformReadDTO>().ReverseMap();
            });

            _mapper = config.CreateMapper();

            PlateformService = new PlatformService(PlatformRepo.Object, _mapper);
            Controller = new PlatformsController(PlateformService);
        }

        [Fact]
        public void GetAll_OK()
        {
            // Arrange                      

            // Act
            var response = Controller.GetAll();
            PlatformRepo.Verify(x => x.GetAll(), Times.Once);

            // Assert
            OkObjectResult result = Assert.IsType<OkObjectResult>(response.Result);

            Assert.Equal(200, result.StatusCode);
            Assert.IsType<OkObjectResult>(result);

            IEnumerable<PlatformReadDTO> responseObj = Assert.IsAssignableFrom<IEnumerable<PlatformReadDTO>>(result.Value);

            Assert.NotNull(responseObj);
            Assert.Equal(4, responseObj.Count());
        }

        [Fact]
        public void GetAll_NOK()
        {
            // Arrange
            //PlatformRepo.Setup(x => x.GetAll()).Throws(null);

            // Act
            var response = Controller.GetAll();
            PlatformRepo.Verify(x => x.GetAll(), Times.Once);

            // Assert
            OkObjectResult result = Assert.IsType<OkObjectResult>(response.Result);

            Assert.Equal(200, result.StatusCode);
            Assert.IsType<OkObjectResult>(result);

            IEnumerable<PlatformReadDTO> responseObj = Assert.IsAssignableFrom<IEnumerable<PlatformReadDTO>>(result.Value);

            Assert.Null(responseObj);
        }
    }
}