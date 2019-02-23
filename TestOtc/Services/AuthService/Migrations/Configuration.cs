namespace AuthService.Migrations
{
    using global::AuthService.Data;
    using global::AuthService.Data.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AuthDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AuthDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var users = new List<DbUser>
            {
                new DbUser { Login = "login",   Password = "123" },
            };

            users.ForEach(s => context.Users.AddOrUpdate(p => p.Login, s));

            context.SaveChanges();
        }
    }
}
