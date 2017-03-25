namespace Baskerville.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMainDataModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameBg = c.String(),
                        NameEn = c.String(),
                        DescriptionBg = c.String(),
                        DescriptionEn = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        ImageUrl = c.String(),
                        IsFinished = c.Boolean(nullable: false),
                        IsRemoved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MeasurementUnits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IndicationBg = c.String(),
                        IndicationEn = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameBg = c.String(),
                        NameEn = c.String(),
                        DescriptionBg = c.String(),
                        DescriptionEn = c.String(),
                        Quantity = c.Double(nullable: false),
                        Price = c.Double(nullable: false),
                        IsAvalible = c.Boolean(nullable: false),
                        IsRemoved = c.Boolean(nullable: false),
                        UnitId = c.Int(nullable: false),
                        ProductCategory_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MeasurementUnits", t => t.UnitId, cascadeDelete: true)
                .ForeignKey("dbo.ProductCategories", t => t.ProductCategory_Id)
                .Index(t => t.UnitId)
                .Index(t => t.ProductCategory_Id);
            
            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameBg = c.String(),
                        NameEn = c.String(),
                        IsRemoved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Promotions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameBg = c.String(),
                        NameEn = c.String(),
                        DescriptionBg = c.String(),
                        DescriptionEn = c.String(),
                        ImageUrl = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        IsRemoved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Subscribers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        PreferedLanguage = c.Int(nullable: false),
                        SubscriptionPendingDate = c.DateTime(nullable: false),
                        SubscriptionDate = c.DateTime(nullable: false),
                        UnsubscribeDate = c.DateTime(nullable: false),
                        SubscriptionVerificationCode = c.String(),
                        UnsubscribeVerificationCode = c.String(),
                        IsRemoved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "ProductCategory_Id", "dbo.ProductCategories");
            DropForeignKey("dbo.Products", "UnitId", "dbo.MeasurementUnits");
            DropIndex("dbo.Products", new[] { "ProductCategory_Id" });
            DropIndex("dbo.Products", new[] { "UnitId" });
            DropTable("dbo.Subscribers");
            DropTable("dbo.Promotions");
            DropTable("dbo.ProductCategories");
            DropTable("dbo.Products");
            DropTable("dbo.MeasurementUnits");
            DropTable("dbo.Events");
        }
    }
}
