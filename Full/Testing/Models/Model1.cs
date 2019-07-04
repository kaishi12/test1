namespace Testing.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<BanDich> BanDiches { get; set; }
        public virtual DbSet<ChuongTruyen> ChuongTruyens { get; set; }
        public virtual DbSet<KhungTruyen> KhungTruyens { get; set; }
        public virtual DbSet<LoaiThongBao> LoaiThongBaos { get; set; }
        public virtual DbSet<LoaiTrang> LoaiTrangs { get; set; }
        public virtual DbSet<NgonNgu> NgonNgus { get; set; }
        public virtual DbSet<NguoiDung> NguoiDungs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TheLoai> TheLoais { get; set; }
        public virtual DbSet<ThongBao> ThongBaos { get; set; }
        public virtual DbSet<TinNhan> TinNhans { get; set; }
        public virtual DbSet<TrangThai> TrangThais { get; set; }
        public virtual DbSet<TrangTruyen> TrangTruyens { get; set; }
        public virtual DbSet<Truyen> Truyens { get; set; }
        public virtual DbSet<ChiTietTruyen> ChiTietTruyens { get; set; }
        public virtual DbSet<ToaDo> ToaDos { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
          
          
            //modelBuilder.Entity<BanDich>()
            //    .HasMany(e => e.TrangTruyens)
            //    .WithMany(e => e.BanDiches)
            //    .Map(m => m.ToTable("ChiTietBanDich").MapLeftKey("MaBanDich").MapRightKey("MaTrangTruyen"));
            

            modelBuilder.Entity<ChuongTruyen>()
                .HasMany(e => e.TrangTruyens)
                .WithRequired(e => e.ChuongTruyen)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhungTruyen>()
                .Property(e => e.KieuChu)
                .IsUnicode(false);

            

            modelBuilder.Entity<LoaiThongBao>()
                .HasMany(e => e.ThongBaos)
                .WithRequired(e => e.LoaiThongBao)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LoaiTrang>()
                .HasMany(e => e.TrangTruyens)
                .WithRequired(e => e.LoaiTrang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NgonNgu>()
                .HasMany(e => e.BanDiches)
                .WithRequired(e => e.NgonNgu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NguoiDung>()
                .HasMany(e => e.BanDiches)
                .WithRequired(e => e.NguoiDung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NguoiDung>()
                .HasMany(e => e.KhungTruyens)
                .WithRequired(e => e.NguoiDung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NguoiDung>()
                .HasMany(e => e.ThongBaos)
                .WithRequired(e => e.NguoiDung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NguoiDung>()
                .HasMany(e => e.TinNhans)
                .WithRequired(e => e.NguoiDung)
                .HasForeignKey(e => e.MaNguoiGui)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NguoiDung>()
                .HasMany(e => e.TinNhans1)
                .WithRequired(e => e.NguoiDung1)
                .HasForeignKey(e => e.MaNguoiNhan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NguoiDung>()
                .HasMany(e => e.Truyens)
                .WithRequired(e => e.NguoiDung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NguoiDung>()
                .HasMany(e => e.TrangTruyens)
                .WithRequired(e => e.NguoiDung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TheLoai>()
                .Property(e => e.Tag)
                .IsUnicode(false);

            //modelBuilder.Entity<TheLoai>()
            //    .HasMany(e => e.Truyens)
            //    .WithMany(e => e.TheLoais)
            //    .Map(m => m.ToTable("ChiTietTruyen").MapLeftKey("MaTheLoai").MapRightKey("MaProject"));
            modelBuilder.Entity<ChiTietTruyen>().HasKey(sc => new { sc.MaProject, sc.MaTheLoai });
            modelBuilder.Entity<Truyen>()
                .HasMany(e => e.ChiTietTruyens)
                .WithRequired(e => e.Truyen)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TheLoai>()
                .HasMany(e => e.ChiTietTruyens)
                .WithRequired(e => e.TheLoai)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TrangThai>()
                .HasMany(e => e.Truyens)
                .WithRequired(e => e.TrangThai1)
                .HasForeignKey(e => e.TrangThai)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<TrangTruyen>()
                .HasMany(e => e.ToaDos)
                .WithRequired(e => e.TrangTruyen)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<ToaDo>()
                .HasMany(e => e.KhungTruyens)
                .WithRequired(e => e.ToaDo)
                .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Truyen>()
            //    .HasMany(e => e.BanDiches)
            //    .WithRequired(e => e.Truyen)
            //    .WillCascadeOnDelete(false);

            modelBuilder.Entity<Truyen>()
                .HasMany(e => e.ChuongTruyens)
                .WithRequired(e => e.Truyen)
                .WillCascadeOnDelete(false);
        }
    }
}
