namespace Blueberry.DLL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNumberColumnToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Number", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Number");
        }
    }
}
