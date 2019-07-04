using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Testing.DAO;
using Testing.Models;
using Testing.ViewModels;

namespace Testing.Controllers
{
    public class ChuongTruyenController : Controller
    {
        // GET: ChuongTruyen
        Model1 data = new Model1();
        public ActionResult Index(int id,string name,string loaitrang)
        { 
            DAO.DaoChuongTruyen chuong = new DAO.DaoChuongTruyen();
            var matruyen = chuong.GetMaTruyen(id);
            var chuongtruoc = chuong.Laychuongtruoc(matruyen, id);
            var chuongsau = chuong.Laychuongsau(matruyen, id);
            ViewBag.chuongtruoc = chuongtruoc;
            ViewBag.chuongsau = chuongsau;
            ViewBag.LoaiTrang = chuong.GetLoaiTrang();
            ViewBag.MaChuong = id;
            ViewBag.TenChuong = name;
            ViewBag.TenLoaiTrang = loaitrang;
            var chuongtruyen = data.TrangTruyens.Where(m => m.MaChuongTruyen == id && m.DaXoa==false && m.LoaiTrang.TenLoaiTrang == loaitrang).ToList();
            ViewBag.MaTruyen = matruyen;
            var list = chuong.LayListChuongTruyen(matruyen);
            ViewBag.ListChuong = list;
            return View(chuongtruyen);
        }
        public ActionResult TaoMoi(int id)
        {
            
            DaoChuongTruyen chuongtruyen = new DaoChuongTruyen();
            ViewBag.LoaiTrang = chuongtruyen.GetLoaiTrang();
            ViewBag.MaTruyen = id;
            return View();
        }
        [HttpPost]
        public ActionResult TaoMoi(int id, ChuongTruyenModel chuongtruyen,HttpPostedFileBase[] AnhTrang)
        {
            NguoiDung nguoi = (NguoiDung)Session["TaiKhoan"];
            DaoChuongTruyen chuongtruyen1 = new DaoChuongTruyen();
            ViewBag.LoaiTrang = chuongtruyen1.GetLoaiTrang();
            if (ModelState.IsValid)
            {
                int thutu = 0;
                DaoChuongTruyen daochuong = new DaoChuongTruyen();
                ChuongTruyen chuong = new ChuongTruyen(); 
                    chuong =  daochuong.Add(id, chuongtruyen.TenChuong, chuongtruyen.ThutuChuong);
                var result = daochuong.Insert(chuong);
                if(result> 0)
                {
                    string ThuTuTrangs = Request.Form["ThuTuTrang"];
                    string TenTrangs = Request.Form["TenTrang"];
                    string[] DsThuTuTrang = ThuTuTrangs.Split(new char[] { ',' });
                    
                    string[] DsTenTrangTrang = TenTrangs.Split(new char[] { ',' });
                    for (int i = 0; i < AnhTrang.Length;i++)
                    {
                       
                        var file1 = Path.GetFileName(AnhTrang[i].FileName);
                        var path = Path.Combine(Server.MapPath("~/Truyen"), file1);
                        AnhTrang[i].SaveAs(path);
                        TrangTruyen trang = new TrangTruyen();
                        trang.MaChuongTruyen = result;
                        trang.MaLoaiTrang = int.Parse(Request.Form["MaLoaiTrang"]);
                        trang.MaNguoiDung = nguoi.MaNguoiDung;
                        trang.ThuTu = int.Parse(DsThuTuTrang[i]);
                        trang.UrlAnh = file1;
                        trang.DaXoa = false;
                        trang.TenTrang = DsTenTrangTrang[i];
                        data.TrangTruyens.Add(trang);
                        data.SaveChanges();
                        thutu += 1;
                    }
                    return RedirectToAction("Index", "User");   
                }
                else
                    ModelState.AddModelError("", "Thêm chương mới thất bại");

            }
            else
            {
                ModelState.AddModelError("", "Yêu cầu Nhập đủ thông tin");
            }

            return RedirectToAction("Index", "User");
        }
        [HttpPost]
        public ActionResult ChinhSua(TrangTruyen model,HttpPostedFileBase fileupload)
        {
            var filename = Path.GetFileName(fileupload.FileName);
            var path = Path.Combine(Server.MapPath("~/Truyen"), filename);
            fileupload.SaveAs(path);
           
            var trang = data.TrangTruyens.SingleOrDefault(m => m.MaTrangTruyen == model.MaTrangTruyen);
            trang.UrlAnh = filename;
            data.SaveChanges();
            return RedirectToAction("Index", new { id = trang.MaChuongTruyen,name = Request.Form["Ten"], loaitrang = Request.Form["LoaiTrang"] });

        }
        [HttpPost]
        public ActionResult Xoa(TrangTruyen model)
        {
            var trang = data.TrangTruyens.SingleOrDefault(m => m.MaTrangTruyen == model.MaTrangTruyen);
            trang.DaXoa = true;
            data.SaveChanges();
            return RedirectToAction("Index", new { id = trang.MaChuongTruyen, name = Request.Form["Ten"], loaitrang = Request.Form["LoaiTrang"] });
        }
        public ActionResult CapNhatChuong(int id)
        {
            DaoChuongTruyen chuongtruyen = new DaoChuongTruyen();
            ViewBag.LoaiTrang = chuongtruyen.GetLoaiTrang();
            ViewBag.MaLoaiTrang = 0;

            ViewBag.Id = chuongtruyen.GetMaTruyen(id);
            return PartialView(chuongtruyen.GetChuongTruyenModel(id));
        }
        [HttpPost]
        public ActionResult CapNhatChuong(int id, ChuongTruyenModel chuongtruyen)
        {
            DaoChuongTruyen chuongtruyen1 = new DaoChuongTruyen();

            if(chuongtruyen1.Update(id, chuongtruyen.TenChuong, chuongtruyen.ThutuChuong)>0)
            {
                return RedirectToAction("Index", "User");
            }
            ViewBag.LoaiTrang = chuongtruyen1.GetLoaiTrang();
          
            ViewBag.id = id;
            return View();
        }
        public ActionResult CongCu(int matruyen,int machuong)
        {
            DAO.DaoChuongTruyen chuong = new DAO.DaoChuongTruyen();
            var list = chuong.LayListChuongTruyen(matruyen);
            ViewBag.ListChuong = list;
            ViewBag.Machuong = machuong;
            return PartialView();
        }
        public ActionResult CapNhatTrang(int id)
        {
            DaoChuongTruyen chuongtruyen = new DaoChuongTruyen();
            ViewBag.LoaiTrang11 = chuongtruyen.GetLoaiTrang();
            DAO.DaoTrangTruyen trangtruyens = new DAO.DaoTrangTruyen();
            ViewBag.TenChuong = data.ChuongTruyens.SingleOrDefault(m => m.MaChuongTruyen == id).TenChuongTruyen;
            ViewBag.id = id;
           
            ViewBag.MaTruyen = chuongtruyen.GetMaTruyen(id);
            return PartialView(trangtruyens.GetTrangTruyen(id,2));
        }
        [HttpPost]
        public ActionResult CapNhatTrang(HttpPostedFileBase[] AnhTrang)
        {
            string ThuTuTrangs = Request.Form["ThuTuTrang"];
            string TenTrangs = Request.Form["TenTrang"];
            string[] DsThuTuTrang = ThuTuTrangs.Split(new char[] { ',' });

            string[] DsTenTrangTrang = TenTrangs.Split(new char[] { ',' });
            for (int i = 0; i < AnhTrang.Length; i++)
            {

                var file1 = Path.GetFileName(AnhTrang[i].FileName);
                var path = Path.Combine(Server.MapPath("~/Truyen"), file1);
                AnhTrang[i].SaveAs(path);
                TrangTruyen trang = new TrangTruyen();
                trang.MaChuongTruyen = int.Parse(Request.Form["id"]);
                trang.MaLoaiTrang = 2;

                trang.ThuTu = int.Parse(DsThuTuTrang[i]);
                trang.UrlAnh = file1;
                trang.DaXoa = false;
                trang.TenTrang = DsTenTrangTrang[i];
                data.TrangTruyens.Add(trang);
                data.SaveChanges();
                
            }

            return RedirectToAction("QuanLyTruyenDaTao", "Truyen");

        }
    }
}