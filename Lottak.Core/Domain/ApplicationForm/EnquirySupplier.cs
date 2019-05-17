using Lottak.Core.Suppliers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottak.Core.ApplicationForm
{
    /// <summary>
    /// 询单供应商记录表
    /// </summary>
    [Table("EnquirySuppliers")]
    public class EnquirySupplier : BaseEntity
    {
        /// <summary>
        /// 供应商编号
        /// </summary>
        public int SupplierId { get; set; }

        /// <summary>
        /// 报价
        /// </summary>
        public decimal Offer { get; set; }

        /// <summary>
        /// 周期
        /// </summary>
        public string Cycle { get; set; }

        /// <summary>
        /// 质保
        /// </summary>
        public string QualityAssurance { get; set; }

        /// <summary>
        /// 结款方式
        /// </summary>
        public int PaymentTypeId { get; set; }

        /// <summary>
        /// 是否提供规格书
        /// </summary>
        public bool IsSpecification { get; set; }

        /// <summary>
        /// 询单编号
        /// </summary>
        public Guid EnquiryAppFormGuid { get; set; }

        /// <summary>
        /// 询单产品编号
        /// </summary>
        public int ApplicationFormProductId { get; set; }


        #region relationship

        /// <summary>
        /// 询单供应商产品信息
        /// </summary>
        public virtual EnquiryAppFormProduct EnquiryAppFormProduct { get; set; }

        /// <summary>
        /// 询单供应商信息
        /// </summary>
        public virtual Supplier Supplier { get; set; }

        /// <summary>
        /// 附件信息
        /// </summary>
        public virtual ICollection<EnquirySupplierAttachment> EnquirySupplierAttachments { get; set; }
        #endregion
    }
}
