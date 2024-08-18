using Business.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ServiceFactory : IServiceFactory
    {
        public ICpuService CreateCpuService()
        {
            return new CpuManager(new EfCpuDal());
        }

        public IRamService CreateRamService()
        {
            return new RamManager(new EfRamDal());
        }

        public IDriveService CreateDriveService()
        {
            return new DriveManager(new EfDriveDal());
        }
    }
}
