using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottak.Core.ApplicationForm
{
    /// <summary>
    /// 表单类型
    /// </summary>
    public enum EnumFormType
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
        /// 入库
        /// </summary>
        [Description("入库")]
        Warehousing = 3
    }

    /// <summary>
    /// 表单人员角色
    /// </summary>
    public enum EnumFormUserRole
    {
        /// <summary>
        /// 协助
        /// </summary>
        [Description("协助")]
        Help = 0,

        /// <summary>
        /// 创建
        /// </summary>
        [Description("创建")]
        Create = 1,

        /// <summary>
        /// 处理
        /// </summary>
        [Description("处理")]
        Handler = 2
    }

    /// <summary>
    /// 表单状态
    /// </summary>
    public enum EnumFormStatus
    {
        /// <summary>
        /// 待处理
        /// </summary>
        [Description("待处理")]
        Pending = 0,

        /// <summary>
        /// 正在处理
        /// </summary>
        [Description("正在处理")]
        Processing = 1,

        /// <summary>
        /// 已完结
        /// </summary>
        [Description("已完结")]
        Completed = 2
    }

    /// <summary>
    /// 采购单类型
    /// </summary>
    public enum EnumPurchaseFormType
    {
        /// <summary>
        /// 物料
        /// </summary>
        [Description("物料")]
        Materiel = 0,

        /// <summary>
        /// 外协
        /// </summary>
        [Description("外协")]
        Coadjutant = 1
    }

    /// <summary>
    /// 采购单产品状态
    /// </summary>
    public enum EnumPurchaseProductStatus
    {
        /// <summary>
        /// 正常
        /// </summary>
        [Description("正常")]
        Normal = 0,

        /// <summary>
        /// 取消
        /// </summary>
        [Description("取消")]
        Cancel = 1,

        /// <summary>
        /// 新变更
        /// </summary>
        [Description("新变更")]
        New = 2,

        /// <summary>
        /// 锁定
        /// </summary>
        [Description("锁定")]
        Lock = 3
    }

    /// <summary>
    /// 采购单合同产品入库状态
    /// </summary>
    public enum EnumWarehousStatus
    {
        /// <summary>
        /// 待收货
        /// </summary>
        [Description("待收货")]
        BeReceive = 0,

        /// <summary>
        /// 待入库
        /// </summary>
        [Description("待入库")]
        PendingStorage = 1,

        /// <summary>
        /// 入库中
        /// </summary>
        [Description("入库中")]
        Warehousing = 2,

        /// <summary>
        /// 已入库
        /// </summary>
        [Description("已入库")]
        Warehoused = 3,
    }
}
