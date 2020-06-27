namespace Blueberry.DLL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeDateTimeNotNullAble : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "DateOfRealization", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "DateOfRealization", c => c.DateTime());
        }
    }
}
