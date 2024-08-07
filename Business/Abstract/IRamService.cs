﻿using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRamService
    {
        IDataResult<Ram> GetTotalRam();
        IDataResult<Ram> GetAvailableRam();
        IDataResult<Ram> GetUsedRam();
        IDataResult<Ram> GetPercentageRam();
        IDataResult<Ram> GetRamInfo(int userId, string email);
        IResult SendRamData(int userId, string email);
        IDataResult<List<Ram>> GetRamDataByUserId(int userId);




    }
}
