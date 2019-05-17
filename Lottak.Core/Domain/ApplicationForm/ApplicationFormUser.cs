using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottak.Core.ApplicationForm
{
    /// <summary>
    /// 表单人员信息表
    /// </summary>
    public class ApplicationFormUser : BaseEntity
    {
        /// <summary>
        /// 员工编号
        /// </summary>
        public Guid EmpGuid { get; set; }

        /// <summary>
        /// 员工名称
        /// </summary>
        public string EmpName { get; set; }

        /// <summary>
        /// 员工角色
        /// </summary>
        public EnumFormUserRole EmpRole { get; set; }

        ///// <summary>
        ///// 表单编号
        ///// </summary>
        //public int ApplicationFormId { get; set; }

        //#region relationship
        ///// <summary>
        ///// 表单信息
        ///// </summary>
        //public virtual ApplicationForm ApplicationForm { get; set; }
        //#endregion
    }
}
