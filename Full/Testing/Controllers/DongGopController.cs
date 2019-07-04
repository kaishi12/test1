using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Testing.Models;
using Testing.ViewModels;

namespace Testing.Controllers
{
    public class DongGopController : Controller
    {
        Model1 data = new Model1();
        // GET: DongGop
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DanhSachTruyen()
        {
            List<TruyenDaTao> truyens = new List<TruyenDaTao>();
           
            var listtruyen = data.Truyens.ToList();
             foreach (var truyen in listtruyen)
            {
                TruyenDaTao truyen1 = new TruyenDaTao();
                truyen1.MaProject = truyen.MaProject;
                truyen1.AnhBia = truyen.AnhBia;
                truyen1.TenTruyen = truyen.TenProject;
                truyen1.TacGia = truyen.TacGia;
                truyen1.TrangThai = truyen.TrangThai1.TenTrangThai;
                truyen1.NgayTao = truyen.NgayTao.ToShortDateString();
                 
                truyens.Add(truyen1);
               

            }
            return View(truyens);
        }
       public ActionResult DanhSachChuong(int id)
        {
            DAO.DaoChuongTruyen dao = new DAO.DaoChuongTruyen();
            var list = dao.LayListChuongTruyen(id);
            return View(list);
        }
        [HttpPost]
        public ActionResult Upload(TrangTruyen model, HttpPostedFileBase fileupload)
        {
            var nguoi = (NguoiDung)Session["TaiKhoan"];
            
            var filename = Path.GetFileName(fileupload.FileName);
            var path = Path.Combine(Server.MapPath("~/Truyen"), filename);
            fileupload.SaveAs(path);
            TrangTruyen trang = new TrangTruyen();
            if(model.MaLoaiTrang == 2)
            {
                trang.MaNguoiDung = nguoi.MaNguoiDung;
                trang.MaLoaiTrang = 4;
                trang.TenTrang = model.TenTrang;
                trang.ThuTu = model.ThuTu;
                trang.UrlAnh = filename;
                trang.MaChuongTruyen = model.MaChuongTruyen;
                trang.DaXoa = false;
                data.TrangTruyens.Add(trang);
                
            }
            else
            {
                var trang1 = data.TrangTruyens.SingleOrDefault(m => m.MaTrangTruyen == model.MaTrangTruyen);
                trang1.UrlAnh = filename;
               
            }
            data.SaveChanges();
            return RedirectToAction("UploadCleartext", new { id=model.MaChuongTruyen});

        }
        public ActionResult UploadCleartext(int id)
        {
            
            var list = new List<TrangTruyen>();
            DAO.DaoChuongTruyen dao = new DAO.DaoChuongTruyen();
            list = dao.ListTrangCvaR(id);
            return View(list);
        }
       
    }
}