using Lottak.Application.Dto;
using Lottak.Core.Suppliers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Lottak.Application
{
    /// <summary>
    /// 自定义值转换器
    /// </summary>
    public class SupplierContactsResolver : IValueResolver<Supplier, SupplierDetailDto, ICollection<SupplierContactsDto>>
    {
        /// <summary>
        /// 转换
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <param name="destMember"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public ICollection<SupplierContactsDto> Resolve(Supplier source, SupplierDetailDto destination, ICollection<SupplierContactsDto> destMember, ResolutionContext context)
        {
            if (source.SupplierContacts != null && source.SupplierContacts.Any())
            {
                destMember = Mapper.Map<ICollection<SupplierContactsDto>>(source.SupplierContacts);
            }
            return destMember;
        }
    }
}
