﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Diagnostics;
using System.Management;

namespace Business.Concrete
{
    public class RamManager : IRamService
    {
        IRamDal _ramDal;
        private readonly Ram _ram;

        public RamManager(IRamDal ramDal)
        {
            _ramDal = ramDal;
        }

        public IDataResult<Ram> GetAvailableRam()
        {
            // Get the available RAM
            PerformanceCounter ramCounter = new PerformanceCounter("Memory", "Available Bytes");
            float availableRam = ramCounter.NextValue();
            var formattedAvailableRam = Math.Round(FormattedBytes.Format((decimal)availableRam), 2);
            var result = new Ram { RamAvailable = formattedAvailableRam };

            return new SuccessDataResult<Ram>(result);
        }

        public IDataResult<Ram> GetPercentageRam()
        {
            var totalRamResult = GetTotalRam();
            var usedRamResult = GetUsedRam();

            if (!totalRamResult.Success || !usedRamResult.Success)
            {
                return new ErrorDataResult<Ram>("Failed to retrieve RAM information");
            }

            decimal usagePercentage = (usedRamResult.Data.RamUsed / totalRamResult.Data.RamTotal) * 100;
            var result = new Ram { UsagePercentage = usagePercentage };

            return new SuccessDataResult<Ram>(result);
        }

        public IDataResult<Ram> GetTotalRam()
        {
            decimal totalRam = 0;
            ManagementObjectSearcher searcher = new("SELECT Capacity FROM Win32_PhysicalMemory");
            foreach (ManagementObject obj in searcher.Get())
            {
                totalRam += (decimal)Convert.ToDouble(obj["Capacity"]);
            }
            var formattedTotalRam = Math.Round(FormattedBytes.Format(totalRam), 2);
            var result = new Ram { RamTotal = formattedTotalRam };
            return new SuccessDataResult<Ram>(result);
        }

        public IDataResult<Ram> GetUsedRam()
        {
            var totalRamResult = GetTotalRam();
            var availableRamResult = GetAvailableRam();

            if (!totalRamResult.Success || !availableRamResult.Success)
            {
                return new ErrorDataResult<Ram>("Failed to retrieve RAM information");
            }

            decimal usedRam = totalRamResult.Data.RamTotal - availableRamResult.Data.RamAvailable;
            var result = new Ram { RamUsed = usedRam };

            return new SuccessDataResult<Ram>(result);
        }
        public IResult SendRamData(int userId, string email)
        {
            var ramInfoResult = GetRamInfo(userId, email);
            if (!ramInfoResult.Success)
            {
                return new ErrorResult("Failed to get Ram info");
            }
            var result = ramInfoResult.Data;
            _ramDal.Add(result);
            return new SuccessResult(Messages.SendRamSql);
        }
        public IDataResult<List<Ram>> GetRamDataByUserId(int userId)
        {
            var result = _ramDal.GetAll(r => r.UserId == userId);
            return new SuccessDataResult<List<Ram>>(result);
        }

        public IDataResult<Ram> GetRamInfo(int userId, string email)
        {
            var totalRamResult = GetTotalRam().Data;
            var usedRamResult = GetUsedRam().Data;
            var availableRamResult = GetAvailableRam().Data;
            var usagePercentageResult = GetPercentageRam().Data;

            var ramInfo = new Ram
            {
                RamTotal = totalRamResult.RamTotal,
                RamUsed = usedRamResult.RamUsed,
                RamAvailable = availableRamResult.RamAvailable,
                UsagePercentage = usagePercentageResult.UsagePercentage,
                UserId = userId,
                Email = email
            };
            return new SuccessDataResult<Ram>(ramInfo);
        }
    }
}
