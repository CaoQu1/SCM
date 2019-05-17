using Abp;
using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Lottak.Core.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottak.Core
{
    [DependsOn(typeof(AbpKernelModule))]
    public class LottakCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            base.PreInitialize();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(LottakCoreModule).GetAssembly());
        }
    }
}
