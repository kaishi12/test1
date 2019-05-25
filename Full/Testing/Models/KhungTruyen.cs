namespace Testing.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhungTruyen")]
    public partial class KhungTruyen
    {
        [Key]
        public int MaText { get; set; }

        public int MaTrangTruyen { get; set; }

        public int MaNguoiDung { get; set; }

        [Required]
        public string NoiDung { get; set; }

        [Required]
        [StringLength(1000)]
        public string KieuChu { get; set; }

        public int DoLon { get; set; }

        public int DoNang { get; set; }

        [Required]
        [StringLength(50)]
        public string ToaDo1 { get; set; }

        [Required]
        [StringLength(50)]
        public string ToaDo2 { get; set; }

        public virtual NguoiDung NguoiDung { get; set; }

        public virtual TrangTruyen TrangTruyen { get; set; }
    }
}
