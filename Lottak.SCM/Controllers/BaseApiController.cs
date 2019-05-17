using Abp.WebApi.Controllers;
using Lottak.Application.IService;
using Lottak.Core;
using Lottak.SCM.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Results;

namespace Lottak.SCM.Controllers
{
    /// <summary>
    /// 基类
    /// </summary>
    [ApiAuthorize]
    public class BaseApiController : AbpApiController
    {
        /// <summary>
        /// web上下文
        /// </summary>
        protected IWebContext _webContext { get; set; }

        /// <summary>
        /// 用户服务
        /// </summary>
        protected ISystemUserService _systemUserService { get; set; }

        /// <summary>
        /// 公司员工服务
        /// </summary>
        protected ICompanyEmployeeService _companyEmployeeService { get; set; }

        /// <summary>
        /// ctor
        /// </summary>
        public BaseApiController()
        {
        }
    }
}
