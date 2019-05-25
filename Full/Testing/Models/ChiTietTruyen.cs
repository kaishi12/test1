namespace Testing.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietTruyen")]
    public partial class ChiTietTruyen
    {
        
        public Truyen Truyen { get; set; }
        public TheLoai TheLoai { get; set; }
        [Key]
        [Column(Order =1)]
        public int MaTheLoai { get; set; }
        [Key]
        [Column(Order = 2)]
        public int MaProject { get; set; }



    }
}
