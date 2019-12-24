namespace MyShop.DataAcess.InSQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orderssecond : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        orderId = c.String(maxLength: 128),
                        itemName = c.String(),
                        itemPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        itemQuentity = c.Int(nullable: false),
                        itemImage = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Orders", t => t.orderId)
                .Index(t => t.orderId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        firstName = c.String(),
                        lastName = c.String(),
                        Email = c.String(),
                        street = c.String(),
                        city = c.String(),
                        state = c.String(),
                        zipCode = c.String(),
                        status = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderItems", "orderId", "dbo.Orders");
            DropIndex("dbo.OrderItems", new[] { "orderId" });
            DropTable("dbo.Orders");
            DropTable("dbo.OrderItems");
        }
    }
}
