using Microsoft.VisualStudio.TestTools.UnitTesting;
using WCFTiendasLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFTiendasLib.Contracts;
using SernaSistemas.Core.Bases;
using System.Configuration;

namespace WCFTiendasLib.Tests
{
    [TestClass()]
    public class TiendasServicesTests
    {

        /// <summary>
        /// Prueba de registro de contacto nuevo, no hay datos duplicados
        /// Se espera registro exitoso
        /// </summary>
        [TestMethod()]
        public void RegistrarContactoTest() {
            try {
                TiendasServices _servicios = new TiendasServices();
                _servicios.connstring = @"Data Source=DESKTOP-8RJ1OMB\SQLEXPRESS;Initial Catalog=Proyectos;Integrated security=true;Pooling=False";

                ContactoRequest request = new ContactoRequest() {
                    Contacto = new Contacto() {
                        Id = 0,
                        Correo = "efrain.serna@gmail.com",
                        IdTienda = 1,
                        Nombre = "Efrain Serna G.",
                        Telefono = "22-25-29-9764"
                    }
                };
                ContactoResponse response = _servicios.RegistrarContacto(request);
                Assert.IsTrue(
                    !response.tieneError &&
                    response.Mensaje.Equals(TiendasServices.K_CONTACTO_REGISTRADO),
                    response.Mensaje);
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Prueba de registro de contacto nuevo con nombre ya existente para la tienda especificada
        /// Se espera mensaje de error sobre nombre ya existente
        /// </summary>
        [TestMethod()]
        public void RegistrarContactoTest1() {
            try {
                TiendasServices _servicios = new TiendasServices();
                _servicios.connstring = @"Data Source=DESKTOP-8RJ1OMB\SQLEXPRESS;Initial Catalog=Proyectos;Integrated security=true;Pooling=False";

                ContactoRequest request = new ContactoRequest() {
                    Contacto = new Contacto() {
                        Id = 0,
                        Correo = "efrain.serna@gmail.com",
                        IdTienda = 1,
                        Nombre = "Efrain Serna G.",
                        Telefono = "22-25-29-9764"
                    }
                };
                ContactoResponse response = _servicios.RegistrarContacto(request);

                Assert.IsTrue(
                    response.tieneError &&
                    response.Mensaje.Equals(TiendasServices.K_NOMBRE_CONTACTO_REGISTRADO),
                    response.Mensaje);
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Prueba de registro de contacto nuevo con nombre distinto y correo ya existente
        /// para la tienda especificada
        /// Se espera mensaje de error sobre correo ya existente
        /// </summary>
        [TestMethod()]
        public void RegistrarContactoTest2() {
            try {
                TiendasServices _servicios = new TiendasServices();
                _servicios.connstring = @"Data Source=DESKTOP-8RJ1OMB\SQLEXPRESS;Initial Catalog=Proyectos;Integrated security=true;Pooling=False";

                ContactoRequest request = new ContactoRequest() {
                    Contacto = new Contacto() {
                        Id = 0,
                        Correo = "efrain.serna@gmail.com",
                        IdTienda = 1,
                        Nombre = "Efrain Serna Gracia",
                        Telefono = "22-24-53-2814"
                    }
                };
                ContactoResponse response = _servicios.RegistrarContacto(request);

                Assert.IsTrue(
                    response.tieneError &&
                    response.Mensaje.Equals(TiendasServices.K_CORREO_CONTACTO_REGISTRADO),
                    response.Mensaje);
                //request.Contacto.Telefono = "efrain.serna@gmail.com";
                //response = _servicios.RegistrarContacto(request);

                //Assert.IsTrue(!response.tieneError && response.Mensaje.Equals(TiendasServices.K_CONTACTO_REGISTRADO), response.Mensaje);
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Prueba de registro de contacto nuevo con nombre y correo distintos, pero teléfono
        /// ya existente para la tienda especificada
        /// Se espera mensaje de error sobre teléfono ya existente
        /// </summary>
        [TestMethod()]
        public void RegistrarContactoTest3() {
            try {
                TiendasServices _servicios = new TiendasServices();
                _servicios.connstring = @"Data Source=DESKTOP-8RJ1OMB\SQLEXPRESS;Initial Catalog=Proyectos;Integrated security=true;Pooling=False";

                ContactoRequest request = new ContactoRequest() {
                    Contacto = new Contacto() {
                        Id = 0,
                        Correo = "efra.maverick.xxi@gmail.com",
                        IdTienda = 1,
                        Nombre = "Efrain Serna Gracia",
                        Telefono = "22-25-29-9764"
                    }
                };
                ContactoResponse response = _servicios.RegistrarContacto(request);

                Assert.IsTrue(
                    response.tieneError &&
                    response.Mensaje.Equals(TiendasServices.K_TELEFONO_CONTACTO_REGISTRADO),
                    response.Mensaje);
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Busca una oferta de tipo producto con base en el Id de Producto
        /// Se espera que encuentre un producto
        /// </summary>
        [TestMethod()]
        public void VerOfertaTest() {
            try {
                TiendasServices _servicios = new TiendasServices();
                _servicios.connstring = @"Data Source=DESKTOP-8RJ1OMB\SQLEXPRESS;Initial Catalog=Proyectos;Integrated security=true;Pooling=False";

                OfertaRequest request = new OfertaRequest() {
                    Id = 341
                };
                OfertaResponse response = _servicios.VerOferta(request);

                Assert.IsTrue(
                    !response.tieneError &&
                    response.Producto.Id == request.Id,
                    response.Mensaje ?? TiendasServices.K_REGISTRO_NO_ENCONTRADO);
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Busca una oferta de tipo servicio con base en el Id de Servicio
        /// Se espera que encuentre un servicio
        /// </summary>
        [TestMethod()]
        public void VerOfertaTest1() {
            try {
                TiendasServices _servicios = new TiendasServices();
                _servicios.connstring = @"Data Source=DESKTOP-8RJ1OMB\SQLEXPRESS;Initial Catalog=Proyectos;Integrated security=true;Pooling=False";

                OfertaRequest request = new OfertaRequest() {
                    Id = 409
                };
                OfertaResponse response = _servicios.VerOferta(request);

                Assert.IsTrue(
                    !response.tieneError &&
                    response.Servicio.Id == request.Id,
                    response.Mensaje ?? TiendasServices.K_REGISTRO_NO_ENCONTRADO);
            } catch (Exception ex) {
                throw ex;
            }
        }

        [TestMethod()]
        public void LoginTest() {
            TiendasServices _servicios = new TiendasServices();
            _servicios.connstring = @"Data Source=DESKTOP-8RJ1OMB\SQLEXPRESS;Initial Catalog=Proyectos;Integrated security=true;Pooling=False";
            LoginRequest request = new LoginRequest() {
                loginModel = new SernaSistemas.Core.Models.LoginModel() {
                    NombreUsuario = "efrain",
                    LoginPass = "efra"
                }
            };
            var response = _servicios.Login(request);
            Assert.IsTrue(response.Mensaje.Equals("Denegado"), string.Format("Error al validar: {0}", response.Mensaje));

            request = new LoginRequest() {
                loginModel = new SernaSistemas.Core.Models.LoginModel() {
                    NombreUsuario = "efrain",
                    LoginPass = "efrain"
                }
            };
            response = _servicios.Login(request);
            Assert.IsTrue(response.Mensaje.Equals("Hecho"), string.Format("Error al validar: {0}", response.Mensaje));
        }
    }
}