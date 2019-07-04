using Microsoft.VisualStudio.TestTools.UnitTesting;
using Testing.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing.DAO.Tests
{
    [TestClass()]
    public class DAONguoiDungTests
    {
        
        [TestMethod()]
        public void LoginTest()
        {
            var dao = new DAO.DAONguoiDung();
            string taikhoan = "hieugat1234";
            string matkhau = dao.CreateMD5("123");
            var result = dao.Login(taikhoan, matkhau);
            Assert.AreEqual(1, result);
        }
        [TestMethod()]
        public void CheckTkTest()
        {
            var dao = new DAO.DAONguoiDung();
            string taikhoan = "hieugat1234";
            var result = dao.CheckTk(taikhoan);
            Assert.AreEqual(true, result);
        }
    }
}