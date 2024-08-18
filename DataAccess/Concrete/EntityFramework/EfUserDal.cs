using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, UserPcInfoContext>, IUserDal
    {
        public User GetUserByEmailAndPassword(string email, string password)
        {
            using (var context = new UserPcInfoContext())
            {
                var user = context.Users.SingleOrDefault(u => u.Email == email);
                if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Password))
                {
                    return user;
                }
                return null;
            }

        }
    }
}