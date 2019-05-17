using Lottak.Application.Dto;
using Lottak.Core.ApplicationForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottak.Application.IService
{
    /// <summary>
    /// 询单服务接口
    /// </summary>
    public interface IEnquiryAppFormService : ICrudAppServiceExtension<EnquiryAppForm, EnquiryAppFormDto>
    {

    }
}
