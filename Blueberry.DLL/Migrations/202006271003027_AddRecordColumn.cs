namespace Blueberry.DLL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRecordColumn : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Records",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        Order_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.Order_Id)
                .Index(t => t.Order_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Records", "Order_Id", "dbo.Orders");
            DropIndex("dbo.Records", new[] { "Order_Id" });
            DropTable("dbo.Records");
        }
    }
}
