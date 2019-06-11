using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Testing.Models;

namespace Testing.DAO
{
    public class DaoTrangTruyen
    {
        Model1 data = null;
        public DaoTrangTruyen()
        {
            data = new Model1();
        }
        public List<TrangTruyen> GetTrangTruyen(int id,int loaitrang)
        {
            var trangtruyens = data.TrangTruyens.Where(m => m.MaChuongTruyen == id && m.MaLoaiTrang == loaitrang).ToList();
            return trangtruyens;
        }
    }
}