namespace Lottak.EntityFramework
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SystemRegions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        FullId = c.String(),
                        FullName = c.String(),
                        Code = c.String(),
                        Sort = c.Int(nullable: false),
                        ParentId = c.Int(),
                        Depth = c.Int(nullable: false),
                        HasChild = c.Boolean(nullable: false),
                        UpdateBy = c.Guid(),
                        CreateOnUtc = c.DateTime(nullable: false),
                        UpdateOnUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Suppliers", "AddressId");
            AddForeignKey("dbo.Suppliers", "AddressId", "dbo.SystemRegions", "Id", cascadeDelete: true);
            //DropColumn("dbo.MenuPermissions", "CompanyNo");
        }
        
        public override void Down()
        {
            //AddColumn("dbo.MenuPermissions", "CompanyNo", c => c.Int(nullable: false));
            DropForeignKey("dbo.Suppliers", "AddressId", "dbo.SystemRegions");
            DropIndex("dbo.Suppliers", new[] { "AddressId" });
            DropTable("dbo.SystemRegions");
        }
    }
}
