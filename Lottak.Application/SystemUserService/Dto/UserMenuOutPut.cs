using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottak.Application.Dto
{
    /// <summary>
    /// 用户菜单信息
    /// </summary>
    public class UserMenuOutPut
    {
        /// <summary>
        /// guid
        /// </summary>
        public Guid UserGuid { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 公司guid
        /// </summary>
        public Guid EmpGuid { get; set; }

        /// <summary>
        /// 公司编号
        /// </summary>
        public int CompanyNo { get; set; }

        /// <summary>
        /// 菜单信息
        /// </summary>
        public List<MenuOutPut> MenuOutPuts { get; set; }

        public UserMenuOutPut()
        {
            this.MenuOutPuts = new List<MenuOutPut>();
        }
    }

    /// <summary>
    /// 菜单信息
    /// </summary>
    public class MenuOutPut
    {
        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// 路径
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 菜单编号
        /// </summary>
        public int MenuId { get; set; }

        /// <summary>
        /// 操作信息
        /// </summary>
        public List<ActionOutput> ActionOutputs { get; set; }
    }

    /// <summary>
    /// 操作信息
    /// </summary>
    public class ActionOutput
    {
        /// <summary>
        /// 路径
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
    }
}
