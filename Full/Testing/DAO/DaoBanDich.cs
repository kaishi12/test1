using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Testing.Models;
using Testing.ViewModels;

namespace Testing.DAO
{
    public class DaoBanDich
    {
        Model1 data = null;
        public DaoBanDich()
        {
            data = new Model1();
        }
        //đưa thông tin từ model vào bản dịch//
        //Ryu//
        public BanDich GetBanDich(BanDichModel model)
        {
            BanDich BanDich = new BanDich();
            BanDich.DaXoa = false;
            BanDich.MaNgonNgu = model.MaNgonNgu;
            BanDich.MaProject = model.MaProject;
            BanDich.MaNguoiDung = model.MaNguoiDung;
            
            return BanDich;
        }
        //Thêm//
        //Ryu//
        public int Add(BanDich ban)
        {
            data.BanDiches.Add(ban);
            data.SaveChanges();
            return ban.MaBanDich;
        }
        //Lấy tên truyện//
        //Ryu//
        public string GetTenTruyen(int id)
        {
            string tentruyen = data.Truyens.Single(m => m.MaProject == id).TenProject;
            return tentruyen;
        }
        //Lấy danh sách người dùng//
        //Ryu//
        public List<User> GetNguoiDung()
        {
            var list = (from the in data.NguoiDungs
                       
                        select new User
                        {
                            MaUser = (int)the.MaNguoiDung,
                            TenUser = (string)the.Taikhoan

                        }).ToList();
            return list;
        }
        public int LayMaNguoiQuanliTruyen(int id)
        {
            var ma = data.ChuongTruyens.SingleOrDefault(m => m.MaChuongTruyen == id).Truyen.MaNguoiDung;
            return ma;
        }
        public int LayMaNguoiQuanLiBanDich(int id)
        {
            var ma = data.BanDiches.SingleOrDefault(m => m.MaBanDich == id).MaNguoiDung;
            return ma;
        }
        //Lấy danh sách ngôn ngữ//
        //Ryu//
        public List<NgonNguModel> GetNgonNgu()
        {
            var list = (from the in data.NgonNgus

                        select new NgonNguModel
                        {
                            MaNgonNgu = (int)the.MaNgonNgu,
                            TenNgonNgu = (string)the.TenNgonNgu

                        }).ToList();
            return list;
        }
        // Lấy danh sách ngôn ngữ đã có bản dịch//
        //Ryu//
        public int[] GetBanDichDaCo(int id)
        {
            var mabandich = (from bandich in data.BanDiches
                             where bandich.MaProject == id
                             select bandich.MaNgonNgu).ToArray();
            return mabandich;
        }
        //lấy danh sách bản dịch user đang quản lí//
        //Ryu//
        public List<BanDich> GetBanDichDangQuanLi(int id)
        {
            var bandich1 = (from bandich in data.BanDiches
                           where bandich.MaNguoiDung == id
                           select bandich).ToList();
            return bandich1;
        }
        //lấy ra chương gồm : các trang dịch và không dịch trong cùng 1 chương //
        //Ryu//
        //public List<TrangTruyenModel> LayChuong(int machuong,int mabandich)
        //{
        //    var listraw = (from trang in data.TrangTruyens where trang.MaChuongTruyen == machuong && trang.MaLoaiTrang == 2
        //                   select new ViewModels.TrangTruyenModel
        //                   {
        //                       MaTrang = trang.MaTrangTruyen,
        //                       ThuTuTrang = trang.ThuTu,
        //                       TenTrang = trang.TenTrang,
        //                       Anh = trang.UrlAnh
        //                   }).OrderBy(a => a.ThuTuTrang).ToList();
        //    var listdich = (from trang in data.TrangTruyens
        //                    join ct in data.ChiTietBanDichs on trang.MaTrangTruyen equals ct.MaTrangTruyen
        //                    join bandich in data.BanDiches on ct.MaBanDich equals bandich.MaBanDich
        //                    where trang.MaChuongTruyen == machuong && bandich.MaBanDich == mabandich
        //                    select new ViewModels.TrangTruyenModel
        //                    {
        //                        MaTrang = trang.MaTrangTruyen,
        //                        ThuTuTrang = trang.ThuTu,
        //                        TenTrang = trang.TenTrang,
        //                        Anh = trang.UrlAnh
        //                    }).OrderBy(a=>a.ThuTuTrang).ToList();
        //    var list = new List<TrangTruyenModel>();
        //    var count = listraw.Count();
        //    for (int i = 0;i< count;i++)
        //    {
        //        int c = 0;
        //        TrangTruyenModel trang = new TrangTruyenModel();
        //        if(listdich!=null)
        //        {
        //            foreach (var item in listdich)
        //            {

        //                if (listraw[i].ThuTuTrang == item.ThuTuTrang)
        //                {
        //                    list.Add(item);
        //                    c++;

        //                    trang = item;
        //                }
        //            }
        //            listdich.Remove(trang);
        //        }
               
               
              
        //        if (c== 0)
        //        {
        //            list.Add(listraw[i]);
        //        }
               
        //    }
        //    return list;
        //}
        public List<BanDich> LayBanDichCuaTruyen(int maproject)
        { 
            var list = (from bandich in data.BanDiches where bandich.MaProject == maproject select bandich).ToList();
            return list;
        }
    }
}