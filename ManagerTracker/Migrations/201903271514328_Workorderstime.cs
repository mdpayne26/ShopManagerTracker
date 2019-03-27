namespace ManagerTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Workorderstime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.WorkOrders", "Date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.WorkOrders", "StartTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.WorkOrders", "EndTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.WorkOrders", "EndTime", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.WorkOrders", "StartTime", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.WorkOrders", "Date", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
    }
}
