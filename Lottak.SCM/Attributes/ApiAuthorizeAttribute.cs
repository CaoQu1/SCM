using Abp.Dependency;
using Abp.Json;
using Abp.Runtime.Caching;
using Lottak.Application;
using Lottak.Application.Dto;
using Lottak.Application.IService;
using Lottak.Core;
using Lottak.Core.Common;
using Lottak.SCM.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace Lottak.SCM.Attributes
{
    /// <summary>
    /// 权限检查
    /// </summary>
    public class ApiAuthorizeAttribute : AuthorizeAttribute
    {
        /// <summary>
        /// 认证管理
        /// </summary>
        private IAuthenticationManager AuthenticationManager { get => HttpContext.Current.GetOwinContext().Authentication; }

        /// <summary>
        /// 检查权限
        /// </summary>
        /// <param name="actionContext"></param>
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext == null) throw new ArgumentNullException(nameof(actionContext));
            if (actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Count > 0) return;
            if (actionContext.ActionDescriptor.ControllerDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Count > 0) return;

            var actionName = actionContext.ActionDescriptor.ActionName;
            var controllerName = actionContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            var area = "";
            var routeValues = actionContext.RequestContext.RouteData.Values;
            if (routeValues.Count > 0 && routeValues["area"] != null)
            {
                area = routeValues["area"].ToString();
            }
            var webcontext = IocManager.Instance.Resolve<IWebContext>();
            var cachemanager = IocManager.Instance.Resolve<ICacheManager>();
            var systemUserService = IocManager.Instance.Resolve<ISystemUserService>();
            if (webcontext.CurrentUser == null)
            {
                var ticket = AuthenticationManager.AuthenticateAsync(OAuthDefaults.AuthenticationType).Result;
                if (ticket == null)
                {
                    HandleUnauthorizedRequest(actionContext.Response, "未授权!");
                    return;
                }
                var userIdentity = ticket.Identity;
                if (!userIdentity.HasClaim(claim => claim.ValueType == ClaimTypes.Name))
                {
                    HandleUnauthorizedRequest(actionContext.Response, "未授权!");
                    return;
                }
                var userGuidStr = userIdentity.Claims.First(x => x.ValueType == ClaimTypes.Name).Value;
                if (Guid.TryParse(userGuidStr, out Guid userGuid))
                {
                    webcontext.CurrentUser = systemUserService.First(x => x.UserGuid == userGuid);
                }

            }
            var userCompanyInfo = webcontext.CurrentCompany;
#if !DEBUG
            if (userCompanyInfo != null && userCompanyInfo.SelectedEmployeeInfo != null)
            {
                var meuns = cachemanager.GetCache(CommonConst.LOTTAK_SYSTEM_CACHE)
                      .Get(string.Format(CommonConst.CACHE_ACTION_PERMISSION, webcontext.CurrentCompany.SelectedEmployeeInfo.CompanyNo, webcontext.CurrentUser.UserGuid), (key) =>
                      {
                          return systemUserService.GetUserMenu(webcontext.CurrentUser.UserGuid, webcontext.CurrentCompany.SelectedEmployeeInfo.CompanyNo).Data;
                      }) as UserMenuOutPut;
                if (!meuns.MenuOutPuts.SelectMany(x => x.ActionOutputs).Select(x => x.Url).Contains(string.Format("{0}/{1}", controllerName, actionName)))
                {
                    HandleUnauthorizedRequest(actionContext.Response, "权限不足!");
                }
            }
            else
            {
                HandleUnauthorizedRequest(actionContext.Response, "未授权!");
            }
#endif
        }

        /// <summary>
        /// 验证权限失败
        /// </summary>
        /// <param name="httpResponse"></param>
        /// <param name="message"></param>
        public void HandleUnauthorizedRequest(HttpResponseMessage httpResponse, string message)
        {
            httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.Unauthorized,
                Content = new StringContent(new ResultJson
                {
                    code = EnumStatusCode.Unauthorized,
                    message = message
                }.ToJsonString(), Encoding.UTF8, "application/json")
            };
        }
    }
}