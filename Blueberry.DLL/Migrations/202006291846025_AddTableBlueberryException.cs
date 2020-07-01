namespace Blueberry.DLL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableBlueberryException : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlueberryExceptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StackTrance = c.String(),
                        IsSolved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
            DropTable("dbo.BlueberryExceptions");
        }
    }
}
