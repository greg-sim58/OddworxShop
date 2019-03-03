namespace OddworxShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedshoptoitems : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "Shop_Id", c => c.Int());
            CreateIndex("dbo.Items", "Shop_Id");
            AddForeignKey("dbo.Items", "Shop_Id", "dbo.Shops", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "Shop_Id", "dbo.Shops");
            DropIndex("dbo.Items", new[] { "Shop_Id" });
            DropColumn("dbo.Items", "Shop_Id");
        }
    }
}
