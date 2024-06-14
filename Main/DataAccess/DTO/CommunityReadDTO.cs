using CentralService.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class CommunityReadDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        /// <summary>
        public int PlatformId { get; internal set; }
        public int Dimension { get; set; }
    }
}
