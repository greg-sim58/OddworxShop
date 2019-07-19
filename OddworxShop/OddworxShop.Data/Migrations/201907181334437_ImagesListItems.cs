namespace OddworxShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImagesListItems : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Images", "Item_Id", c => c.Int());
            CreateIndex("dbo.Images", "Item_Id");
            AddForeignKey("dbo.Images", "Item_Id", "dbo.Items", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Images", "Item_Id", "dbo.Items");
            DropIndex("dbo.Images", new[] { "Item_Id" });
            DropColumn("dbo.Images", "Item_Id");
        }
    }
}
