using Abp.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lottak.SCM.App_Start
{
    public class LottakConfigProvider : SettingProvider
    {
        /// <summary>
        /// 定义配置文件值
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override IEnumerable<SettingDefinition> GetSettingDefinitions(SettingDefinitionProviderContext context)
        {
            return new SettingDefinition[] {


           };
        }
    }
}