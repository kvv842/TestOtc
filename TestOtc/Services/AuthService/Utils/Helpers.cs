using AuthService.Data;
using AuthService.Migrations;
using System.Data.Entity;

namespace AuthService.Utils
{
    public static class Helpers
    {
        public static void InitializerDb()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AuthDbContext, Configuration>());
            AuthDbContext contexttest = new AuthDbContext();
            contexttest.Database.Initialize(true);
        }
    }
}
