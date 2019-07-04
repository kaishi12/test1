namespace Testing.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class s : DbMigration
    {
        public override void Up()
        {
            
        }
        
        public override void Down()
        {
            AddColumn("dbo.Truyen", "MaTruyen", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.ChuongTruyen", "MaProject", "dbo.Truyen");
            DropForeignKey("dbo.ChiTietTruyen", "MaProject", "dbo.Truyen");
            DropForeignKey("dbo.BanDich", "MaProject", "dbo.Truyen");
            DropIndex("dbo.BanDich", new[] { "MaProject" });
            DropPrimaryKey("dbo.Truyen");
            AlterColumn("dbo.BanDich", "MaProject", c => c.Int());
            DropColumn("dbo.Truyen", "MaProject");
            AddPrimaryKey("dbo.Truyen", "MaTruyen");
            RenameIndex(table: "dbo.ChiTietTruyen", name: "IX_MaProject", newName: "IX_Truyen_MaTruyen");
            RenameIndex(table: "dbo.ChuongTruyen", name: "IX_MaProject", newName: "IX_Truyen_MaTruyen");
            RenameColumn(table: "dbo.ChiTietTruyen", name: "MaProject", newName: "Truyen_MaTruyen");
            RenameColumn(table: "dbo.ChuongTruyen", name: "MaProject", newName: "Truyen_MaTruyen");
            RenameColumn(table: "dbo.BanDich", name: "MaProject", newName: "Truyen_MaTruyen");
            AddColumn("dbo.ChiTietTruyen", "MaProject", c => c.Int(nullable: false));
            AddColumn("dbo.ChuongTruyen", "MaProject", c => c.Int(nullable: false));
            AddColumn("dbo.BanDich", "MaProject", c => c.Int(nullable: false));
            CreateIndex("dbo.BanDich", "Truyen_MaTruyen");
            AddForeignKey("dbo.ChuongTruyen", "Truyen_MaTruyen", "dbo.Truyen", "MaTruyen");
            AddForeignKey("dbo.ChiTietTruyen", "Truyen_MaTruyen", "dbo.Truyen", "MaTruyen");
            AddForeignKey("dbo.BanDich", "Truyen_MaTruyen", "dbo.Truyen", "MaTruyen");
        }
    }
}
