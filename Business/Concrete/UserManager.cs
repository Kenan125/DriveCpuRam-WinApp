using Business.Abstract;
using Business.Constants;
using Core.Utilities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        ICpuDal _cpuDal;
        IDriveDal _driveDal;
        IRamDal _ramDal;

        public UserManager(IUserDal userDal, ICpuDal cpuDal, IDriveDal driveDal, IRamDal ramDal)
        {
            _userDal = userDal;
            _cpuDal = cpuDal;
            _driveDal = driveDal;
            _ramDal = ramDal;
        }

        public IResult AddUser(User user)
        {
            user.Password = PasswordHasher.HashPassword(user.Password); // Hash the password
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult UpdateUser(User user)
        {
            user.Password = PasswordHasher.HashPassword(user.Password); // Hash the password
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }

        public IResult DeleteUser(int userId)
        {
            var user = _userDal.Get(u => u.Id == userId);
            if (user == null)
            {
                return new ErrorResult(Messages.UserNotFound);
            }

            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<User> GetUserById(int userId)
        {
            var user = _userDal.Get(u => u.Id == userId);
            if (user == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            return new SuccessDataResult<User>(user, Messages.UserRetrieved);
        }

        public IDataResult<List<User>> GetAllUsers()
        {
            var users = _userDal.GetAll();
            return new SuccessDataResult<List<User>>(users, Messages.UserAllRetrieved);
        }

        public IResult Login(string email, string password)
        {
            var hashedPassword = PasswordHasher.HashPassword(password); // Hash the password
            var user = _userDal.Get(u => u.Email == email && u.Password == hashedPassword);
            if (user == null)
            {
                return new ErrorResult(Messages.PasswordEmailFail);
            }

            // Add login logic here (e.g., set session)
            return new SuccessResult(Messages.LoginSuccess);
        }

        public IResult ChangePassword(int userId, string newPassword)
        {
            var user = _userDal.Get(u => u.Id == userId);
            if (user == null)
            {
                return new ErrorResult(Messages.UserNotFound);
            }

            user.Password = PasswordHasher.HashPassword(newPassword); // Hash the new password
            _userDal.Update(user);
            return new SuccessResult(Messages.PasswordChange);
        }

        public IDataResult<List<Cpu>> GetUserCpuInfo(int userId)
        {
            var result = _cpuDal.GetAll(c => c.UserId == userId);
            return new SuccessDataResult<List<Cpu>>(result);
        }

        public IDataResult<List<Drive>> GetUserDriveInfo(int userId)
        {
            var result = _driveDal.GetAll(d => d.UserId == userId);
            return new SuccessDataResult<List<Drive>>(result);
        }

        public IDataResult<List<Ram>> GetUserRamInfo(int userId)
        {
            var result = _ramDal.GetAll(r => r.UserId == userId);
            return new SuccessDataResult<List<Ram>>(result);
        }

        public IResult Logout()
        {
            // Add logout logic here (e.g., clear session)
            return new SuccessResult(Messages.LogoutSuccess);
        }

        public IResult Register(User user)
        {
            user.Password = PasswordHasher.HashPassword(user.Password); // Hash the password
            _userDal.Add(user);
            return new SuccessResult(Messages.RegistrationSuccess);
        }

        public IDataResult<User> GetUserByEmail(string email)
        {
            var user = _userDal.Get(u => u.Email == email);
            if (user != null)
            {
                return new SuccessDataResult<User>(user);
            }
            return new ErrorDataResult<User>(Messages.UserNotFound);
        }
        public IDataResult<int> GetUserIdByEmail(string email)
        {
            var user = _userDal.Get(u => u.Email == email);
            if (user != null)
            {
                return new SuccessDataResult<int>(user.Id, Messages.UserIdRetrieved);
            }
            return new ErrorDataResult<int>(Messages.UserNotFound);
        }
    }
}
