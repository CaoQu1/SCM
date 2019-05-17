using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.Runtime.Caching;
using Lottak.Application;
using Lottak.Application.Dto;
using Lottak.Application.IService;
using Lottak.Core;
using Lottak.Core.Authorization;
using Lottak.Core.Common;
using Lottak.Core.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottak.Application.Service
{
    /// <summary>
    /// 用户服务
    /// </summary>
    public class SystemUserService : AppServiceBase<SystemUser>, ISystemUserService
    {
        /// <summary>
        /// 数据仓储服务
        /// </summary>
        //private readonly IRepository<SystemUser> _userRepository;
        private readonly IRepositoryExtesion<CompanyEmployee> _companyRepository;
        private readonly IRepositoryExtesion<SystemUserRole> _userRoleReposity;
        private readonly IRepositoryExtesion<MenuPermission> _meunRepository;
        private readonly IRepositoryExtesion<MenuPermissionRole> _meunRoleReposity;
        private readonly IRepositoryExtesion<ActionPermission> _actionRepository;
        private readonly IRepositoryExtesion<ActionPermissionRole> _actionRoleReposity;

        /// <summary>
        /// 加密服务
        /// </summary>
        private readonly IEncryptionService _encryptionService;

        /// <summary>
        /// 缓存服务
        /// </summary>
        private readonly ICacheManager _cacheManager;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="encryptionService"></param>
        /// <param name="repository"></param>
        public SystemUserService(IEncryptionService encryptionService,
            IRepositoryExtesion<SystemUser> userRepository,
            IRepositoryExtesion<SystemUserRole> userRoleRepository,
            IRepositoryExtesion<MenuPermission> menuRepository,
            IRepositoryExtesion<MenuPermissionRole> menuRoleRepository,
            IRepositoryExtesion<ActionPermission> actionRepository,
            IRepositoryExtesion<ActionPermissionRole> actionRoleRepository,
            IRepositoryExtesion<CompanyEmployee> companyRepository,
            ICacheManager cacheManager) : base(userRepository)
        {
            //this._userRepository = userRepository;
            this._encryptionService = encryptionService;
            this._userRoleReposity = userRoleRepository;
            this._meunRepository = menuRepository;
            this._meunRoleReposity = menuRoleRepository;
            this._actionRepository = actionRepository;
            this._actionRoleReposity = actionRoleRepository;
            this._cacheManager = cacheManager;
            this._companyRepository = companyRepository;
        }

        /// <summary>
        /// 获取用户菜单信息
        /// </summary>
        /// <param name="userGuid"></param>
        /// <param name="companyNo"></param>
        /// <returns></returns>
        public OpreateResult<UserMenuOutPut> GetUserMenu(Guid userGuid, int companyNo)
        {
            OpreateResult<UserMenuOutPut> opreateResult = new OpreateResult<UserMenuOutPut>();
            try
            {
                var userMenuOutPut = _companyRepository.GetAll().Where(x => x.CompanyNo == companyNo && x.UserGuid == userGuid).Select(x => new UserMenuOutPut
                {
                    CompanyNo = companyNo,
                    UserGuid = userGuid,
                    EmpGuid = x.EmployeeGuid,
                    UserName = x.RealName
                }).FirstOrDefault();

                var roleIds = _userRoleReposity.GetAll().Where(x => x.CompanyNo == companyNo && x.UserGuid == userGuid && x.Status == EnumStatus.Normal).Select(x => x.RoleId).ToList();
                var actions = _actionRoleReposity.GetAll().Where(x => x.CompanyNo == companyNo && roleIds.Contains(x.RoleId)).Select(x => x.ActionPermission).ToList();
                var meuns = _meunRoleReposity.GetAll().Where(x => x.CompanyNo == companyNo && roleIds.Contains(x.RoleId)).Select(x => new MenuOutPut
                {
                    Icon = x.MenuPermission.Icon,
                    Title = x.MenuPermission.Title,
                    Url = x.MenuPermission.Area + "/" + x.MenuPermission.Controller + "/" + x.MenuPermission.Action,
                    MenuId = x.MenuPermissionId
                }).ToList();
                foreach (var item in meuns)
                {
                    item.ActionOutputs.AddRange(actions.Where(x => x.MenuPermissionId == item.MenuId).Select(x => new ActionOutput
                    {
                        Title = x.Description,
                        Url = x.Controller + "/" + x.Action
                    }));
                }
                userMenuOutPut.MenuOutPuts.AddRange(meuns);

                opreateResult.Data = userMenuOutPut;
            }
            catch (Exception ex)
            {
                opreateResult.AddError(ex);
            }
            return opreateResult;
        }

        /// <summary>
        /// 获取用户角色
        /// </summary>
        /// <param name="userGuid"></param>
        /// <returns></returns>
        public OpreateResult<List<UserRoleDto>> GetUserRole(Guid userGuid, int companyNo)
        {
            OpreateResult<List<UserRoleDto>> opreateResult = new OpreateResult<List<UserRoleDto>>();
            try
            {
                opreateResult.Data = ObjectMapper.Map<List<UserRoleDto>>(_userRoleReposity.GetAllList(x => x.UserGuid == userGuid && x.CompanyNo == companyNo));
            }
            catch (Exception ex)
            {
                opreateResult.AddError(ex);
            }
            return opreateResult;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="userNoOrEmail"></param>
        /// <param name="passWord"></param>
        /// <returns></returns>
        public OpreateResult<SystemUser> Login(string userNoOrEmail, string passWord)
        {
            OpreateResult<SystemUser> opreateResult = new OpreateResult<SystemUser>();
            var user = this._repository.GetAll().FirstOrDefault(x => x.UserNo.ToString() == userNoOrEmail || x.UserName == userNoOrEmail || x.Email == userNoOrEmail);
            if (user == null)
            {
                opreateResult.AddError("账号不存在!");
                return opreateResult;
            }
            switch ((EnumPasswordFormat)user.PasswordFormatId)
            {
                case EnumPasswordFormat.Encrypted:
                    passWord = _encryptionService.EncryptText(passWord);
                    break;
                case EnumPasswordFormat.Hashed:
                    passWord = _encryptionService.CreatePasswordHash(passWord, user.PasswordSalt);
                    break;
                case EnumPasswordFormat.MD5:
                    passWord = _encryptionService.MD5Hash(passWord, user.PasswordSalt);
                    break;
            }

            bool isValid = passWord == user.Password;
            if (isValid)
            {
                user.LatestLoginDateUtc = DateTime.UtcNow;
                _repository.Update(user);
                opreateResult.Data = user;
                opreateResult.Message = "登陆成功！";
            }
            else
            {
                opreateResult.Message = "用户密码错误！";
                opreateResult.AddError("用户密码错误！");
            }
            return opreateResult;
        }
    }
}
