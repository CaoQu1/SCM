using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottak.Core.ApplicationForm
{
    /// <summary>
    /// 入库单信息表
    /// </summary>
    [Table("WarehousAppForms")]
    public class WarehousAppForm : ApplicationForm
    {
        /// <summary>
        /// 入库状态
        /// </summary>
        public EnumWarehousStatus Status { get; set; }
    }
}
