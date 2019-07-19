namespace OddworxShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VarbinaryForImage1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Images", "ImageData", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Images", "ImageData");
        }
    }
}
