using System.Data.Entity.Migrations;
using Abp.MultiTenancy;
using EntityFramework.DynamicFilters;
using Lottak.EntityFramework;

namespace Lottak.EntityFramework
{
    public sealed class Configuration : DbMigrationsConfiguration<LottakDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "LottakSCM";
        }

        protected override void Seed(LottakDataContext context)
        {
            context.DisableAllFilters();

            context.SaveChanges();
        }
    }
}
