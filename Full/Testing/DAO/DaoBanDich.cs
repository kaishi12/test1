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
            BanDich.TenBanDich = model.TenBanDich;
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
    }
}