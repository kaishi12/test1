using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Testing.ViewModels
{
    public class TruyenModel
    {
        [Display(Name = "Tên Truyện")]
        [Required(ErrorMessage = "Yêu cầu nhập tên truyện")]
        public string TenTruyen { get; set; }
        [Display(Name = "Tên khác")]
        public string TenKhac { get; set; }
        [Display(Name = "Ảnh bìa")]
        [Required(ErrorMessage = "Yêu cầu có ảnh bìa")]
        public string AnhBia { get; set; }
        [Display(Name = "Mô tả")]
        [Required(ErrorMessage = "Yêu cầu có mô tả")]
        public string MoTa { get; set; }
        [Display(Name = "Tác Giả")]
        [Required(ErrorMessage = "Yêu cầu có tên tác giả")]
        public string Tacgia { get; set; }
        [Display(Name = "Trạng Thái")]
        [RegularExpression("^[0-9]+$",ErrorMessage ="Yêu cầu chọn trạng thái")]
        public int MaTrangThai { get; set; }
        
        public int[] DStheloai { get; set; }


    }
}