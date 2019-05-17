using Lottak.Core.ApplicationForm;
using Lottak.Core.Authorization;
using Lottak.Core.FeedbackRecord;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottak.Core.Attachment
{
    /// <summary>
    /// 系统附件表
    /// </summary>
    [Table("SystemAttachments")]
    public class SystemAttachment : BaseEntity
    {
        /// <summary>
        /// 上传人
        /// </summary>
        public Guid UserGuid { get; set; }
        /// <summary>
        /// 上传人名称
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 原始文件名
        /// </summary>
        public string OriginalFileName { get; set; }
        /// <summary>
        /// 文件别名
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 存储服务器
        /// </summary>
        public string FileDomain { get; set; }
        /// <summary>
        /// 存储路径
        /// </summary>
        public string FilePath { get; set; }
        /// <summary>
        /// 缩略图位置
        /// </summary>
        public string ThumbnailFilePath { get; set; }
        /// <summary>
        /// 文件格式
        /// </summary>
        public string FileExt { get; set; }
        /// <summary>
        /// 文件大小
        /// </summary>
        public Nullable<decimal> FileSize { get; set; }
        /// <summary>
        /// 来源模块编号
        /// </summary>
        public Nullable<int> ModuleId { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public EnumStatus Status { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [DisplayName("备注")]
        [StringLength(200, ErrorMessage = "{0}不得超过{1}个字符")]
        public string Description { get; set; }

        /// <summary>
        /// 公司编号
        /// </summary>
        public int CompanyNo { get; set; }

        #region relationship

        ///// <summary>
        ///// 采购附件信息
        ///// </summary>
        //public virtual ICollection<PurchaseAppFormAttachment> PurchaseAppForms { get; set; }

        ///// <summary>
        ///// 询单附件信息
        ///// </summary>
        //public virtual ICollection<EnquiryAppFormAttachment> EnquiryAppForms { get; set; }

        /// <summary>
        /// 表单附件信息
        /// </summary>
        public virtual ICollection<ApplicationFormAttachment> ApplicationFormAttachments { get; set; }

        /// <summary>
        /// 反馈附件信息
        /// </summary>
        public virtual ICollection<FeedbackRecordAttachment> FeedbackRecordAttachments { get; set; }

        /// <summary>
        /// 询单记录附件信息
        /// </summary>
        public virtual ICollection<EnquirySupplierAttachment> EnquirySupplierAttachments { get; set; }

        #endregion
    }
}
