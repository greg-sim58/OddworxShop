namespace OddworxShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedadminuser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Images", "AdminUserRole_Id", "dbo.AdminUserRoles");
            DropIndex("dbo.Images", new[] { "AdminUserRole_Id" });
            DropColumn("dbo.Images", "AdminUserRole_Id");
            DropTable("dbo.AdminUserRoles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AdminUserRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Images", "AdminUserRole_Id", c => c.Int());
            CreateIndex("dbo.Images", "AdminUserRole_Id");
            AddForeignKey("dbo.Images", "AdminUserRole_Id", "dbo.AdminUserRoles", "Id");
        }
    }
}
