using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyFramework.Project.DataAccess.Concrete.EntityFramework;

namespace MyFramework.Project.DataAccess.Tests.EntityFrameworkTests
{
    [TestClass]
    public class AccessTest
    {
        [TestMethod]
        public void Get_all_returns_haber()
        {
            EfHaberDal _dB = new EfHaberDal();
            var result = _dB.GetAll().ToList();
            Assert.AreEqual(3, result.Count());
        }

        [TestMethod]
        public void Get_all_returns_filtered_haber()
        {
            EfHaberDal _dB = new EfHaberDal();
            var result = _dB.GetAll().Where(i=>i.Baslik=="Bilgisayar").FirstOrDefault();
            Assert.AreEqual(null, result);
        }
    }
}
