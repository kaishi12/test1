namespace Testing.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChuongTruyen")]
    public partial class ChuongTruyen
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ChuongTruyen()
        {
            TrangTruyens = new HashSet<TrangTruyen>();
        }

        [Key]
        public int MaChuongTruyen { get; set; }

        public int MaProject { get; set; }

        [Required]
        [StringLength(1000)]
        public string TenChuongTruyen { get; set; }

        public int ThuTuChuong { get; set; }

        public int LuotXem { get; set; }

        public DateTime ThoiGianCapNhat { get; set; }

        public bool DaXoa { get; set; }

        public virtual Truyen Truyen { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrangTruyen> TrangTruyens { get; set; }
    }
}
