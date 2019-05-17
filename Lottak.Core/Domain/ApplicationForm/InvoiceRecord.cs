using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottak.Core.ApplicationForm
{
    /// <summary>
    /// 发票记录
    /// </summary>
    [Table("InvoiceRecords")]
    public class InvoiceRecord : BaseEntity
    {
        /// <summary>
        ///发票编号
        /// </summary>
        public string InvoceCode { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 合同产品编号
        /// </summary>
        public int PurchaseContractProductId { get; set; }

        #region relationship

        /// <summary>
        /// 合同产品信息
        /// </summary>
        public virtual PurchaseContractProduct PurchaseContractProduct { get; set; }

        #endregion
    }
}
