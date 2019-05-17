using Lottak.Core.Authorization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottak.Core.Company
{
    /// <summary>
    /// 公司部门信息表
    /// </summary>
    [Serializable]
    [Table("Departments")]
    public class Department : BaseEntity
    {
        public Department()
        {
            this.SubDpts = new List<Department>();
        }

        /// <summary>
        /// 圈子编号
        /// </summary>
        [DisplayName("圈子编号")]
        public int CompanyNo { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        [DisplayName("部门名称")]
        [Required(ErrorMessage = "请填写{0}")]
        [StringLength(20, ErrorMessage = "{0}为{2}-{1}个字符", MinimumLength = 2)]
        public string Name { get; set; }

        /// <summary>
        /// 映射的部门编号
        /// </summary>
        public Nullable<int> FromDptId { get; set; }

        /// <summary>
        /// 上级部门编号
        /// </summary>
        [DisplayName("上级部门编号")]
        public Nullable<int> ParentId { get; set; }

        /// <summary>
        /// 层级深度
        /// </summary>
        [DisplayName("层级深度")]
        public int Depth { get; set; }

        /// <summary>
        /// 部门状态
        /// </summary>
        [DisplayName("部门状态")]
        [Required(ErrorMessage = "请选择{0}")]
        public EnumStatus Status { get; set; }

        /// <summary>
        /// 备注信息
        /// </summary>
        [DisplayName("备注信息")]
        [StringLength(200, ErrorMessage = "{0}最大长度为{1}个字符")]
        public string Description { get; set; }

        /// <summary>
        /// 排序号
        /// </summary>
        [DisplayName("排序号")]
        [Required(ErrorMessage = "请输入{0}")]
        [DefaultValue(99)]
        public int SortId { get; set; }

        /// <summary>
        /// 部门管理人员编号
        /// </summary>
        [DisplayName("管理人员")]
        public Nullable<Guid> DptManagerEmpGuid { get; set; }

        /// <summary>
        /// 部门管理员名称(员工名称)
        /// </summary>
        [NotMapped]
        public string DptManagerName { get; set; }

        /// <summary>
        /// 是否已删除
        /// </summary>
        [DisplayName("已删除")]
        public bool IsDeleted { get; set; }

        #region Relationships

        public virtual Department ParentDpt { get; set; }

        public virtual ICollection<Department> SubDpts { get; set; }

        #endregion
    }
}
