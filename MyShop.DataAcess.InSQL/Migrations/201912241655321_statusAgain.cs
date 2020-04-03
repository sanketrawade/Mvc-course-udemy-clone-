namespace MyShop.DataAcess.InSQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class statusAgain : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderStatus",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        status = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.OrderStatus");
        }
    }
}
