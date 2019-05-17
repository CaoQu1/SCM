using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Extensions;
using Abp.Modules;
using Abp.Runtime.Caching.Redis;
using AutoMapper;
using Lottak.Application.Dto;
using Lottak.Core;
using Lottak.Core.ApplicationForm;
using Lottak.Core.Authorization;
using Lottak.Core.Common;
using Lottak.Core.Extension;
using Lottak.Core.Item;
using Lottak.Core.Suppliers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottak.Application
{
    [DependsOn(typeof(LottakCoreModule), typeof(AbpAutoMapperModule), typeof(AbpRedisCacheModule))]
    public class LottakApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            base.PreInitialize();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(LottakApplicationModule).Assembly);
            Configuration.Modules.AbpAutoMapper().Configurators.Add(cfg =>
            {
                cfg.CreateMap<DateTime, string>()
                .ConstructUsing((y) => y.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss"));

                cfg.CreateMap<ItemValue, KeyValue>()
                   .ForMember(d => d.Id, s =>
                {
                    s.Condition(x => x != null);
                    s.MapFrom(x => x.Id);
                })
                   .ForMember(d => d.Name, s =>
                {
                    s.Condition(x => x != null);
                    s.MapFrom(x => x.Value);
                });

                cfg.CreateMap<SupplierContact, SupplierContactsDto>()
                   .ForMember(d => d.Id, s => s.MapFrom(x => x.Id))
                   .ForMember(d => d.Name, s => s.MapFrom(x => x.ContactName))
                   .ForMember(d => d.Mobile, s => s.MapFrom(x => x.ContactPhone))
                   .ForMember(d => d.QQ, s => s.MapFrom(x => x.ContactQQ))
                   .ForMember(d => d.WeChat, s => s.MapFrom(x => x.ContactWeixin))
                   .ReverseMap();

                cfg.CreateMap<Supplier, SupplierDto>()
                   .ConstructUsing(s =>
                   {
                       var fullName = s.SystemRegion.FullName.Split(',');
                       return new SupplierDto
                       {
                           Name = s.SupplierName,
                           Phone = s.SupplierPhone,
                           Logo = s.Logo,
                           Country = fullName.Length > 0 ? fullName[0] : "",
                           Province = fullName.Length > 1 ? fullName[1] : "",
                           City = fullName.Length > 2 ? fullName[2] : "",
                           Area = fullName.Length > 3 ? fullName[3] : "",
                           Grade = Mapper.Map<KeyValue>(s.SupplierGrades),
                           Type = s.SupplierType.ToKeyValue(),
                           Nature = Mapper.Map<KeyValue>(s.CompanyTypes),
                           PaymentMethod = Mapper.Map<KeyValue>(s.PaymentTypes),
                           WebSite = s.WebSite,
                           Business = s.MainBusiness,
                           Remark = s.Description,
                           InternalSupplier = s.IsInternal,
                           CreateTimeUtcFmt = Mapper.Map<string>(s.CreateOnUtc),
                           UpdateTimeUtcFmt = s.UpdateOnUtc.HasValue ? Mapper.Map<string>(s.UpdateOnUtc.Value) : ""
                       };
                   })
                   .Include<Supplier, SupplierDetailDto>()
                   .ReverseMap();

                cfg.CreateMap<Supplier, SupplierDetailDto>()
                   .ForMember(d => d.Business, s =>
                   {
                       s.Condition(x => !x.MainBusiness.IsNullOrEmpty());
                       s.MapFrom(x => x.MainBusiness.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries));
                   })
                   .ForMember(d => d.Account, s => s.MapFrom(x => x.BackCardNumber))
                   .ForMember(d => d.Address, s => s.MapFrom(x => x.Address))
                   .ForMember(d => d.Bank, s => s.MapFrom(x => x.OpenBack))
                   .ForMember(d => d.BankOfDeposit, s => s.MapFrom(x => x.OpenBack))
                   .ForMember(d => d.Contacts, s => s.ResolveUsing<SupplierContactsResolver>())
                   .ForMember(d => d.Operator, s => s.Ignore())
                   .ForMember(d => d.Fax, s => s.MapFrom(x => x.Fax))
                   .ForMember(d => d.EstablishmentDate, s => s.MapFrom(x => x.FoundDate.ToString("yyyy-MM-dd HH:mm:ss")))
                   .ReverseMap();

                cfg.CreateMap<EnquiryAppForm, EnquiryAppFormDto>()
                .ForMember(d => d.CreateDateTimeUtcFmt, s => s.MapFrom(x => x.CreateOnUtc))
                .ForMember(d => d.FinishDateTimeUtcFmt, s =>
                {
                    s.Condition(x => x.FinishDate.HasValue);
                    s.NullSubstitute("");
                    s.MapFrom(x => x.FinishDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                })
                .ForMember(d => d.Status, s => s.ResolveUsing<KeyValue>((x) =>
                {
                    return new KeyValue
                    {
                        Id = (int)x.FromStatus,
                        Name = x.FromStatus.ToDescription()
                    };
                }))
                .ForMember(d => d.Number, s => s.MapFrom(x => x.FormCode))
                .ForMember(d => d.Applicant, s => s.MapFrom(x => x.Proposer))
                .ForMember(d => d.Id, s => s.MapFrom(x => x.Id))
                .ForMember(d => d.Operator, s => s.Ignore());
            });
        }
    }
}
