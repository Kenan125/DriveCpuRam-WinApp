using Business.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class DataService
    {
        private readonly ICpuService _cpuService;
        private readonly IRamService _ramService;
        private readonly IDriveService _driveService;

        public DataService(ICpuService cpuService, IRamService ramService, IDriveService driveService)
        {
            _cpuService = cpuService;
            _ramService = ramService;
            _driveService = driveService;
        }

        public void SendDataToSqlServer(int userId, string email)
        {
            _cpuService.SendCpuData(userId, email);
            _ramService.SendRamData(userId, email);
            _driveService.SendDriveData(userId, email);
        }

        public List<Cpu> GetCpuData(int userId)
        {
            return _cpuService.GetCpuDataByUserId(userId).Data;
        }

        public List<Ram> GetRamData(int userId)
        {
            return _ramService.GetRamDataByUserId(userId).Data;
        }

        public List<Drive> GetDriveData(int userId)
        {
            return _driveService.GetDriveDataByUserId(userId).Data;
        }
    }
}
