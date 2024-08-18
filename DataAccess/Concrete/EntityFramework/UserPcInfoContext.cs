using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class UserPcInfoContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = Kenan\\MSSQL2022; Initial Catalog = UserPcInfo; Persist Security Info = True; User ID = sa; Password = 54321; Trust Server Certificate = True");
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Cpu> Cpus { get; set; }
        public DbSet<Ram> Rams { get; set; }
        public DbSet<Drive> Drives { get; set; }
    }
}
