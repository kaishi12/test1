using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Testing.Models;
using PagedList.Mvc;
using PagedList;
namespace Testing.Controllers
{
    public class TimKiemController : Controller
    {
        Model1 data = new Model1();
       
        // GET: TimKiem
        [HttpPost]
        public ActionResult KetQuaTimKiem(FormCollection f,int ? page)
        {
            string sTuKhoa = f["txtTimKiem"].ToString();
            ViewBag.TuKhoa = sTuKhoa;
            List<Truyen> lstKQTK = data.Truyens.Where(n => n.TenProject.Contains(sTuKhoa)).ToList();

            //Phân trang
            int pageNum = (page ?? 1);
            int pageSize = 9;
            if (lstKQTK.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy kết quả";
            }
            ViewBag.ThongBao = "Đã tìm thấy " + lstKQTK.Count + " kết quả";
            return View(lstKQTK.OrderBy(n=>n.TenProject).ToPagedList(pageNum,pageSize));
        }

        [HttpGet]
        public ActionResult KetQuaTimKiem(string sTuKhoa, int? page)
        {
            ViewBag.TuKhoa = sTuKhoa;
            List<Truyen> lstKQTK = data.Truyens.Where(n => n.TenProject.Contains(sTuKhoa)).ToList();

            //Phân trang
            int pageNum = (page ?? 1);
            int pageSize = 9;
            if (lstKQTK.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy kết quả";
            }
            ViewBag.ThongBao = "Đã tìm thấy " + lstKQTK.Count + " kết quả";
            return View(lstKQTK.OrderBy(n => n.TenProject).ToPagedList(pageNum, pageSize));
        }
    }
}