using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Testing.Models;
using Testing.ViewModels;

namespace Testing.DAO
{
    public class DaoCTTruyen
    {
        Model1 data = null;
        public DaoCTTruyen()
        {
            data = new Model1();
        }
        public bool Insert(int matheloai,int maproject)
        {
            ChiTietTruyen ct = new ChiTietTruyen();

            
                ct.MaTheLoai = matheloai;
            ct.MaProject = maproject;
            
            data.ChiTietTruyens.Add(ct);
            data.SaveChanges();
            return true;
        }
        public bool Get(string[] text,int maproject)
        {
            foreach (string s in text)
            {
                if (!Insert(int.Parse(s), maproject))
                    return false;
            }
            return true;
        }
        public bool Update(int[] text,int maproject)
        {
            var ChiTiet = data.ChiTietTruyens.Where(m => m.MaProject == maproject).ToList();
            //thêm vào
            foreach (int s in text)
            {
                int them = 0;
                int matheloai = s;
                foreach (var chitiet in ChiTiet)
                {
                    if (chitiet.MaTheLoai == matheloai)
                    {
                        them++;
                    }
                }
                if (them == 0)
                {
                    ChiTietTruyen chitiet1 = new ChiTietTruyen();
                    chitiet1.MaTheLoai = matheloai;
                    chitiet1.MaProject = maproject;
                    data.ChiTietTruyens.Add(chitiet1);
                    data.SaveChanges();
                }

            }
            //
            //Xoá đi
            foreach (var chitiet in ChiTiet)
            {
                int xoa = 0;
                foreach (int s in text)
                {
                    int matheloai = s;
                    if (chitiet.MaTheLoai == matheloai)
                    {
                        xoa++;
                    }

                }
                if (xoa == 0)
                {
                    data.ChiTietTruyens.Remove(chitiet);
                    data.SaveChanges();
                }
                
            }
            return true;
        }
        public int[] GetTheLoai(int id)
        {
            var theloai = (from the in data.ChiTietTruyens where the.MaProject == id select the.MaTheLoai).ToArray();
            return theloai;
        }
    }
}