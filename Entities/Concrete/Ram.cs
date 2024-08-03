using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Ram : IEntity
    {
        public decimal RamAvailable { get; set; }
        public decimal RamTotal { get; set; }
        public decimal RamUsed { get; set; }
        public decimal UsagePercentage { get; set; }
        public int UserId { get; set; }
        public string Email { get; set; }
    }
}
