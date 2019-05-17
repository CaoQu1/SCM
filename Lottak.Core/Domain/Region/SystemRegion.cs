using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottak.Core.Region
{
    /// <summary>
    /// 系统区域
    /// </summary>
    [Table("SystemRegions")]
    public class SystemRegion : BaseEntity
    {
        /// <summary>
        /// 区域名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 完全区域编号
        /// </summary>
        public string FullId { get; set; }

        /// <summary>
        /// 完全区域名称
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 父编号
        /// </summary>
        public int? ParentId { get; set; }

        /// <summary>
        /// 层级
        /// </summary>
        public int Depth { get; set; }

        /// <summary>
        /// 是否有子区域
        /// </summary>
        public bool HasChild { get; set; }

        #region notmapped
        [NotMapped]
        public override Guid CreateBy { get; set; }
        public override Guid? UpdateBy { get; set; }
        #endregion
    }
}
