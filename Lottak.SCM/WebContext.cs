using Abp.Dependency;
using Abp.Extensions;
using Lottak.Application;
using Lottak.Application.IService;
using Lottak.Core;
using Lottak.Core.Authorization;
using Lottak.Core.Common;
using Lottak.Core.Company;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace Lottak.SCM
{
    /// <summary>
    /// Web上下文
    /// </summary>
    public class WebContext : IWebContext, ITransientDependency
    {
        /// <summary>
        /// 认证管理
        /// </summary>
        private IAuthenticationManager _authenticationManager { get => HttpContext.Current.GetOwinContext().Authentication; }

        /// <summary>
        /// 加密服务
        /// </summary>
        private readonly IEncryptionService _encryptionService;

        /// <summary>
        /// 用户服务
        /// </summary>
        private readonly ISystemUserService _systemUserService;

        /// <summary>
        /// 公司员工服务
        /// </summary>
        private readonly ICompanyEmployeeService _companyEmployeeService;

        /// <summary>
        /// 公司服务
        /// </summary>
        private readonly ICompanyService _companyService;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="encryptionService"></param>
        public WebContext(IEncryptionService encryptionService,
            ISystemUserService systemUserService,
            ICompanyEmployeeService companyEmployeeService,
            ICompanyService companyService)
        {
            this._encryptionService = encryptionService;
            this._systemUserService = systemUserService;
            this._companyEmployeeService = companyEmployeeService;
            this._companyService = companyService;
        }

        /// <summary>
        /// 当前用户
        /// </summary>
        private SystemUser _currentUser;
        public SystemUser CurrentUser
        {
            get
            {
                if (_currentUser == null)
                {
                    var userCookie = GetCookie(CommonConst.COOKIE_USER_NAME);
                    if (userCookie != null && !userCookie.Value.IsNullOrEmpty())
                    {
                        var ras_cookie_value = _encryptionService.RsaDecrypt(userCookie.Value);
                        if (Guid.TryParse(ras_cookie_value, out Guid userGuid))
                        {
                            try
                            {
                                _currentUser = _systemUserService.First(x => x.UserGuid == userGuid);
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                        }
                    }
                    if (_currentUser == null)
                    {
                        var authenticateResult = _authenticationManager.AuthenticateAsync(OAuthDefaults.AuthenticationType).Result;
                        if (authenticateResult != null)
                        {
                            var isClaim = authenticateResult.Identity.HasClaim(x => x.ValueType == ClaimTypes.Name);
                            if (isClaim)
                            {
                                if (Guid.TryParse(authenticateResult.Identity.FindFirst(x => x.ValueType == ClaimTypes.Name).Value, out Guid userGuid))
                                {
                                    _currentUser = _systemUserService.First(x => x.UserGuid == userGuid);
                                }
                            }
                        }
                    }
                }
                return _currentUser;
            }
            set
            {
                _currentUser = value;
                var cookie_value = _encryptionService.RsaEncrypt(value.UserGuid.ToString("n"));
                SetCookie(CommonConst.COOKIE_USER_NAME, cookie_value);
            }
        }

        /// <summary>
        /// 当前公司信息
        /// </summary>
        private UserCompanyInfo _currentCompany;
        public UserCompanyInfo CurrentCompany
        {
            get
            {
                if (_currentUser == null) return null;
                if (_currentCompany == null)
                {
                    _currentCompany = new UserCompanyInfo();
                    var companyEmployees = _companyEmployeeService.GetByWhere(x => x.UserGuid == _currentUser.UserGuid);
                    if (companyEmployees != null && companyEmployees.Any())
                    {
                        _currentCompany.SelectedEmployeeInfo = companyEmployees.FirstOrDefault();
                        _currentCompany.SeletedCompany = _companyService.GetByWhere(x => x.CompanyNo == _currentCompany.SelectedEmployeeInfo.CompanyNo).FirstOrDefault();
                        var companyNos = companyEmployees.Select(x => x.CompanyNo).ToList();
                        _currentCompany.Companies = _companyService.GetByWhere(x => companyNos.Contains(x.CompanyNo)).ToList();
                        _currentCompany.UserGuid = _currentUser.UserGuid;
                    }
                }
                return _currentCompany;
            }
            set
            {
                _currentCompany = value;
            }
        }

        /// <summary>
        /// 获取cookie
        /// </summary>
        /// <param name="cookieName"></param>
        /// <returns></returns>
        public HttpCookie GetCookie(string cookieName)
        {
            if (HttpContext.Current != null && HttpContext.Current.Request != null)
                return HttpContext.Current.Request.Cookies[cookieName];
            return null;
        }

        /// <summary>
        /// 设置cookie
        /// </summary>
        /// <param name="cookieName"></param>
        /// <param name="value"></param>
        /// <param name="expire"></param>
        public void SetCookie(string cookieName, object value, int? expire = 60)
        {
            if (HttpContext.Current != null && HttpContext.Current.Response != null && value != null)
            {
                var httpcookie = new HttpCookie(cookieName, value.ToString());
                if (expire.HasValue)
                {
                    httpcookie.Expires = DateTime.Now.AddMinutes(expire.Value);
                }
                httpcookie.HttpOnly = true;
                HttpContext.Current.Response.Cookies.Remove(cookieName);
                HttpContext.Current.Response.AppendCookie(httpcookie);
            }
        }
    }
}