using Abp.Logging;
using Lottak.Core.Authorization;
using Lottak.Core.Company;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottak.EntityFramework.Migrations.SeedData
{
    /// <summary>
    /// 初始化数据库
    /// </summary>
    public class InitialDbBuilder : DropCreateDatabaseIfModelChanges<LottakDataContext>
    {
        /// <summary>
        /// 初始数据库
        /// </summary>
        /// <param name="context"></param>
        public override void InitializeDatabase(LottakDataContext context)
        {
            if (context.Database.CreateIfNotExists())
            {
                //initializeData(context);
            }
        }

        /// <summary>
        /// 种子数据
        /// </summary>
        /// <param name="context"></param>
        protected override void Seed(LottakDataContext context)
        {
            base.Seed(context);
        }

        ///// <summary>
        ///// 初始化测试数据
        ///// </summary>
        //private void initializeData(LottakDataContext context)
        //{
        //    int superAdminUserNo = 10001,
        //        adminUserNo = 10002;

        //    Guid superAdminGuid = Guid.NewGuid(),
        //        adminGuid = Guid.NewGuid();

        //    Guid superAdminEmpId = Guid.NewGuid(),
        //        adminEmpId = Guid.NewGuid();


        //    using (var trans = context.Database.BeginTransaction())
        //    {
        //        try
        //        {
        //            #region 圈子信息

        //            var company = new Company()
        //            {
        //                CompanyNo = 10001,
        //                Domain = "http://10001.domain.com",
        //                Abbreviation = "默认圈子",
        //                CompanyName = "默认圈子",
        //                Address = "四川省成都市郫都区",
        //                Logo = "",
        //                CompanyType = EnumCompanyType.Other,
        //                Phone = "028-838586",
        //                Fax = "028-838586",
        //                Email = "10001@domain.com",
        //                IsActive = true,
        //                IsDeleted = false,
        //                OwnerUserGuid = superAdminGuid,
        //                OwnerUserNo = superAdminUserNo,
        //                Abstract = "系统初始化圈子",
        //                CreateBy = superAdminGuid,
        //                CreateOnUtc = DateTime.UtcNow,
        //                UpdateBy = superAdminGuid,
        //                UpdateOnUtc = DateTime.UtcNow
        //            };

        //            context.Companies.Add(company);

        //            #endregion

        //            #region 后台菜单信息

        //            var menuPermissions = new List<MenuPermission>()
        //            {
        //                new MenuPermission(){
        //                    Id=1,
        //                    ParentId = null,
        //                    Title="系统信息",
        //                    Icon="fa-con",
        //                    Area = "Admin",
        //                    Controller="Home",
        //                    Action="Index",
        //                    Front = false,
        //                    Status = EnumStatus.Normal,
        //                    IsVisible = true,
        //                    SortId = 90,
        //                    CreateOnUtc = DateTime.UtcNow,
        //                    CreateBy = superAdminGuid,
        //                    UpdateOnUtc = DateTime.UtcNow,
        //                    UpdateBy = superAdminGuid,
        //                    ActionPermissions = new List<ActionPermission>(){
        //                        new ActionPermission(){
        //                            Area = "Admin",
        //                            Controller = "Home",
        //                            Action = "Index",
        //                            SortId = 99,
        //                            Description = "首页",
        //                            Status = EnumStatus.Normal,
        //                            IsDeleted = false,
        //                            CreateOnUtc = DateTime.UtcNow,
        //                            CreateBy = superAdminGuid,
        //                            UpdateOnUtc = DateTime.UtcNow,
        //                            UpdateBy = superAdminGuid
        //                        }
        //                    }
        //                },
        //                new MenuPermission(){
        //                    Id=2,
        //                    ParentId = null,
        //                    Title="组织架构",
        //                    Icon="fa-con",
        //                    Area = "Admin",
        //                    Controller="DepartmentManage",
        //                    Action="Index",
        //                    Front = false,
        //                    Status = EnumStatus.Normal,
        //                    IsVisible=true,
        //                    SortId=91,
        //                    CreateOnUtc = DateTime.UtcNow,
        //                    CreateBy = superAdminGuid,
        //                    UpdateOnUtc = DateTime.UtcNow,
        //                    UpdateBy = superAdminGuid,
        //                    ActionPermissions = new List<ActionPermission>(){
        //                        new ActionPermission(){
        //                            Area = "Admin",
        //                            Controller = "DepartmentManage",
        //                            Action = "DeleteDpt",
        //                            SortId = 99,
        //                            Description = "删除部门及部门员工",
        //                            Status = EnumStatus.Normal,
        //                            IsDeleted = false,
        //                            CreateOnUtc = DateTime.UtcNow,
        //                            CreateBy = superAdminGuid,
        //                            UpdateOnUtc = DateTime.UtcNow,
        //                            UpdateBy = superAdminGuid
        //                        },
        //                        new ActionPermission(){
        //                            Area = "Admin",
        //                            Controller = "DepartmentManage",
        //                            Action = "Form",
        //                            SortId = 99,
        //                            Description = "编辑组织架构",
        //                            Status = EnumStatus.Normal,
        //                            IsDeleted = false,
        //                            CreateOnUtc = DateTime.UtcNow,
        //                            CreateBy = superAdminGuid,
        //                            UpdateOnUtc = DateTime.UtcNow,
        //                            UpdateBy = superAdminGuid
        //                        },
        //                        new ActionPermission(){
        //                            Area = "Admin",
        //                            Controller = "DepartmentManage",
        //                            Action = "GetActiveEmps",
        //                            SortId = 99,
        //                            Description = "获取在职的公司员工",
        //                            Status = EnumStatus.Normal,
        //                            IsDeleted = false,
        //                            CreateOnUtc = DateTime.UtcNow,
        //                            CreateBy = superAdminGuid,
        //                            UpdateOnUtc = DateTime.UtcNow,
        //                            UpdateBy = superAdminGuid
        //                        },
        //                        new ActionPermission(){
        //                            Area = "Admin",
        //                            Controller = "DepartmentManage",
        //                            Action = "GetDptEmps",
        //                            SortId = 99,
        //                            Description = "获取部门员工",
        //                            Status = EnumStatus.Normal,
        //                            IsDeleted = false,
        //                            CreateOnUtc = DateTime.UtcNow,
        //                            CreateBy = superAdminGuid,
        //                            UpdateOnUtc = DateTime.UtcNow,
        //                            UpdateBy = superAdminGuid
        //                        },
        //                        new ActionPermission(){
        //                            Area = "Admin",
        //                            Controller = "DepartmentManage",
        //                            Action = "Index",
        //                            SortId = 99,
        //                            Description = "组织架构首页",
        //                            Status = EnumStatus.Normal,
        //                            IsDeleted = false,
        //                            CreateOnUtc = DateTime.UtcNow,
        //                            CreateBy = superAdminGuid,
        //                            UpdateOnUtc = DateTime.UtcNow,
        //                            UpdateBy = superAdminGuid
        //                        },
        //                        new ActionPermission(){
        //                            Area = "Admin",
        //                            Controller = "DepartmentManage",
        //                            Action = "SaveDpt",
        //                            SortId = 99,
        //                            Description = "保存部门信息",
        //                            Status = EnumStatus.Normal,
        //                            IsDeleted = false,
        //                            CreateOnUtc = DateTime.UtcNow,
        //                            CreateBy = superAdminGuid,
        //                            UpdateOnUtc = DateTime.UtcNow,
        //                            UpdateBy = superAdminGuid
        //                        },
        //                        new ActionPermission(){
        //                            Area = "Admin",
        //                            Controller = "DepartmentManage",
        //                            Action = "SaveEmpDpts",
        //                            SortId = 99,
        //                            Description = "批量分配员工部门信息",
        //                            Status = EnumStatus.Normal,
        //                            IsDeleted = false,
        //                            CreateOnUtc = DateTime.UtcNow,
        //                            CreateBy = superAdminGuid,
        //                            UpdateOnUtc = DateTime.UtcNow,
        //                            UpdateBy = superAdminGuid
        //                        },
        //                        new ActionPermission(){
        //                            Area = "Admin",
        //                            Controller = "DepartmentManage",
        //                            Action = "SetDptManager",
        //                            SortId = 99,
        //                            Description = "设置部门负责人",
        //                            Status = EnumStatus.Normal,
        //                            IsDeleted = false,
        //                            CreateOnUtc = DateTime.UtcNow,
        //                            CreateBy = superAdminGuid,
        //                            UpdateOnUtc = DateTime.UtcNow,
        //                            UpdateBy = superAdminGuid
        //                        },
        //                        new ActionPermission(){
        //                            Area = "Admin",
        //                            Controller = "DepartmentManage",
        //                            Action = "SetDptStatus",
        //                            SortId = 99,
        //                            Description = "更新部门状态",
        //                            Status = EnumStatus.Normal,
        //                            IsDeleted = false,
        //                            CreateOnUtc = DateTime.UtcNow,
        //                            CreateBy = superAdminGuid,
        //                            UpdateOnUtc = DateTime.UtcNow,
        //                            UpdateBy = superAdminGuid
        //                        }
        //                    }
        //                },
        //                new MenuPermission(){
        //                    Id=3,
        //                    ParentId = null,
        //                    Title="用户和角色",
        //                    Icon="fa-users",
        //                    Area = null,
        //                    Controller = null,
        //                    Action=null,
        //                    Front = false,
        //                    Status = EnumStatus.Normal,
        //                    IsVisible =true,
        //                    SortId = 92,
        //                    CreateOnUtc = DateTime.UtcNow,
        //                    CreateBy = superAdminGuid,
        //                    UpdateOnUtc = DateTime.UtcNow,
        //                    UpdateBy = superAdminGuid,
        //                    ActionPermissions = new List<ActionPermission>(){

        //                    }
        //                },
        //                new MenuPermission(){
        //                    Id=4,
        //                    ParentId = 3,
        //                    Title="用户管理",
        //                    Icon="fa-users",
        //                    Area = "Admin",
        //                    Controller="UserManage",
        //                    Action="Index",
        //                    Front = false,
        //                    Status = EnumStatus.Normal,
        //                    IsVisible =true,
        //                    SortId = 95,
        //                    CreateOnUtc = DateTime.UtcNow,
        //                    CreateBy = superAdminGuid,
        //                    UpdateOnUtc = DateTime.UtcNow,
        //                    UpdateBy = superAdminGuid,
        //                    ActionPermissions = new List<ActionPermission>(){
        //                        new ActionPermission(){
        //                            Area = "Admin",
        //                            Controller = "UserManage",
        //                            Action = "DisableUser",
        //                            SortId = 99,
        //                            Description = "禁用用户",
        //                            Status = EnumStatus.Normal,
        //                            IsDeleted = false,
        //                            CreateOnUtc = DateTime.UtcNow,
        //                            CreateBy = superAdminGuid,
        //                            UpdateOnUtc = DateTime.UtcNow,
        //                            UpdateBy = superAdminGuid
        //                        },
        //                        new ActionPermission(){
        //                            Area = "Admin",
        //                            Controller = "UserManage",
        //                            Action = "EnableUser",
        //                            SortId = 99,
        //                            Description = "启用用户",
        //                            Status = EnumStatus.Normal,
        //                            IsDeleted = false,
        //                            CreateOnUtc = DateTime.UtcNow,
        //                            CreateBy = superAdminGuid,
        //                            UpdateOnUtc = DateTime.UtcNow,
        //                            UpdateBy = superAdminGuid
        //                        },
        //                        new ActionPermission(){
        //                            Area = "Admin",
        //                            Controller = "UserManage",
        //                            Action = "Index",
        //                            SortId = 99,
        //                            Description = "用户管理首页",
        //                            Status = EnumStatus.Normal,
        //                            IsDeleted = false,
        //                            CreateOnUtc = DateTime.UtcNow,
        //                            CreateBy = superAdminGuid,
        //                            UpdateOnUtc = DateTime.UtcNow,
        //                            UpdateBy = superAdminGuid
        //                        },
        //                        new ActionPermission(){
        //                            Area = "Admin",
        //                            Controller = "UserManage",
        //                            Action = "SaveRolesUsers",
        //                            SortId = 99,
        //                            Description = "批量设置角色和用户信息",
        //                            Status = EnumStatus.Normal,
        //                            IsDeleted = false,
        //                            CreateOnUtc = DateTime.UtcNow,
        //                            CreateBy = superAdminGuid,
        //                            UpdateOnUtc = DateTime.UtcNow,
        //                            UpdateBy = superAdminGuid
        //                        },
        //                        new ActionPermission(){
        //                            Area = "Admin",
        //                            Controller = "UserManage",
        //                            Action = "SaveUserRoles",
        //                            SortId = 99,
        //                            Description = "批量设置用户角色",
        //                            Status = EnumStatus.Normal,
        //                            IsDeleted = false,
        //                            CreateOnUtc = DateTime.UtcNow,
        //                            CreateBy = superAdminGuid,
        //                            UpdateOnUtc = DateTime.UtcNow,
        //                            UpdateBy = superAdminGuid
        //                        }
        //                    }
        //                },
        //            };

        //            menuPermissions.ForEach(e => context.MenuPermissions.Add(e));
        //            #endregion

        //            context.SaveChanges();
        //            trans.Commit();
        //        }
        //        catch (Exception e)
        //        {
        //            trans.Rollback();
        //            LogHelper.LogException(e);
        //        }
        //    }
        //}
    }
}
