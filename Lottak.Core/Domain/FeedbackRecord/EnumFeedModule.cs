using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottak.Core.FeedbackRecord
{
    /// <summary>
    /// 反馈模块
    /// </summary>
    public enum EnumFeedModule
    {
        /// <summary>
        /// 询单
        /// </summary>
        [Description("询单")]
        Enquiry = 0,

        /// <summary>
        /// 采购
        /// </summary>
        [Description("采购")]
        Purchase = 1,

        /// <summary>
        /// 确认
        /// </summary>
        [Description("确认")]
        Confirm = 2,

        /// <summary>
        /// 其他
        /// </summary>
        [Description("其他")]
        Other = 3
    }
}
