using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Testing.Models;
using Testing.ViewModels;

namespace Testing.DAO
{
    public class DaoChuongTruyen
    {
        Model1 data = null;
        public DaoChuongTruyen()
            {
            data = new Model1();
            }
        //Thêm chương//
        //Ryu//
        public int Insert(ChuongTruyen chuong)
        {
            data.ChuongTruyens.Add(chuong);
            data.SaveChanges();
            return chuong.MaChuongTruyen;
        }
        public ChuongTruyenModel GetChuongTruyenModel(int id)
        {
            var chuongtruyen = data.ChuongTruyens.SingleOrDefault(m => m.MaChuongTruyen == id);
            ChuongTruyenModel chuong = new ChuongTruyenModel();
            chuong.MaChuong = chuongtruyen.MaChuongTruyen;
            chuong.TenChuong = chuongtruyen.TenChuongTruyen;
            chuong.ThutuChuong = chuongtruyen.ThuTuChuong;
            TrangTruyen trang = data.TrangTruyens.Where(m => m.MaChuongTruyen == id).First();
            chuong.MaLoaiTrang = trang.MaLoaiTrang;
            chuong.Trangstruyen = data.TrangTruyens.Where(m => m.MaChuongTruyen == id).ToList();
            return chuong;
        }
        public ChuongTruyen Add(int maproject,string tenchuong,int thutu)
        {
            ChuongTruyen chuong = new ChuongTruyen();
            chuong.MaProject = maproject;
            chuong.LuotXem = 0;
            chuong.DaXoa = false;
            chuong.TenChuongTruyen = tenchuong;
            chuong.ThoiGianCapNhat = DateTime.Now;
            chuong.ThuTuChuong = thutu;
            return chuong;
        }
        public int Update(int machuongtruyen, string tenchuong,int thutuchuong)
        {
            ChuongTruyen chuong = data.ChuongTruyens.SingleOrDefault(n => n.MaChuongTruyen == machuongtruyen); 
            chuong.TenChuongTruyen = tenchuong;
            chuong.ThoiGianCapNhat = DateTime.Now;
            chuong.ThuTuChuong = thutuchuong;
            
            data.SaveChanges();
            return chuong.MaChuongTruyen;

        }
        public int check(int machuongtruyen,int id)
        {


           var check = (from nguoi in data.NguoiDungs
                         join truyen in data.Truyens on nguoi.MaNguoiDung equals truyen.MaNguoiDung
                         where nguoi.MaNguoiDung == id
                         join chuongtruyen in data.ChuongTruyens on truyen.MaProject equals chuongtruyen.MaProject
                         where chuongtruyen.MaChuongTruyen == machuongtruyen
                         select chuongtruyen).ToList();
            if (check.Count > 0)
                return 1;
            else
                return 2;
        }
        public List<LoaiTrangModel> GetLoaiTrang()
        {
            var list = (from trang in data.LoaiTrangs
                        select new LoaiTrangModel
                        {
                            MaLoaiTrang = (int)trang.MaLoaiTrang,
                            TenLoaiTrang = (string)trang.TenLoaiTrang

                        }).ToList();
            return list;
        }
        public int GetMaTruyen(int machuong)
        {
            var truyen = data.ChuongTruyens.SingleOrDefault(m => m.MaChuongTruyen == machuong);
            var matruyen = truyen.MaProject;
            return matruyen;
        }
    }
}