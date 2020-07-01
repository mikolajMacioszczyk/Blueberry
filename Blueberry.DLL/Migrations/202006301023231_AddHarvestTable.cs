namespace Blueberry.DLL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHarvestTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Harvests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Single(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        Employee_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.Employee_Id)
                .Index(t => t.Employee_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Harvests", "Employee_Id", "dbo.Employees");
            DropIndex("dbo.Harvests", new[] { "Employee_Id" });
            DropTable("dbo.Harvests");
        }
    }
}
