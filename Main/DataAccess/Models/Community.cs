using CentralService.DataAccess.Models;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class Community
    {
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Community Name
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Platform to which the Community belongs
        /// </summary>
        [Required]
        public int PlatformId { get; internal set; }
        public Platform Platform { get; set; }
        /// <summary>
        /// Community Dimensions
        /// </summary>
        [Required]
        public int Dimension { get; set; }        
    }
}
