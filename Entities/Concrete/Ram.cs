using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Ram : IEntity
    {
        public int Id { get; set; }
        [Column("AvailableMemory")]
        public decimal RamAvailable { get; set; }
        [Column("TotalMemory")]
        public decimal RamTotal { get; set; }
        [Column("UsedMemory")]
        public decimal RamUsed { get; set; }
        [Column("UsagePercentage")]
        public decimal UsagePercentage { get; set; }
        public int UserId { get; set; }
        public string Email { get; set; }
    }
}
