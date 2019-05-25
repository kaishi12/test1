using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Testing.Models;
using PagedList;
using PagedList.Mvc;
using System.IO;

namespace Testing.Controllers
{
    public class TruyenController : Controller
    {
        Model1 data = new Model1();
        // GET: Truyen
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TaoMoi()
        {
            if (Session["TaiKhoan"] == null)
                return RedirectToAction("DangNhap", "User");
            else
            {
                ViewBag.MaTheLoai = new SelectList(data.TheLoais.ToList(), "MaTheLoai", "TenTheLoai");
                ViewBag.MaTrangThai = new SelectList(data.TrangThais.ToList(), "MaTrangThai", "TenTrangThai");
                return View();
            }
        }
        [HttpPost]
        public ActionResult TaoMoi(Truyen truyen, FormCollection collection, HttpPostedFileBase fileupload)
        {
            ViewBag.MaTheLoai = new SelectList(data.TheLoais.ToList(), "MaTheLoai", "TenTheLoai");
            ViewBag.MaTrangThai = new SelectList(data.TrangThais.ToList(), "MaTrangThai", "TenTrangThai");


            NguoiDung nguoi = (NguoiDung)Session["TaiKhoan"];

            var filename = Path.GetFileName(fileupload.FileName);
            var path = Path.Combine(Server.MapPath("~/Truyen"), filename);
            if (System.IO.File.Exists(path))
            {
                ViewBag.ThongBao = "Hình ảnh đã tồn tại";
            }
            else
            {
                fileupload.SaveAs(path);
            }

            truyen.MaNguoiDung = nguoi.MaNguoiDung;
            truyen.TrangThai = int.Parse(collection["MaTrangThai"]);
            truyen.NgayTao = DateTime.Now;
            truyen.DaXoa = false;
            truyen.AnhBia = filename;
            truyen.TenProject = collection["Name"];
            truyen.TenKhac = collection["OtherName"];
            truyen.MoTa = collection["MoTa"];
            truyen.TacGia = collection["TacGia"];
            data.Truyens.Add(truyen);
            data.SaveChanges();
            Truyen truyen1 = new Truyen();
            truyen1 = data.Truyens.SingleOrDefault(m => m.MaNguoiDung == truyen.MaNguoiDung && m.TenProject == truyen.TenProject);
            string theloais = collection["TheLoai"];
            

            string[] DSTheLoai = theloais.Split(new char[] { ',' });
            foreach (string s in DSTheLoai)
            {
                ChiTietTruyen ChiTiet = new ChiTietTruyen();
                TheLoai TheLoai = new TheLoai();
                TheLoai = data.TheLoais.SingleOrDefault(n => n.TenTheLoai == s);
                ChiTiet.MaTheLoai = TheLoai.MaTheLoai;
                ChiTiet.MaProject = truyen1.MaProject;
                data.ChiTietTruyens.Add(ChiTiet);
                data.SaveChanges();
            }


            return RedirectToAction("Index", "NguoiDung");
        }
        public ActionResult QuanLyTruyenDaTao(int ? page)
        {
            int pageNum = (page ?? 1);
            int pageSize = 7;
            return View(data.Truyens.ToList().OrderByDescending(a=>a.NgayTao).ToPagedList(pageNum,pageSize));
        }

        public ActionResult QuanLyChuong(int id,int ? page)
        {
            ViewBag.MaProject = id;
            int pageNum = (page ?? 1);
            int pageSize = 7;
            var chuongtruyen = (from chap in data.ChuongTruyens where chap.MaProject == id select chap).OrderByDescending(a => a.ThoiGianCapNhat).ToList();
            return View(chuongtruyen.ToPagedList(pageNum, pageSize));
        }
    }
}