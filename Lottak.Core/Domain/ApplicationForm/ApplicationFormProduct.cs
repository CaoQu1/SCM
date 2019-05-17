using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottak.Core.ApplicationForm
{
    /// <summary>
    /// 表单产品信息表
    /// </summary>
    public class ApplicationFormProduct : BaseEntity
    {
        /// <summary>
        /// 来源产品编号
        /// </summary>
        public Guid OrginProductGuid { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 型号
        /// </summary>
        public string ProductModel { get; set; }

        /// <summary>
        /// 规格
        /// </summary>
        public string ProductSpecifications { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int ProductNumber { get; set; }

        /// <summary>
        /// 周期
        /// </summary>
        public string ProductCycle { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// 指标要求
        /// </summary>
        public string ProductQualification { get; set; }

        ///// <summary>
        ///// 表单编号
        ///// </summary>
        //public virtual int ApplicationFormId { get; set; }

        //#region relationship

        ///// <summary>
        ///// 表单信息
        ///// </summary>
        //public virtual ApplicationForm ApplicationForm { get; set; }

        ///// <summary>
        ///// 询单产品供应商记录
        ///// </summary>
        //public virtual ICollection<EnquirySupplier> EnquiryAppFormSuppliers { get; set; }

        //#endregion
    }
}
