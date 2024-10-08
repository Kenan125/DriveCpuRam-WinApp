﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
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
                cpuName = share["Name"]?.ToString();

            }
            var result = new Cpu { CpuName = cpuName };
            return new SuccessDataResult<Cpu>(result);
        }

        public IDataResult<Cpu> GetCpuUsage()
        {

            using (var cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total"))
            {
                cpuCounter.NextValue();
                Thread.Sleep(2000);
                float cpuUsage = cpuCounter.NextValue();
                var result = new Cpu { CpuUsage = (decimal)cpuUsage };
                return new SuccessDataResult<Cpu>(result);
            }
        }



        public IResult SendCpuData(int userId, string email)
        {
            var cpuInfoResult = GetCpuInfo(userId, email);

            if (!cpuInfoResult.Success)
            {
                return new ErrorResult("Failed to get CPU info");
            }

            _cpuDal.Add(cpuInfoResult.Data);
            return new SuccessResult(Messages.SendCpuSql);
        }
        public IDataResult<List<Cpu>> GetCpuDataByUserId(int userId)
        {
            var result = _cpuDal.GetAll(c => c.UserId == userId);
            return new SuccessDataResult<List<Cpu>>(result);
        }

        public IDataResult<Cpu> GetCpuInfo(int userId, string email)
        {
            var cpuCoreResult = GetCpuCore().Data.CpuCore;
            var cpuNameResult = GetCpuName().Data.CpuName;
            var cpuUsageResult = GetCpuUsage().Data.CpuUsage;
            var cpuInfo = new Cpu
            {
                CpuCore = cpuCoreResult,
                CpuName = cpuNameResult,
                CpuUsage = cpuUsageResult,
                UserId = userId,
                Email = email
            };

            return new SuccessDataResult<Cpu>(cpuInfo);
        }
    }
}
