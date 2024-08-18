using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICpuService
    {
        IDataResult<Cpu> GetCpuName();
        IDataResult<Cpu> GetCpuCore();
        IDataResult<Cpu> GetCpuUsage();
        IDataResult<Cpu> GetCpuInfo(int userId, string email);
        IResult SendCpuData(int userId, string email);
        IDataResult<List<Cpu>> GetCpuDataByUserId(int userId);




    }
}
