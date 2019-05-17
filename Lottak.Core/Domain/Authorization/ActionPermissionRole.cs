using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottak.Core.Authorization
{
    /// <summary>
    /// 操作角色关联信息表
    /// </summary>
    [Table("ActionPermissionRoles")]
    public class ActionPermissionRole : BaseEntity
    {
        /// <summary>
        /// 公司编号
        /// </summary>
        public int CompanyNo { get; set; }
        /// <summary>
        /// Action权限编号
        /// </summary>
        public int ActionPermissionId { get; set; }
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
        /// Action
        /// </summary>
        public virtual ActionPermission ActionPermission { get; set; }

        /// <summary>
        /// 角色信息
        /// </summary>
        public virtual Role Role { get; set; }

        #endregion
    }
}
