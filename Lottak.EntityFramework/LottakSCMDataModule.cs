using Abp.EntityFramework;
using Abp.Modules;
using Lottak.Core;
using Lottak.EntityFramework.Migrations.SeedData;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lottak.EntityFramework
{
    [DependsOn(typeof(AbpEntityFrameworkModule), typeof(LottakCoreModule))]
    public class LottakSCMDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<LottakDataContext>());

            Configuration.DefaultNameOrConnectionString = "default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
