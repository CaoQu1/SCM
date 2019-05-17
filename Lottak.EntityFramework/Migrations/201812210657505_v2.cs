namespace Lottak.EntityFramework
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SystemAttachments", "CompanyNo", c => c.Int(nullable: false));
            AddColumn("dbo.Suppliers", "CompanyNo", c => c.Int(nullable: false));
            AddColumn("dbo.SupplierContacts", "CompanyNo", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SupplierContacts", "CompanyNo");
            DropColumn("dbo.Suppliers", "CompanyNo");
            DropColumn("dbo.SystemAttachments", "CompanyNo");
        }
    }
}
