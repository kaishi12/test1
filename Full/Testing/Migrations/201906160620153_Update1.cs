namespace Testing.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.KhungTruyen", "MaTrangTruyen", "dbo.TrangTruyen");
            DropIndex("dbo.KhungTruyen", new[] { "MaTrangTruyen" });
            CreateTable(
                "dbo.ToaDo",
                c => new
                    {
                        MaToaDo = c.Int(nullable: false, identity: true),
                        ToaDo1 = c.String(nullable: false, maxLength: 50),
                        ToaDo2 = c.String(nullable: false, maxLength: 50),
                        DaXoa = c.Boolean(nullable: false),
                        TrangTruyen_MaTrangTruyen = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaToaDo)
                .ForeignKey("dbo.TrangTruyen", t => t.TrangTruyen_MaTrangTruyen)
                .Index(t => t.TrangTruyen_MaTrangTruyen);
            
            AddColumn("dbo.KhungTruyen", "MaToaDo", c => c.Int(nullable: false));
            CreateIndex("dbo.KhungTruyen", "MaToaDo");
            AddForeignKey("dbo.KhungTruyen", "MaToaDo", "dbo.ToaDo", "MaToaDo");
            DropColumn("dbo.KhungTruyen", "MaTrangTruyen");
            DropColumn("dbo.KhungTruyen", "ToaDo1");
            DropColumn("dbo.KhungTruyen", "ToaDo2");
        }
        
        public override void Down()
        {
            AddColumn("dbo.KhungTruyen", "ToaDo2", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AddColumn("dbo.KhungTruyen", "ToaDo1", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AddColumn("dbo.KhungTruyen", "MaTrangTruyen", c => c.Int(nullable: false));
            DropForeignKey("dbo.ToaDo", "TrangTruyen_MaTrangTruyen", "dbo.TrangTruyen");
            DropForeignKey("dbo.KhungTruyen", "MaToaDo", "dbo.ToaDo");
            DropIndex("dbo.ToaDo", new[] { "TrangTruyen_MaTrangTruyen" });
            DropIndex("dbo.KhungTruyen", new[] { "MaToaDo" });
            DropColumn("dbo.KhungTruyen", "MaToaDo");
            DropTable("dbo.ToaDo");
            CreateIndex("dbo.KhungTruyen", "MaTrangTruyen");
            AddForeignKey("dbo.KhungTruyen", "MaTrangTruyen", "dbo.TrangTruyen", "MaTrangTruyen");
        }
    }
}
