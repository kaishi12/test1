using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Testing.Models;
using PagedList;
using PagedList.Mvc;
using System.IO;
using Testing.ViewModels;
using Testing.DAO;

namespace Testing.Controllers
{
    public class TruyenController : Controller
    {
        Model1 data = new Model1();
        // GET: Truyen
        public ActionResult Index()
        {
            if (!CheckSS())
                return RedirectToAction("DangNhap", "User");
            else
            {
                return View();
                }
        }
        public string ThemAnh(HttpPostedFileBase fileupload)
        {
            var filename = Path.GetFileName(fileupload.FileName);
            var path = Path.Combine(Server.MapPath("~/Truyen"), filename);
            fileupload.SaveAs(path);
            return filename;
        }
        public bool CheckSS()
        {
            if (Session["TaiKhoan"] == null)
                return false;
            else
                return true;
        }
        public ActionResult TaoMoi()
        {
           if(!CheckSS())
                return RedirectToAction("DangNhap", "User");
            else
            {
                DaoTruyen truyen = new DaoTruyen();
                DAO.DaoBanDich bandich = new DAO.DaoBanDich();
                ViewBag.NgonNgu = bandich.GetNgonNgu();
                ViewBag.TheLoai = truyen.LayTheLoai(); 
                ViewBag.TrangThai = truyen.LayTrangThai();
                return View();
            }
        }
        [HttpPost]
        public ActionResult TaoMoi(TruyenModel truyen,HttpPostedFileBase AnhBia)
        {
            DaoTruyen truyen2 = new DaoTruyen();
            ViewBag.TheLoai = truyen2.LayTheLoai();
            ViewBag.TrangThai = truyen2.LayTrangThai();
            if (ModelState.IsValid)
            {
               
                DaoCTTruyen ct = new DaoCTTruyen();
                NguoiDung nguoi = (NguoiDung)Session["TaiKhoan"];
                var truyen1 = new Truyen();
                truyen.AnhBia = ThemAnh(AnhBia);
                int maproject = truyen2.ThemVao(truyen2.Tao(truyen, nguoi));
                string theloais = Request.Form["DSTheLoai"];
                string[] DSTheLoai = theloais.Split(new char[] { ',' });

                if(ct.Get(DSTheLoai, maproject))
                    {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Lỗi");
                }
            }
           else
                ModelState.AddModelError("", "Yêu cầu nhập các trường bắt buộc");
            return View(truyen);

        }
        public ActionResult QuanLyTruyenDaTao()
        {
            if (!CheckSS())
                return RedirectToAction("DangNhap", "User");
            else
            {
                NguoiDung nguoi = (NguoiDung)Session["TaiKhoan"];
                List<TruyenDaTao> truyens = new List<TruyenDaTao>();
                var listtruyen = data.Truyens.Where(n => n.MaNguoiDung == nguoi.MaNguoiDung && n.DaXoa == false).ToList().OrderByDescending(a => a.NgayTao);
                foreach(var truyen in listtruyen)
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
        }
        [HttpPost]
        public ActionResult QuanLyTruyenDaTao(int? page,FormCollection formCollection)
        {
            string[] ids = formCollection["ID"].Split(new char[] { ',' });
            foreach (string id in ids)
            {
                var truyen = data.Truyens.Find(int.Parse(id));
                truyen.DaXoa = true;
                data.SaveChanges();
            }
            
            return RedirectToAction("QuanLyTruyenDaTao");

        }

        public ActionResult QuanLyChuong(int id)
        {
            if (!CheckSS())
                return RedirectToAction("DangNhap", "User");
            else
            {
                var tentruyen = data.Truyens.SingleOrDefault(m => m.MaProject == id).TenProject;
                ViewBag.TenTruyen = tentruyen;
                ViewBag.MaProject = id;
                //int pageNum = (page ?? 1);
                //int pageSize = 7;
                DAO.DaoChuongTruyen daoChuongTruyen = new DAO.DaoChuongTruyen();
                ViewBag.LoaiTrang = daoChuongTruyen.GetLoaiTrang();
                var list = daoChuongTruyen.LayListChuongTruyen(id);
                return View(list);
            }
        }
        [HttpPost]
        public ActionResult QuanLyChuong(int id,int? page, FormCollection formCollection)
        {
            
            string[] ids = formCollection["ID"].Split(new char[] { ',' });
            foreach (string id1 in ids)
            {
                var truyen = data.ChuongTruyens.Find(int.Parse(id1));
                truyen.DaXoa = true;
                data.SaveChanges();
            }
            var maproject = data.ChuongTruyens.SingleOrDefault(m => m.MaChuongTruyen == id).MaProject;
            return RedirectToAction("QuanLyChuong", new { id = maproject });
            //return View(chuongtruyens.ToPagedList(pageNum, pageSize));

        }
        public ActionResult CapNhatTruyen(int id)
        {
            if (!CheckSS())
                return RedirectToAction("DangNhap", "User");
            else
            {
                DaoTruyen truyen = new DaoTruyen();
                DaoCTTruyen ct = new DaoCTTruyen();
                ViewBag.TheLoai = truyen.LayTheLoai();
                ViewBag.TrangThai = truyen.LayTrangThai();
                
                return View(truyen.LayTruyenModel(id, ct.GetTheLoai(id)));
            }
           
        }
        [HttpPost]
        public ActionResult CapNhatTruyen(int id,TruyenModel model, HttpPostedFileBase fileupload)
        {

            DaoTruyen truyen2 = new DaoTruyen();
            ViewBag.TheLoai = truyen2.LayTheLoai();
            ViewBag.TrangThai = truyen2.LayTrangThai();
            if (ModelState.IsValid)
            {
                if(fileupload != null)
                {
                    model.AnhBia = ThemAnh(fileupload);
                }
               
                int maproject = -1;
                maproject = truyen2.CapNhat(id, model);
                if(maproject == -1)
                {
                    ModelState.AddModelError("", "Chỉnh sửa thất bại");
                }
                else
                {
                  
                    
                    DaoCTTruyen ct = new DaoCTTruyen();
                    if (ct.Update(model.DStheloai, maproject))
                        return RedirectToAction("QuanLyTruyenDaTao", "Truyen");
                    else
                        ModelState.AddModelError("", "Chỉnh sửa thể loại thất bại");
                }
                
            }
            else
                ModelState.AddModelError("", "Nhập các thông tin bắt buộc");
            return View(model);

        }
      
    }
}