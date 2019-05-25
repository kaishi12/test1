namespace Testing.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.A",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BanDich",
                c => new
                    {
                        MaBanDich = c.Int(nullable: false, identity: true),
                        TenBanDich = c.String(nullable: false, maxLength: 100),
                        MaNgonNgu = c.Int(nullable: false),
                        MaProject = c.Int(nullable: false),
                        MaNguoiDung = c.Int(nullable: false),
                        DaXoa = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MaBanDich)
                .ForeignKey("dbo.Truyen", t => t.MaProject, cascadeDelete: true)
                .ForeignKey("dbo.NguoiDung", t => t.MaNguoiDung)
                .ForeignKey("dbo.NgonNgu", t => t.MaNgonNgu)
                .Index(t => t.MaNgonNgu)
                .Index(t => t.MaProject)
                .Index(t => t.MaNguoiDung);
            
            CreateTable(
                "dbo.ChiTietBanDich",
                c => new
                    {
                        MaBanDich = c.Int(nullable: false),
                        MaTrangTruyen = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MaBanDich, t.MaTrangTruyen })
                .ForeignKey("dbo.TrangTruyen", t => t.MaTrangTruyen)
                .ForeignKey("dbo.BanDich", t => t.MaBanDich)
                .Index(t => t.MaBanDich)
                .Index(t => t.MaTrangTruyen);
            
            CreateTable(
                "dbo.TrangTruyen",
                c => new
                    {
                        MaTrangTruyen = c.Int(nullable: false, identity: true),
                        MaChuongTruyen = c.Int(nullable: false),
                        MaLoaiTrang = c.Int(nullable: false),
                        ThuTu = c.Int(nullable: false),
                        TenTrang = c.String(nullable: false, maxLength: 1000),
                        UrlAnh = c.Binary(nullable: false),
                        DaXoa = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MaTrangTruyen)
                .ForeignKey("dbo.ChuongTruyen", t => t.MaChuongTruyen)
                .ForeignKey("dbo.LoaiTrang", t => t.MaLoaiTrang)
                .Index(t => t.MaChuongTruyen)
                .Index(t => t.MaLoaiTrang);
            
            CreateTable(
                "dbo.ChuongTruyen",
                c => new
                    {
                        MaChuongTruyen = c.Int(nullable: false, identity: true),
                        MaProject = c.Int(nullable: false),
                        TenChuongTruyen = c.String(nullable: false, maxLength: 1000),
                        ThuTuChuong = c.Int(),
                        LuotXem = c.Int(nullable: false),
                        ThoiGianCapNhat = c.DateTime(nullable: false),
                        DaXoa = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MaChuongTruyen)
                .ForeignKey("dbo.Truyen", t => t.MaProject)
                .Index(t => t.MaProject);
            
            CreateTable(
                "dbo.Truyen",
                c => new
                    {
                        MaProject = c.Int(nullable: false, identity: true),
                        MaNguoiDung = c.Int(nullable: false),
                        TrangThai = c.Int(nullable: false),
                        AnhBia = c.String(nullable: false, maxLength: 1000),
                        TenProject = c.String(nullable: false),
                        TenKhac = c.String(),
                        MoTa = c.String(nullable: false),
                        NgayTao = c.DateTime(nullable: false),
                        TacGia = c.String(nullable: false, maxLength: 100),
                        DaXoa = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MaProject)
                .ForeignKey("dbo.NguoiDung", t => t.MaNguoiDung)
                .ForeignKey("dbo.TrangThai", t => t.TrangThai)
                .Index(t => t.MaNguoiDung)
                .Index(t => t.TrangThai);
            
            CreateTable(
                "dbo.ChiTietTruyen",
                c => new
                    {
                        MaTheLoai = c.Int(nullable: false),
                        MaProject = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MaTheLoai, t.MaProject })
                .ForeignKey("dbo.TheLoai", t => t.MaTheLoai)
                .ForeignKey("dbo.Truyen", t => t.MaProject)
                .Index(t => t.MaTheLoai)
                .Index(t => t.MaProject);
            
            CreateTable(
                "dbo.TheLoai",
                c => new
                    {
                        MaTheLoai = c.Int(nullable: false, identity: true),
                        TenTheLoai = c.String(nullable: false, maxLength: 100),
                        Mota = c.String(maxLength: 1000),
                        Tag = c.String(nullable: false, maxLength: 100, unicode: false),
                        DaXoa = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MaTheLoai);
            
            CreateTable(
                "dbo.NguoiDung",
                c => new
                    {
                        MaNguoiDung = c.Int(nullable: false, identity: true),
                        Taikhoan = c.String(nullable: false, maxLength: 50),
                        MatKhau = c.String(nullable: false, maxLength: 50),
                        Email = c.String(maxLength: 50),
                        SoDienThoai = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.MaNguoiDung);
            
            CreateTable(
                "dbo.KhungTruyen",
                c => new
                    {
                        MaText = c.Int(nullable: false, identity: true),
                        MaTrangTruyen = c.Int(nullable: false),
                        MaNguoiDung = c.Int(nullable: false),
                        NoiDung = c.String(nullable: false),
                        KieuChu = c.String(nullable: false, maxLength: 1000, unicode: false),
                        DoLon = c.Int(nullable: false),
                        DoNang = c.Int(nullable: false),
                        ToaDo1 = c.String(nullable: false, maxLength: 50, unicode: false),
                        ToaDo2 = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.MaText)
                .ForeignKey("dbo.NguoiDung", t => t.MaNguoiDung)
                .ForeignKey("dbo.TrangTruyen", t => t.MaTrangTruyen)
                .Index(t => t.MaTrangTruyen)
                .Index(t => t.MaNguoiDung);
            
            CreateTable(
                "dbo.ThongBao",
                c => new
                    {
                        MaThongBao = c.Int(nullable: false, identity: true),
                        MaLoaiThongBao = c.Int(nullable: false),
                        MaNguoiDung = c.Int(nullable: false),
                        NoiDung = c.String(nullable: false),
                        ThoiGian = c.DateTime(nullable: false),
                        DaXem = c.Boolean(nullable: false),
                        DaXoa = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MaThongBao)
                .ForeignKey("dbo.LoaiThongBao", t => t.MaLoaiThongBao)
                .ForeignKey("dbo.NguoiDung", t => t.MaNguoiDung)
                .Index(t => t.MaLoaiThongBao)
                .Index(t => t.MaNguoiDung);
            
            CreateTable(
                "dbo.LoaiThongBao",
                c => new
                    {
                        MaLoaiThongBao = c.Int(nullable: false, identity: true),
                        TenLoaiThongBao = c.String(nullable: false, maxLength: 1000),
                        DaXoa = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MaLoaiThongBao);
            
            CreateTable(
                "dbo.TinNhan",
                c => new
                    {
                        MaTinNhan = c.Int(nullable: false, identity: true),
                        MaNguoiGui = c.Int(nullable: false),
                        MaNguoiNhan = c.Int(nullable: false),
                        NoiDung = c.String(nullable: false),
                        ThoiGian = c.DateTime(nullable: false),
                        DaXoa = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MaTinNhan)
                .ForeignKey("dbo.NguoiDung", t => t.MaNguoiGui)
                .ForeignKey("dbo.NguoiDung", t => t.MaNguoiNhan)
                .Index(t => t.MaNguoiGui)
                .Index(t => t.MaNguoiNhan);
            
            CreateTable(
                "dbo.TrangThai",
                c => new
                    {
                        MaTrangThai = c.Int(nullable: false, identity: true),
                        TenTrangThai = c.String(nullable: false, maxLength: 50),
                        DaXoa = c.Boolean(),
                    })
                .PrimaryKey(t => t.MaTrangThai);
            
            CreateTable(
                "dbo.LoaiTrang",
                c => new
                    {
                        MaLoaiTrang = c.Int(nullable: false, identity: true),
                        TenLoaiTrang = c.String(nullable: false, maxLength: 100),
                        DaXoa = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MaLoaiTrang);
            
            CreateTable(
                "dbo.NgonNgu",
                c => new
                    {
                        MaNgonNgu = c.Int(nullable: false, identity: true),
                        TenNgonNgu = c.String(nullable: false, maxLength: 100),
                        DaXoa = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MaNgonNgu);
            
            CreateTable(
                "dbo.sysdiagrams",
                c => new
                    {
                        diagram_id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 128),
                        principal_id = c.Int(nullable: false),
                        version = c.Int(),
                        definition = c.Binary(),
                    })
                .PrimaryKey(t => t.diagram_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BanDich", "MaNgonNgu", "dbo.NgonNgu");
            DropForeignKey("dbo.ChiTietBanDich", "MaBanDich", "dbo.BanDich");
            DropForeignKey("dbo.TrangTruyen", "MaLoaiTrang", "dbo.LoaiTrang");
            DropForeignKey("dbo.KhungTruyen", "MaTrangTruyen", "dbo.TrangTruyen");
            DropForeignKey("dbo.Truyen", "TrangThai", "dbo.TrangThai");
            DropForeignKey("dbo.Truyen", "MaNguoiDung", "dbo.NguoiDung");
            DropForeignKey("dbo.TinNhan", "MaNguoiNhan", "dbo.NguoiDung");
            DropForeignKey("dbo.TinNhan", "MaNguoiGui", "dbo.NguoiDung");
            DropForeignKey("dbo.ThongBao", "MaNguoiDung", "dbo.NguoiDung");
            DropForeignKey("dbo.ThongBao", "MaLoaiThongBao", "dbo.LoaiThongBao");
            DropForeignKey("dbo.KhungTruyen", "MaNguoiDung", "dbo.NguoiDung");
            DropForeignKey("dbo.BanDich", "MaNguoiDung", "dbo.NguoiDung");
            DropForeignKey("dbo.ChuongTruyen", "MaProject", "dbo.Truyen");
            DropForeignKey("dbo.ChiTietTruyen", "MaProject", "dbo.Truyen");
            DropForeignKey("dbo.ChiTietTruyen", "MaTheLoai", "dbo.TheLoai");
            DropForeignKey("dbo.BanDich", "MaProject", "dbo.Truyen");
            DropForeignKey("dbo.TrangTruyen", "MaChuongTruyen", "dbo.ChuongTruyen");
            DropForeignKey("dbo.ChiTietBanDich", "MaTrangTruyen", "dbo.TrangTruyen");
            DropIndex("dbo.TinNhan", new[] { "MaNguoiNhan" });
            DropIndex("dbo.TinNhan", new[] { "MaNguoiGui" });
            DropIndex("dbo.ThongBao", new[] { "MaNguoiDung" });
            DropIndex("dbo.ThongBao", new[] { "MaLoaiThongBao" });
            DropIndex("dbo.KhungTruyen", new[] { "MaNguoiDung" });
            DropIndex("dbo.KhungTruyen", new[] { "MaTrangTruyen" });
            DropIndex("dbo.ChiTietTruyen", new[] { "MaProject" });
            DropIndex("dbo.ChiTietTruyen", new[] { "MaTheLoai" });
            DropIndex("dbo.Truyen", new[] { "TrangThai" });
            DropIndex("dbo.Truyen", new[] { "MaNguoiDung" });
            DropIndex("dbo.ChuongTruyen", new[] { "MaProject" });
            DropIndex("dbo.TrangTruyen", new[] { "MaLoaiTrang" });
            DropIndex("dbo.TrangTruyen", new[] { "MaChuongTruyen" });
            DropIndex("dbo.ChiTietBanDich", new[] { "MaTrangTruyen" });
            DropIndex("dbo.ChiTietBanDich", new[] { "MaBanDich" });
            DropIndex("dbo.BanDich", new[] { "MaNguoiDung" });
            DropIndex("dbo.BanDich", new[] { "MaProject" });
            DropIndex("dbo.BanDich", new[] { "MaNgonNgu" });
            DropTable("dbo.sysdiagrams");
            DropTable("dbo.NgonNgu");
            DropTable("dbo.LoaiTrang");
            DropTable("dbo.TrangThai");
            DropTable("dbo.TinNhan");
            DropTable("dbo.LoaiThongBao");
            DropTable("dbo.ThongBao");
            DropTable("dbo.KhungTruyen");
            DropTable("dbo.NguoiDung");
            DropTable("dbo.TheLoai");
            DropTable("dbo.ChiTietTruyen");
            DropTable("dbo.Truyen");
            DropTable("dbo.ChuongTruyen");
            DropTable("dbo.TrangTruyen");
            DropTable("dbo.ChiTietBanDich");
            DropTable("dbo.BanDich");
            DropTable("dbo.A");
        }
    }
}
