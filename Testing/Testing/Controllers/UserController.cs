using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Testing.Models;

namespace Testing.Controllers
{
    public class UserController : Controller
    {
        Model1 data = new Model1();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public int KiemTrakMatKhau(string text)
        {
            int a = 0;
            int b = 0;
            if (text.Length < 8 || text.Length > 32)
            {
                return 0;
            }
            foreach (char c in text)
            {
                if (Char.IsDigit(c))
                {
                    a = a + 1;
                }
                else
                if (Char.IsUpper(c))
                {
                    b = b + 1;
                }
            }
            if (a > 0 && b > 0)
            {
                return 1;
            }
            return 0;
        }
        public int KiemTraTaiKhoan(string text)
        {

            NguoiDung nguoi = data.NguoiDungs.SingleOrDefault(n => n.Taikhoan == text);
            if (nguoi != null)
            {
                return 1;
            }

            else
            if (text.Length < 8 || text.Length > 32)
            {
                return 3;
            }
            else
            {
                return 2;
            }
        }
        public int KiemTraEmail(string text)
        {
            NguoiDung nguoi = data.NguoiDungs.SingleOrDefault(n => n.Email == text);
            if (nguoi != null)
            {
                return 1;
            }
            else
                return 2;
        }
        public int KiemTraSDT(string text)
        {
            foreach (char c in text)
            {
                if (char.IsLetter(c))
                {
                    return 1;
                }
            }
            return 2;
        }
        public string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(FormCollection collection, NguoiDung nguoi)
        {
            var Tk = collection["TaiKhoan"];
            var Mk = collection["MatKhau"];
            var Mk2 = collection["Matkhau2"];
            var Email = collection["Email"];
            var SDT = collection["SoDienThoai"];
            int checkmk = KiemTrakMatKhau(Mk);
            int checktk = KiemTraTaiKhoan(Tk);
            int checkemail = KiemTraEmail(Email);
            int checkSDT = KiemTraSDT(SDT);
            if (checktk == 1)
            {
                ViewBag.ThongBao = "Đã có tài khoản này";

            }
            else
                if (checktk == 3)
            {
                ViewBag.ThongBao = "Tài khoản phải từ 8 - 32 kí tự";
            }
            else
            if (checkSDT == 1)
            {
                ViewBag.ThongBao = "Nhập Khong đúng số điện thoại";
            }
            else
            if (checkemail == 1)
            {
                ViewBag.ThongBao = "Email đã được đăng ký";
            }
            else
            if (checkmk == 0)
            {
                ViewBag.ThongBao = "Mật khẩu từ 8 - 32 kí tự, gồm số và chữ in hoa";
            }
            else
                if (Mk != Mk2)
            {
                ViewBag.ThongBao = "Mật khẩu không trùng khớp";
            }
            else
            {
                string matkhau = CreateMD5(Mk);
                nguoi.Taikhoan = Tk;
                nguoi.MatKhau = matkhau;
                nguoi.Email = Email;
                nguoi.SoDienThoai = SDT;
                
                return RedirectToAction("DangNhap");
            }
            return View();

        }

        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection collection)
        {
            var Tk = collection["TaiKhoan"];
            var Mk = collection["MatKhau"];
            string matkhau = CreateMD5(Mk);

            NguoiDung nguoi = data.NguoiDungs.SingleOrDefault(n => n.Taikhoan == Tk && n.MatKhau == matkhau);
            if (nguoi != null)
            {

                Session["TaiKhoan"] = nguoi;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ThongBao = "Đăng Nhập Thất Bại";
            }
            return View();
        }
        public ActionResult DangXuat()
        {
            Session["TaiKhoan"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}