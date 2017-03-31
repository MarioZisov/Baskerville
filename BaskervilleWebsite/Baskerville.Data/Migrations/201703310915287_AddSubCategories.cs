namespace Baskerville.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSubCategories : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductCategories", "IsPrimary", c => c.Boolean(nullable: false));
            AddColumn("dbo.ProductCategories", "PrimaryCategoryId", c => c.Int());
            AddColumn("dbo.ProductViewModels", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.ProductCategories", "PrimaryCategoryId");
            AddForeignKey("dbo.ProductCategories", "PrimaryCategoryId", "dbo.ProductCategories", "Id");
            DropColumn("dbo.ProductViewModels", "ProductCategoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductViewModels", "ProductCategoryId", c => c.Int(nullable: false));
            DropForeignKey("dbo.ProductCategories", "PrimaryCategoryId", "dbo.ProductCategories");
            DropIndex("dbo.ProductCategories", new[] { "PrimaryCategoryId" });
            DropColumn("dbo.ProductViewModels", "CategoryId");
            DropColumn("dbo.ProductCategories", "PrimaryCategoryId");
            DropColumn("dbo.ProductCategories", "IsPrimary");
        }
    }
}
