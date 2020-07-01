namespace Blueberry.DLL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBlueberryDataEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlueberryDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PricePerKilo = c.Int(nullable: false),
                        SalaryPerKilo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BlueberryDatas");
        }
    }
}
