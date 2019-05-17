using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Lottak.Core.Authorization;
using Microsoft.AspNet.Identity;

namespace Lottak.Core.Authorization
{
    /// <summary>
    /// 系统用户信息表
    /// </summary>
    [Table("SystemUsers")]
    public class SystemUser : BaseEntity
    {
        /// <summary>
        /// 用户标识
        /// </summary>
        [DisplayName("用户标识")]
        public Guid UserGuid { get; set; }

        /// <summary>
        /// 映射的用户标识
        /// </summary>
        public Nullable<Guid> FromUserGuid { get; set; }

        /// <summary>
        /// 用户编号
        /// </summary>
        [DisplayName("用户编号")]
        public int UserNo { get; set; }

        /// <summary>
        /// 映射的用户编号
        /// </summary>
        public Nullable<int> FromUserNo { get; set; }

        /// <summary>
        /// 用户名称
        /// </summary>
        [DisplayName("用户名称")]
        public string UserName { get; set; }

        /// <summary>
        /// 真实名称
        /// </summary>
        [DisplayName("真实名称")]
        [StringLength(30, ErrorMessage = "{0}不得超过{1}个字符")]
        public string RealName { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        [DisplayName("性别")]
        public EnumSex Sex { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        [DisplayName("头像")]
        [StringLength(256, ErrorMessage = "{0}不得超过{1}个字符")]
        public string Avatar { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        [DisplayName("手机号码")]
        [StringLength(20, ErrorMessage = "{0}不得超过{1}个字符")]
        public string Mobile { get; set; }

        /// <summary>
        /// 邮箱地址
        /// </summary>
        [DisplayName("邮箱地址")]
        [StringLength(50, ErrorMessage = "{0}不得超过{1}个字符")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "{0}格式错误")]
        public string Email { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        public string PasswordFormat { get; set; }
        public int PasswordFormatId { get; set; }

        /// <summary>
        /// 密钥
        /// </summary>
        public string PasswordSalt { get; set; }

        /// <summary>
        /// 是否激活
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// 是否已删除
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 最后一次登录IP
        /// </summary>
        public string LatestIPAddress { get; set; }

        /// <summary>
        /// 上次登录时间
        /// </summary>
        public Nullable<DateTime> LatestLoginDateUtc { get; set; }
        /// <summary>
        /// 激活时间
        /// </summary>
        public Nullable<DateTime> LatestActivityDateUtc { get; set; }

        #region NotMapped

        [NotMapped]
        public override Guid CreateBy { get; set; }

        [NotMapped]
        public override Nullable<DateTime> UpdateOnUtc { get; set; }

        [NotMapped]
        public override Nullable<Guid> UpdateBy { get; set; }

        #endregion
    }
}
