using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IDriveService
    {
        IDataResult<List<Drive>> GetDrives();
        IResult SendDriveData(int userId, string email);
        IDataResult<List<Drive>> GetDriveDataByUserId(int userId);


    }
}
