using Abp.Application.Services;
using Lottak.Application.Dto;
using Lottak.Core.Authorization;
using Lottak.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lottak.Application.IService
{
    /// <summary>
    /// 用户服务接口
    /// </summary>
    public interface ISystemUserService : IApplicationServiceExtension<SystemUser>
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="userNoOrEmail"></param>
        /// <param name="passWord"></param>
        /// <returns></returns>
        OpreateResult<SystemUser> Login(string userNoOrEmail, string passWord);

        /// <summary>
        /// 获取用户角色
        /// </summary>
        /// <param name="userGuid"></param>
        /// <returns></returns>
        OpreateResult<List<UserRoleDto>> GetUserRole(Guid userGuid, int companyNo);

        /// <summary>
        /// 获取菜单信息
        /// </summary>
        /// <param name="userGuid"></param>
        /// <param name="companyNo"></param>
        /// <returns></returns>
        OpreateResult<UserMenuOutPut> GetUserMenu(Guid userGuid, int companyNo);
    }
}
