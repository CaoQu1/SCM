using Abp.Application.Navigation;
using Abp.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lottak.SCM.App_Start
{
    public class LottakSCMNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
              .AddItem(
                  new MenuItemDefinition(
                      PermissionNames.Supplier,
                      L("HomePage"),
                      url: "",
                      icon: "home",
                      requiresAuthentication: true
                  )
              ).AddItem(
                  new MenuItemDefinition(
                     PermissionNames.Supplier,
                      L("Tenants"),
                      url: "Tenants",
                      icon: "business",
                      requiredPermissionName: PermissionNames.Supplier_Index
                  )
              ).AddItem(
                  new MenuItemDefinition(
                      PermissionNames.Supplier,
                      L("Users"),
                      url: "Users",
                      icon: "people",
                      requiredPermissionName: PermissionNames.Supplier_Index
                  )
              ).AddItem(
                  new MenuItemDefinition(
                     PermissionNames.Supplier,
                      L("Roles"),
                      url: "Roles",
                      icon: "local_offer",
                      requiredPermissionName: PermissionNames.Supplier_Index
                  )
              )
              .AddItem(
                  new MenuItemDefinition(
                     PermissionNames.Supplier,
                      L("用户详情"),
                      url: "UserInfo",
                      icon: "people",
                      requiredPermissionName: PermissionNames.Supplier_Index
                  )
              )
             .AddItem(
                  new MenuItemDefinition(
                      PermissionNames.Supplier,
                      L("后台工作者"),
                      url: "hangfire",
                      icon: "people",
                      requiredPermissionName: PermissionNames.Supplier_Index
                  )
              )
               .AddItem(
                  new MenuItemDefinition(
                    PermissionNames.Supplier,
                      L("swaggerAPI文档"),
                      url: "/swagger/ui/index",
                      icon: "people",
                      requiredPermissionName: PermissionNames.Supplier_Index
                  )
              )
              .AddItem(
                  new MenuItemDefinition(
                     PermissionNames.Supplier,
                      L("About"),
                      url: "About",
                      icon: "info"
                  )
              ).AddItem( //Menu items below is just for demonstration!
                  new MenuItemDefinition(
                      "MultiLevelMenu",
                      L("MultiLevelMenu"),
                      icon: "menu"
                  ).AddItem(
                      new MenuItemDefinition(
                          "AspNetBoilerplate",
                          new FixedLocalizableString("ASP.NET Boilerplate")
                      ).AddItem(
                          new MenuItemDefinition(
                              "AspNetBoilerplateHome",
                              new FixedLocalizableString("Home"),
                              url: "https://aspnetboilerplate.com?ref=abptmpl"
                          )
                      ).AddItem(
                          new MenuItemDefinition(
                              "AspNetBoilerplateTemplates",
                              new FixedLocalizableString("Templates"),
                              url: "https://aspnetboilerplate.com/Templates?ref=abptmpl"
                          )
                      ).AddItem(
                          new MenuItemDefinition(
                              "AspNetBoilerplateSamples",
                              new FixedLocalizableString("Samples"),
                              url: "https://aspnetboilerplate.com/Samples?ref=abptmpl"
                          )
                      ).AddItem(
                          new MenuItemDefinition(
                              "AspNetBoilerplateDocuments",
                              new FixedLocalizableString("Documents"),
                              url: "https://aspnetboilerplate.com/Pages/Documents?ref=abptmpl"
                          )
                      )
                  ).AddItem(
                      new MenuItemDefinition(
                          "AspNetZero",
                          new FixedLocalizableString("ASP.NET Zero")
                      ).AddItem(
                          new MenuItemDefinition(
                              "AspNetZeroHome",
                              new FixedLocalizableString("Home"),
                              url: "https://aspnetzero.com?ref=abptmpl"
                          )
                      ).AddItem(
                          new MenuItemDefinition(
                              "AspNetZeroDescription",
                              new FixedLocalizableString("Description"),
                              url: "https://aspnetzero.com/?ref=abptmpl#description"
                          )
                      ).AddItem(
                          new MenuItemDefinition(
                              "AspNetZeroFeatures",
                              new FixedLocalizableString("Features"),
                              url: "https://aspnetzero.com/?ref=abptmpl#features"
                          )
                      ).AddItem(
                          new MenuItemDefinition(
                              "AspNetZeroPricing",
                              new FixedLocalizableString("Pricing"),
                              url: "https://aspnetzero.com/?ref=abptmpl#pricing"
                          )
                      ).AddItem(
                          new MenuItemDefinition(
                              "AspNetZeroFaq",
                              new FixedLocalizableString("Faq"),
                              url: "https://aspnetzero.com/Faq?ref=abptmpl"
                          )
                      ).AddItem(
                          new MenuItemDefinition(
                              "AspNetZeroDocuments",
                              new FixedLocalizableString("Documents"),
                              url: "https://aspnetzero.com/Documents?ref=abptmpl"
                          )
                      )
                  )
              );
        }
        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, "LottakSCM");
        }
    }
}