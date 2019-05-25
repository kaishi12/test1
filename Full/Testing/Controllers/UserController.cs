using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Testing.Models;
using Testing.ViewModels;

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
        public ActionResult DangKy(DangKyModel model)
        {
            if (ModelState.IsValid)
            {
                var Dao = new DAO.DAONguoiDung();
                var result = Dao.CheckTk(model.TaiKhoan);
                var result1 = Dao.CheckEmail(model.Email);
                if (result)
                {
                    ModelState.AddModelError("", "Tài Khoản đã tồn tại");
                }
                else
                if (result1)
                {
                    ModelState.AddModelError("", "Email đã tồn tại");
                }
                else
                {
                    NguoiDung nguoi = new NguoiDung();

                    string matkhau = CreateMD5(model.MatKhau);
                    nguoi.Taikhoan = model.TaiKhoan;
                    nguoi.MatKhau = matkhau;
                    nguoi.Email = model.Email;
                    nguoi.SoDienThoai = model.SoDienThoai;
                    var result2 = Dao.Insert(nguoi);

                    if (result2 > 0)
                        return RedirectToAction("DangNhap");
                    else
                        ModelState.AddModelError("", "Đăng kí thất bại");
                }

            }
            else
            {
                ModelState.AddModelError("", "Nhập đầy đủ thông tin");
            }
            return View(model);
        }
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(DangNhapModel model)
        {
            if (ModelState.IsValid)
            {
                var Dao = new DAO.DAONguoiDung();
                var mk = CreateMD5(model.MatKhau);
                var result = Dao.Login(model.TaiKhoan, CreateMD5(model.MatKhau));
                if (result == 1)
                {
                    NguoiDung nguoi = data.NguoiDungs.SingleOrDefault(n => n.Taikhoan == model.TaiKhoan && n.MatKhau == mk);
                    Session["TaiKhoan"] = nguoi;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng Nhập thất bại");
                }
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