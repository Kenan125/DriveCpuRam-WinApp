using DriveCpuRam_WinApp.Entity;
using System.Diagnostics;
using System.Management;

namespace DriveCpuRam_WinApp.PcInfo
{
    internal class CpuInfo
    {
        public static string GetCpuName()
        {

            //CpuInfoEntity _cpuName = new CpuInfoEntity();
            string cpuName = "";
            //_cpuName.CpuName = "";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
            foreach (ManagementObject share in searcher.Get())
            {
                cpuName = share["Name"].ToString();

                //_cpuName.CpuName = share["Name"].ToString();
            }

            return cpuName;

            //return _cpuName.CpuName;


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
            Thread.Sleep(2000);
            float cpuUsage = cpuCounter.NextValue();

            return cpuUsage;
        }
    }
}
