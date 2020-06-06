using Microsoft.VisualStudio.TestTools.UnitTesting;
using WCFTiendasLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFTiendasLib.Tests
{
    [TestClass()]
    public class TiendasServicesTests
    {
        [TestMethod()]
        public void ListarContactosTest() {
            TiendasServices services = new TiendasServices();
            WCFTiendasLib.Contracts.ListarContactosResponse response = services.ListarContactos(new Contracts.ListarContactosRequest() {
                IdTienda = 100
            });

            Assert.IsTrue(!response.tieneError, "ERROR AL OBTENER DATOS");
            if (!response.tieneError) {
                Assert.IsTrue(response.Contactos.Count() > 0, "SIN DATOS");
                Assert.IsFalse(response.Contactos.Count() != 0, response.Contactos.Count().ToString());
            }
        }

        [TestMethod()]
        public void VerPropietarioTest() {
            Assert.IsTrue(true, "NADA");
        }
    }
}