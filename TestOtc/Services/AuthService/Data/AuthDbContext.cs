using AuthService.Data.Entities;
using System.Data.Entity;

namespace AuthService.Data
{
    internal class AuthDbContext : DbContext
    {
        public DbSet<DbUser> Users { get; set; }

        public AuthDbContext() : base("AuthDbConnection") { }
    }
}
