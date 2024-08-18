using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IResourceMonitorService
    {
        void StartMonitoring();
        void StopMonitoring();
        double CpuWarningThreshold { get; set; }
        double RamWarningThreshold { get; set; }
        double DriveWarningThreshold { get; set; }
    }
}
