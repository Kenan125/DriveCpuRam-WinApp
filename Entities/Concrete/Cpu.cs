using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Cpu : IEntity
    {
        public string CpuName { get; set; }
        public int CpuCore { get; set; }
        public float CpuUsage { get; set; }
        public int UserId { get; set; }
        public string Email { get; set; }
    }
}
