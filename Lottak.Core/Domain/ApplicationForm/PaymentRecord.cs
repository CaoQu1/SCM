using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottak.Core.ApplicationForm
{
    /// <summary>
    /// 付款记录
    /// </summary>
    [Table("PaymentRecords")]
    public class PaymentRecord : BaseEntity
    {
        /// <summary>
        /// 采购合同产品记录编号
        /// </summary>
        public int PurchaseContractProductId { get; set; }

        /// <summary>
        /// 付款金额
        /// </summary>
        public decimal Money { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        #region relationship

        /// <summary>
        /// 采购合同产品信息
        /// </summary>
        public PurchaseContractProduct PurchaseContractProduct { get; set; }

        #endregion
    }
}
