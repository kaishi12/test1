using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Testing.Models;

namespace Testing.DAO
{
    public class DAONguoiDung
    {
        Model1 data = null;
        public DAONguoiDung()
        {
            data = new Model1();
        }
        public int Insert(NguoiDung nguoi)
        {
            data.NguoiDungs.Add(nguoi);
            data.SaveChanges();
            return nguoi.MaNguoiDung;
        }
        public int Login(string Tk, string MK)
        {
            var result = data.NguoiDungs.Count(n => n.Taikhoan == Tk && n.MatKhau == MK);
            if (result > 0)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }
        public bool CheckTk(string Tk)
        {
            return data.NguoiDungs.Count(n => n.Taikhoan == Tk) > 0;

        }
        public bool CheckEmail(string Email)
        {
            return data.NguoiDungs.Count(n => n.Email == Email) > 0;

        }
    }
}