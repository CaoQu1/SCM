using Lottak.Core.Authorization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottak.Core.Item
{
    /// <summary>
    /// 字典键信息表
    /// </summary>
    [Table("Items")]
    public class Item : BaseEntity
    {
        /// <summary>
        /// 键名称
        /// </summary>
        public string ItemName { get; set; }

        /// <summary>
        /// 显示名称
        /// </summary>
        public string DispalyName { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int SortId { get; set; }

        /// <summary>
        /// 是否是系统内置键
        /// </summary>
        public bool IsSystem { get; set; }

        /// <summary>
        /// 父键值
        /// </summary>
        public int? ParentId { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public EnumStatus Status { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDeleted { get; set; }

        #region relationship

        /// <summary>
        /// 键值信息
        /// </summary>
        public virtual ICollection<ItemValue> ItemValues { get; set; }

        /// <summary>
        /// 父键值
        /// </summary>
        public virtual Item Parent { get; set; }

        /// <summary>
        /// 子键值
        /// </summary>
        public virtual ICollection<Item> Childrens { get; set; }

        #endregion
    }
}
