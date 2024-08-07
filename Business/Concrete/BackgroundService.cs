using Business.Abstract;
using Entities.Concrete;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BackgroundService: IHostedService, IDisposable
    {
        private readonly UserManager _userManager;
        private readonly CpuManager _cpuManager;
        private readonly RamManager _ramManager;
        private readonly DriveManager _driveManager;
        private Timer _timer;
        private readonly ICpuService _cpuService;
        private readonly IRamService _ramService;
        private readonly IDriveService _driveService;
        private readonly User _user;
        public BackgroundService(Timer timer, ICpuService cpuService, IRamService ramService, IDriveService driveService, UserManager userManager, CpuManager cpuManager, RamManager ramManager, DriveManager driveManager)
        {
            _timer = timer;
            _cpuService = cpuService;
            _ramService = ramService;
            _driveService = driveService;
            _userManager = userManager;
            _cpuManager = cpuManager;
            _ramManager = ramManager;
            _driveManager = driveManager;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(60));
            return Task.CompletedTask;
        }
        private void DoWork(object state)
        {
            //var cpuInfo = _cpuService.GetCpuInfo(_user.Id,_user.Email);
            //var ramInfo = _ramService.GetRamInfo(_user.Id,_user.Email);
            //var driveInfo = _driveService.GetDrives();

            // Save data to the SQL server (implement your data access logic here)
            SendDataToSqlServer();
        }
        private void SendDataToSqlServer()
        {
            _cpuManager.SendCpuData(_user.Id, _user.Email);
            _ramManager.SendRamData(_user.Id, _user.Email);
            _driveManager.SendDriveData(_user.Id, _user.Email);
        }
        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }
        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
