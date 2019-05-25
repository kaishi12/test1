namespace Testing.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Truyen")]
    public partial class Truyen
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Truyen()
        {
            BanDiches = new HashSet<BanDich>();
            ChuongTruyens = new HashSet<ChuongTruyen>();
            ChiTietTruyens = new HashSet<ChiTietTruyen>();
        }

        [Key]
        public int MaProject { get; set; }

        public int MaNguoiDung { get; set; }

        public int TrangThai { get; set; }

        [Required]
        [StringLength(1000)]
        public string AnhBia { get; set; }

        [Required]
        public string TenProject { get; set; }

        public string TenKhac { get; set; }

        [Required]
        public string MoTa { get; set; }

        public DateTime NgayTao { get; set; }

        [Required]
        [StringLength(100)]
        public string TacGia { get; set; }

        public bool DaXoa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BanDich> BanDiches { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChuongTruyen> ChuongTruyens { get; set; }

        public virtual NguoiDung NguoiDung { get; set; }

        public virtual TrangThai TrangThai1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietTruyen> ChiTietTruyens { get; set; }
    }
}
