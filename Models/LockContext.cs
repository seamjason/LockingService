using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using TheSeam.DataAccess;

namespace WebApplication2.Models
{
    public class LockContext : DbContext
    {
        public readonly string _connectionString;
        public LockContext(string connectionString) { 
            _connectionString = connectionString;
        }    

        public DbSet<Lock> Locks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
