using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        // User Management
        IResult AddUser(User user);
        IResult UpdateUser(User user);
        IResult DeleteUser(int userId);
        IDataResult<User> GetUserById(int userId);
        IDataResult<List<User>> GetAllUsers();

        // Authentication
        IResult Login(string email, string password);
        IResult Logout();
        IResult Register(User user);
        IResult ChangePassword(int userId, string newPassword);

        // Data Retrieval
        IDataResult<List<Cpu>> GetUserCpuInfo(int userId);
        IDataResult<List<Drive>> GetUserDriveInfo(int userId);
        IDataResult<List<Ram>> GetUserRamInfo(int userId);

        // Additional Methods
        IDataResult<User> GetUserByEmail(string email);
        IDataResult<int> GetUserIdByEmail(string email);
    }
}
