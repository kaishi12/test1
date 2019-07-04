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
        public ChuongTruyen Laychuongtruoc(int maproject,int machuong)
        {
            var listchuongtruyen = data.ChuongTruyens.Where(m => m.MaProject == maproject).OrderBy(m => m.ThuTuChuong).ToList();
            var chuongtruyen = new ChuongTruyen();
            
            int i = 0;
            foreach (var item in listchuongtruyen)
            {
                if(item.MaChuongTruyen == machuong)
                {
                    if(i==0)
                    {
                        break;
                    }
                    else
                    {
                        chuongtruyen = listchuongtruyen[i-1];
                        return chuongtruyen;
                    }

                    
                }
                i++;
            }
            return null;
            
        }
        public ChuongTruyen LayChuongTruocTrongListBanDich(int machuong,List<ChuongTruyen> chuong)
        {
            var chuongtruyen = new ChuongTruyen();

            int i = 0;
            foreach (var item in chuong)
            {
                if (item.MaChuongTruyen == machuong)
                {
                    if (i == 0)
                    {
                        break;
                    }
                    else
                    {
                        chuongtruyen = chuong[i - 1];
                        return chuongtruyen;
                    }


                }
                i++;
            }
            return null;

        }
        public ChuongTruyen Laychuongsau(int maproject, int machuong)
        {
            var listchuongtruyen = data.ChuongTruyens.Where(m => m.MaProject == maproject).OrderBy(m => m.ThuTuChuong).ToList();
            var chuongtruyen = new ChuongTruyen();
            var count = listchuongtruyen.Count();
            int i = 0;
            foreach (var item in listchuongtruyen)
            {
                if (item.MaChuongTruyen == machuong)
                {

                    if (i != count-1)
                    {
                        chuongtruyen = listchuongtruyen[i+1];
                        return chuongtruyen;
                    }

                }
                i++;
            }
            return null;
        }
        public ChuongTruyen LayChuongSauTrongListBanDich(int machuong, List<ChuongTruyen> chuong)
        {
            var chuongtruyen = new ChuongTruyen();
            var count = chuong.Count();
            int i = 0;
            foreach (var item in chuong)
            {
                if (item.MaChuongTruyen == machuong)
                {

                    if (i != count - 1)
                    {
                        chuongtruyen = chuong[i + 1];
                        return chuongtruyen;
                    }

                }
                i++;
            }
            return null;

        }
        public List<ChuongTruyenDaTao> LayListChuongTruyen(int maproject)
        {
            var listtruyen = data.ChuongTruyens.Where(m => m.MaProject == maproject && m.DaXoa == false).OrderByDescending(a => a.ThuTuChuong).ToList();
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
            return chuongtruyens;
        }
        //public List<ChuongTruyen> LayListChuongTheoBanDich(int maproject,int mabandich)
        //{
        //    var listraw = data.ChuongTruyens.Where(m => m.MaProject == maproject).OrderBy(m=>m.ThuTuChuong).ToList();
        //    var listdich = new List<ChuongTruyen>();
           
            
        //    foreach(var item in listraw)
        //    {
        //        var listtrang = (from trang in data.TrangTruyens
        //                         join ctbd in data.ChiTietBanDichs
        //                         on trang.MaTrangTruyen equals ctbd.MaTrangTruyen
        //                         where trang.MaChuongTruyen == item.MaChuongTruyen && ctbd.MaBanDich == mabandich
        //                         select trang);
        //        if(listtrang.Count() >0)
        //        {
                    
        //            listdich.Add(item);
        //        }
        //    }
        //    if (listdich.Count != 0)
        //        return listdich;
        //    else
        //    return null;
        //}
        public List<TrangTruyen> ListTrangCvaR(int machuong)
        {
            var listc = data.TrangTruyens.Where(m => m.MaChuongTruyen == machuong && m.MaLoaiTrang == 4).ToList();
            var listr = data.TrangTruyens.Where(m => m.MaChuongTruyen == machuong && m.MaLoaiTrang == 2).ToList();
            var list = new List<TrangTruyen>();
            var count = listc.Count() - 1;
            for(int i = 0;i<listr.Count();i++)
            {
                int c = 0;
                TrangTruyen trang = new TrangTruyen();
                if (listc != null)
                {
                    foreach (var item in listc)
                    {

                        if (listr[i].ThuTu == item.ThuTu)
                        {
                            list.Add(item);
                            c++;

                            trang = item;
                        }
                    }
                    listc.Remove(trang);
                }
                if (c == 0)
                {
                    list.Add(listr[i]);
                }

            }
            return list;
        }
    }
}