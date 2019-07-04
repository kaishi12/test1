namespace Testing.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateRelation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TrangTruyen", "MaNguoiDung", c => c.Int(nullable: false));
            CreateIndex("dbo.TrangTruyen", "MaNguoiDung");
            AddForeignKey("dbo.TrangTruyen", "MaNguoiDung", "dbo.NguoiDung", "MaNguoiDung");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TrangTruyen", "MaNguoiDung", "dbo.NguoiDung");
            DropIndex("dbo.TrangTruyen", new[] { "MaNguoiDung" });
            DropColumn("dbo.TrangTruyen", "MaNguoiDung");
        }
    }
}
