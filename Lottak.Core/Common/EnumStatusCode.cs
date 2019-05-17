using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottak.Core.Common
{
    /// <summary>
    /// 返回结果枚举
    /// </summary>
    public enum EnumStatusCode
    {
        /// <summary>
        /// OK
        /// </summary>
        [Description("OK")]
        OK = 0,
        /// <summary>
        /// 一般错误
        /// </summary>
        [Description("一般错误")]
        Normal = 900,
        /// <summary>
        /// 授权失败
        /// </summary>
        [Description("授权失败")]
        Unauthorized = 401,
        /// <summary>
        /// 找不到资源
        /// </summary>
        [Description("找不到资源")]
        NotFound = 404,
        /// <summary>
        /// 应用程序错误
        /// </summary>
        [Description("应用程序错误")]
        Application = 500,
        /// <summary>
        /// 未实现
        /// </summary>
        [Description("未实现")]
        NotImplemented = 501,
        /// <summary>
        /// 不支持
        /// </summary>
        [Description("不支持")]
        Unsupported = 415
    }
}
