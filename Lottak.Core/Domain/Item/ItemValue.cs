using Lottak.Core.ApplicationForm;
using Lottak.Core.Authorization;
using Lottak.Core.Suppliers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottak.Core.Item
{
    /// <summary>
    /// 字典值信息表
    /// </summary>
    [Table("ItemValues")]
    public class ItemValue : BaseEntity
    {
        /// <summary>
        /// 公司编号
        /// </summary>
        public int CompanyNo { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int SortId { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public EnumStatus Status { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 键编号
        /// </summary>
        public int ItemId { get; set; }

        #region relationship

        /// <summary>
        /// 键信息
        /// </summary>
        public virtual Item Item { get; set; }

        /// <summary>
        /// 公司性质
        /// </summary>
        public virtual ICollection<Supplier> CompanyTypes { get; set; }

        /// <summary>
        /// 注册资本
        /// </summary>
        public virtual ICollection<Supplier> RegisterCapitals { get; set; }

        /// <summary>
        /// 结款方式
        /// </summary>
        public virtual ICollection<Supplier> PaymentTypes { get; set; }

        /// <summary>
        /// 供应商等级
        /// </summary>
        public virtual ICollection<Supplier> SupplierGrades { get; set; }

        /// <summary>
        /// 税率
        /// </summary>
        public virtual ICollection<PurchaseContract> Rates { get; set; }

        /// <summary>
        /// 付款周期
        /// </summary>
        public virtual ICollection<PurchaseContract> PaymenCycles { get; set; }

        #endregion
    }
}
