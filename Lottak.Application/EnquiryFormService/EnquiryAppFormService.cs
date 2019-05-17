using Lottak.Application.Dto;
using Lottak.Application.IService;
using Lottak.Core;
using Lottak.Core.ApplicationForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottak.Application.Service
{
    /// <summary>
    /// 询单服务
    /// </summary>
    public class EnquiryAppFormService : CrudAppServiceBase<EnquiryAppForm, EnquiryAppFormDto>, IEnquiryAppFormService
    {
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="repository"></param>
        public EnquiryAppFormService(IRepositoryExtesion<EnquiryAppForm> repository) : base(repository)
        {
        }
    }
}
