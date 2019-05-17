using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottak.Core.ApplicationForm
{
    /// <summary>
    /// 变更记录表
    /// </summary>
    [Table("ChangeRecords")]
    public class ChangeRecord : BaseEntity
    {
        /// <summary>
        /// 源表单编号
        /// </summary>
        public Nullable<Guid> OrginFormGuid { get; set; }

        /// <summary>
        /// 源产品Guid
        /// </summary>
        public Nullable<Guid> OrginProductGuid { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 操作人
        /// </summary>
        public string Operator { get; set; }

        [NotMapped]
        public override Guid CreateBy { get; set; }
    }
}
