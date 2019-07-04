using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Testing.ViewModels
{
    public class TruyenDaTao
    {
        public int MaProject { get; set; }
        [Display(Name = "Ảnh Bìa")]
        public string AnhBia { get; set; }
        [Display(Name = "Tên Truyện")]
        public string TenTruyen { get; set; }
        [Display(Name = "Trạng Thái")]
        public string TrangThai { get; set; }
        [Display(Name = "Tác Giả")]
        public string TacGia { get; set; }
        [Display(Name = "Ngày Tạo")]
        public string NgayTao { get; set; }
    }
}