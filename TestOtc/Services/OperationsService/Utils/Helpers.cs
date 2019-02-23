using OperationsService.Data;
using OperationsService.Migrations;
using System.Data.Entity;

namespace OperationsService.Utils
{
    public static class Helpers
    {
        public static void InitializerDb()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<OperationsDbContext, Configuration>());
            var contexttest = new OperationsDbContext();
            contexttest.Database.Initialize(true);
        }
    }
}
