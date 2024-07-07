using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveCpuRam_WinApp.Entity
{
    internal class DriveInfoEntity
    {
        public string DriveName { get; set; }
        public decimal TotalSpaceGB { get; set; }
        public decimal AvailableSpaceGB { get; set; }
        public decimal UsedSpaceGB { get; set; }
        public decimal UsedPercentage { get; set; }
        
    }
}
