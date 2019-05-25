using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Testing.ViewModels
{
    public class DangNhapModel
    {
        [Required(ErrorMessage = "Mời nhập tài khoản")]
        public string TaiKhoan { get; set; }
        [Required(ErrorMessage = "Mời nhập mật khẩu")]
        public string MatKhau { get; set; }
    }
}