using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottak.Core.Company
{
    /// <summary>
    /// 公司性质
    /// </summary>
    public enum EnumCompanyType
    {
        /// <summary>
        /// 国有企业
        /// </summary>
        [Description("国有企业")]
        StateOwned = 1,
        /// <summary>
        /// 私有企业
        /// </summary>
        [Description("私有企业")]
        Private = 2,
        /// <summary>
        /// 事业单位或社会团体
        /// </summary>
        [Description("事业单位或社会团体")]
        NonProfitOrg = 3,
        /// <summary>
        /// 中外合资
        /// </summary>
        [Description("中外合资")]
        SinoForeignJoint = 4,
        /// <summary>
        /// 外商独资
        /// </summary>
        [Description("外商独资")]
        ForeignOwned = 5,
        /// <summary>
        /// 其他
        /// </summary>
        [Description("其他")]
        Other = 6,
    }

    /// <summary>
    /// 员工状态
    /// </summary>
    public enum EnumCompanyEmployeeStatus
    {
        /// <summary>
        /// 待审核
        /// </summary>
        [Description("待审核")]
        Pending = 0,
        /// <summary>
        /// 在职
        /// </summary>
        [Description("在职")]
        Active = 1,
        /// <summary>
        /// 离职
        /// </summary>
        [Description("离职")]
        Leaved = 2,
        /// <summary>
        /// 已拒绝
        /// </summary>
        [Description("已拒绝")]
        Reject = 3,
        /// <summary>
        /// 申请离职
        /// </summary>
        [Description("申请离职")]
        Leaving = 4,
        /// <summary>
        /// 不存在
        /// </summary>
        [Description("不存在")]
        NotExist = 5
    }
}
