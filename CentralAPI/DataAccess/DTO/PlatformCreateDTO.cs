using System.ComponentModel.DataAnnotations;

namespace CentralService.DataAccess.DTO
{
    public class PlatformCreateDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Cost { get; set; }
    }
}
