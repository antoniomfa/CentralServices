using AutoMapper;
using CentralService.DataAccess.DTO;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;

namespace CentralServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformService _platService;
        private readonly ICommandDataClient _commandDataClient;        

        public PlatformsController(IPlatformService platService, ICommandDataClient commandDataClient)
        {
            _platService = platService;
            _commandDataClient = commandDataClient;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDTO>> GetAll()
        {
            System.Diagnostics.Debug.WriteLine("--> Getting All ...");

            IEnumerable<PlatformReadDTO> platforms = _platService.GetAll();

            return Ok(platforms);
        }

        [HttpGet("{id}", Name = "GetById")]
        public ActionResult<PlatformReadDTO> GetById(int id)
        {
            System.Diagnostics.Debug.WriteLine("--> Getting By Id ...");

            PlatformReadDTO platform = _platService.GetById(id);

            if (platform != null)
            {
                return Ok(platform);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<PlatformReadDTO>> Create(PlatformCreateDTO platformCreateDTO)
        {
            System.Diagnostics.Debug.WriteLine("--> Creating ...");

            PlatformReadDTO platformModel = _platService.Create(platformCreateDTO);

            try
            {
                await _commandDataClient.SendPlatformToCommunity(platformModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"--> Could not send synchronously: {ex.Message}");
            }

            return CreatedAtRoute(nameof(GetById), new { Id = platformModel.Id }, platformModel);
        }
    }
}
