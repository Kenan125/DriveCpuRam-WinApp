namespace DriveCpuRam_WinApp.PcInfo
{
    public class DriveInfoProvider
    {
        public static List<object[]> GetDriveInfo()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            List<object[]> driveInfos = new List<object[]>();

            for (int i = 0; i < drives.Length; i++)
            {
                DriveInfo drive = drives[i];
                if (drive.IsReady)
                {
                    // Use drive name without trailing backslashes as key
                    string driveName = drive.Name.TrimEnd('\\');
                    double totalSpace = drive.TotalSize / 1024.0 / 1024 / 1024; // Convert to GB
                    double availableSpace = drive.AvailableFreeSpace / 1024.0 / 1024 / 1024; // Convert to GB
                    double usedSpace = totalSpace - availableSpace;
                    double percentage = usedSpace / totalSpace * 100; ;

                    object[] driveInfo = new object[] { driveName, totalSpace, availableSpace, usedSpace, percentage };
                    driveInfos.Add(driveInfo);
                }
                else
                {
                    driveInfos[i] = null;
                }


            }



            return driveInfos;





        }


    }
}





