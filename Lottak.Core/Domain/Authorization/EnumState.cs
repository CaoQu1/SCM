using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottak.Core.Authorization
{
    /// <summary>
    /// 状态枚举
    /// </summary>
    public enum EnumStatus
    {
        /// <summary>
        /// 启用
        /// </summary>
        [Description("启用")]
        Normal = 0,

        /// <summary>
        /// 禁用
        /// </summary>
        [Description("禁用")]
        Disable = 1
    }

    /// <summary>
    /// 性别枚举
    /// </summary>
    public enum EnumSex
    {
        /// <summary>
        /// 男
        /// </summary>
        [Description("男")]
        Man = 0,

        /// <summary>
        /// 女
        /// </summary>
        [Description("女")]
        Woman = 1,

        /// <summary>
        /// 未知
        /// </summary>
        [Description("未知")]
        UnKown = 2
    }

    /// <summary>
    /// 加密方式
    /// </summary>
    public enum EnumPasswordFormat : int
    {
        /// <summary>
        /// 明文
        /// </summary>
        [Description("明文")]
        Clear = 0,
        /// <summary>
        /// Hash 加密
        /// </summary>
        [Description("Hash 加密")]
        Hashed = 1,
        /// <summary>
        /// 密钥 Hash 加密
        /// </summary>
        [Description("密钥 Hash 加密")]
        Encrypted = 2,
        /// <summary>
        /// MD5 加密
        /// </summary>
        [Description("MD5 加密")]
        MD5 = 3
    }
}
