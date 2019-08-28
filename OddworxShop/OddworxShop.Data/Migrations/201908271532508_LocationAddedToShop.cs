namespace OddworxShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LocationAddedToShop : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Shops", "Location", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Shops", "Location");
        }
    }
}
