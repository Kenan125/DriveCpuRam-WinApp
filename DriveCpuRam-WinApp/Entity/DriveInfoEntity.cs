namespace DriveCpuRam_WinApp.Entity
{
    internal class DriveInfoEntity
    {
        public string DriveName { get; set; }
        public decimal TotalSpaceGB { get; set; }
        public decimal AvailableSpaceGB { get; set; }
        public decimal UsedSpaceGB { get; set; }
        public decimal UsedPercentage { get; set; }

    }
}
