namespace Testing.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatabase : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT [dbo].[NguoiDung] ON ");
            Sql("INSERT [dbo].[NguoiDung] ([MaNguoiDung], [Taikhoan], [MatKhau], [Email], [SoDienThoai]) VALUES (1, N'trikiet60', N'20E7702D29132A952EB8CA984E25A80A', N'trikiet60@yahoo.com.vn', N'0123')");
            Sql("SET IDENTITY_INSERT [dbo].[NguoiDung] OFF");
            Sql("SET IDENTITY_INSERT [dbo].[TrangThai] ON ");
            Sql("INSERT [dbo].[TrangThai] ([MaTrangThai], [TenTrangThai], [DaXoa]) VALUES (1, N'Ok', 0)");
            Sql("SET IDENTITY_INSERT [dbo].[TrangThai] OFF");
            Sql("SET IDENTITY_INSERT [dbo].[Truyen] ON ");
            Sql("INSERT [dbo].[Truyen] ([MaProject], [MaNguoiDung], [TrangThai], [AnhBia], [TenProject], [TenKhac], [MoTa], [NgayTao], [TacGia], [DaXoa]) VALUES (1, 1, 1, N'01.jpg', N'Testing', N'Test', N'Test lun', CAST(N'2019-01-01 01:00:00.000' AS DateTime), N'K', 0)");
            Sql("INSERT [dbo].[Truyen] ([MaProject], [MaNguoiDung], [TrangThai], [AnhBia], [TenProject], [TenKhac], [MoTa], [NgayTao], [TacGia], [DaXoa]) VALUES (2, 1, 1, N'02.jpg', N'Testing1', N'T', N'T', CAST(N'2019-01-01 02:00:00.000' AS DateTime), N'K', 0)");
            Sql("INSERT [dbo].[Truyen] ([MaProject], [MaNguoiDung], [TrangThai], [AnhBia], [TenProject], [TenKhac], [MoTa], [NgayTao], [TacGia], [DaXoa]) VALUES (3, 1, 1, N'03.jpg', N'Testing2', N'TT', N'TT', CAST(N'2019-01-01 00:00:00.000' AS DateTime), N'K', 0)");
            Sql("INSERT [dbo].[Truyen] ([MaProject], [MaNguoiDung], [TrangThai], [AnhBia], [TenProject], [TenKhac], [MoTa], [NgayTao], [TacGia], [DaXoa]) VALUES (4, 1, 1, N'01.jpg', N'TTTT', N'TTTT', N'TTTT', CAST(N'2019-01-01 00:00:00.000' AS DateTime), N'K', 0)");
            Sql("SET IDENTITY_INSERT [dbo].[Truyen] OFF");
            Sql("SET IDENTITY_INSERT [dbo].[ChuongTruyen] ON ");
            Sql("INSERT [dbo].[ChuongTruyen] ([MaChuongTruyen], [MaProject], [TenChuongTruyen], [LuotXem], [ThoiGianCapNhat], [DaXoa], [ThuTuChuong]) VALUES (15, 1, N'T', 100, CAST(N'2019-01-01 00:00:00.000' AS DateTime), 0, 1)");
            Sql("INSERT [dbo].[ChuongTruyen] ([MaChuongTruyen], [MaProject], [TenChuongTruyen], [LuotXem], [ThoiGianCapNhat], [DaXoa], [ThuTuChuong]) VALUES (16, 1, N'T1', 1000, CAST(N'2019-01-01 01:00:00.000' AS DateTime), 0, 2)");
            Sql("INSERT [dbo].[ChuongTruyen] ([MaChuongTruyen], [MaProject], [TenChuongTruyen], [LuotXem], [ThoiGianCapNhat], [DaXoa], [ThuTuChuong]) VALUES (17, 2, N'T', 200, CAST(N'2019-01-02 00:00:00.000' AS DateTime), 0, 1)");
            Sql("INSERT [dbo].[ChuongTruyen] ([MaChuongTruyen], [MaProject], [TenChuongTruyen], [LuotXem], [ThoiGianCapNhat], [DaXoa], [ThuTuChuong]) VALUES (18, 3, N'T', 3000, CAST(N'2019-01-03 00:00:00.000' AS DateTime), 0, 1)");
            Sql("INSERT [dbo].[ChuongTruyen] ([MaChuongTruyen], [MaProject], [TenChuongTruyen], [LuotXem], [ThoiGianCapNhat], [DaXoa], [ThuTuChuong]) VALUES (19, 1, N'T2', 2000, CAST(N'2019-01-04 00:00:00.000' AS DateTime), 0, 3)");
            Sql("SET IDENTITY_INSERT [dbo].[ChuongTruyen] OFF");
            Sql("SET IDENTITY_INSERT [dbo].[TheLoai] ON ");
            Sql("INSERT [dbo].[TheLoai] ([MaTheLoai], [TenTheLoai], [Mota], [Tag], [DaXoa]) VALUES (1, N'Comedy', N'Hài hước', N'Comedy', 0)");
            Sql("INSERT [dbo].[TheLoai] ([MaTheLoai], [TenTheLoai], [Mota], [Tag], [DaXoa]) VALUES (2, N'Action', N'Hành động', N'Action', 0)");
            Sql("INSERT [dbo].[TheLoai] ([MaTheLoai], [TenTheLoai], [Mota], [Tag], [DaXoa]) VALUES (3, N'Fantasy', N'Fantasy', N'Fantasy', 0)");
            Sql("INSERT [dbo].[TheLoai] ([MaTheLoai], [TenTheLoai], [Mota], [Tag], [DaXoa]) VALUES (4, N'Magic', N'Phép thuật', N'Magic', 0)");
            Sql("INSERT [dbo].[TheLoai] ([MaTheLoai], [TenTheLoai], [Mota], [Tag], [DaXoa]) VALUES (5, N'Isekai', N'Chuyển sinh dị giới', N'Isekai', 0)");
            Sql("INSERT [dbo].[TheLoai] ([MaTheLoai], [TenTheLoai], [Mota], [Tag], [DaXoa]) VALUES (6, N'Manhua', N'Thẻ loại Manhua', N'Manhua', 0)");
            Sql("INSERT [dbo].[TheLoai] ([MaTheLoai], [TenTheLoai], [Mota], [Tag], [DaXoa]) VALUES (8, N'Horror', N'Kinh dị', N'Horror', 0)");
            Sql("INSERT [dbo].[TheLoai] ([MaTheLoai], [TenTheLoai], [Mota], [Tag], [DaXoa]) VALUES (9, N'Drama', N'Drama', N'Drama', 0)");
            Sql("INSERT [dbo].[TheLoai] ([MaTheLoai], [TenTheLoai], [Mota], [Tag], [DaXoa]) VALUES (10, N'Mystery', N'Mystery', N'Mystery', 0)");
            Sql("INSERT [dbo].[TheLoai] ([MaTheLoai], [TenTheLoai], [Mota], [Tag], [DaXoa]) VALUES (12, N'Adventure', N'Phiêu lưu', N'Adventure', 0)");
            Sql("SET IDENTITY_INSERT [dbo].[TheLoai] OFF");
           
            Sql("INSERT [dbo].[ChiTietTruyen] ([MaTheLoai], [MaProject]) VALUES (1, 1)");
            Sql("INSERT [dbo].[ChiTietTruyen] ([MaTheLoai], [MaProject]) VALUES (2, 1)");
            Sql("INSERT [dbo].[ChiTietTruyen] ([MaTheLoai], [MaProject]) VALUES (3, 1)");
            Sql("INSERT [dbo].[ChiTietTruyen] ([MaTheLoai], [MaProject]) VALUES (4, 1)");
            Sql("INSERT [dbo].[ChiTietTruyen] ([MaTheLoai], [MaProject]) VALUES (1, 2)");
            Sql("INSERT [dbo].[ChiTietTruyen] ([MaTheLoai], [MaProject]) VALUES (3, 2)");
            Sql("INSERT [dbo].[ChiTietTruyen] ([MaTheLoai], [MaProject]) VALUES (6, 2)");
            Sql("INSERT [dbo].[ChiTietTruyen] ([MaTheLoai], [MaProject]) VALUES (10, 2)");
            Sql("INSERT [dbo].[ChiTietTruyen] ([MaTheLoai], [MaProject]) VALUES (9, 2)");
            Sql("INSERT [dbo].[ChiTietTruyen] ([MaTheLoai], [MaProject]) VALUES (8, 3)");
            Sql("INSERT [dbo].[ChiTietTruyen] ([MaTheLoai], [MaProject]) VALUES (1, 3)");
            Sql("INSERT [dbo].[ChiTietTruyen] ([MaTheLoai], [MaProject]) VALUES (4, 3)");
            Sql("INSERT [dbo].[ChiTietTruyen] ([MaTheLoai], [MaProject]) VALUES (6, 3)");
            
        }
        
        public override void Down()
        {
        }
    }
}
