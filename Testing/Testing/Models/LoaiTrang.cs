namespace Testing.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoaiTrang")]
    public partial class LoaiTrang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoaiTrang()
        {
            TrangTruyens = new HashSet<TrangTruyen>();
        }

        [Key]
        public int MaLoaiTrang { get; set; }

        [Required]
        [StringLength(100)]
        public string TenLoaiTrang { get; set; }

        public bool DaXoa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrangTruyen> TrangTruyens { get; set; }
    }
}
