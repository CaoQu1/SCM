using Lottak.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lottak.Core.Common
{
    /// <summary>
    /// 返回结果模型
    /// </summary>
    public class ResultJson : ResultJson<object>
    {

    }

    /// <summary>
    /// 泛型结果模型
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResultJson<T>
    {
        /// <summary>
        /// 数据
        /// </summary>
        public T data { get; set; }

        ///// <summary>
        ///// 是否成功
        ///// </summary>
        //public bool success { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public string message { get; set; }

        /// <summary>
        /// code
        /// </summary>
        public EnumStatusCode code { get; set; }
    }

    /// <summary>
    /// 分页结果模型
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PageResultJson<T>
    {
        /// <summary>
        /// 总条数
        /// </summary>
        public int total { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        public List<T> items { get; set; }
    }
}