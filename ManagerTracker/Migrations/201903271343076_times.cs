namespace ManagerTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class times : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.WorkOrders", "EndTime", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.WorkOrders", "EndTime", c => c.DateTime(nullable: false));
        }
    }
}
