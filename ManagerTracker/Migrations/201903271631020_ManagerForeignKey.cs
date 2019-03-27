namespace ManagerTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ManagerForeignKey : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Managers", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Managers", "ApplicationUserId");
            AddForeignKey("dbo.Managers", "ApplicationUserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Managers", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Managers", new[] { "ApplicationUserId" });
            DropColumn("dbo.Managers", "ApplicationUserId");
        }
    }
}
