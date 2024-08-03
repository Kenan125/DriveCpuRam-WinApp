using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System.Diagnostics;
using System.Management;

namespace Business.Concrete
{
    public class CpuManager : ICpuService
    {
        ICpuDal _cpuDal;

        public CpuManager(ICpuDal cpuDal)
        {
            _cpuDal = cpuDal;
        }

        public IDataResult<Cpu> GetCpuCore()
        {

            // Get the number of CPU cores
            int cpuCores = Environment.ProcessorCount;
            var result = new Cpu { CpuCore = cpuCores };
            return new SuccessDataResult<Cpu>(result);
        }

        public IDataResult<Cpu> GetCpuName()
        {

            string cpuName = "";

            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
            foreach (ManagementObject share in searcher.Get())
            {
                cpuName = share["Name"].ToString();
            }
            var result = new Cpu { CpuName = cpuName };
            return new SuccessDataResult<Cpu>(result);
        }

        public IDataResult<Cpu> GetCpuUsage()
        {
            // Get the CPU usage
            PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            cpuCounter.NextValue();
            Thread.Sleep(2000);
            float cpuUsage = cpuCounter.NextValue();
            var result = new Cpu { CpuUsage = cpuUsage };
            return new SuccessDataResult<Cpu>(result);
        }

        public IResult SendCpuData()
        {
            var cpuCoreResult = GetCpuCore().Data;
            var cpuNameResult = GetCpuName().Data;
            var cpuUsageResult = GetCpuUsage().Data;

            var cpuInfo = new Cpu
            {
                CpuCore = cpuCoreResult.CpuCore,
                CpuName = cpuNameResult.CpuName,
                CpuUsage = cpuUsageResult.CpuUsage
            };

            _cpuDal.Add(cpuInfo);
            return new SuccessResult(Messages.SendCpuSql);
        }
    }
}
