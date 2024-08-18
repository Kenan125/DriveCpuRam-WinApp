using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class DriveManager : IDriveService
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
                    decimal availableSpace = (decimal)(drive.AvailableFreeSpace / 1024.0 / 1024 / 1024); // Convert to GB
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

        public IResult SendDriveData(int userId, string email)
        {
            var drivesResult = GetDrives().Data;

            foreach (var driveInfo in drivesResult)
            {
                driveInfo.UserId = userId;
                driveInfo.Email = email;
                _driveDal.Add(driveInfo);
            }

            return new SuccessResult(Messages.SendDriveSql);
        }

        public IDataResult<List<Drive>> GetDriveDataByUserId(int userId)
        {
            var result = _driveDal.GetAll(d => d.UserId == userId);
            return new SuccessDataResult<List<Drive>>(result);
        }


    }
}
