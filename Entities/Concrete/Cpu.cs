using Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Concrete
{
    public class Cpu : IEntity
    {
        public int Id { get; set; }
        [Column("CpuName")]
        public string CpuName { get; set; }
        [Column("CpuCoreNumber")]
        public int CpuCore { get; set; }
        [Column("UsedCpuPercentage")]
        public decimal CpuUsage { get; set; }
        public int UserId { get; set; }
        public string Email { get; set; }
    }
}
