namespace Testing.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TinNhan")]
    public partial class TinNhan
    {
        [Key]
        public int MaTinNhan { get; set; }

        public int MaNguoiGui { get; set; }

        public int MaNguoiNhan { get; set; }

        [Required]
        public string NoiDung { get; set; }

        public DateTime ThoiGian { get; set; }

        public bool DaXoa { get; set; }

        public virtual NguoiDung NguoiDung { get; set; }

        public virtual NguoiDung NguoiDung1 { get; set; }
    }
}
