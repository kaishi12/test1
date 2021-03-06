USE [master]
GO
/****** Object:  Database [HeThongDichTruyenOnline]    Script Date: 5/11/2019 4:25:21 PM ******/
CREATE DATABASE [HeThongDichTruyenOnline]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HeThongDichTruyenOnline', FILENAME = N'D:\HeThongDichTruyenOnline.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'HeThongDichTruyenOnline_log', FILENAME = N'D:\HeThongDichTruyenOnline_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [HeThongDichTruyenOnline] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HeThongDichTruyenOnline].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HeThongDichTruyenOnline] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HeThongDichTruyenOnline] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HeThongDichTruyenOnline] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HeThongDichTruyenOnline] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HeThongDichTruyenOnline] SET ARITHABORT OFF 
GO
ALTER DATABASE [HeThongDichTruyenOnline] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HeThongDichTruyenOnline] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HeThongDichTruyenOnline] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HeThongDichTruyenOnline] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HeThongDichTruyenOnline] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HeThongDichTruyenOnline] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HeThongDichTruyenOnline] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HeThongDichTruyenOnline] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HeThongDichTruyenOnline] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HeThongDichTruyenOnline] SET  DISABLE_BROKER 
GO
ALTER DATABASE [HeThongDichTruyenOnline] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HeThongDichTruyenOnline] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HeThongDichTruyenOnline] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HeThongDichTruyenOnline] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HeThongDichTruyenOnline] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HeThongDichTruyenOnline] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HeThongDichTruyenOnline] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HeThongDichTruyenOnline] SET RECOVERY FULL 
GO
ALTER DATABASE [HeThongDichTruyenOnline] SET  MULTI_USER 
GO
ALTER DATABASE [HeThongDichTruyenOnline] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HeThongDichTruyenOnline] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HeThongDichTruyenOnline] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HeThongDichTruyenOnline] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [HeThongDichTruyenOnline] SET DELAYED_DURABILITY = DISABLED 
GO
USE [HeThongDichTruyenOnline]
GO
/****** Object:  Table [dbo].[BanDich]    Script Date: 5/11/2019 4:25:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BanDich](
	[MaBanDich] [int] IDENTITY(1,1) NOT NULL,
	[TenBanDich] [nvarchar](100) NOT NULL,
	[MaNgonNgu] [int] NOT NULL,
	[MaProject] [int] NOT NULL,
	[MaNguoiDung] [int] NOT NULL,
	[DaXoa] [bit] NOT NULL,
 CONSTRAINT [PK_BanDich] PRIMARY KEY CLUSTERED 
(
	[MaBanDich] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChiTietBanDich]    Script Date: 5/11/2019 4:25:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietBanDich](
	[MaBanDich] [int] NOT NULL,
	[MaTrangTruyen] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChiTietTruyen]    Script Date: 5/11/2019 4:25:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietTruyen](
	[MaTheLoai] [int] NOT NULL,
	[MaProject] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChuongTruyen]    Script Date: 5/11/2019 4:25:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChuongTruyen](
	[MaChuongTruyen] [int] IDENTITY(1,1) NOT NULL,
	[MaProject] [int] NOT NULL,
	[TenChuongTruyen] [nvarchar](1000) NOT NULL,
	[LuotXem] [int] NOT NULL,
	[ThoiGianCapNhat] [datetime] NOT NULL,
	[DaXoa] [bit] NOT NULL,
 CONSTRAINT [PK_Chapter] PRIMARY KEY CLUSTERED 
(
	[MaChuongTruyen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KhungTruyen]    Script Date: 5/11/2019 4:25:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[KhungTruyen](
	[MaText] [int] IDENTITY(1,1) NOT NULL,
	[MaTrangTruyen] [int] NOT NULL,
	[MaNguoiDung] [int] NOT NULL,
	[NoiDung] [nvarchar](max) NOT NULL,
	[KieuChu] [varchar](1000) NOT NULL,
	[DoLon] [int] NOT NULL,
	[DoNang] [int] NOT NULL,
	[ToaDo1] [varchar](50) NOT NULL,
	[ToaDo2] [varchar](50) NOT NULL,
 CONSTRAINT [PK_KhungTruyen] PRIMARY KEY CLUSTERED 
(
	[MaText] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LoaiThongBao]    Script Date: 5/11/2019 4:25:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiThongBao](
	[MaLoaiThongBao] [int] IDENTITY(1,1) NOT NULL,
	[TenLoaiThongBao] [nvarchar](1000) NOT NULL,
	[DaXoa] [bit] NOT NULL,
 CONSTRAINT [PK_LoaiThongBao] PRIMARY KEY CLUSTERED 
(
	[MaLoaiThongBao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LoaiTrang]    Script Date: 5/11/2019 4:25:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiTrang](
	[MaLoaiTrang] [int] IDENTITY(1,1) NOT NULL,
	[TenLoaiTrang] [nvarchar](100) NOT NULL,
	[DaXoa] [bit] NOT NULL,
 CONSTRAINT [PK_LoaiTrang] PRIMARY KEY CLUSTERED 
(
	[MaLoaiTrang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NgonNgu]    Script Date: 5/11/2019 4:25:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NgonNgu](
	[MaNgonNgu] [int] IDENTITY(1,1) NOT NULL,
	[TenNgonNgu] [nvarchar](100) NOT NULL,
	[DaXoa] [bit] NOT NULL,
 CONSTRAINT [PK_NgonNgu] PRIMARY KEY CLUSTERED 
(
	[MaNgonNgu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NguoiDung]    Script Date: 5/11/2019 4:25:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NguoiDung](
	[MaNguoiDung] [int] IDENTITY(1,1) NOT NULL,
	[Taikhoan] [nvarchar](50) NOT NULL,
	[MatKhau] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NULL,
	[SoDienThoai] [nvarchar](50) NULL,
 CONSTRAINT [PK_NguoiDung] PRIMARY KEY CLUSTERED 
(
	[MaNguoiDung] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TheLoai]    Script Date: 5/11/2019 4:25:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TheLoai](
	[MaTheLoai] [int] IDENTITY(1,1) NOT NULL,
	[TenTheLoai] [nvarchar](100) NOT NULL,
	[Mota] [nvarchar](1000) NULL,
	[Tag] [varchar](100) NOT NULL,
	[DaXoa] [bit] NOT NULL,
 CONSTRAINT [PK_TheLoai] PRIMARY KEY CLUSTERED 
(
	[MaTheLoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ThongBao]    Script Date: 5/11/2019 4:25:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThongBao](
	[MaThongBao] [int] IDENTITY(1,1) NOT NULL,
	[MaLoaiThongBao] [int] NOT NULL,
	[MaNguoiDung] [int] NOT NULL,
	[NoiDung] [nvarchar](max) NOT NULL,
	[ThoiGian] [datetime] NOT NULL,
	[DaXem] [bit] NOT NULL,
	[DaXoa] [bit] NOT NULL,
 CONSTRAINT [PK_ThongBao] PRIMARY KEY CLUSTERED 
(
	[MaThongBao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TinNhan]    Script Date: 5/11/2019 4:25:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TinNhan](
	[MaTinNhan] [int] IDENTITY(1,1) NOT NULL,
	[MaNguoiGui] [int] NOT NULL,
	[MaNguoiNhan] [int] NOT NULL,
	[NoiDung] [nvarchar](max) NOT NULL,
	[ThoiGian] [datetime] NOT NULL,
	[DaXoa] [bit] NOT NULL,
 CONSTRAINT [PK_TinNhan] PRIMARY KEY CLUSTERED 
(
	[MaTinNhan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TrangThai]    Script Date: 5/11/2019 4:25:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TrangThai](
	[MaTrangThai] [int] IDENTITY(1,1) NOT NULL,
	[TenTrangThai] [nvarchar](50) NOT NULL,
	[DaXoa] [bit] NULL,
 CONSTRAINT [PK_TrangThai] PRIMARY KEY CLUSTERED 
(
	[MaTrangThai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TrangTruyen]    Script Date: 5/11/2019 4:25:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TrangTruyen](
	[MaTrangTruyen] [int] IDENTITY(1,1) NOT NULL,
	[MaChuongTruyen] [int] NOT NULL,
	[MaLoaiTrang] [int] NOT NULL,
	[ThuTu] [int] NOT NULL,
	[TenTrang] [nvarchar](1000) NOT NULL,
	[UrlAnh] [varbinary](max) NOT NULL,
	[DaXoa] [bit] NOT NULL,
 CONSTRAINT [PK_TrangTruyen] PRIMARY KEY CLUSTERED 
(
	[MaTrangTruyen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Truyen]    Script Date: 5/11/2019 4:25:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Truyen](
	[MaProject] [int] IDENTITY(1,1) NOT NULL,
	[MaNguoiDung] [int] NOT NULL,
	[TrangThai] [int] NOT NULL,
	[AnhBia] [nvarchar](1000) NOT NULL,
	[TenProject] [nvarchar](max) NOT NULL,
	[TenKhac] [nvarchar](max) NULL,
	[MoTa] [nvarchar](max) NOT NULL,
	[NgayTao] [datetime] NOT NULL,
	[TacGia] [nvarchar](100) NOT NULL,
	[DaXoa] [bit] NOT NULL,
 CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED 
(
	[MaProject] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[ChiTietTruyen] ([MaTheLoai], [MaProject]) VALUES (1, 1)
INSERT [dbo].[ChiTietTruyen] ([MaTheLoai], [MaProject]) VALUES (2, 1)
INSERT [dbo].[ChiTietTruyen] ([MaTheLoai], [MaProject]) VALUES (3, 1)
INSERT [dbo].[ChiTietTruyen] ([MaTheLoai], [MaProject]) VALUES (4, 1)
INSERT [dbo].[ChiTietTruyen] ([MaTheLoai], [MaProject]) VALUES (5, 2)
INSERT [dbo].[ChiTietTruyen] ([MaTheLoai], [MaProject]) VALUES (6, 2)
INSERT [dbo].[ChiTietTruyen] ([MaTheLoai], [MaProject]) VALUES (8, 2)
INSERT [dbo].[ChiTietTruyen] ([MaTheLoai], [MaProject]) VALUES (9, 2)
INSERT [dbo].[ChiTietTruyen] ([MaTheLoai], [MaProject]) VALUES (10, 2)
INSERT [dbo].[ChiTietTruyen] ([MaTheLoai], [MaProject]) VALUES (1, 3)
SET IDENTITY_INSERT [dbo].[ChuongTruyen] ON 

INSERT [dbo].[ChuongTruyen] ([MaChuongTruyen], [MaProject], [TenChuongTruyen], [LuotXem], [ThoiGianCapNhat], [DaXoa]) VALUES (1, 1, N'ABC', 1, CAST(N'2019-01-01 00:00:00.000' AS DateTime), 0)
INSERT [dbo].[ChuongTruyen] ([MaChuongTruyen], [MaProject], [TenChuongTruyen], [LuotXem], [ThoiGianCapNhat], [DaXoa]) VALUES (3, 1, N'AS', 1, CAST(N'2019-01-01 01:00:00.000' AS DateTime), 0)
INSERT [dbo].[ChuongTruyen] ([MaChuongTruyen], [MaProject], [TenChuongTruyen], [LuotXem], [ThoiGianCapNhat], [DaXoa]) VALUES (4, 1, N'213', 1, CAST(N'2019-01-01 02:00:00.000' AS DateTime), 0)
INSERT [dbo].[ChuongTruyen] ([MaChuongTruyen], [MaProject], [TenChuongTruyen], [LuotXem], [ThoiGianCapNhat], [DaXoa]) VALUES (7, 1, N'123', 1, CAST(N'2019-01-01 03:00:00.000' AS DateTime), 0)
INSERT [dbo].[ChuongTruyen] ([MaChuongTruyen], [MaProject], [TenChuongTruyen], [LuotXem], [ThoiGianCapNhat], [DaXoa]) VALUES (8, 2, N'13124', 1, CAST(N'2019-01-01 04:00:00.000' AS DateTime), 0)
INSERT [dbo].[ChuongTruyen] ([MaChuongTruyen], [MaProject], [TenChuongTruyen], [LuotXem], [ThoiGianCapNhat], [DaXoa]) VALUES (10, 1, N'1321', 1000, CAST(N'2019-01-05 00:00:00.000' AS DateTime), 0)
INSERT [dbo].[ChuongTruyen] ([MaChuongTruyen], [MaProject], [TenChuongTruyen], [LuotXem], [ThoiGianCapNhat], [DaXoa]) VALUES (11, 2, N'1254', 100, CAST(N'2019-01-04 00:00:00.000' AS DateTime), 0)
INSERT [dbo].[ChuongTruyen] ([MaChuongTruyen], [MaProject], [TenChuongTruyen], [LuotXem], [ThoiGianCapNhat], [DaXoa]) VALUES (13, 3, N'111', 200, CAST(N'2019-01-06 00:00:00.000' AS DateTime), 0)
INSERT [dbo].[ChuongTruyen] ([MaChuongTruyen], [MaProject], [TenChuongTruyen], [LuotXem], [ThoiGianCapNhat], [DaXoa]) VALUES (14, 2, N'111', 200, CAST(N'2019-01-07 00:00:00.000' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[ChuongTruyen] OFF
SET IDENTITY_INSERT [dbo].[NguoiDung] ON 

INSERT [dbo].[NguoiDung] ([MaNguoiDung], [Taikhoan], [MatKhau], [Email], [SoDienThoai]) VALUES (1, N'trikiet60', N'20E7702D29132A952EB8CA984E25A80A', N'trikiet60@yahoo.com.vn', N'0123')
SET IDENTITY_INSERT [dbo].[NguoiDung] OFF
SET IDENTITY_INSERT [dbo].[TheLoai] ON 

INSERT [dbo].[TheLoai] ([MaTheLoai], [TenTheLoai], [Mota], [Tag], [DaXoa]) VALUES (1, N'Comedy', N'Hài hước', N'Comedy', 0)
INSERT [dbo].[TheLoai] ([MaTheLoai], [TenTheLoai], [Mota], [Tag], [DaXoa]) VALUES (2, N'Action', N'Hành động', N'Action', 0)
INSERT [dbo].[TheLoai] ([MaTheLoai], [TenTheLoai], [Mota], [Tag], [DaXoa]) VALUES (3, N'Fantasy', N'Fantasy', N'Fantasy', 0)
INSERT [dbo].[TheLoai] ([MaTheLoai], [TenTheLoai], [Mota], [Tag], [DaXoa]) VALUES (4, N'Magic', N'Phép thuật', N'Magic', 0)
INSERT [dbo].[TheLoai] ([MaTheLoai], [TenTheLoai], [Mota], [Tag], [DaXoa]) VALUES (5, N'Isekai', N'Chuyển sinh dị giới', N'Isekai', 0)
INSERT [dbo].[TheLoai] ([MaTheLoai], [TenTheLoai], [Mota], [Tag], [DaXoa]) VALUES (6, N'Manhua', N'Thẻ loại Manhua', N'Manhua', 0)
INSERT [dbo].[TheLoai] ([MaTheLoai], [TenTheLoai], [Mota], [Tag], [DaXoa]) VALUES (8, N'Horror', N'Kinh dị', N'Horror', 0)
INSERT [dbo].[TheLoai] ([MaTheLoai], [TenTheLoai], [Mota], [Tag], [DaXoa]) VALUES (9, N'Drama', N'Drama', N'Drama', 0)
INSERT [dbo].[TheLoai] ([MaTheLoai], [TenTheLoai], [Mota], [Tag], [DaXoa]) VALUES (10, N'Mystery', N'Mystery', N'Mystery', 0)
INSERT [dbo].[TheLoai] ([MaTheLoai], [TenTheLoai], [Mota], [Tag], [DaXoa]) VALUES (12, N'Adventure', N'Phiêu lưu', N'Adventure', 0)
SET IDENTITY_INSERT [dbo].[TheLoai] OFF
SET IDENTITY_INSERT [dbo].[TrangThai] ON 

INSERT [dbo].[TrangThai] ([MaTrangThai], [TenTrangThai], [DaXoa]) VALUES (1, N'Ok', 0)
SET IDENTITY_INSERT [dbo].[TrangThai] OFF
SET IDENTITY_INSERT [dbo].[Truyen] ON 

INSERT [dbo].[Truyen] ([MaProject], [MaNguoiDung], [TrangThai], [AnhBia], [TenProject], [TenKhac], [MoTa], [NgayTao], [TacGia], [DaXoa]) VALUES (1, 1, 1, N'01.jpg', N'Testing', N'Test', N'Test lun', CAST(N'2019-01-01 01:00:00.000' AS DateTime), N'K', 0)
INSERT [dbo].[Truyen] ([MaProject], [MaNguoiDung], [TrangThai], [AnhBia], [TenProject], [TenKhac], [MoTa], [NgayTao], [TacGia], [DaXoa]) VALUES (2, 1, 1, N'02.jpg', N'Testing1', N'T', N'T', CAST(N'2019-01-01 02:00:00.000' AS DateTime), N'K', 0)
INSERT [dbo].[Truyen] ([MaProject], [MaNguoiDung], [TrangThai], [AnhBia], [TenProject], [TenKhac], [MoTa], [NgayTao], [TacGia], [DaXoa]) VALUES (3, 1, 1, N'03.jpg', N'Testing2', N'TT', N'TT', CAST(N'2019-01-01 00:00:00.000' AS DateTime), N'K', 0)
INSERT [dbo].[Truyen] ([MaProject], [MaNguoiDung], [TrangThai], [AnhBia], [TenProject], [TenKhac], [MoTa], [NgayTao], [TacGia], [DaXoa]) VALUES (4, 1, 1, N'01.jpg', N'TTTT', N'TTTT', N'TTTT', CAST(N'2019-01-01 00:00:00.000' AS DateTime), N'K', 0)
SET IDENTITY_INSERT [dbo].[Truyen] OFF
ALTER TABLE [dbo].[BanDich]  WITH CHECK ADD  CONSTRAINT [FK_BanDich_NgonNgu] FOREIGN KEY([MaNgonNgu])
REFERENCES [dbo].[NgonNgu] ([MaNgonNgu])
GO
ALTER TABLE [dbo].[BanDich] CHECK CONSTRAINT [FK_BanDich_NgonNgu]
GO
ALTER TABLE [dbo].[BanDich]  WITH CHECK ADD  CONSTRAINT [FK_BanDich_NguoiDung] FOREIGN KEY([MaNguoiDung])
REFERENCES [dbo].[NguoiDung] ([MaNguoiDung])
GO
ALTER TABLE [dbo].[BanDich] CHECK CONSTRAINT [FK_BanDich_NguoiDung]
GO
ALTER TABLE [dbo].[BanDich]  WITH CHECK ADD  CONSTRAINT [FK_BanDich_Truyen] FOREIGN KEY([MaProject])
REFERENCES [dbo].[Truyen] ([MaProject])
GO
ALTER TABLE [dbo].[BanDich] CHECK CONSTRAINT [FK_BanDich_Truyen]
GO
ALTER TABLE [dbo].[ChiTietBanDich]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietBanDich_BanDich] FOREIGN KEY([MaBanDich])
REFERENCES [dbo].[BanDich] ([MaBanDich])
GO
ALTER TABLE [dbo].[ChiTietBanDich] CHECK CONSTRAINT [FK_ChiTietBanDich_BanDich]
GO
ALTER TABLE [dbo].[ChiTietBanDich]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietBanDich_TrangTruyen] FOREIGN KEY([MaTrangTruyen])
REFERENCES [dbo].[TrangTruyen] ([MaTrangTruyen])
GO
ALTER TABLE [dbo].[ChiTietBanDich] CHECK CONSTRAINT [FK_ChiTietBanDich_TrangTruyen]
GO
ALTER TABLE [dbo].[ChiTietTruyen]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietTruyen_TheLoai] FOREIGN KEY([MaTheLoai])
REFERENCES [dbo].[TheLoai] ([MaTheLoai])
GO
ALTER TABLE [dbo].[ChiTietTruyen] CHECK CONSTRAINT [FK_ChiTietTruyen_TheLoai]
GO
ALTER TABLE [dbo].[ChiTietTruyen]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietTruyen_Truyen] FOREIGN KEY([MaProject])
REFERENCES [dbo].[Truyen] ([MaProject])
GO
ALTER TABLE [dbo].[ChiTietTruyen] CHECK CONSTRAINT [FK_ChiTietTruyen_Truyen]
GO
ALTER TABLE [dbo].[ChuongTruyen]  WITH CHECK ADD  CONSTRAINT [FK_ChuongTruyen_Truyen] FOREIGN KEY([MaProject])
REFERENCES [dbo].[Truyen] ([MaProject])
GO
ALTER TABLE [dbo].[ChuongTruyen] CHECK CONSTRAINT [FK_ChuongTruyen_Truyen]
GO
ALTER TABLE [dbo].[KhungTruyen]  WITH CHECK ADD  CONSTRAINT [FK_KhungTruyen_NguoiDung] FOREIGN KEY([MaNguoiDung])
REFERENCES [dbo].[NguoiDung] ([MaNguoiDung])
GO
ALTER TABLE [dbo].[KhungTruyen] CHECK CONSTRAINT [FK_KhungTruyen_NguoiDung]
GO
ALTER TABLE [dbo].[KhungTruyen]  WITH CHECK ADD  CONSTRAINT [FK_KhungTruyen_TrangTruyen] FOREIGN KEY([MaTrangTruyen])
REFERENCES [dbo].[TrangTruyen] ([MaTrangTruyen])
GO
ALTER TABLE [dbo].[KhungTruyen] CHECK CONSTRAINT [FK_KhungTruyen_TrangTruyen]
GO
ALTER TABLE [dbo].[ThongBao]  WITH CHECK ADD  CONSTRAINT [FK_ThongBao_LoaiThongBao] FOREIGN KEY([MaLoaiThongBao])
REFERENCES [dbo].[LoaiThongBao] ([MaLoaiThongBao])
GO
ALTER TABLE [dbo].[ThongBao] CHECK CONSTRAINT [FK_ThongBao_LoaiThongBao]
GO
ALTER TABLE [dbo].[ThongBao]  WITH CHECK ADD  CONSTRAINT [FK_ThongBao_NguoiDung] FOREIGN KEY([MaNguoiDung])
REFERENCES [dbo].[NguoiDung] ([MaNguoiDung])
GO
ALTER TABLE [dbo].[ThongBao] CHECK CONSTRAINT [FK_ThongBao_NguoiDung]
GO
ALTER TABLE [dbo].[TinNhan]  WITH CHECK ADD  CONSTRAINT [FK_TinNhan_NguoiDung] FOREIGN KEY([MaNguoiGui])
REFERENCES [dbo].[NguoiDung] ([MaNguoiDung])
GO
ALTER TABLE [dbo].[TinNhan] CHECK CONSTRAINT [FK_TinNhan_NguoiDung]
GO
ALTER TABLE [dbo].[TinNhan]  WITH CHECK ADD  CONSTRAINT [FK_TinNhan_NguoiDung1] FOREIGN KEY([MaNguoiNhan])
REFERENCES [dbo].[NguoiDung] ([MaNguoiDung])
GO
ALTER TABLE [dbo].[TinNhan] CHECK CONSTRAINT [FK_TinNhan_NguoiDung1]
GO
ALTER TABLE [dbo].[TrangTruyen]  WITH CHECK ADD  CONSTRAINT [FK_TrangTruyen_ChuongTruyen] FOREIGN KEY([MaChuongTruyen])
REFERENCES [dbo].[ChuongTruyen] ([MaChuongTruyen])
GO
ALTER TABLE [dbo].[TrangTruyen] CHECK CONSTRAINT [FK_TrangTruyen_ChuongTruyen]
GO
ALTER TABLE [dbo].[TrangTruyen]  WITH CHECK ADD  CONSTRAINT [FK_TrangTruyen_LoaiTrang] FOREIGN KEY([MaLoaiTrang])
REFERENCES [dbo].[LoaiTrang] ([MaLoaiTrang])
GO
ALTER TABLE [dbo].[TrangTruyen] CHECK CONSTRAINT [FK_TrangTruyen_LoaiTrang]
GO
ALTER TABLE [dbo].[Truyen]  WITH CHECK ADD  CONSTRAINT [FK_Truyen_NguoiDung] FOREIGN KEY([MaNguoiDung])
REFERENCES [dbo].[NguoiDung] ([MaNguoiDung])
GO
ALTER TABLE [dbo].[Truyen] CHECK CONSTRAINT [FK_Truyen_NguoiDung]
GO
ALTER TABLE [dbo].[Truyen]  WITH CHECK ADD  CONSTRAINT [FK_Truyen_TrangThai] FOREIGN KEY([TrangThai])
REFERENCES [dbo].[TrangThai] ([MaTrangThai])
GO
ALTER TABLE [dbo].[Truyen] CHECK CONSTRAINT [FK_Truyen_TrangThai]
GO
USE [master]
GO
ALTER DATABASE [HeThongDichTruyenOnline] SET  READ_WRITE 
GO
