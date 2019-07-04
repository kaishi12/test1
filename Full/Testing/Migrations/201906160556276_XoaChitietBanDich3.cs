namespace Testing.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class XoaChitietBanDich3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ChiTietBanDich", "MaBanDich", "dbo.BanDich");
            DropForeignKey("dbo.ChiTietBanDich", "MaTrangTruyen", "dbo.TrangTruyen");
        }
        
        public override void Down()
        {
            AddForeignKey("dbo.ChiTietBanDich", "MaBanDich", "dbo.BanDich", "MaBanDich", cascadeDelete: true);
            AddForeignKey("dbo.ChiTietBanDich", "MaTrangTruyen", "dbo.TrangTruyen", "MaTrangTruyen", cascadeDelete: true);
        }
    }
}
