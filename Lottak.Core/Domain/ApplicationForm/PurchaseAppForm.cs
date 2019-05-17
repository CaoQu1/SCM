using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottak.Core.ApplicationForm
{
    /// <summary>
    /// 采购单信息表
    /// </summary>
    [Table("PurchaseAppForms")]
    public class PurchaseAppForm : ApplicationForm
    {
        /// <summary>
        /// 物料名称
        /// </summary>
        public string MaterialName { get; set; }

        /// <summary>
        /// 采购单类型
        /// </summary>
        public EnumPurchaseFormType PurchaseFormType { get; set; }

        /// <summary>
        /// 采购单产品信息
        /// </summary>
        public virtual ICollection<PurchaseProduct> PurchaseProducts { get; set; }

        ///// <summary>
        ///// 表单附件信息
        ///// </summary>
        //public virtual ICollection<PurchaseAppFormAttachment> ApplicationFormAttachments { get; set; }
    }

    ///// <summary>
    ///// 采购附件信息
    ///// </summary>
    //[Table("PurchaseAppFormAttachments")]
    //public class PurchaseAppFormAttachment : ApplicationFormAttachment
    //{
    //    /// <summary>
    //    /// 采购单信息
    //    /// </summary>
    //    public PurchaseAppForm PurchaseAppForm { get; set; }
    //}
}
