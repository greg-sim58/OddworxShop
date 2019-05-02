namespace OddworxShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedadminusers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        UniqueUserId = c.Guid(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        LastModifiedAt = c.DateTime(nullable: false),
                        LastModifiedBy = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        AdminUserRole_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AdminUserRoles", t => t.AdminUserRole_Id)
                .Index(t => t.AdminUserRole_Id);
            
            CreateTable(
                "dbo.AdminUserRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AdminUsers", "AdminUserRole_Id", "dbo.AdminUserRoles");
            DropIndex("dbo.AdminUsers", new[] { "AdminUserRole_Id" });
            DropTable("dbo.AdminUserRoles");
            DropTable("dbo.AdminUsers");
        }
    }
}
