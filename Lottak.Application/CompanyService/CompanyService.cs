using Abp.Application.Services;
using Abp.Domain.Repositories;
using Lottak.Application.Dto;
using Lottak.Application.IService;
using Lottak.Core;
using Lottak.Core.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottak.Application.Service
{
    /// <summary>
    /// 公司服务
    /// </summary>
    public class CompanyService : CrudAppServiceBase<Company, CompanyDto>, ICompanyService
    {
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="repository"></param>
        public CompanyService(IRepositoryExtesion<Company> repository) : base(repository)
        {
        }
    }
}
