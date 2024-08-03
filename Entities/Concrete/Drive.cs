using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Drive : IEntity
    {
        public int Id { get; set; }
        public string DriveName { get; set; }
        [Column("TotalSpaceGB")]
        public decimal TotalSpace { get; set; }
        [Column("AvailableSpaceGB")]
        public decimal AvailableSpace { get; set; }
        [Column("UsedSpaceGB")]
        public decimal UsedSpace { get; set; }
        [Column("UsedPercentage")]
        public decimal UsedSpacePercentage { get; set; }
        public int UserId { get; set; }
        public string Email { get; set; }
    }
}
