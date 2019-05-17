using Lottak.Core.Attachment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottak.Core.ApplicationForm
{
    /// <summary>
    /// 表单附件
    /// </summary>
    public class ApplicationFormAttachment : BaseEntity
    {
        /// <summary>
        /// 表单编号
        /// </summary>
        public int ApplicationFormId { get; set; }

        /// <summary>
        /// 附件编号
        /// </summary>
        public int SystemAttachmentId { get; set; }

        #region relationship

        /// <summary>
        /// 表单信息
        /// </summary>
        public virtual ApplicationForm ApplicationForm { get; set; }

        /// <summary>
        /// 附件信息
        /// </summary>
        public virtual SystemAttachment SystemAttachment { get; set; }

        #endregion
    }
}
