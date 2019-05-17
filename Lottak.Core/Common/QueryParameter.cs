using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottak.Core.Common
{
    /// <summary>
    /// 查询公共参数
    /// </summary>
    public class QueryParameter
    {
        /// <summary>
        /// 页码
        /// </summary>
        public int pageIndex { get; set; } = 1;

        /// <summary>
        /// 每页的条数
        /// </summary>
        public int pageSize { get; set; } = 10;

        /// <summary>
        /// 关键字
        /// </summary>
        public string keyWord { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public string Sort { get; set; }
    }
}
