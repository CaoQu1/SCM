using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottak.Core.ApplicationForm
{
    /// <summary>
    /// 采购产品信息表
    /// </summary>
    [Table("PurchaseProducts")]
    public class PurchaseProduct : ApplicationFormProduct
    {
        /// <summary>
        /// 已采购数量
        /// </summary>
        public int PurchasQuantitied { get; set; }

        /// <summary>
        /// 询单编号
        /// </summary>
        public Guid EnquiryFormGuid { get; set; }

        /// <summary>
        /// 产品状态
        /// </summary>
        public EnumPurchaseProductStatus ProductStatus { get; set; }

        /// <summary>
        /// 是否已变更
        /// </summary>
        public bool IsChange { get; set; }

        /// <summary>
        /// 表单编号
        /// </summary>
        public int ApplicationFormId { get; set; }

        /// <summary>
        /// 采购单信息
        /// </summary>
        public virtual PurchaseAppForm PurchaseAppForm { get; set; }
    }
}
