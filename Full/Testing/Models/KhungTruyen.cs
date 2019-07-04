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

        public int MaToaDo { get; set; }

        public int MaNguoiDung { get; set; }

        [Required]
        public string NoiDung { get; set; }

        [Required]
        [StringLength(1000)]
        public string KieuChu { get; set; }

        public int DoLon { get; set; }

        public int DoNang { get; set; }

       

        public virtual NguoiDung NguoiDung { get; set; }

        public virtual ToaDo ToaDo { get; set; }
    }
}
