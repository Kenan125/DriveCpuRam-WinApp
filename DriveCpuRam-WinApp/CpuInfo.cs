using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace DriveCpuRam_WinApp
{
    internal class CpuInfo
    {
        public static string GetCpuName()
        {


            string cpuName = "";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
            foreach (ManagementObject share in searcher.Get())
            {
                cpuName = share["Name"].ToString();
            }


            return cpuName;


        }
        public static int GetCpuCore()
        {
            // Get the number of CPU cores
            int cpuCores = Environment.ProcessorCount;
            return cpuCores;

        }
        public static float GetCpuUsage()
        {
            // Get the CPU usage
            PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            cpuCounter.NextValue();
            System.Threading.Thread.Sleep(2000);
            float cpuUsage = cpuCounter.NextValue();

            return cpuUsage;
        }
    }
}
