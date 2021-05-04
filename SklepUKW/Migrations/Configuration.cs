namespace SklepUKW.Migrations
{
    using SklepUKW.DAL;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

   public sealed class Configuration : DbMigrationsConfiguration<SklepUKW.DAL.FilmsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "SklepUKW.DAL.FilmsContext";
        }

        protected override void Seed(SklepUKW.DAL.FilmsContext context)
        {
            FilmsInitializer.SeedFilmy(context);
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
