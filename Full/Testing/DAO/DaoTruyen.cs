using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Testing.Models;
using Testing.ViewModels;

namespace Testing.DAO
{
    public class DaoTruyen
    {
        Model1 data = null;
        public DaoTruyen()
        {
            data = new Model1();
        }
        public int ThemVao(Truyen truyen)
        {
            data.Truyens.Add(truyen);
            data.SaveChanges();
            return truyen.MaProject;
        }
        public Truyen Tao(TruyenModel truyen,NguoiDung nguoi)
        {
            Truyen truyendangtao = new Truyen();


            truyendangtao.TrangThai = truyen.MaTrangThai;
            truyendangtao.NgayTao = DateTime.Now;
            truyendangtao.DaXoa = false;
            truyendangtao.AnhBia = truyen.AnhBia;
            truyendangtao.TenProject = truyen.TenTruyen;
            truyendangtao.TenKhac = truyen.TenKhac;
            truyendangtao.MoTa = truyen.MoTa;
            truyendangtao.TacGia = truyen.Tacgia;
            truyendangtao.MaNguoiDung = nguoi.MaNguoiDung;
        
            return truyendangtao;
        }
        public List<TrangThaiModel> LayTrangThai()
        {
            var list = (from trang in data.TrangThais
                        select new TrangThaiModel
                        {
                            Matrangthai = (int)trang.MaTrangThai,
                            Tentrangthai = (string)trang.TenTrangThai

                        }).ToList();
            return list;
        }
        public List<TheLoaiModel> LayTheLoai()
        {
            var list = (from the in data.TheLoais where the.DaXoa == false
                        select new TheLoaiModel
                        {
                            MaTheLoai = (int)the.MaTheLoai,
                           TenTheLoai = (string)the.TenTheLoai

                        } ).ToList();
            return list;
        }
        
        public TruyenModel LayTruyenModel(int id,int[] theloai)
        {
            Truyen truyen = data.Truyens.SingleOrDefault(m => m.MaProject == id);
            TruyenModel truyen1 = new TruyenModel();
            truyen1.MoTa = truyen.MoTa;
            truyen1.Tacgia = truyen.TacGia;
            truyen1.MaTrangThai = truyen.TrangThai;
            truyen1.TenKhac = truyen.TenKhac;
            truyen1.TenTruyen = truyen.TenProject;
            truyen1.AnhBia = truyen.AnhBia;
            truyen1.DStheloai = theloai;
            return truyen1;
        }
        public int CapNhat(int id,TruyenModel truyen)
        {
            Truyen truyendangupdate = data.Truyens.SingleOrDefault(m => m.MaProject == id);
            truyendangupdate.MoTa = truyen.MoTa;
            truyendangupdate.TacGia = truyen.Tacgia;
            truyendangupdate.TenKhac = truyen.TenKhac;
            truyendangupdate.TenProject = truyen.TenTruyen;
            truyendangupdate.TrangThai = truyen.MaTrangThai;
            truyendangupdate.AnhBia = truyen.AnhBia;
            data.SaveChanges();
            return truyendangupdate.MaProject;
        }
        public BanDichModel LayBanDichModel(int manguoidung,int maproject,int mangonngu)
        {
            BanDichModel bandich = new BanDichModel();
           
            bandich.MaNgonNgu = mangonngu;
            bandich.MaNguoiDung = manguoidung;
            bandich.MaProject = maproject;
            return bandich;
        }
    }
}