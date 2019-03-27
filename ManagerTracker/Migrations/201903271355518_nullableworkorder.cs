namespace ManagerTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullableworkorder : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.WorkOrders", "TrailersId", "dbo.Trailers");
            DropForeignKey("dbo.WorkOrders", "TrucksId", "dbo.Trucks");
            DropIndex("dbo.WorkOrders", new[] { "TrucksId" });
            DropIndex("dbo.WorkOrders", new[] { "TrailersId" });
            AlterColumn("dbo.WorkOrders", "TrucksId", c => c.Int());
            AlterColumn("dbo.WorkOrders", "TrailersId", c => c.Int());
            CreateIndex("dbo.WorkOrders", "TrucksId");
            CreateIndex("dbo.WorkOrders", "TrailersId");
            AddForeignKey("dbo.WorkOrders", "TrailersId", "dbo.Trailers", "Id");
            AddForeignKey("dbo.WorkOrders", "TrucksId", "dbo.Trucks", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkOrders", "TrucksId", "dbo.Trucks");
            DropForeignKey("dbo.WorkOrders", "TrailersId", "dbo.Trailers");
            DropIndex("dbo.WorkOrders", new[] { "TrailersId" });
            DropIndex("dbo.WorkOrders", new[] { "TrucksId" });
            AlterColumn("dbo.WorkOrders", "TrailersId", c => c.Int(nullable: false));
            AlterColumn("dbo.WorkOrders", "TrucksId", c => c.Int(nullable: false));
            CreateIndex("dbo.WorkOrders", "TrailersId");
            CreateIndex("dbo.WorkOrders", "TrucksId");
            AddForeignKey("dbo.WorkOrders", "TrucksId", "dbo.Trucks", "Id", cascadeDelete: true);
            AddForeignKey("dbo.WorkOrders", "TrailersId", "dbo.Trailers", "Id", cascadeDelete: true);
        }
    }
}
