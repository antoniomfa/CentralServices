﻿using DataAccess.Models;
using System.ComponentModel.DataAnnotations;

namespace CentralService.DataAccess.Models
{
    public class Platform
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Cost { get; set; }

        /// <summary>
        /// Communities using this Platform
        /// </summary>
        public ICollection<Community> Communities { get; set; } = new List<Community>();
    }
}
