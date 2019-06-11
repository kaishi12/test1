using System;
using System.Collections.Generic;
using System.IO;
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
            if (!CheckSS())
            {
                return RedirectToAction("DangNhap", "User");
            }
               
            else
            {
               var tk = (NguoiDung)Session["TaiKhoan"];
                ViewBag.TK = tk.Taikhoan;
                return View();
                }
        }
        public bool CheckSS()
        {
            if (Session["TaiKhoan"] == null)
                return false;
            else
                return true;
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
        [ValidateAntiForgeryToken]
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
        public ActionResult ThongTinCaNhan(string id)
        {

            DAO.DAONguoiDung tt = new DAO.DAONguoiDung();
            
            
            return PartialView(tt.GetTTCN(id));
            
        }
        public string ThemAnh(HttpPostedFileBase fileupload)
        {
            var filename = Path.GetFileName(fileupload.FileName);
            var path = Path.Combine(Server.MapPath("~/Truyen"), filename);
            fileupload.SaveAs(path);
            return filename;
        }
        [HttpPost]
        public ActionResult ThongTinCaNhan(ThongTinCaNhan tt,HttpPostedFileBase fileupload)
        {
            if(fileupload != null)
            {
                var Anh = ThemAnh(fileupload);
                tt.AnhDaiDien = Anh;
            }
            DAO.DAONguoiDung tt1 = new DAO.DAONguoiDung();
            if (tt1.CheckEmail(tt.Email))
               ModelState.AddModelError("", "Đã có Email này");
            tt1.UpdateThongTinCaNhan(tt);
            var nguoi = data.NguoiDungs.SingleOrDefault(m => m.MaNguoiDung == tt.Ma);
            
            return RedirectToAction("Index","User");
        }
        public ActionResult BaoMat(string id)
        {
            DAO.DAONguoiDung tt = new DAO.DAONguoiDung();
            ViewBag.TK = id;
            ViewBag.MK = CreateMD5(tt.GetMatKhau(id));
            
            return PartialView();
        }
        [HttpPost]
        public ActionResult BaoMat()
        {
            DAO.DAONguoiDung tt = new DAO.DAONguoiDung();
            var tk = Request.Form["TK"];
            var mk = CreateMD5(Request.Form["MatKhau"]);
            tt.UpdateMatKhau(tk, mk);
            return RedirectToAction("Index", "User");
        }
    }
}