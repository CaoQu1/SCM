using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottak.Core.Suppliers
{
    /// <summary>
    /// 供应商联系人信息表
    /// </summary>
    [Table("SupplierContacts")]
    public class SupplierContact : BaseEntity
    {
        /// <summary>
        /// 公司编号
        /// </summary>
        public int CompanyNo { get; set; }

        /// <summary>
        /// 联系人名称
        /// </summary>
        public string ContactName { get; set; }

        /// <summary>
        /// 联系人手机
        /// </summary>
        public string ContactPhone { get; set; }

        /// <summary>
        /// 联系人微信
        /// </summary>
        public string ContactWeixin { get; set; }

        /// <summary>
        /// 联系人QQ
        /// </summary>
        public string ContactQQ { get; set; }

        /// <summary>
        /// 供应商编号
        /// </summary>
        public int SupplierId { get; set; }

        #region relationship

        /// <summary>
        /// 供应商信息
        /// </summary>
        public virtual Supplier Supplier { get; set; }

        #endregion
    }
}
