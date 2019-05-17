using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lottak.SCM.Models
{
    /// <summary>
    /// 登录模型
    /// </summary>
    public class LoginModel
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        public string UserNOorEmail { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string PassWord { get; set; }

        /// <summary>
        /// 是否记住
        /// </summary>
        public bool IsRemember { get; set; }
    }
}