using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveCpuRam_WinApp.Entity
{
    internal class RamInfoEntity
    {
        public float RamAvailable { get; set; }
        public float RamTotal { get; set; }
        public float RamUsed { get; set; }
        public  float RamPercentage { get; set; }
    }
}
