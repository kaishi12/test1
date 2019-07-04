using PagedList;
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
    public class BanDichController : Controller
    {
      
        Model1 data = new Model1();
        public ActionResult index(int id,string name)
        {
            
            var mabandich = int.Parse(name);
            DAO.DaoBanDich bd = new DAO.DaoBanDich();
            DAO.DaoChuongTruyen dao = new DAO.DaoChuongTruyen();
            var matruyen = dao.GetMaTruyen(id);
           
            
            return View();
        }
        public bool CheckSS()
        {
            if (Session["TaiKhoan"] == null)
                return false;
            else
                return true;
        }
        // GET: BanDich
        public ActionResult QuanLy()
        {
            if (!CheckSS())
                return RedirectToAction("DangNhap", "User");
            else
            {
                NguoiDung nguoi = (NguoiDung)Session["TaiKhoan"];
                DAO.DaoBanDich bandich0 = new DAO.DaoBanDich();
                List<BanDich> bandich = bandich0.GetBanDichDangQuanLi(nguoi.MaNguoiDung);
               
                return View(bandich);
            }

        }
        public ActionResult ThemMoi(int id)
        {
            if (!CheckSS())
                return RedirectToAction("DangNhap", "User");
            else
            {
                DAO.DaoBanDich bandich = new DAO.DaoBanDich();
                ViewBag.TenTruyen = bandich.GetTenTruyen(id);
                ViewBag.NgonNgu = bandich.GetNgonNgu();
                ViewBag.User = bandich.GetNguoiDung();
                ViewBag.DsBanDich = bandich.GetBanDichDaCo(id);
                ViewBag.id = id;
               
                return View();
            }
        }
        [HttpPost]
        public ActionResult ThemMoi(BanDichModel model)
        {
            DAO.DaoBanDich bandich = new DAO.DaoBanDich();
            ViewBag.TenTruyen = bandich.GetTenTruyen(model.MaProject);
            ViewBag.NgonNgu = bandich.GetNgonNgu();
            ViewBag.User = bandich.GetNguoiDung();
            ViewBag.id = model.MaProject;
            if (ModelState.IsValid)
            {
                if (bandich.Add(bandich.GetBanDich(model)) > 0)
                {
                    return RedirectToAction("QuanLyTruyenDaTao", "Truyen");
                }
            }

            return View(model);
        }
        public ActionResult DanhSachChuong(int id,string name)
        {
            if (!CheckSS())
                return RedirectToAction("DangNhap", "User");
            else
            {
                var tentruyen = data.Truyens.SingleOrDefault(m => m.MaProject == id).TenProject;
                ViewBag.TenTruyen = tentruyen;
                ViewBag.MaProject = id;
                ViewBag.Tenbandich = name;
                //int pageNum = (page ?? 1);
                //int pageSize = 7;
                DAO.DaoChuongTruyen daoChuongTruyen = new DAO.DaoChuongTruyen();
                ViewBag.LoaiTrang = daoChuongTruyen.GetLoaiTrang();
                var listtruyen = data.ChuongTruyens.Where(m => m.MaProject == id && m.DaXoa == false).OrderByDescending(a => a.ThuTuChuong).ToList();
                List<ChuongTruyenDaTao> chuongtruyens = new List<ChuongTruyenDaTao>();

                foreach (var truyen in listtruyen)
                {
                    ChuongTruyenDaTao chuongtruyen1 = new ChuongTruyenDaTao();
                    chuongtruyen1.TenChuong = truyen.TenChuongTruyen;
                    DateTime Tgcn = truyen.ThoiGianCapNhat;
                    var month = new DateDifference(Tgcn, DateTime.Now);

                    chuongtruyen1.Thoigian = month.ToString();
                    chuongtruyen1.LuotXem = truyen.LuotXem;
                    chuongtruyen1.MaChuong = truyen.MaChuongTruyen;
                    chuongtruyens.Add(chuongtruyen1);

                }
                return View(chuongtruyens);

            }
        }
       
    }
}