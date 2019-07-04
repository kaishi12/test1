using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Testing.Models;
using PagedList;
using PagedList.Mvc;


namespace Testing.Controllers
{
    public class HomeController : Controller
    {
        Model1 data = new Model1();
        public ActionResult Index(int? page)
        {
            int pageSize = 12;
            int pageNum = (page ?? 1);

            var webtruyen = (from tr in data.Truyens
                             join chap in data.ChuongTruyens
                             on tr.MaProject equals chap.MaProject
                             where tr.DaXoa == false
                             group new { tr, chap } by new { tr.MaProject, tr.TenProject, tr.AnhBia, tr.MoTa, tr.TacGia } into grp
                             select new ViewModels.TruyenMoiCapNhat
                             {
                                 MaProject = grp.Key.MaProject,
                                 TenProject = grp.Key.TenProject,
                                 AnhBia = grp.Key.AnhBia,
                                 MoTa = grp.Key.MoTa,
                                 TacGia = grp.Key.TacGia,
                                 MabanDich = data.BanDiches.Where(m => m.MaProject == grp.Key.MaProject).FirstOrDefault().MaBanDich,
                                 ThoiGianCapNhat = grp.Max(a => a.chap.ThoiGianCapNhat)
                             }).OrderByDescending(a => a.ThoiGianCapNhat).ToList();
            //var webtruyen = data.Truyens.OrderByDescending(a=>a.NgayTao).ToList();
            return View(webtruyen.ToPagedList(pageNum, pageSize));
        }

        private int TongLuotXem(int id)
        {
            int Tong = 0;
            var sl = (from chap in data.ChuongTruyens where chap.MaProject == id select chap).ToList();
            Tong = sl.Sum(n => n.LuotXem);
            return Tong;
        }

        public ActionResult TongLuotView(int id)
        {
            int project = (from tr in data.Truyens where tr.MaProject == id select tr.MaProject).First();
            ViewBag.View = TongLuotXem(project);
            return PartialView();
        }

        public ActionResult ChuongTruyenMoi(int id,int? mabandich)
        {
            if(mabandich!=null)
            ViewBag.Mabandich = mabandich;
            
            var chuongtruyenmoi = (from chap in data.ChuongTruyens where chap.MaProject == id select chap).OrderByDescending(a => a.ThuTuChuong).Take(1).ToList();
            return PartialView(chuongtruyenmoi.Single());
        }

        public ActionResult ThongTinTruyen(int id,string name)
        {
            ViewBag.MaTruyen = id;
            var xemtruyen = from tr in data.Truyens where tr.MaProject == id select tr;
            var dao = new DAO.DaoBanDich();
            ViewBag.MaBanDich = name;
            ViewBag.BanDich = dao.LayBanDichCuaTruyen(id);
            return View(xemtruyen.Single());
        }

        public ActionResult TheLoaiTruyen(int id)
        {
            var theloai = (from tr in data.Truyens
                           join ctt in data.ChiTietTruyens on tr.MaProject equals ctt.MaProject
                           join tl in data.TheLoais on ctt.MaTheLoai equals tl.MaTheLoai
                           where tr.MaProject == id
                           select tl).ToList();
            return PartialView(theloai);
        }

        public ActionResult ChuongTruyen(int id,string name)
        {
            var dao = new DAO.DaoChuongTruyen();
            ViewBag.Mabandich = name;
            //var list = dao.LayListChuongTheoBanDich(id, int.Parse(name));
            
            return PartialView();
        }

        public ActionResult TheLoai()
        {
            var theloai = (from tl in data.TheLoais select tl).OrderBy(a => a.TenTheLoai).ToList();
            return PartialView(theloai);
        }

        public ActionResult TruyenTheoTheLoai(int id, int? page)
        {
            int pageSize = 12;
            int pageNum = (page ?? 1);

            var truyen = (from tr in data.Truyens
                          join chap in data.ChuongTruyens
                          on tr.MaProject equals chap.MaProject
                          join ctt in data.ChiTietTruyens on tr.MaProject equals ctt.MaProject
                          where ctt.MaTheLoai == id
                          group new { tr, chap } by new { tr.MaProject, tr.TenProject, tr.AnhBia, tr.TacGia, tr.MoTa } into grp
                          select new ViewModels.TruyenTheoTheLoai
                          {
                              MaProject = grp.Key.MaProject,
                              TenProject = grp.Key.TenProject,
                              AnhBia = grp.Key.AnhBia,
                              TacGia = grp.Key.TacGia,
                              MoTa = grp.Key.MoTa,
                          }).OrderByDescending(a => a.TenProject).ToList();
            if (truyen.Count == 0)
            {
                ViewBag.ThongBao = "Chưa có truyện thuộc thể loại này";
            }

            ViewBag.TheLoai = (from tl in data.TheLoais where tl.MaTheLoai == id select tl.TenTheLoai).First();
            ViewBag.MaTheLoai = (from tl in data.TheLoais where tl.MaTheLoai == id select tl.MaTheLoai).First();

            return View(truyen.ToPagedList(pageNum, pageSize));
        }

        public ActionResult TruyenNoiBat(int? page)
        {
            int pageSize = 12;
            int pageNum = (page ?? 1);

            var truyen = (from tr in data.Truyens
                          join chap in data.ChuongTruyens on tr.MaProject equals chap.MaProject
                          group new { tr, chap } by new { tr.MaProject, tr.TenProject, tr.AnhBia, tr.TacGia, tr.MoTa } into grp
                          where grp.Sum(a => a.chap.LuotXem) > 900
                          select new ViewModels.TruyenNoiBat
                          {
                              MaProject = grp.Key.MaProject,
                              TenProject = grp.Key.TenProject,
                              AnhBia = grp.Key.AnhBia,
                              TacGia = grp.Key.TacGia,
                              MoTa = grp.Key.MoTa,
                              LuotXem = grp.Sum(a => a.chap.LuotXem)
                          }).OrderByDescending(a => a.LuotXem).ToList();
            return View(truyen.ToPagedList(pageNum, pageSize));
        }

        public ActionResult TruyenTheoTacGia(string tacgia, int? page)
        {
            int pageSize = 12;
            int pageNum = (page ?? 1);
            ViewBag.Tacgia = tacgia;
            var truyen = (from tr in data.Truyens
                          where tr.TacGia == tacgia
                          select tr).OrderByDescending(a => a.NgayTao).ToList();
            return View(truyen.ToPagedList(pageNum, pageSize));
        }

        public ActionResult XemTruyen(int id, int chuong,string mabandich)
        {
            string TenTruyen = (from tr in data.Truyens where tr.MaProject == id select tr.TenProject).First();
            ViewBag.Mabandich = mabandich;
            var dao = new DAO.DaoBanDich();
            //var chuong1 = dao.LayChuong(chuong,int.Parse(mabandich));
            ViewBag.TenTruyen = TenTruyen;
            ViewBag.MaTruyen = id;
            ViewBag.MaChuong = chuong;
            
            return View();
        }

        public ActionResult ChonTruyen(int id, int chuong,string mabandich)
        {
            ViewBag.matruyen = id;
            ViewBag.MaChuong = chuong;
            ViewBag.Mabandich = mabandich;
            DAO.DaoChuongTruyen dao = new DAO.DaoChuongTruyen();
            //var list = dao.LayListChuongTheoBanDich(id, int.Parse(mabandich));
            //var chuongtruoc = dao.LayChuongTruocTrongListBanDich(chuong,list);
            //var chuongsau = dao.LayChuongSauTrongListBanDich(chuong,list);
            //ViewBag.chuongtruoc = chuongtruoc;
            //ViewBag.chuongsau = chuongsau;
            //ViewBag.listchuong = list;

            return PartialView();
        }
        public ActionResult TruyenMoi()
        {
            var webtruyen = (from tr in data.Truyens
                             join chap in data.ChuongTruyens
                             on tr.MaProject equals chap.MaProject
                             where tr.DaXoa == false
                             group new { tr, chap } by new { tr.MaProject, tr.TenProject, tr.AnhBia, tr.MoTa, tr.TacGia } into grp
                             select new ViewModels.TruyenMoiCapNhat
                             {
                                 MaProject = grp.Key.MaProject,
                                 TenProject = grp.Key.TenProject,
                                 AnhBia = grp.Key.AnhBia,
                                 MoTa = grp.Key.MoTa,
                                 TacGia = grp.Key.TacGia,
                                 MabanDich = data.BanDiches.Where(m => m.MaProject == grp.Key.MaProject).FirstOrDefault().MaBanDich,
                                 ThoiGianCapNhat = grp.Max(a => a.chap.ThoiGianCapNhat)
                             }).OrderByDescending(a => a.ThoiGianCapNhat).ToList();
            return PartialView(webtruyen);
        }
    }
}