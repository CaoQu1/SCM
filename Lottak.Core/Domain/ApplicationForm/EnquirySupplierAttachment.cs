using Lottak.Core.Attachment;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottak.Core.ApplicationForm
{
    /// <summary>
    /// 询单供应商记录附件信息表
    /// </summary>
    [Table("EnquirySupplierAttachments")]
    public class EnquirySupplierAttachment : BaseEntity
    {
        /// <summary>
        /// 附件编号
        /// </summary>
        public int SystemAttachmentId { get; set; }

        /// <summary>
        /// 询单供应商记录编号
        /// </summary>
        public int EnquirySupplierId { get; set; }

        #region relationship

        /// <summary>
        /// 附件信息
        /// </summary>
        public virtual SystemAttachment SystemAttachment { get; set; }

        /// <summary>
        /// 供应商记录
        /// </summary>
        public virtual EnquirySupplier EnquirySupplier { get; set; }

        #endregion
    }
}
