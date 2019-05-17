using Abp.Domain.Repositories;
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
    /// 公司员工服务
    /// </summary>
    public class CompanyEmployeeService : AppServiceBase<CompanyEmployee>, ICompanyEmployeeService
    {
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="repository"></param>
        public CompanyEmployeeService(IRepositoryExtesion<CompanyEmployee> repository) : base(repository) { }
    }
}
