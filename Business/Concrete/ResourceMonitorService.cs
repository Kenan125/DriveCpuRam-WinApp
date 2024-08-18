using Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ResourceMonitorService : IResourceMonitorService
    {
        public double CpuWarningThreshold { get; set; } = 90.0;
        public double RamWarningThreshold { get; set; } = 90.0;
        public double DriveWarningThreshold { get; set; } = 90.0;

        private System.Threading.Timer _monitoringTimer;

        public void StartMonitoring()
        {
            _monitoringTimer = new System.Threading.Timer(MonitorResources, null, TimeSpan.Zero, TimeSpan.FromMinutes(1));
        }

        public void StopMonitoring()
        {
            _monitoringTimer?.Change(Timeout.Infinite, 0);
        }

        private void MonitorResources(object state)
        {
            // Create an instance of the ServiceFactory
            var serviceFactory = new ServiceFactory();

            // Get the services
            var cpuService = serviceFactory.CreateCpuService();
            var ramService = serviceFactory.CreateRamService();
            var driveService = serviceFactory.CreateDriveService();

            // Get the current CPU, RAM, and drive usage
            var cpuResult = cpuService.GetCpuUsage(); // Get the result object
            double currentCpuUsage = (double)cpuResult.Data.CpuUsage; // Assuming UsagePercentage is the property in the Cpu entity

            var ramResult = ramService.GetPercentageRam(); // Get the result object
            double currentRamUsage = (double)ramResult.Data.UsagePercentage; // Assuming GetPercentageRam returns a double directly

            var driveResult = driveService.GetDrives().Data; // Get the result object
            foreach (var drive in driveResult)
            {
                if ((double)drive.UsedSpacePercentage >= DriveWarningThreshold)
                {
                    // Trigger Drive warning for this specific drive
                    LogWarning($"Drive {drive.DriveName} usage is critical: {drive.UsedSpacePercentage}% used.");
                    // You can log the warning, update the UI, or take other appropriate actions
                }
            } // Assuming GetDrives returns a double representing overall usage

            // Compare the usage with the thresholds and trigger warnings if necessary
            if (currentCpuUsage >= CpuWarningThreshold)
            {
                LogWarning($"CPU usage is critical: {currentCpuUsage}%.");
                // Trigger CPU warning
            }

            if (currentRamUsage >= RamWarningThreshold)
            {
                LogWarning($"RAM usage is critical: {currentRamUsage}%.");
                // Trigger RAM warning
            }

            
        }
        private void LogWarning(string message)
        {
            // Placeholder for logging or notifying about the warning
            Console.WriteLine(message); // You can replace this with actual logging or UI updates
        }
    }
}
