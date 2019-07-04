namespace Testing.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class XoaChitietBanDich : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ChiTietBanDich", "MaBanDich", "dbo.BanDich");
            DropForeignKey("dbo.ChiTietBanDich", "MaTrangTruyen", "dbo.TrangTruyen");
            AddForeignKey("dbo.ChiTietBanDich", "MaBanDich", "dbo.BanDich", "MaBanDich", cascadeDelete: true);
            AddForeignKey("dbo.ChiTietBanDich", "MaTrangTruyen", "dbo.TrangTruyen", "MaTrangTruyen", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChiTietBanDich", "MaTrangTruyen", "dbo.TrangTruyen");
            DropForeignKey("dbo.ChiTietBanDich", "MaBanDich", "dbo.BanDich");
            AddForeignKey("dbo.ChiTietBanDich", "MaTrangTruyen", "dbo.TrangTruyen", "MaTrangTruyen");
            AddForeignKey("dbo.ChiTietBanDich", "MaBanDich", "dbo.BanDich", "MaBanDich");
        }
    }
}
