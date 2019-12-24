namespace MyShop.DataAcess.InSQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class basket : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BasketItems",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        basketId = c.String(maxLength: 128),
                        productId = c.String(),
                        quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Baskets", t => t.basketId)
                .Index(t => t.basketId);
            
            CreateTable(
                "dbo.Baskets",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BasketItems", "basketId", "dbo.Baskets");
            DropIndex("dbo.BasketItems", new[] { "basketId" });
            DropTable("dbo.Baskets");
            DropTable("dbo.BasketItems");
        }
    }
}
