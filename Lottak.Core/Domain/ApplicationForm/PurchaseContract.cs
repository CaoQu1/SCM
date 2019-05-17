using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lottak.Core.Item;
using Lottak.Core.Suppliers;

namespace Lottak.Core.ApplicationForm
{
    /// <summary>
    /// 采购合同信息表
    /// </summary>
    [Table("PurchaseContracts")]
    public class PurchaseContract : BaseEntity
    {
        /// <summary>
        /// 采购单编号
        /// </summary>
        public Guid FormGuid { get; set; }

        /// <summary>
        /// 合同编号
        /// </summary>
        public string ContractCode { get; set; }

        /// <summary>
        /// 合同内部编号
        /// </summary>
        public string ContractInsideCode { get; set; }

        /// <summary>
        /// 合同客户编号
        /// </summary>
        public string ContractContactCode { get; set; }

        /// <summary>
        /// 应付款项
        /// </summary>
        public decimal Payables { get; set; }

        /// <summary>
        /// 供应商编号
        /// </summary>
        public int SupplierId { get; set; }

        /// <summary>
        /// 评级
        /// </summary>
        public double Grade { get; set; }

        /// <summary>
        /// 销售金额
        /// </summary>
        public decimal SalePrice { get; set; }

        /// <summary>
        /// 税率
        /// </summary>
        public int RateId { get; set; }

        /// <summary>
        /// 付款周期
        /// </summary>
        public int PaymenCycleId { get; set; }

        #region relationship

        /// <summary>
        /// 供应商
        /// </summary>
        public virtual Supplier Supplier { get; set; }

        /// <summary>
        /// 税率
        /// </summary>
        public virtual ItemValue Rates { get; set; }

        /// <summary>
        /// 付款周期
        /// </summary>
        public virtual ItemValue PaymenCycles { get; set; }

        /// <summary>
        /// 采购合同产品信息
        /// </summary>
        public virtual ICollection<PurchaseContractProduct> PurchaseContractProducts { get; set; }
             
        #endregion
    }
}
