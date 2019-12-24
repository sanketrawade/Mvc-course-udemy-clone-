namespace MyShop.DataAcess.InSQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Custom2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        userID = c.String(),
                        firstName = c.String(),
                        lastName = c.String(),
                        Email = c.String(),
                        street = c.String(),
                        city = c.String(),
                        state = c.String(),
                        zipCode = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Customers");
        }
    }
}
