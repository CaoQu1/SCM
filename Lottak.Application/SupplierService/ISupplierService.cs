using Abp.Application.Services.Dto;
using Lottak.Application.Dto;
using Lottak.Core.Suppliers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottak.Application.IService
{
    /// <summary>
    /// 供应商服务
    /// </summary>
    public interface ISupplierService : ICrudAppServiceExtension<Supplier, SupplierDto>
    {

    }
}
