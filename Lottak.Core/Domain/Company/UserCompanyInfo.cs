using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottak.Core.Company
{
    /// <summary>
    /// 用户公司信息
    /// </summary>
    [Serializable]
    public class UserCompanyInfo
    {
        public UserCompanyInfo()
        {
            this.Companies = new List<Company>();
        }
        /// <summary>
        /// 用户编号
        /// </summary>
        public Guid UserGuid { get; set; }

        /// <summary>
        /// 所属公司
        /// </summary>

        public IList<Company> Companies { get; set; }

        /// <summary>
        /// 当前选中的公司
        /// </summary>
        public Company SeletedCompany { get; set; }

        /// <summary>
        /// 当前选中的公司员工信息
        /// </summary>
        public CompanyEmployee SelectedEmployeeInfo { get; set; }
    }
}
