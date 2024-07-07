using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveCpuRam_WinApp.Entity
{
    internal class CpuInfoEntity
    {
        public string CpuName { get; set; }
        public int CpuCore { get; set; }
        public float CpuUsage { get; set; }
    }
}
