using Abp.Domain.Repositories;
using Lottak.Application.Dto;
using Lottak.Application.IService;
using Lottak.Core;
using Lottak.Core.Suppliers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottak.Application.Service
{
    /// <summary>
    /// 供应商服务
    /// </summary>
    public class SupplierService : CrudAppServiceBase<Supplier, SupplierDto>, ISupplierService
    {
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="repository"></param>
        public SupplierService(IRepositoryExtesion<Supplier> repository) : base(repository) { }
    }
}
