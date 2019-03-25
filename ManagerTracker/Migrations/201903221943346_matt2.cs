namespace ManagerTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class matt2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Trailers", "Year", c => c.Int());
            AlterColumn("dbo.Trucks", "Year", c => c.Int());
            AlterColumn("dbo.Trucks", "EngineSerialNumber", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Trucks", "EngineSerialNumber", c => c.Int(nullable: false));
            AlterColumn("dbo.Trucks", "Year", c => c.Int(nullable: false));
            AlterColumn("dbo.Trailers", "Year", c => c.Int(nullable: false));
        }
    }
}
