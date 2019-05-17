using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottak.Core.Authorization
{
    /// <summary>
    /// 菜单角色关联信息表
    /// </summary>
    [Table("MenuPermissionRoles")]
    public class MenuPermissionRole : BaseEntity
    {
        /// <summary>
        /// 公司编号
        /// </summary>
        public int CompanyNo { get; set; }

        /// <summary>
        /// 菜单权限编辑
        /// </summary>
        public int MenuPermissionId { get; set; }

        /// <summary>
        /// 角色编号
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// 是否已删除
        /// </summary>
        public bool IsDeleted { get; set; }

        #region Relationships

        /// <summary>
        /// 菜单信息
        /// </summary>
        public virtual MenuPermission MenuPermission { get; set; }

        /// <summary>
        /// 角色信息
        /// </summary>
        public virtual Role Role { get; set; }

        #endregion
    }
}
