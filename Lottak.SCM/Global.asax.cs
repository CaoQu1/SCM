using Abp.Castle.Logging.Log4Net;
using Abp.Web;
using Castle.Facilities.Logging;
using Lottak.SCM.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Lottak.SCM
{
    public class WebApiApplication : AbpWebApplication<LottakSCMWebModule>
    {
        protected override void Application_Start(object sender, EventArgs e)
        {
            AbpBootstrapper.IocManager.IocContainer.
                AddFacility<LoggingFacility>(f => f.LogUsing<Log4NetLoggerFactory>().WithConfig(Server.MapPath("/Config/log4net.config")));
            base.Application_Start(sender, e);
        }
    }
}
