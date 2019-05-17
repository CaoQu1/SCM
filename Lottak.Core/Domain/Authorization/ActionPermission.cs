using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottak.Core.Authorization
{
    /// <summary>
    /// 操作信息表
    /// </summary>
    [Table("ActionPermissions")]
    public class ActionPermission : BaseEntity
    {
        /// <summary>
        /// 菜单编号
        /// </summary>
        public int MenuPermissionId { get; set; }

        /// <summary>
        /// 区域
        /// </summary>
        public string Area { get; set; }

        /// <summary>
        /// 控制器
        /// </summary>
        public string Controller { get; set; }

        /// <summary>
        /// 方法
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int SortId { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public EnumStatus Status { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDeleted { get; set; }

        #region relationship
        /// <summary>
        /// 菜单信息
        /// </summary>
        public virtual MenuPermission MenuPermission { get; set; }

        /// <summary>
        /// 操作角色
        /// </summary>
        public virtual ICollection<ActionPermissionRole> ActionPermissionRoles { get; set; }
        #endregion
    }
}
