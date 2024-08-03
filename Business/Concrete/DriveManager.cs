using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class DriveManager:IDriveService
    {
        IDriveDal _driveDal;

        public DriveManager(IDriveDal driveDal)
        {
            _driveDal = driveDal;
        }

        public IDataResult<List<Drive>> GetDrives()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            List<Drive> driveInfos = new List<Drive>();

            foreach (var drive in drives)
            {
                if (drive.IsReady)
                {
                    string driveName = drive.Name.TrimEnd('\\');
                    decimal totalSpace = (decimal)(drive.TotalSize / 1024.00 / 1024.00 / 1024); // Convert to GB
                    decimal availableSpace = (decimal)(drive.AvailableFreeSpace/ 1024.0 / 1024 / 1024); // Convert to GB
                    decimal usedSpace = totalSpace - availableSpace;
                    decimal percentage = usedSpace / totalSpace * 100;

                    var driveInfo = new Drive
                    {
                        DriveName = driveName,
                        TotalSpace = totalSpace,
                        AvailableSpace = availableSpace,
                        UsedSpace = usedSpace,
                        UsedSpacePercentage = percentage
                    };
                    driveInfos.Add(driveInfo);
                }
            }
            var result = driveInfos;
            return new SuccessDataResult<List<Drive>>(result);
        }

        public IResult SendDriveData(int userId)
        {
            var drives = GetDrives().Data;
            foreach (var drive in drives)
            {
                drive.UserId = userId;
                drive.Email = "user@example.com"; // Replace with actual user email if needed
                _driveDal.Add(drive);
            }
            return new SuccessResult("Drive data sent to SQL");
        }
        public IResult SetUserIdForDrive(string email, int userId)
        {
            var driveRecords = _driveDal.GetAll(d => d.Email == email);
            foreach (var record in driveRecords)
            {
                record.UserId = userId;
                _driveDal.Update(record);
            }
            return new SuccessResult("User ID set for Drive records.");
        }
    }
}
