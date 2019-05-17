using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottak.Core.ApplicationForm
{
    /// <summary>
    /// 采购合同产品信息表
    /// </summary>
    [Table("PurchaseContractProducts")]
    public class PurchaseContractProduct : ApplicationFormProduct
    {
        /// <summary>
        /// 采购数量
        /// </summary>
        public int PurchaseNumber { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        public decimal ProductPrice { get; set; }

        /// <summary>
        /// 优惠金额
        /// </summary>
        public decimal DiscountPrice { get; set; }

        /// <summary>
        /// 采购合同编号
        /// </summary>
        public int PurchaseContractId { get; set; }

        //[NotMapped]
        //public override int ApplicationFormId { get; set; }

        #region relationship

        /// <summary>
        /// 采购合同信息
        /// </summary>
        public virtual PurchaseContract PurchaseContract { get; set; }

        /// <summary>
        /// 付款记录
        /// </summary>
        public virtual ICollection<PaymentRecord> PaymentRecords { get; set; }

        /// <summary>
        /// 发票记录
        /// </summary>
        public virtual ICollection<InvoiceRecord> InvoiceRecords { get; set; }

        #endregion
    }
}
