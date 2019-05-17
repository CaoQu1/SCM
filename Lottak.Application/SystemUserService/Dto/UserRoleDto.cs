using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Lottak.Core.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottak.Application.Dto
{
    /// <summary>
    /// 用户角色
    /// </summary>
    [AutoMap(typeof(SystemUserRole))]
    public class UserRoleDto : EntityDto
    {
        /// <summary>
        /// 公司编号
        /// </summary>
        public int CompanyNo { get; set; }

        /// <summary>
        /// 用户guid
        /// </summary>
        public Guid UserGuid { get; set; }

        /// <summary>
        /// 角色编号
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { get; set; }
    }
}
