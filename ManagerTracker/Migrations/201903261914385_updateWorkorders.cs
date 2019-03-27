namespace ManagerTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateWorkorders : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.WorkOrders", name: "TrailerId", newName: "TrailersId");
            RenameColumn(table: "dbo.WorkOrders", name: "TruckId", newName: "TrucksId");
            RenameColumn(table: "dbo.WorkOrders", name: "MechanicId", newName: "MechanicsId");
            RenameIndex(table: "dbo.WorkOrders", name: "IX_MechanicId", newName: "IX_MechanicsId");
            RenameIndex(table: "dbo.WorkOrders", name: "IX_TruckId", newName: "IX_TrucksId");
            RenameIndex(table: "dbo.WorkOrders", name: "IX_TrailerId", newName: "IX_TrailersId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.WorkOrders", name: "IX_TrailersId", newName: "IX_TrailerId");
            RenameIndex(table: "dbo.WorkOrders", name: "IX_TrucksId", newName: "IX_TruckId");
            RenameIndex(table: "dbo.WorkOrders", name: "IX_MechanicsId", newName: "IX_MechanicId");
            RenameColumn(table: "dbo.WorkOrders", name: "MechanicsId", newName: "MechanicId");
            RenameColumn(table: "dbo.WorkOrders", name: "TrucksId", newName: "TruckId");
            RenameColumn(table: "dbo.WorkOrders", name: "TrailersId", newName: "TrailerId");
        }
    }
}
