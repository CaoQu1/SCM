using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottak.Core.Common
{
    /// <summary>
    /// 常量配置
    /// </summary>
    public class CommonConst
    {
        #region Cache
        /// <summary>
        /// 用户角色缓存关键字
        /// <remarks>参数：{0}=>公司编号；{1}=>用户唯一标志；{2}=>用户状态</remarks>
        /// </summary>
        public const string CACHE_USER_ROLES = "SYSTEM_USER_ROLES_{0}_{1}_{2}";

        /// <summary>
        /// Menu权限缓存关键字
        /// 参数：{0}=>公司编号；{1}=>用户唯一标志；{2}=>Front:[all|front]
        /// </summary>
        public const string CACHE_MENU_PERMISSION = "MENU_PERMISSION_{0}_{1}_{2}";
        /// <summary>
        /// Menu-Role权限缓存关键字
        /// 参数：{0}=>公司编号；{1}=>用户唯一标志；
        /// </summary>
        public const string CACHE_MENU_PERMISSION_ROLE = "MENU_PERMISSION_ROLE_{0}_{1}";

        /// <summary>
        /// Action权限缓存关键字
        /// <remarks>参数：{0}=>公司编号；{1}=>用户唯一标志；</remarks>
        /// </summary>
        public const string CACHE_ACTION_PERMISSION = "ACTION_PERMISSION_{0}_{1}";
        /// <summary>
        /// Action-Role权限缓存关键字
        /// <remarks>参数：{0}=>公司编号；{1}=>用户唯一标志；</remarks>
        /// </summary>
        public const string CACHE_ACTION_PERMISSION_ROLE = "ACTION_PERMISSION_ROIE_{0}_{1}";

        /// <summary>
        /// <remarks>参数：{0}=>公司编号；{1}=>部门编号；</remarks>
        /// </summary>
        public const string CACHE_DPT_MEMBERS = "DPT_MEMBERS_{0}_{1}";

        /// <summary>
        /// <remarks>参数：{0}=>公司编号；{1}=>用户唯一标志；{2}=>Front:[all|front]</remarks>
        /// </summary>
        public const string CACHE_MENU_DATA_BUILDER = "MENU_DATA_BUILDER_{0}_{1}_{2}";

        /// <summary>
        /// 用户cookie关键字
        /// </summary>
        public const string COOKIE_USER_NAME = "LOTTAK.SCM";

        /// <summary>
        /// 系统缓存关键字
        /// </summary>
        public const string LOTTAK_SYSTEM_CACHE = "LOTTAK.SYSTEM.CACHE";
        #endregion

        #region Config

        /// <summary>
        /// 数据库连接字符串键
        /// </summary>
        public const string LOTTAKCONN = "Lottak";
        #endregion
    }
}
