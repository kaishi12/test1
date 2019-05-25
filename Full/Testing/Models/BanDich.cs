namespace Testing.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BanDich")]
    public partial class BanDich
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BanDich()
        {
            ChiTietBanDichs = new HashSet<ChiTietBanDich>();
        }

        [Key]
        public int MaBanDich { get; set; }

        [Required]
        [StringLength(100)]
        public string TenBanDich { get; set; }

        public int MaNgonNgu { get; set; }

        public int MaProject { get; set; }

        public int MaNguoiDung { get; set; }

        public bool DaXoa { get; set; }

        public virtual NgonNgu NgonNgu { get; set; }

        public virtual NguoiDung NguoiDung { get; set; }

        public virtual Truyen Truyen { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietBanDich> ChiTietBanDichs { get; set; }
    }
}
