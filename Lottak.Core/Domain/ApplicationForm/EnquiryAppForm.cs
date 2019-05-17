using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottak.Core.ApplicationForm
{
    /// <summary>
    /// 询单
    /// </summary>
    [Table("EnquiryAppForms")]
    public class EnquiryAppForm : ApplicationForm
    {
        /// <summary>
        /// 询单人员信息
        /// </summary>
        public virtual ICollection<EnquiryAppFromUser> EnquiryAppFromUsers { get; set; }

        /// <summary>
        /// 询单产品信息
        /// </summary>
        public virtual ICollection<EnquiryAppFormProduct> EnquiryAppFormProducts { get; set; }

        ///// <summary>
        ///// 表单附件信息
        ///// </summary>
        //public virtual ICollection<EnquiryAppFormAttachment> ApplicationFormAttachments { get; set; }
    }

    /// <summary>
    /// 询单人员信息
    /// </summary>
    [Table("EnquiryAppFromUsers")]
    public class EnquiryAppFromUser : ApplicationFormUser
    {
        /// <summary>
        /// 表单编号
        /// </summary>
        public int ApplicationFormId { get; set; }

        /// <summary>
        /// 询单信息
        /// </summary>
        public virtual EnquiryAppForm EnquiryAppForm { get; set; }
    }

    /// <summary>
    /// 询单产品信息
    /// </summary>
    [Table("EnquiryAppFormProducts")]
    public class EnquiryAppFormProduct : ApplicationFormProduct
    {
        public int ApplicationFormId { get; set; }

        /// <summary>
        /// 询单信息
        /// </summary>
        public virtual EnquiryAppForm EnquiryAppForm { get; set; }

        /// <summary>
        /// 询单供应商信息
        /// </summary>
        public virtual ICollection<EnquirySupplier> EnquirySuppliers { get; set; }
    }

    ///// <summary>
    ///// 询单附件信息
    ///// </summary>
    //[Table("EnquiryAppFormAttachments")]
    //public class EnquiryAppFormAttachment : ApplicationFormAttachment
    //{
    //    /// <summary>
    //    /// 询单信息
    //    /// </summary>
    //    public EnquiryAppForm EnquiryAppForm { get; set; }
    //}
}
