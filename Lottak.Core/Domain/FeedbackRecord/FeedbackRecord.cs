using Lottak.Core.Authorization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottak.Core.FeedbackRecord
{
    /// <summary>
    /// 反馈记录信息表
    /// </summary>
    [Table("FeedbackRecords")]
    public class FeedbackRecord : BaseEntity
    {
        /// <summary>
        /// 模块编号
        /// </summary>
        public EnumFeedModule ModuleId { get; set; }

        /// <summary>
        /// 目标编号
        /// </summary>
        public int? TargetId { get; set; }

        /// <summary>
        /// 父编号
        /// </summary>
        public int? ParentId { get; set; }

        /// <summary>
        /// 员工名称
        /// </summary>
        public string EmpName { get; set; }

        /// <summary>
        /// 员工编号
        /// </summary>
        public Guid EmpGuid { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        public string Actvar { get; set; }

        /// <summary>
        /// 反馈信息
        /// </summary>
        public string FeedMessage { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public EnumStatus Status { get; set; }

        #region relationship

        /// <summary>
        /// 反馈附件信息
        /// </summary>
        public virtual ICollection<FeedbackRecordAttachment> FeedbackRecordAttachments { get; set; }

        #endregion

    }
}
