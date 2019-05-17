using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using AutoMapper;
using Lottak.Core.Authorization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Lottak.Core
{
    /// <summary>
    /// 实体基类
    /// </summary>
    [Serializable]
    [DataContract]
    public abstract partial class BaseEntity : IEntity<int>
    {
        /// <summary>
        /// Gets or sets the entity identifier
        /// </summary>
        [DisplayName("唯一标识")]
        [DataMember]
        public virtual int Id { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [IgnoreMap]
        [DisplayName("创建时间")]
        [DataMember]
        public virtual DateTime CreateOnUtc { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        [IgnoreMap]
        [DisplayName("创建人")]
        [DataMember]
        public virtual Guid CreateBy { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        [IgnoreMap]
        [DisplayName("更新时间")]
        [DataMember]
        public virtual Nullable<DateTime> UpdateOnUtc { get; set; }
        /// <summary>
        /// 更新人
        /// </summary>
        [IgnoreMap]
        [DisplayName("更新人")]
        [DataMember]
        public virtual Nullable<Guid> UpdateBy { get; set; }


        public override bool Equals(object obj)
        {
            return Equals(obj as BaseEntity);
        }

        private static bool IsTransient(BaseEntity obj)
        {
            return obj != null && Equals(obj.Id, default(int));
        }

        private Type GetUnproxiedType()
        {
            return GetType();
        }

        public virtual bool Equals(BaseEntity other)
        {
            if (other == null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (!IsTransient(this) &&
                !IsTransient(other) &&
                Equals(Id, other.Id))
            {
                var otherType = other.GetUnproxiedType();
                var thisType = GetUnproxiedType();
                return thisType.IsAssignableFrom(otherType) ||
                        otherType.IsAssignableFrom(thisType);
            }

            return false;
        }

        public override int GetHashCode()
        {
            if (Equals(Id, default(int)))
                return base.GetHashCode();
            return Id.GetHashCode();
        }

        public bool IsTransient()
        {
            throw new NotImplementedException();
        }

        public static bool operator ==(BaseEntity x, BaseEntity y)
        {
            return Equals(x, y);
        }

        public static bool operator !=(BaseEntity x, BaseEntity y)
        {
            return !(x == y);
        }

    }
}
