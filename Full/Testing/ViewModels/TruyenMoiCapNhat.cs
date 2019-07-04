using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Testing.ViewModels
{
    public class TruyenMoiCapNhat
    {
        public int MaProject { get; set; }
        public int MabanDich { get; set; }
        public string TenProject { get; set; }
        public string AnhBia { get; set; }
        public string MoTa { get; set; }
        public string TacGia { get; set; }
        public DateTime ThoiGianCapNhat { get; set; }
    }
}