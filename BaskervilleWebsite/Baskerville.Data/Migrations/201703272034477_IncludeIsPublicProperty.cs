namespace Baskerville.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IncludeIsPublicProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "IsPublic", c => c.Boolean(nullable: false));
            AddColumn("dbo.Products", "IsPublic", c => c.Boolean(nullable: false));
            AddColumn("dbo.Promotions", "IsPublic", c => c.Boolean(nullable: false));
            DropColumn("dbo.Events", "EndDate");
            DropColumn("dbo.Events", "IsFinished");
            DropColumn("dbo.Promotions", "IsActive");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Promotions", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Events", "IsFinished", c => c.Boolean(nullable: false));
            AddColumn("dbo.Events", "EndDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Promotions", "IsPublic");
            DropColumn("dbo.Products", "IsPublic");
            DropColumn("dbo.Events", "IsPublic");
        }
    }
}
