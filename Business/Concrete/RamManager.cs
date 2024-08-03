using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using Business.Constants;
using System.Diagnostics;

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
            var formattedTotalRam =  Math.Round(FormattedBytes.Format(totalRam), 2);
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

        public IResult SendRamData(int userId)
        {
            var totalMemoryResult = GetTotalRam().Data;
            var usedMemoryResult = GetUsedRam().Data;
            var availableMemoryResult = GetAvailableRam().Data;
            var usagePercentageResult = GetPercentageRam().Data;

            var ramInfo = new Ram
            {
                RamTotal = totalMemoryResult.RamTotal,
                RamUsed = usedMemoryResult.RamUsed,
                RamAvailable = availableMemoryResult.RamAvailable,
                UsagePercentage = usagePercentageResult.UsagePercentage,
                UserId = userId,
                Email = "user@example.com" // Replace with actual user email if needed
            };

            _ramDal.Add(ramInfo);
            return new SuccessResult("RAM data sent to SQL");
        }
        public IResult SetUserIdForRam(string email, int userId)
        {
            var ramRecords = _ramDal.GetAll(r => r.Email == email);
            foreach (var record in ramRecords)
            {
                record.UserId = userId;
                _ramDal.Update(record);
            }
            return new SuccessResult("User ID set for RAM records.");
        }

    }
}
