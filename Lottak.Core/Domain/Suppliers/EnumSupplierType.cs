using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottak.Core.Suppliers
{
    /// <summary>
    /// 供应商分类
    /// </summary>
    public enum EnumSupplierType
    {
        /// <summary>
        /// 待定
        /// </summary>
        [Description("待定")]
        Undetermined = 0,

        /// <summary>
        /// 合格
        /// </summary>
        [Description("合格")]
        Qualified = 1,

        /// <summary>
        /// 不合格
        /// </summary>
        [Description("不合格")]
        Unqualified = 2
    }

    /// <summary>
    /// 供应商等级
    /// </summary>
    public enum EnumSupplierGrade
    {
        /// <summary>
        /// 一颗星
        /// </summary>
        [Description("一颗星")]
        OneStar,

        /// <summary>
        /// 二颗星
        /// </summary>
        [Description("二颗星")]
        TowStar,

        /// <summary>
        /// 三颗星
        /// </summary>
        [Description("三颗星")]
        ThreeStar,

        /// <summary>
        /// 四颗星
        /// </summary>
        [Description("四颗星")]
        FourStar,

        /// <summary>
        /// 五颗星
        /// </summary>
        [Description("五颗星")]
        FiveStar,
    }
}
