namespace Baskerville.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TempRemoveProductUnit : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "UnitId", "dbo.MeasurementUnits");
            DropIndex("dbo.Products", new[] { "UnitId" });
            DropColumn("dbo.Products", "UnitId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "UnitId", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "UnitId");
            AddForeignKey("dbo.Products", "UnitId", "dbo.MeasurementUnits", "Id", cascadeDelete: true);
        }
    }
}
