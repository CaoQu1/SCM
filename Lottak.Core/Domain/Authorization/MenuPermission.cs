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
    /// 菜单信息表
    /// </summary>
    [Table("MenuPermissions")]
    public class MenuPermission : BaseEntity
    {
        /// <summary>
        /// 父菜单编号
        /// </summary>
        public int? ParentId { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; }

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
        /// 是否前台菜单
        /// </summary>
        public bool Front { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public EnumStatus State { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int SortId { get; set; }

        /// <summary>
        /// 是否显示
        /// </summary>
        public bool IsVisible { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public EnumStatus Status { get; set; }

        #region  relationship
        /// <summary>
        /// 父菜单
        /// </summary>
        public virtual MenuPermission Parent { get; set; }

        /// <summary>
        /// 子菜单
        /// </summary>
        public virtual ICollection<MenuPermission> Childrens { get; set; }

        /// <summary>
        /// 菜单操作关系
        /// </summary>
        public virtual ICollection<ActionPermission> ActionPermissions { get; set; }

        /// <summary>
        /// 菜单角色
        /// </summary>
        public virtual ICollection<MenuPermissionRole> MenuPermissionRoles { get; set; }
        #endregion
    }
}
