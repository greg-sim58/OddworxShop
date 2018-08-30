namespace OddworxShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialoddworx1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Data = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ItemCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Parent = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        LastModifiedAt = c.DateTime(nullable: false),
                        LastModifiedBy = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        Category_Id = c.Int(),
                        Image_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ItemCategories", t => t.Category_Id)
                .ForeignKey("dbo.Images", t => t.Image_Id)
                .Index(t => t.Category_Id)
                .Index(t => t.Image_Id);
            
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Stars = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        LastModifiedAt = c.DateTime(nullable: false),
                        LastModifiedBy = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        Item_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.Item_Id)
                .Index(t => t.Item_Id);
            
            CreateTable(
                "dbo.ShopCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        LastModifiedAt = c.DateTime(nullable: false),
                        LastModifiedBy = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Shops",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        ContactEmail = c.String(),
                        ContactPhone = c.String(),
                        WebSite = c.String(),
                        AdminUser_Id = c.Int(),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.AdminUser_Id)
                .ForeignKey("dbo.ShopCategories", t => t.Category_Id)
                .Index(t => t.AdminUser_Id)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        EMail = c.String(),
                        AboutMe = c.String(),
                        Location = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        LastModifiedAt = c.DateTime(nullable: false),
                        LastModifiedBy = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        Account_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserAccounts", t => t.Account_Id)
                .Index(t => t.Account_Id);
            
            CreateTable(
                "dbo.UserAccounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        LastModifiedAt = c.DateTime(nullable: false),
                        LastModifiedBy = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        AccountType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserAccountTypes", t => t.AccountType_Id)
                .Index(t => t.AccountType_Id);
            
            CreateTable(
                "dbo.UserAccountTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaymentFrequency = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Shops", "Category_Id", "dbo.ShopCategories");
            DropForeignKey("dbo.Shops", "AdminUser_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "Account_Id", "dbo.UserAccounts");
            DropForeignKey("dbo.UserAccounts", "AccountType_Id", "dbo.UserAccountTypes");
            DropForeignKey("dbo.Ratings", "Item_Id", "dbo.Items");
            DropForeignKey("dbo.Items", "Image_Id", "dbo.Images");
            DropForeignKey("dbo.Items", "Category_Id", "dbo.ItemCategories");
            DropIndex("dbo.UserAccounts", new[] { "AccountType_Id" });
            DropIndex("dbo.Users", new[] { "Account_Id" });
            DropIndex("dbo.Shops", new[] { "Category_Id" });
            DropIndex("dbo.Shops", new[] { "AdminUser_Id" });
            DropIndex("dbo.Ratings", new[] { "Item_Id" });
            DropIndex("dbo.Items", new[] { "Image_Id" });
            DropIndex("dbo.Items", new[] { "Category_Id" });
            DropTable("dbo.UserAccountTypes");
            DropTable("dbo.UserAccounts");
            DropTable("dbo.Users");
            DropTable("dbo.Shops");
            DropTable("dbo.ShopCategories");
            DropTable("dbo.Ratings");
            DropTable("dbo.Items");
            DropTable("dbo.ItemCategories");
            DropTable("dbo.Images");
        }
    }
}
