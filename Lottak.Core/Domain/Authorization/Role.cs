using Abp.Domain.Entities;
using Lottak.Core.Authorization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottak.Core.Authorization
{
    /// <summary>
    /// 角色信息表
    /// </summary>
    [Table("Roles")]
    public class Role : BaseEntity
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public EnumStatus State { get; set; }

        /// <summary>
        /// 公司编号
        /// </summary>
        public int CompanyNo { get; set; }

        /// <summary>
        /// 是否是系统内置账号
        /// </summary>
        public bool IsSystemRole { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 用户角色
        /// </summary>
        public virtual ICollection<SystemUserRole> SystemUserRoles { get; set; }

        /// <summary>
        /// 角色操作
        /// </summary>
        public virtual ICollection<ActionPermissionRole> ActionPermissionRoles { get; set; }

        /// <summary>
        /// 角色菜单
        /// </summary>
        public virtual ICollection<MenuPermissionRole> MenuPermissionRoles { get; set; }
    }
}
