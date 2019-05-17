using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottak.Core.Company
{
    /// <summary>
    /// 公司信息表
    /// </summary>
    [Table("Companys")]
    public class Company : BaseEntity
    {
        /// <summary>
        /// 公司编号
        /// </summary>
        [DisplayName("公司编号")]
        [Required(ErrorMessage = "请选择{0}")]
        public int CompanyNo { get; set; }

        /// <summary>
        /// 同步公司编号
        /// </summary>
        public Nullable<int> FromCompanyNo { get; set; }

        /// <summary>
        /// 公司域名
        /// </summary>
        [DisplayName("公司域名")]
        [StringLength(256, ErrorMessage = "{0}不能超过{1}个字符")]
        public string Domain { get; set; }

        /// <summary>
        /// 公司简称
        /// </summary>
        [DisplayName("公司简称")]
        [StringLength(20, ErrorMessage = "{0}不能超过{1}个字符")]
        public string Abbreviation { get; set; }

        /// <summary>
        /// 公司名称
        /// </summary>
        [DisplayName("公司名称")]
        [Required(ErrorMessage = "{0}必须填写")]
        [RegularExpression(@"^((?!_)(?!.*?_$)[a-zA-Z0-9_\u4e00-\u9fa5]{2,20})$", ErrorMessage = "{0}为2-20位字符,包含汉字、数字、字母和下划线")]
        public string CompanyName { get; set; }

        /// <summary>
        /// 地址编码
        /// </summary>
        public Nullable<Guid> AddressId { get; set; }

        /// <summary>
        /// 详细地址
        /// </summary>
        [DisplayName("详细地址")]
        [StringLength(256, ErrorMessage = "{0}不能超过{1}个字符")]
        public string Address { get; set; }

        /// <summary>
        /// 公司头像
        /// </summary>
        [DisplayName("公司头像")]
        public string Logo { get; set; }

        /// <summary>
        /// 公司类型
        /// </summary>
        [DisplayName("公司类型")]
        public EnumCompanyType CompanyType { get; set; }

        /// <summary>
        /// 公司电话
        /// </summary>
        [DisplayName("公司电话")]
        [StringLength(20, ErrorMessage = "{0}不能超过{1}个字符")]
        public string Phone { get; set; }

        /// <summary>
        /// 传真
        /// </summary>
        [DisplayName("传真")]
        [StringLength(20, ErrorMessage = "{0}不能超过{1}个字符")]
        public string Fax { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [DisplayName("邮箱")]
        [StringLength(30, ErrorMessage = "{0}不能超过{1}个字符")]
        public string Email { get; set; }

        /// <summary>
        /// QQ
        /// </summary>
        [DisplayName("QQ")]
        [StringLength(15, ErrorMessage = "{0}不能超过{1}个字符")]
        public string QQ { get; set; }

        /// <summary>
        /// 微信
        /// </summary>
        [DisplayName("微信")]
        [StringLength(30, ErrorMessage = "{0}不能超过{1}个字符")]
        public string Weixin { get; set; }

        /// <summary>
        /// 主页
        /// </summary>
        [DisplayName("主页")]
        [StringLength(256, ErrorMessage = "{0}不能超过{1}个字符")]
        public string Homepage { get; set; }

        /// <summary>
        /// 是否已激活
        /// </summary>
        [DisplayName("是否已激活")]
        public bool IsActive { get; set; }

        /// <summary>
        /// 是否已删除
        /// </summary>
        [DisplayName("是否已删除")]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 公司拥有人编号
        /// </summary>
        [DisplayName("圈子拥有人编号")]
        public Guid OwnerUserGuid { get; set; }

        /// <summary>
        /// 公司拥有人用户编号
        /// </summary>
        [DisplayName("公司拥有人用户编号")]
        public int OwnerUserNo { get; set; }

        /// <summary>
        /// 公司描述
        /// </summary>
        [DisplayName("公司描述")]
        [StringLength(200, ErrorMessage = "{0}不能超过{1}个字符")]
        public string Abstract { get; set; }
    }
}
