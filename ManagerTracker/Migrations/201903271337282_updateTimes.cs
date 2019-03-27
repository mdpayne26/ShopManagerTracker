namespace ManagerTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateTimes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.WorkOrders", "Date", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.WorkOrders", "StartTime", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.WorkOrders", "StartTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.WorkOrders", "Date", c => c.DateTime(nullable: false));
        }
    }
}
