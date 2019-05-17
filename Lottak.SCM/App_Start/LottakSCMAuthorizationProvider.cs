using Abp.Authorization;
using Abp.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lottak.SCM.App_Start
{
    public class LottakSCMAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Supplier_Index, L(PermissionNames.Supplier), L(PermissionNames.Supplier))
                 .CreateChildPermission(PermissionNames.Supplier_Index, L(PermissionNames.Supplier), L(PermissionNames.Supplier));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, "LottakSCM");
        }
    }
}