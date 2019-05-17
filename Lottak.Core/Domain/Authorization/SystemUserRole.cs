using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottak.Core.Authorization
{
    /// <summary>
    /// 用户角色信息表
    /// </summary>
    [Table("SystemUserRoles")]
    public class SystemUserRole : BaseEntity
    {
        /// <summary>
        /// 公司编号
        /// </summary>
        [DisplayName("圈子编号")]
        public int CompanyNo { get; set; }

        /// <summary>
        /// 用户标识
        /// </summary>
        [DisplayName("用户标识")]
        [Required(ErrorMessage = "请选择{0}")]
        public Guid UserGuid { get; set; }

        /// <summary>
        /// 角色编号
        /// </summary>
        [DisplayName("角色编号")]
        [Required(ErrorMessage = "请选择{0}")]
        public int RoleId { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        [DisplayName("角色名称")]
        [StringLength(20, ErrorMessage = "{0}不得超过{1}个字符")]
        public string RoleName { get; set; }

        /// <summary>
        /// 角色状态
        /// </summary>
        [DisplayName("角色状态")]
        public EnumStatus Status { get; set; }

        #region [NotMapped] Roles

        /// <summary>
        /// 角色备注
        /// </summary>
        [NotMapped]
        public string Description { get; set; }

        #endregion

        #region Relationships

        /// <summary>
        /// 角色信息
        /// </summary>
        public virtual Role Role { get; set; }

        #endregion
    }
}
