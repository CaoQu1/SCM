using Lottak.Core.Authorization;
using Lottak.Core.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottak.Core
{
    public interface IWebContext
    {
        /// <summary>
        /// 当前登录用户
        /// </summary>
        SystemUser CurrentUser { get; set; }

        /// <summary>
        /// 当前用户公司信息
        /// </summary>
        UserCompanyInfo CurrentCompany { get; set; }
    }
}
