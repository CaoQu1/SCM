using Lottak.Core.ApplicationForm;
using Lottak.Core.Company;
using Lottak.Core.Item;
using Lottak.Core.Region;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottak.Core.Suppliers
{
    /// <summary>
    /// 供应商信息表
    /// </summary>
    [Table("Suppliers")]
    public class Supplier : BaseEntity
    {
        /// <summary>
        /// 公司编号
        /// </summary>
        public int CompanyNo { get; set; }

        /// <summary>
        /// 供应商名称
        /// </summary>
        public string SupplierName { get; set; }

        /// <summary>
        /// 供应商分类
        /// </summary>
        public EnumSupplierType SupplierType { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string SupplierPhone { get; set; }

        /// <summary>
        /// 供应商等级
        /// </summary>
        public int SupplierGradeId { get; set; }

        /// <summary>
        /// 主营业务
        /// </summary>
        public string MainBusiness { get; set; }

        /// <summary>
        /// 区域
        /// </summary>
        public int AddressId { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 网址
        /// </summary>
        public string WebSite { get; set; }

        /// <summary>
        /// 是否是内部供应商
        /// </summary>
        public bool IsInternal { get; set; }

        /// <summary>
        /// 公司性质
        /// </summary>
        public int CompanyTypeId { get; set; }

        /// <summary>
        /// 注册资本
        /// </summary>
        public int RegisterCapitalId { get; set; }

        /// <summary>
        /// 结款方式
        /// </summary>
        public int PaymentTypeId { get; set; }

        /// <summary>
        /// 成立日期
        /// </summary>
        public DateTime FoundDate { get; set; }

        /// <summary>
        /// 传真
        /// </summary>
        public string Fax { get; set; }

        /// <summary>
        /// 公司logo
        /// </summary>
        public string Logo { get; set; }

        /// <summary>
        /// 开户行
        /// </summary>
        public string OpenBack { get; set; }

        /// <summary>
        /// 卡号
        /// </summary>
        public string BackCardNumber { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }


        #region relationship

        /// <summary>
        /// 公司性质
        /// </summary>
        public virtual ItemValue CompanyTypes { get; set; }

        /// <summary>
        /// 注册资本
        /// </summary>
        public virtual ItemValue RegisterCapitals { get; set; }

        /// <summary>
        /// 结款方式
        /// </summary>
        public virtual ItemValue PaymentTypes { get; set; }

        /// <summary>
        /// 供应商等级
        /// </summary>
        public virtual ItemValue SupplierGrades { get; set; }

        /// <summary>
        /// 供应商联系人信息
        /// </summary>
        public virtual ICollection<SupplierContact> SupplierContacts { get; set; }

        /// <summary>
        /// 供应商询单记录
        /// </summary>
        public virtual ICollection<EnquirySupplier> EnquirySuppliers { get; set; }

        /// <summary>
        /// 供应商采购合同
        /// </summary>
        public virtual ICollection<PurchaseContract> PurchaseContracts { get; set; }

        /// <summary>
        /// 供应商地址
        /// </summary>
        public virtual SystemRegion SystemRegion { get; set; }
        #endregion

    }
}
