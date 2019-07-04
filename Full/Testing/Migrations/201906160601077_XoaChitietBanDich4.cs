namespace Testing.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class XoaChitietBanDich4 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.ChiTietBanDich", new[] { "MaBanDich" });
            DropIndex("dbo.ChiTietBanDich", new[] { "MaTrangTruyen" });
            DropTable("dbo.ChiTietBanDich");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ChiTietBanDich",
                c => new
                    {
                        MaBanDich = c.Int(nullable: false),
                        MaTrangTruyen = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MaBanDich, t.MaTrangTruyen });
            
            CreateIndex("dbo.ChiTietBanDich", "MaTrangTruyen");
            CreateIndex("dbo.ChiTietBanDich", "MaBanDich");
            AddForeignKey("dbo.ChiTietBanDich", "MaTrangTruyen", "dbo.TrangTruyen", "MaTrangTruyen", cascadeDelete: true);
            AddForeignKey("dbo.ChiTietBanDich", "MaBanDich", "dbo.BanDich", "MaBanDich", cascadeDelete: true);
        }
    }
}
