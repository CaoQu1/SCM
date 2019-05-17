using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Configuration.Startup;
using Abp.Modules;
using Abp.Quartz;
using Abp.Runtime.Caching.Redis;
using Abp.Web.SignalR;
using Abp.WebApi;
using Abp.WebApi.Configuration;
using Lottak.Application;
using Lottak.Core;
using Lottak.Core.Common;
using Lottak.EntityFramework;
using Swashbuckle.Application;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Lottak.SCM.App_Start
{
    [DependsOn(typeof(LottakSCMDataModule),
        typeof(LottakApplicationModule),
        typeof(AbpWebSignalRModule),
        typeof(AbpRedisCacheModule),
        typeof(AbpQuartzModule),
        typeof(AbpWebApiModule),
        typeof(AbpAutoMapperModule))]
    public class LottakSCMWebModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Caching.UseRedis();

            Configuration.Caching.ConfigureAll(cache =>
            {
                cache.DefaultSlidingExpireTime = TimeSpan.FromHours(2);
            });

            //Configuration.Authorization.Providers.Add<LottakSCMAuthorizationProvider>();
            //Configuration.Navigation.Providers.Add<LottakSCMNavigationProvider>();
            Configuration.Settings.Providers.Add<LottakConfigProvider>();

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            Configuration.Modules.AbpAutoMapper().Configurators.Add(cfg =>
            {
                cfg.CreateMap(typeof(PagedResultDto<>), typeof(PageResultJson<>))
                   .ForMember("total", s => s.MapFrom("TotalCount"))
                   .ForMember("items", s => s.MapFrom("Items"));

                cfg.CreateMap<QueryParameter, PagedAndSortedResultRequestDto>()
                   .ForMember(d => d.SkipCount, s =>
                   {
                       s.MapFrom(x => (x.pageIndex - 1) * x.pageSize);
                   })
                   .ForMember(d => d.MaxResultCount, s => s.MapFrom(x => x.pageSize))
                   .ForMember(d => d.Sorting, s => s.MapFrom(x => x.Sort));
            });
            //ConfigureSwaggerUi();
        }

        public override void PostInitialize()
        {
            var httpConfiguration = IocManager.Resolve<IAbpWebApiConfiguration>().HttpConfiguration;
        }

        //private void ConfigureSwaggerUi()
        //{
        //    GlobalConfiguration.Configuration
        //        .EnableSwagger(c =>
        //        {
        //            c.SingleApiVersion("v1", "API文档");
        //            c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

        //            //将application层中的注释添加到SwaggerUI中
        //            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

        //            var commentsFileName = "bin//Lottak.SCM.Application.xml";
        //            var commentsFile = Path.Combine(baseDirectory, commentsFileName);
        //            //将注释的XML文档添加到SwaggerUI中
        //            c.IncludeXmlComments(commentsFile);

        //        })
        //      .EnableSwaggerUi(c => c.InjectJavaScript(Assembly.GetExecutingAssembly(), " ABPCMS.SwaggerUI.Scripts.wagger.js"));

        //}
    }
}