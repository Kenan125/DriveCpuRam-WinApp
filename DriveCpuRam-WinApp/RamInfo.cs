using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace DriveCpuRam_WinApp
{
    public class RamInfo
    {
        public static decimal GetTotalRam()
        {
            decimal totalRam = 0;
            ManagementObjectSearcher searcher = new("SELECT Capacity FROM Win32_PhysicalMemory");
            foreach (ManagementObject obj in searcher.Get())
            {
                totalRam += (decimal)Convert.ToDouble(obj["Capacity"]);
            }
            return Math.Round(FormatBytes((decimal)totalRam),0);
            
        }
        public static decimal GetAvailableRam()
        {
            // Get the available RAM
            PerformanceCounter ramCounter = new PerformanceCounter("Memory", "Available Bytes");
            float availableRam = ramCounter.NextValue();
            return Math.Round(FormatBytes((decimal)availableRam), 2);

        }
        public static decimal GetUsedRam()
        {
            // Calculate used RAM
            decimal usedRam = GetTotalRam() - GetAvailableRam();
            return usedRam;


        }
        public static decimal GetPercentageRam() 
        {
            // Calculate usage percentage
            decimal usagePercentage = (GetUsedRam() / GetTotalRam()) * 100;
            return usagePercentage;

        }
        
        
        
        static decimal FormatBytes(decimal bytes)
        {
            
            int counter = 0;
            decimal number = (decimal)bytes;
            while (number / 1024 >= 1)
            {
                number /= 1024;
                counter++;
            }
            return number;
        }
    }
}
