using Lottak.Core.Attachment;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottak.Core.FeedbackRecord
{
    [Table("FeedbackRecordAttachments")]
    public class FeedbackRecordAttachment : BaseEntity
    {
        /// <summary>
        /// 反馈编号
        /// </summary>
        public int FeedbackRecordId { get; set; }

        /// <summary>
        /// 附件编号
        /// </summary>
        public int SystemAttachmentId { get; set; }

        #region relationship

        /// <summary>
        /// 反馈信息
        /// </summary>
        public virtual FeedbackRecord FeedbackRecord { get; set; }

        /// <summary>
        /// 附件信息
        /// </summary>
        public virtual SystemAttachment SystemAttachment { get; set; }
        #endregion
    }
}
