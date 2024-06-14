using Moq;
using AutoMapper;
using ServiceLayer.Services;
using CentralTests.MockData;
using ServiceLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using CentralServiceAPI.Controllers;
using CentralService.DataAccess.DTO;
using CentralService.DataAccess.Data;
using CentralService.DataAccess.Models;
using Microsoft.Extensions.Configuration;

namespace CentralTests.Tests
{
    public class PlatformTests 
    {
        private Mock<IPlatformRepo> platformRepo;
        private IPlatformService plateformService;
        private PlatformsController controller;
        private IMapper _mapper;
        private ICommandDataClient commandDataClient;
        private HttpClient httpClient;
        private readonly IConfiguration configuration;

        public PlatformTests()
        {
            IEnumerable<Platform> platforms = new PlatformMockData().Platforms;

            platformRepo = new Mock<IPlatformRepo>();           

            platformRepo.Setup(x => x.GetAll()).Returns(platforms);

            // Mappers
            var config = new MapperConfiguration(x =>
            {
                x.CreateMap<Platform, PlatformReadDTO>().ReverseMap();
            });

            _mapper = config.CreateMapper();

            plateformService = new PlatformService(platformRepo.Object, _mapper);
            httpClient = new HttpClient();
            commandDataClient = new HttpCommandDataClient(httpClient, configuration);
            controller = new PlatformsController(plateformService, commandDataClient);
        }

        [Fact]
        public void GetAll_OK()
        {
            // Arrange                      

            // Act
            var response = controller.GetAll();
            platformRepo.Verify(x => x.GetAll(), Times.Once);

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
            var response = controller.GetAll();
            platformRepo.Verify(x => x.GetAll(), Times.Once);

            // Assert
            OkObjectResult result = Assert.IsType<OkObjectResult>(response.Result);

            Assert.Equal(200, result.StatusCode);
            Assert.IsType<OkObjectResult>(result);

            IEnumerable<PlatformReadDTO> responseObj = Assert.IsAssignableFrom<IEnumerable<PlatformReadDTO>>(result.Value);

            Assert.Null(responseObj);
        }
    }
}