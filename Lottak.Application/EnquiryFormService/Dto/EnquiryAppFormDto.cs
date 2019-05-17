using Abp.Application.Services.Dto;
using Lottak.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottak.Application.Dto
{
    /// <summary>
    /// 询单模型
    /// </summary>
    public class EnquiryAppFormDto : EntityDto
    {
        /// <summary>
        /// 询单编号
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// 询单状态
        /// </summary>
        public KeyValue Status { get; set; }

        /// <summary>
        /// 申请人
        /// </summary>
        public string Applicant { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public string CreateDateTimeUtcFmt { get; set; }

        /// <summary>
        /// 完结时间
        /// </summary>
        public string FinishDateTimeUtcFmt { get; set; }

        /// <summary>
        /// 操作人
        /// </summary>
        public string Operator { get; set; }
    }
}
