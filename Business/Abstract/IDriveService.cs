using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IDriveService
    {
        IDataResult<List<Drive>> GetDrives();
        IResult SendDriveData(int userId, string email);
        IDataResult<List<Drive>> GetDriveDataByUserId(int userId);


    }
}
