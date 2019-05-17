using Lottak.Core.Authorization;
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
    /// 公司员工信息表
    /// </summary>
    [Serializable]
    [Table("CompanyEmployees")]
    public partial class CompanyEmployee : BaseEntity
    {
        /// <summary>
        /// 公司编号
        /// </summary>
        [DisplayName("公司编号")]
        public int CompanyNo { get; set; }

        /// <summary>
        /// 员工编号
        /// </summary>
        [DisplayName("员工编号")]
        public Guid EmployeeGuid { get; set; }

        /// <summary>
        /// 映射的员工编号
        /// </summary>
        public Nullable<Guid> FromEmpGuid { get; set; }

        /// <summary>
        /// 真实名字
        /// </summary>
        [DisplayName("真实名字")]
        [StringLength(20, ErrorMessage = "{0}不得超过{1}个字符")]
        public string RealName { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        [DisplayName("昵称")]
        [StringLength(20, ErrorMessage = "{0}不得超过{1}个字符")]
        public string NickName { get; set; }

        /// <summary>
        /// 备注名称
        /// </summary>
        [DisplayName("备注名称")]
        [StringLength(20, ErrorMessage = "{0}不得超过{1}个字符")]
        public string RemarkName { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        [DisplayName("性别")]
        [Required(ErrorMessage = "请选择{0}")]
        public EnumSex Sex { get; set; }

        /// <summary>
        /// 用户唯一标识
        /// </summary>
        [DisplayName("用户唯一标识")]
        public Guid UserGuid { get; set; }
        /// <summary>
        /// 映射的用户标识
        /// </summary>
        public Nullable<Guid> FromUserGuid { get; set; }
        /// <summary>
        /// 映射的用户编号
        /// </summary>
        public Nullable<int> FromUserNo { get; set; }
        /// <summary>
        /// 用户编号
        /// </summary>
        [DisplayName("用户编号")]
        public int UserNo { get; set; }

        /// <summary>
        /// 邮箱地址
        /// </summary>
        [DisplayName("邮箱地址")]
        [StringLength(30, ErrorMessage = "{0}不得超过{1}个字符")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "{0}格式错误")]
        public string Email { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        [DisplayName("联系电话")]
        [StringLength(20, ErrorMessage = "{0}不得超过{1}个字符")]
        public string Phone { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        [DisplayName("手机号码")]
        [StringLength(20, ErrorMessage = "{0}不得超过{1}个字符")]
        public string Mobile { get; set; }

        /// <summary>
        /// QQ
        /// </summary>
        [DisplayName("QQ")]
        [StringLength(20, ErrorMessage = "{0}不得超过{1}个字符")]
        public string QQ { get; set; }

        /// <summary>
        /// 微信
        /// </summary>
        [DisplayName("微信")]
        [StringLength(30, ErrorMessage = "{0}不得超过{1}个字符")]
        public string Weixin { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [DisplayName("状态")]
        public EnumCompanyEmployeeStatus Status { get; set; }

        /// <summary>
        /// 加入理由
        /// </summary>
        [DisplayName("加入理由")]
        [StringLength(200, ErrorMessage = "{0}不得超过{1}个字符")]
        public string JoinReason { get; set; }

        /// <summary>
        /// 离开理由
        /// </summary>
        [DisplayName("离开理由")]
        [StringLength(200, ErrorMessage = "{0}不得超过{1}个字符")]
        public string LeaveReason { get; set; }

        /// <summary>
        /// 同意或拒绝原因
        /// </summary>
        [DisplayName("批注")]
        [StringLength(200, ErrorMessage = "{0}不得超过{1}个字符")]
        public string Reason { get; set; }

        /// <summary>
        /// 是否已删除
        /// </summary>
        [DisplayName("已删除")]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 是否是公司管理员
        /// </summary>
        [DisplayName("是否是公司管理员")]
        public bool IsAdmin { get; set; }
    }
}
