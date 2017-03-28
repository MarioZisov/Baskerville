namespace Baskerville.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategoryToProduct : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Products", name: "ProductCategory_Id", newName: "CategoryId");
            RenameIndex(table: "dbo.Products", name: "IX_ProductCategory_Id", newName: "IX_CategoryId");
            CreateTable(
                "dbo.ProductViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameBg = c.String(),
                        NameEn = c.String(),
                        DescriptionBg = c.String(),
                        DescriptionEn = c.String(),
                        Quantity = c.Double(nullable: false),
                        Price = c.Double(nullable: false),
                        ProductCategoryId = c.Int(nullable: false),
                        IsPublic = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ProductViewModels");
            RenameIndex(table: "dbo.Products", name: "IX_CategoryId", newName: "IX_ProductCategory_Id");
            RenameColumn(table: "dbo.Products", name: "CategoryId", newName: "ProductCategory_Id");
        }
    }
}
