using Abp.WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security;
using System.Threading.Tasks;
using Microsoft.Extensions.Internal;
using Abp.Web.Models;
using Abp.Authorization;
using Abp.UI;
using Owin;
using Microsoft.Owin.Security.OAuth;
using Lottak.SCM.Models;
using Lottak.Application;
using Microsoft.AspNet.Identity;
using System.Web;
using Lottak.Application.IService;

namespace Lottak.SCM.Controllers
{
    /// <summary>
    /// 用户模块
    /// </summary>
    public class UserController : BaseApiController
    {
    }
}