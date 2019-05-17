using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottak.Core.Common
{
    /// <summary>
    /// 操作结果
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class OpreateResult<T>
    {
        /// <summary>
        /// 错误列表
        /// </summary>
        public IList<string> Errors { get; set; }

        public OpreateResult()
        {
            this.Errors = new List<string>();
        }

        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Success
        {
            get { return (this.Errors.Count == 0); }
        }

        /// <summary>
        /// 返回成功消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 添加错误信息
        /// </summary>
        /// <param name="error"></param>
        public void AddError(string error)
        {
            this.Errors.Add(error);
        }

        /// <summary>
        /// 添加错误信息
        /// </summary>
        /// <param name="ex"></param>
        public void AddError(Exception ex)
        {
            this.Errors.Add(ex.Message);
        }

        /// <summary>
        /// 返回结果实体
        /// </summary>
        public T Data { get; set; }
    }
}
