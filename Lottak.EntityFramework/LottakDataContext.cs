using Abp.Domain.Repositories;
using Abp.EntityFramework;
using Lottak.Core;
using Lottak.Core.ApplicationForm;
using Lottak.Core.Attachment;
using Lottak.Core.Authorization;
using Lottak.Core.Common;
using Lottak.Core.Company;
using Lottak.Core.FeedbackRecord;
using Lottak.Core.Item;
using Lottak.Core.Log;
using Lottak.Core.Region;
using Lottak.Core.Suppliers;
using Lottak.EntityFramework.Migrations.SeedData;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottak.EntityFramework
{
    [AutoRepositoryTypes(typeof(IRepositoryExtesion<>),
        typeof(IRepositoryExtesion<,>),
        typeof(LottakEfRepositoryBase<>),
        typeof(LottakEfRepositoryBase<,>))]
    public class LottakDataContext : AbpDbContext
    {
        public LottakDataContext() : base(CommonConst.LOTTAKCONN)
        {
        }

        #region Basic

        public IDbSet<SystemUser> SystemUsers { get; set; }

        public IDbSet<Role> Roles { get; set; }

        public IDbSet<SystemUserRole> SystemUserRoles { get; set; }

        public IDbSet<Company> Companies { get; set; }

        public IDbSet<CompanyEmployee> CompanyEmployees { get; set; }

        public IDbSet<Department> Departments { get; set; }

        public IDbSet<DepartmentMember> DepartmentMembers { get; set; }

        public IDbSet<MenuPermission> MenuPermissions { get; set; }

        public IDbSet<MenuPermissionRole> MenuPermissionRoles { get; set; }

        public IDbSet<ActionPermission> ActionPermissions { get; set; }

        public IDbSet<ActionPermissionRole> ActionPermissionRoles { get; set; }

        public IDbSet<SystemAttachment> SystemAttachments { get; set; }

        public IDbSet<AuditLog> AuditLogs { get; set; }

        public IDbSet<Item> Items { get; set; }

        public IDbSet<ItemValue> ItemValues { get; set; }

        public IDbSet<SystemRegion> SystemRegions { get; set; }

        #endregion

        #region Business

        public IDbSet<Supplier> Suppliers { get; set; }

        public IDbSet<SupplierContact> SupplierContacts { get; set; }

        public IDbSet<EnquiryAppForm> EnquiryAppForms { get; set; }

        public IDbSet<EnquiryAppFromUser> EnquiryAppFromUsers { get; set; }

        public IDbSet<EnquiryAppFormProduct> EnquiryAppFormProducts { get; set; }

        //public IDbSet<EnquiryAppFormAttachment> EnquiryAppFormAttachments { get; set; }
        public IDbSet<ApplicationFormAttachment> ApplicationFormAttachments { get; set; }

        public IDbSet<EnquirySupplier> EnquirySuppliers { get; set; }

        public IDbSet<EnquirySupplierAttachment> EnquirySupplierAttachments { get; set; }

        public IDbSet<PurchaseAppForm> PurchaseAppForms { get; set; }

        public IDbSet<PurchaseProduct> PurchaseProducts { get; set; }

        public IDbSet<PurchaseContract> PurchaseContracts { get; set; }

        //public IDbSet<PurchaseAppFormAttachment> PurchaseAppFormAttachments { get; set; }

        public IDbSet<PurchaseContractProduct> PurchaseContractProducts { get; set; }

        public IDbSet<PaymentRecord> PaymentRecords { get; set; }

        public IDbSet<InvoiceRecord> InvoiceRecords { get; set; }

        public IDbSet<WarehousAppForm> WarehousAppForms { get; set; }

        public IDbSet<ChangeRecord> ChangeRecords { get; set; }

        public IDbSet<FeedbackRecord> FeedbackRecords { get; set; }

        public IDbSet<FeedbackRecordAttachment> FeedbackRecordAttachments { get; set; }

        #endregion

        /// <summary>
        /// 重建模型
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SystemUserRole>()
                        .HasRequired(x => x.Role)
                        .WithMany(x => x.SystemUserRoles)
                        .HasForeignKey(fk => fk.RoleId);

            modelBuilder.Entity<Department>()
                        .HasOptional(x => x.ParentDpt)
                        .WithMany(y => y.SubDpts)
                        .HasForeignKey(fk => fk.ParentId);

            modelBuilder.Entity<MenuPermission>()
                        .HasOptional(x => x.Parent)
                        .WithMany(y => y.Childrens)
                        .HasForeignKey(fk => fk.ParentId);

            modelBuilder.Entity<ActionPermission>()
                        .HasRequired(x => x.MenuPermission)
                        .WithMany(y => y.ActionPermissions)
                        .HasForeignKey(fk => fk.MenuPermissionId);

            modelBuilder.Entity<MenuPermissionRole>()
                        .HasRequired(x => x.MenuPermission)
                        .WithMany(y => y.MenuPermissionRoles)
                        .HasForeignKey(fk => fk.MenuPermissionId);
            modelBuilder.Entity<MenuPermissionRole>()
                        .HasRequired(x => x.Role)
                        .WithMany(y => y.MenuPermissionRoles)
                        .HasForeignKey(fk => fk.RoleId);

            modelBuilder.Entity<ActionPermissionRole>()
                        .HasRequired(x => x.ActionPermission)
                        .WithMany(y => y.ActionPermissionRoles)
                        .HasForeignKey(fk => fk.ActionPermissionId);
            modelBuilder.Entity<ActionPermissionRole>()
                        .HasRequired(x => x.Role)
                        .WithMany(y => y.ActionPermissionRoles)
                        .HasForeignKey(fk => fk.RoleId);

            modelBuilder.Entity<Item>()
                        .HasOptional(x => x.Parent)
                        .WithMany(y => y.Childrens)
                        .HasForeignKey(fk => fk.ParentId);

            modelBuilder.Entity<ItemValue>()
                        .HasRequired(x => x.Item)
                        .WithMany(y => y.ItemValues)
                        .HasForeignKey(fk => fk.ItemId);

            modelBuilder.Entity<Supplier>()
                        .HasRequired(x => x.CompanyTypes)
                        .WithMany(y => y.CompanyTypes)
                        .HasForeignKey(fk => fk.CompanyTypeId)
                        .WillCascadeOnDelete(false);
            modelBuilder.Entity<Supplier>()
                        .HasRequired(x => x.RegisterCapitals)
                        .WithMany(y => y.RegisterCapitals)
                        .HasForeignKey(fk => fk.RegisterCapitalId)
                        .WillCascadeOnDelete(false);
            modelBuilder.Entity<Supplier>()
                        .HasRequired(x => x.PaymentTypes)
                        .WithMany(y => y.PaymentTypes)
                        .HasForeignKey(fk => fk.PaymentTypeId)
                        .WillCascadeOnDelete(false);
            modelBuilder.Entity<Supplier>()
                        .HasRequired(x => x.SupplierGrades)
                        .WithMany(y => y.SupplierGrades)
                        .HasForeignKey(fk => fk.SupplierGradeId)
                        .WillCascadeOnDelete(false);
            modelBuilder.Entity<Supplier>()
                        .HasRequired(x => x.SystemRegion)
                        .WithMany()
                        .HasForeignKey(fk => fk.AddressId);//（共享主键，外键关系单向一对一关系）

            modelBuilder.Entity<SupplierContact>()
                        .HasRequired(x => x.Supplier)
                        .WithMany(y => y.SupplierContacts)
                        .HasForeignKey(fk => fk.SupplierId);

            modelBuilder.Entity<ApplicationForm>()
                        .Map<EnquiryAppForm>(map => { map.ToTable("EnquiryAppForms"); })
                        .Map<PurchaseAppForm>(map => { map.ToTable("PurchaseAppForms"); })
                        .Map<WarehousAppForm>(map => { map.ToTable("WarehousAppForms"); });
            modelBuilder.Entity<ApplicationFormProduct>()
                        .Map<PurchaseProduct>(map => { map.ToTable("PurchaseProducts"); })
                        .Map<EnquiryAppFormProduct>(map => { map.ToTable("EnquiryAppFormProducts"); })
                        .Map<PurchaseContractProduct>(map => { map.ToTable("PurchaseContractProducts"); });
            modelBuilder.Entity<ApplicationFormUser>()
                        .Map<EnquiryAppFromUser>(map => { map.ToTable("EnquiryAppFromUsers"); });

            modelBuilder.Entity<ApplicationFormAttachment>()
                        .HasRequired(x => x.SystemAttachment)
                        .WithMany(y => y.ApplicationFormAttachments)
                        .HasForeignKey(fk => fk.SystemAttachmentId);
            modelBuilder.Entity<ApplicationFormAttachment>()
                   .HasRequired(x => x.ApplicationForm)
                   .WithMany(y => y.ApplicationFormAttachments)
                   .HasForeignKey(fk => fk.ApplicationFormId);


            modelBuilder.Entity<EnquiryAppFromUser>()
                        .HasRequired(x => x.EnquiryAppForm)
                        .WithMany(y => y.EnquiryAppFromUsers)
                        .HasForeignKey(fk => fk.ApplicationFormId);

            modelBuilder.Entity<EnquiryAppFormProduct>()
                        .HasRequired(x => x.EnquiryAppForm)
                        .WithMany(y => y.EnquiryAppFormProducts)
                        .HasForeignKey(fk => fk.ApplicationFormId);

            modelBuilder.Entity<EnquirySupplier>()
                        .HasRequired(x => x.Supplier)
                        .WithMany(x => x.EnquirySuppliers)
                        .HasForeignKey(fk => fk.SupplierId);
            modelBuilder.Entity<EnquirySupplier>()
                        .HasRequired(x => x.EnquiryAppFormProduct)
                        .WithMany(y => y.EnquirySuppliers)
                        .HasForeignKey(fk => fk.ApplicationFormProductId);

            modelBuilder.Entity<PurchaseProduct>()
                        .HasRequired(x => x.PurchaseAppForm)
                        .WithMany(y => y.PurchaseProducts)
                        .HasForeignKey(fk => fk.ApplicationFormId);

            modelBuilder.Entity<PurchaseContract>()
                        .HasRequired(x => x.Supplier)
                        .WithMany(x => x.PurchaseContracts)
                        .HasForeignKey(fk => fk.SupplierId);
            modelBuilder.Entity<PurchaseContract>()
                        .HasRequired(x => x.Rates)
                        .WithMany(x => x.Rates)
                        .HasForeignKey(fk => fk.RateId)
                        .WillCascadeOnDelete(false);
            modelBuilder.Entity<PurchaseContract>()
                        .HasRequired(x => x.PaymenCycles)
                        .WithMany(x => x.PaymenCycles)
                        .HasForeignKey(fk => fk.PaymenCycleId)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<PurchaseContractProduct>()
                        .HasRequired(x => x.PurchaseContract)
                        .WithMany(y => y.PurchaseContractProducts)
                        .HasForeignKey(fk => fk.PurchaseContractId);

            modelBuilder.Entity<PaymentRecord>()
                        .HasRequired(x => x.PurchaseContractProduct)
                        .WithMany(y => y.PaymentRecords)
                        .HasForeignKey(fk => fk.PurchaseContractProductId);

            modelBuilder.Entity<InvoiceRecord>()
                        .HasRequired(x => x.PurchaseContractProduct)
                        .WithMany(y => y.InvoiceRecords)
                        .HasForeignKey(fk => fk.PurchaseContractProductId);

            //modelBuilder.Entity<PurchaseAppFormAttachment>()
            //            .HasRequired(x => x.SystemAttachment)
            //            .WithMany(y => y.PurchaseAppForms)
            //            .HasForeignKey(fk => fk.SystemAttachmentId);
            //modelBuilder.Entity<PurchaseAppFormAttachment>()
            //            .HasRequired(x => x.PurchaseAppForm)
            //            .WithMany(y => y.ApplicationFormAttachments)
            //            .HasForeignKey(fk => fk.ApplicationFormId);

            //modelBuilder.Entity<EnquiryAppFormAttachment>()
            //            .HasRequired(x => x.SystemAttachment)
            //            .WithMany(y => y.EnquiryAppForms)
            //            .HasForeignKey(fk => fk.SystemAttachmentId);
            //modelBuilder.Entity<EnquiryAppFormAttachment>()
            //            .HasRequired(x => x.EnquiryAppForm)
            //            .WithMany(y => y.ApplicationFormAttachments)
            //            .HasForeignKey(fk => fk.ApplicationFormId);

            modelBuilder.Entity<FeedbackRecordAttachment>()
                        .HasRequired(x => x.SystemAttachment)
                        .WithMany(y => y.FeedbackRecordAttachments)
                        .HasForeignKey(fk => fk.SystemAttachmentId);
            modelBuilder.Entity<FeedbackRecordAttachment>()
                        .HasRequired(x => x.FeedbackRecord)
                        .WithMany(y => y.FeedbackRecordAttachments)
                        .HasForeignKey(fk => fk.FeedbackRecordId);

            modelBuilder.Entity<EnquirySupplierAttachment>()
                        .HasRequired(x => x.SystemAttachment)
                        .WithMany(y => y.EnquirySupplierAttachments)
                        .HasForeignKey(fk => fk.SystemAttachmentId);
            modelBuilder.Entity<EnquirySupplierAttachment>()
                        .HasRequired(x => x.EnquirySupplier)
                        .WithMany(y => y.EnquirySupplierAttachments)
                        .HasForeignKey(fk => fk.EnquirySupplierId);
            base.OnModelCreating(modelBuilder);
        }
    }
}
