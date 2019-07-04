namespace Testing.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.ToaDo", name: "TrangTruyen_MaTrangTruyen", newName: "MaTrangTruyen");
            RenameIndex(table: "dbo.ToaDo", name: "IX_TrangTruyen_MaTrangTruyen", newName: "IX_MaTrangTruyen");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.ToaDo", name: "IX_MaTrangTruyen", newName: "IX_TrangTruyen_MaTrangTruyen");
            RenameColumn(table: "dbo.ToaDo", name: "MaTrangTruyen", newName: "TrangTruyen_MaTrangTruyen");
        }
    }
}
