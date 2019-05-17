using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Abp.Dependency;
using Lottak.Application;
using Lottak.Application.IService;
using Lottak.Core;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Infrastructure;
using Microsoft.Owin.Security.OAuth;
using Owin;

[assembly: OwinStartup(typeof(Lottak.SCM.Startup))]

namespace Lottak.SCM
{
    public class Startup
    {
        /// <summary>
        /// OAuth配置
        /// </summary>
        /// <param name="app"></param>
        public void Configuration(IAppBuilder app)
        {
            //设置默认认证方式
            app.SetDefaultSignInAsAuthenticationType(DefaultAuthenticationTypes.ApplicationCookie);
            //api使用Bearer认证
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

            //OAuth认证服务器配置
            app.UseOAuthAuthorizationServer(new Microsoft.Owin.Security.OAuth.OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                //AuthorizeEndpointPath = new PathString("/Authrize"),
                TokenEndpointPath = new Microsoft.Owin.PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(2),
                Provider = new LottakOAuthAuthorizationServerProvider(),
                ApplicationCanDisplayErrors = true,
                //AuthorizationCodeProvider = new AuthenticationTokenProvider
                //{
                //    OnCreate = CreateCode,
                //    OnReceive = ReciveCode
                //},
                //RefreshTokenProvider = new AuthenticationTokenProvider
                //{
                //    OnCreate = CreateAccessToken,
                //    OnReceive = ReciveAccessToken
                //}
            });
        }

        /// <summary>
        /// 存储一次性code
        /// </summary>
        private readonly ConcurrentDictionary<string, string> _authenticationCodes = new ConcurrentDictionary<string, string>(StringComparer.Ordinal);

        /// <summary>
        /// 生成code
        /// </summary>
        /// <param name="authenticationTokenCreateContext"></param>
        public void CreateCode(AuthenticationTokenCreateContext authenticationTokenCreateContext)
        {
            authenticationTokenCreateContext.SetToken(Guid.NewGuid().ToString("n"));
            _authenticationCodes[authenticationTokenCreateContext.Token] = authenticationTokenCreateContext.SerializeTicket();
        }

        /// <summary>
        /// 验证code
        /// </summary>
        /// <param name="authenticationTokenReceiveContext"></param>
        public void ReciveCode(AuthenticationTokenReceiveContext authenticationTokenReceiveContext)
        {
            string value;
            if (_authenticationCodes.TryRemove(authenticationTokenReceiveContext.Token, out value))
            {
                authenticationTokenReceiveContext.DeserializeTicket(value);
            }
        }

        /// <summary>
        /// 创建Token
        /// </summary>
        /// <param name="authenticationTokenCreateContext"></param>
        public void CreateAccessToken(AuthenticationTokenCreateContext authenticationTokenCreateContext)
        {
            authenticationTokenCreateContext.SetToken(authenticationTokenCreateContext.SerializeTicket());
        }

        /// <summary>
        /// 验证Token
        /// </summary>
        /// <param name="authenticationTokenReceiveContext"></param>
        public void ReciveAccessToken(AuthenticationTokenReceiveContext authenticationTokenReceiveContext)
        {
            authenticationTokenReceiveContext.DeserializeTicket(authenticationTokenReceiveContext.Token);
        }
    }


    public class LottakOAuthAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        /// <summary>
        /// 客户端缓存
        /// </summary>
        private ConcurrentDictionary<string, string> Clients = new ConcurrentDictionary<string, string>();

        /// <summary>
        /// 验证url
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
        {
            Clients.AddOrUpdate(context.ClientId, context.RedirectUri, (x, y) => y);
            context.Validated(context.RedirectUri);
            return base.ValidateClientRedirectUri(context);
        }

        /// <summary>
        /// 验证clientSecret
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            string clientId, clientSecret;
            if (context.TryGetBasicCredentials(out clientId, out clientSecret) || context.TryGetFormCredentials(out clientId, out clientSecret))
            {
                context.Validated(clientId);
                context.OwinContext.Set("client.id", clientId);
            }
            return base.ValidateClientAuthentication(context);
        }

        /// <summary>
        /// 生成客户端凭证
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task GrantClientCredentials(OAuthGrantClientCredentialsContext context)
        {
            var cliams = context.Scope.Select(q => new Claim("scope", q));
            var identity = new ClaimsIdentity(new GenericIdentity(context.ClientId, OAuthDefaults.AuthenticationType), claims: cliams);
            context.Validated(identity);
            //var oAuthIdentity = new ClaimsIdentity(context.Options.AuthenticationType);
            //oAuthIdentity.AddClaim(new Claim(ClaimTypes.Name, "Scope"));
            //var ticket = new AuthenticationTicket(oAuthIdentity, new AuthenticationProperties());
            //context.Validated(ticket);
            return base.GrantClientCredentials(context);
        }

        /// <summary>
        /// 生成资源拥有者凭证
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var oAuthIdentity = new ClaimsIdentity(context.Options.AuthenticationType);
            var systemUserService = IocManager.Instance.Resolve<ISystemUserService>();
            var opreateResult = systemUserService.Login(context.UserName, context.Password);
            if (opreateResult.Success)
            {
                oAuthIdentity.AddClaim(new Claim(ClaimTypes.Name, opreateResult.Data.UserGuid.ToString("n")));
                IocManager.Instance.Resolve<IWebContext>().CurrentUser = opreateResult.Data;
                var ticket = new AuthenticationTicket(oAuthIdentity, new AuthenticationProperties());
                context.Validated(ticket);
            }
            return base.GrantResourceOwnerCredentials(context);
        }
    }
}
