using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Lottak.Application;
using Lottak.Application.Dto;
using Lottak.Core.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottak.Application.IService
{
    /// <summary>
    /// 公司服务接口
    /// </summary>
    public interface ICompanyService : ICrudAppServiceExtension<Company, CompanyDto>
    {

    }
}
