using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottak.Core.ApplicationForm
{
    /// <summary>
    /// 表单信息表
    /// </summary>
    public class ApplicationForm : BaseEntity
    {
        /// <summary>
        /// 公司编号
        /// </summary>
        public int CompanyNo { get; set; }

        /// <summary>
        /// 表单唯一编号
        /// </summary>
        public Guid FormGuid { get; set; }

        /// <summary>
        /// 来源表单编号
        /// </summary>
        public Guid OrginFormGuid { get; set; }

        /// <summary>
        /// 表单编号
        /// </summary>
        public string FormCode { get; set; }

        /// <summary>
        /// 表单类型
        /// </summary>
        public EnumFormType FromType { get; set; }

        /// <summary>
        /// 表单状态
        /// </summary>
        public EnumFormStatus FromStatus { get; set; }

        /// <summary>
        /// （业务）完结时间
        /// </summary>
        public Nullable<DateTime> FinishDate { get; set; }

        /// <summary>
        /// 处理人员工编号
        /// </summary>
        public Guid HandleGuid { get; set; }

        /// <summary>
        /// 申请人
        /// </summary>
        public string Proposer { get; set; }

        [NotMapped]
        public override Guid CreateBy { get; set; }

        #region relationship

        /// <summary>
        /// 表单附件信息
        /// </summary>
        public virtual ICollection<ApplicationFormAttachment> ApplicationFormAttachments { get; set; }

        #endregion
    }
}
