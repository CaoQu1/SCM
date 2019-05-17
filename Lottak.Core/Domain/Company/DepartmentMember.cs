using Lottak.Core.Company;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottak.Core
{
    /// <summary>
    /// 部门成员信息表
    /// </summary>
    [Serializable]
    [Table("DepartmentMembers")]
    public class DepartmentMember : BaseEntity
    {   /// <summary>
        /// 圈子编号
        /// </summary>
        [DisplayName("圈子编号")]
        public int CompanyNo { get; set; }

        /// <summary>
        /// 部门编号
        /// </summary>
        [DisplayName("部门编号")]
        [Required(ErrorMessage = "请选择{0}")]
        [ForeignKey("Dpt")]
        public int DptId { get; set; }

        /// <summary>
        /// 员工编号
        /// </summary>
        [DisplayName("员工编号")]
        [Required(ErrorMessage = "请选择{0}")]
        public Guid EmpGuid { get; set; }

        /// <summary>
        /// 用户编号
        /// </summary>
        [DisplayName("用户编号")]
        public Guid UserGuid { get; set; }

        /// <summary>
        /// 是否部门管理员
        /// </summary>
        [DisplayName("部门管理员")]
        public bool IsDptAdmin { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [DisplayName("状态")]
        public bool IsDeleted { get; set; }

        [NotMapped]
        public int Level { get; set; }

        /// <summary>
        /// 部门信息
        /// </summary>
        public virtual Department Dpt { get; set; }
    }
}
