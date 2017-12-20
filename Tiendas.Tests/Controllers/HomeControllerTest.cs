using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tiendas;
using Tiendas.Controllers;

namespace Tiendas.Tests.Controllers {
    [TestClass]
    public class HomeControllerTest {
        [TestMethod]
        public void About() {
            #region Arrange
            HomeController controller = new HomeController();
            #endregion
            #region Act
            ViewResult result = controller.About() as ViewResult;
            #endregion
            #region Assert
            Assert.AreEqual("Tu negocio en línea", result.ViewBag.Message);
            #endregion
        }
        [TestMethod]
        public void Browse() {
            #region Arrange
            HomeController controller = new HomeController();
            #endregion
            #region Act
            ViewResult result = controller.Browse() as ViewResult;
            #endregion
            #region Assert
            Assert.IsNotNull(result);
            #endregion
        }
        [TestMethod]
        public void Contact() {
            #region Arrange
            HomeController controller = new HomeController();
            #endregion
            #region Act
            ViewResult result = controller.Contact() as ViewResult;
            #endregion
            #region Assert
            Assert.IsNotNull(result);
            #endregion
        }
        [TestMethod]
        public void Index() {
            #region Arrange
            HomeController controller = new HomeController();
            #endregion
            #region Act
            ViewResult result = controller.Index() as ViewResult;
            #endregion
            #region Assert
            Assert.IsNotNull(result);
            #endregion
        }
        [TestMethod]
        public void loadMap() {
            #region Arrange
            HomeController controller = new HomeController();
            #endregion
            #region Act
            ViewResult result = controller.loadMap() as ViewResult;
            #endregion
            #region Assert
            Assert.IsNotNull(result);
            #endregion
        }
        [TestMethod]
        public void Login() {
            #region Arrange
            HomeController controller = new HomeController();
            #endregion
            #region Act
            ViewResult result = controller.Login() as ViewResult;
            #endregion
            #region Assert
            Assert.IsNotNull(result);
            #endregion
        }
        [TestMethod]
        public void verNegocio() {
            #region Arrange
            HomeController controller = new HomeController();
            int idNegocio = 1;
            #endregion
            #region Act
            ViewResult result = controller.verNegocio(idNegocio) as ViewResult;
            #endregion
            #region Assert
            Assert.IsNotNull(result);
            #endregion
        }
    }
}
