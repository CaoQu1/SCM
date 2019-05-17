using Lottak.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lottak.Core.Extension
{
    /// <summary>
    /// 枚举扩展
    /// </summary>
    public static class EnumExtension
    {
        /// <summary>
        /// 获取枚举描述
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToDescription(this Enum value)
        {
            var descriptionAttributes = value.GetType().GetCustomAttributes(typeof(DescriptionAttribute), false);
            return descriptionAttributes != null && descriptionAttributes.Any() ? (descriptionAttributes.First() as DescriptionAttribute).Description : "";
        }

        /// <summary>
        /// 返回key=>value对象
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static KeyValue ToKeyValue(this Enum value) => new KeyValue { Name = ToDescription(value), Id = (int)Enum.Parse(value.GetType(), value.ToString()) };

    }
}
