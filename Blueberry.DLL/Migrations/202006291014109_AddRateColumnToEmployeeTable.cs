namespace Blueberry.DLL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRateColumnToEmployeeTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Rate", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "Rate");
        }
    }
}
