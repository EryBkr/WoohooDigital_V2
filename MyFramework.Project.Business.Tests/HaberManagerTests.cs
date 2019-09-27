using System;
using FluentValidation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyFramework.Project.Business.Concrete.Managers;
using MyFramework.Project.DataAccess.Abstract;
using MyFramework.Project.Entities.Concrete;

namespace MyFramework.Project.Business.Tests
{
    [TestClass]
    public class HaberManagerTests
    {
        [ExpectedException(typeof(ValidationException))]
        [TestMethod]
        public void Haber_validation_check()
        {
            Mock<IHaberDal> mock = new Mock<IHaberDal>();
            HaberManager productManager = new HaberManager(mock.Object);

            productManager.Add(new Haber {Detay="Detay" });
        }
    }
}
