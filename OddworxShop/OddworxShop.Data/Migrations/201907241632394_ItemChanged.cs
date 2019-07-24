namespace OddworxShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ItemChanged : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Items", "Image_Id", "dbo.Images");
            DropIndex("dbo.Items", new[] { "Image_Id" });
            AddColumn("dbo.Items", "DefaultImage", c => c.Int(nullable: false));
            DropColumn("dbo.Items", "Image_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Items", "Image_Id", c => c.Int());
            DropColumn("dbo.Items", "DefaultImage");
            CreateIndex("dbo.Items", "Image_Id");
            AddForeignKey("dbo.Items", "Image_Id", "dbo.Images", "Id");
        }
    }
}
