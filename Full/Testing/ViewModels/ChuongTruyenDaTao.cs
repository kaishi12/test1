using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Testing.ViewModels
{
    public class ChuongTruyenDaTao
    {
        public int MaChuong { get; set; }
        [Display(Name = "Tên Chương Truyện")]
        public string TenChuong { get; set; }
        [Display(Name = "Lượt Xem")]
        public int LuotXem { get; set; }
        [Display(Name = "Thời gian cập nhật")]
        public string Thoigian { get; set; }
    }
}