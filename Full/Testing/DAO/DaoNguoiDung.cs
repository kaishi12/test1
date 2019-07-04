using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Testing.Models;
using Testing.ViewModels;

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
        public string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
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
        public ThongTinCaNhan GetTTCN(string tk)
        {
            var nguoi = data.NguoiDungs.SingleOrDefault(m => m.Taikhoan == tk);
            ThongTinCaNhan tt = new ThongTinCaNhan();
            tt.AnhDaiDien = nguoi.AnhDaiDien;
            tt.Email = nguoi.Email;
            tt.SoDienThoai = nguoi.SoDienThoai;
            tt.Ma = nguoi.MaNguoiDung;
            return tt;
        }
        public string GetMatKhau(string tk)
        {
            var nguoi = data.NguoiDungs.SingleOrDefault(m => m.Taikhoan == tk);
            return nguoi.MatKhau;
        }
        public string UpdateMatKhau(string tk,string mk)
        {
            var nguoi = data.NguoiDungs.SingleOrDefault(m => m.Taikhoan == tk);
            nguoi.MatKhau = mk;
            data.SaveChanges();
            return nguoi.Taikhoan;
        }
        public string UpdateThongTinCaNhan(ThongTinCaNhan tt)
        {
            NguoiDung nguoi = data.NguoiDungs.SingleOrDefault(m => m.MaNguoiDung == tt.Ma);
            nguoi.AnhDaiDien = tt.AnhDaiDien;
            nguoi.Email = tt.Email;
            nguoi.SoDienThoai = tt.SoDienThoai;
            data.SaveChanges();
            
            return nguoi.Taikhoan;
        }
    }
}