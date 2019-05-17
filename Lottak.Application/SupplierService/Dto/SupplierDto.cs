using Abp.Application.Services.Dto;
using Lottak.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottak.Application.Dto
{
    /// <summary>
    /// 供应商模型
    /// </summary>
    public class SupplierDto : EntityDto
    {
        /// <summary>
        ///  公司名称
        /// </summary>
        [DisplayName("公司名称")]
        [Required(ErrorMessage = "请填写{0}")]
        public string Name { get; set; }

        /// <summary>
        /// 公司电话
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 公司logo
        /// </summary>
        public string Logo { get; set; }

        /// <summary>
        /// 国家
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// 省
        /// </summary>
        public string Province { get; set; }

        /// <summary>
        /// 市
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 区
        /// </summary>
        public string Area { get; set; }

        /// <summary>
        /// 评级
        /// </summary>
        public KeyValue Grade { get; set; }

        /// <summary>
        /// 分类
        /// </summary>
        [DisplayName("分类")]
        [Required(ErrorMessage = "请选择{0}")]
        public KeyValue Type { get; set; }

        /// <summary>
        /// 公司性质
        /// </summary>
        [DisplayName("公司性质")]
        [Required(ErrorMessage = "请选择{0}")]
        public KeyValue Nature { get; set; }

        /// <summary>
        /// 付款方式
        /// </summary>
        [DisplayName("付款方式")]
        [Required(ErrorMessage = "请选择{0}")]
        public KeyValue PaymentMethod { get; set; }

        /// <summary>
        /// 站点
        /// </summary>
        public string WebSite { get; set; }

        /// <summary>
        /// 主营业务
        /// </summary>
        public string Business { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 是否是内部供应商
        /// </summary>
        [DisplayName("是否是内部供应商")]
        [Required(ErrorMessage = "请选择{0}")]
        public bool InternalSupplier { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public string CreateTimeUtcFmt { get; set; }

        /// <summary>
        /// 编辑时间
        /// </summary>
        public string UpdateTimeUtcFmt { get; set; }
    }

    /// <summary>
    /// 供应商详情模型
    /// </summary>
    public class SupplierDetailDto : SupplierDto
    {
        /// <summary>
        /// 详细地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 开户银行
        /// </summary>
        public string Bank { get; set; }

        /// <summary>
        /// 注册资金
        /// </summary>
        [DisplayName("注册资金")]
        [Required(ErrorMessage = "请选择{0}")]
        public KeyValue RegisteredCapital { get; set; }

        /// <summary>
        /// 成立日期
        /// </summary>
        public string EstablishmentDate { get; set; }

        /// <summary>
        /// 传真
        /// </summary>
        public string Fax { get; set; }

        /// <summary>
        /// 银行账户
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 开户行
        /// </summary>
        public string BankOfDeposit { get; set; }

        /// <summary>
        /// 操作人
        /// </summary>
        public string Operator { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        public ICollection<SupplierContactsDto> Contacts { get; set; }

        /// <summary>
        /// 主营业务
        /// </summary>
        public new string[] Business { get; set; }
    }

    /// <summary>
    /// 供应商联系人模型
    /// </summary>
    public class SupplierContactsDto : EntityDto
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// 微信
        /// </summary>
        public string WeChat { get; set; }

        /// <summary>
        /// QQ
        /// </summary>
        public string QQ { get; set; }
    }
}
