namespace Testing.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThongBao")]
    public partial class ThongBao
    {
        [Key]
        public int MaThongBao { get; set; }

        public int MaLoaiThongBao { get; set; }

        public int MaNguoiDung { get; set; }

        [Required]
        public string NoiDung { get; set; }

        public DateTime ThoiGian { get; set; }

        public bool DaXem { get; set; }

        public bool DaXoa { get; set; }

        public virtual LoaiThongBao LoaiThongBao { get; set; }

        public virtual NguoiDung NguoiDung { get; set; }
    }
}
