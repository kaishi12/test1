using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace Testing.Models
{
    [Table("ToaDo")]
    public class ToaDo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ToaDo()
        {
            KhungTruyens = new HashSet<KhungTruyen>();
        }
        [Key]
        public int MaToaDo { get; set; }
        public int MaTrangTruyen { get; set; }
        [Required]
        [StringLength(50)]
        public string ToaDo1 { get; set; }

        [Required]
        [StringLength(50)]
        public string ToaDo2 { get; set; }
        public bool DaXoa { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KhungTruyen> KhungTruyens { get; set; }
        public virtual TrangTruyen TrangTruyen { get; set; }

    }
}