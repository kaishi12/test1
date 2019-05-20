namespace Testing.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietBanDich")]
    public partial class ChiTietBanDich
    {

        public TrangTruyen TrangTruyen { get; set; }
        public BanDich BanDich { get; set; }
        [Key]
        [Column(Order = 1)]
        public int MaBanDich { get; set; }
        [Key]
        [Column(Order = 2)]
        public int MaTrangTruyen { get; set; }



    }
}
