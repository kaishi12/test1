namespace Testing.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TrangTruyen")]
    public partial class TrangTruyen
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TrangTruyen()
        {
            ToaDos = new HashSet<ToaDo>();
        }

        [Key]
        public int MaTrangTruyen { get; set; }
        public int MaNguoiDung { get; set; }
        public int MaChuongTruyen { get; set; }

        public int MaLoaiTrang { get; set; }

        public int ThuTu { get; set; }

        [Required]
        [StringLength(1000)]
        public string TenTrang { get; set; }

        [Required]
        public string UrlAnh { get; set; }

        public bool DaXoa { get; set; }
        public virtual NguoiDung NguoiDung { get; set; }

        public virtual ChuongTruyen ChuongTruyen { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ToaDo> ToaDos { get; set; }

        public virtual LoaiTrang LoaiTrang { get; set; }
        

        
    }
}
