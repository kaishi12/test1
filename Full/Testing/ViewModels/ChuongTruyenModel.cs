using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Testing.Models;

namespace Testing.ViewModels
{
    public class ChuongTruyenModel
    {
        public int MaChuong { get; set; }
        [Display(Name = "Tên Chương Truyện")]
        public string TenChuong { get; set; }
        [Display(Name = "Thời gian cập nhật")]
        public string Thoigian { get; set; }
        [Display(Name = "Thứ tự chương")]
        public int ThutuChuong { get; set; }
        [RegularExpression("^[0-9]+$", ErrorMessage = "Yêu cầu chọn trạng thái")]
        public int MaLoaiTrang { get; set; }
        public IEnumerable<TrangTruyen> Trangstruyen { get; set; }

    }
}