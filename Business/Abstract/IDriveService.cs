﻿using Core.Utilities.Results;
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
        IResult SetUserIdForDrive(string email, int userId);
    }
}