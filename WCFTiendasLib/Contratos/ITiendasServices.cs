using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCFTiendasLib.Contracts;

namespace WCFTiendasLib {
    [ServiceContract]
    interface ITiendasServices {
        /// <summary>
        /// Inicio de sesión para el administrador del negocio.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [OperationContract]
        LoginResponse Login(LoginRequest request);

        [OperationContract]
        PropietarioResponse CrearCuenta(RegistrarPropietarioRequest request);
        [OperationContract]
        VerPropietarioResponse VerPropietario(VerPropietarioRequest request);
        /// <summary>
        /// Usa información de seguridad para realizar el guardado de la información
        /// principal de la tienda.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [OperationContract]
        PropietarioResponse GuardarDatos(RegistrarPropietarioRequest request);

        /// <summary>
        /// En el request se envía información de seguridad e identificación de tienda para
        /// recuperar los datos del negocio.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>La información principal del negocio</returns>
        [OperationContract]
        InfoTiendaResponse obtenerInfoNegocio(InfoTiendaRequest request);
        /// <summary>
        /// Se usa en la página de visitante.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [OperationContract]
        ListarTiendasResponse ListarTiendas(ListarTiendasRequest request);
        [OperationContract]
        TiendaResponse RegistrarTienda(TiendaRequest request);
        /// <summary>
        /// Se usa en la página de visitante.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [OperationContract]
        TiendaResponse VerTienda(TiendaRequest request);
        /// <summary>
        /// Se usa en la página de visitante.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [OperationContract]
        TiendaResponse VerSeccion(TiendaRequest request);

        [OperationContract]
        ListarLocalesResponse ListarLocales(ListarLocalesRequest request);
        [OperationContract]
        LocalResponse RegistrarLocal(LocalRequest request);
        /// <summary>
        /// Muestra los datos de un local de tienda (matríz o sucursal) especificado por
        /// el Id del mismo.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [OperationContract]
        LocalResponse VerLocal(LocalRequest request);

        /// <summary>
        /// Se usa en la página de visitante.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [OperationContract]
        ListarOfertasResponse ListarOfertas(ListarOfertasRequest request);
        [OperationContract]
        OfertaResponse RegistrarOferta(OfertaRequest request);
        [OperationContract]
        OfertaResponse cambiarVisibilidadOferta(OfertaRequest request);
        /// <summary>
        /// Muestra los datos de una oferta especificada por el Id de la misma.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [OperationContract]
        OfertaResponse VerOferta(OfertaRequest request);
        /// <summary>
        /// Se usa en la página de visitante.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [OperationContract]
        ListarNovedadesResponse ListarNovedades(ListarNovedadesRequest request);

        /// <summary>
        /// Devuelve la colección de fotos para un negocio identificado por el parámetro en el request.
        /// Se usa en la página de visitante.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [OperationContract]
        ListarFotoResponse ListarFotos(ListarFotoRequest request);
        [OperationContract]
        FotoResponse RegistrarFoto(FotoRequest request);
        [OperationContract]
        FotoResponse VerFoto(FotoRequest request);

        [OperationContract]
        ListarContactosResponse ListarContactos(ListarContactosRequest request);

        /// <summary>
        /// Registra un contacto nuevo para la tienda especificada. Devuelve mensaje de error
        /// si el nombre, correo o teléfono ya existen para los contactos de la tienda.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [OperationContract]
        ContactoResponse RegistrarContacto(ContactoRequest request);
        [OperationContract]
        ContactoResponse VerContacto(ContactoRequest request);
        [OperationContract]
        VerEtiquetasResponse VerEtiquetas(VerEtiquetasRequest request);

        /// <summary>
        /// Se usa en la página de visitante.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [OperationContract]
        ListarGirosResponse ListarGiros(ListarGirosRequest request);

        [OperationContract]
        ListarSeccionesResponse ListarSecciones(ListarSeccionesRequest request);

        [OperationContract]
        EliminarObjetoResponse eliminarRegistro(EliminarObjetoRequest request);

        [OperationContract]
        SeccionResponse guardarSeccion(SeccionRequest request);

        [OperationContract]
        ListarTiposSucursalesResponse ListarTiposSucursales(ListarGirosRequest request);

        [OperationContract]
        SucursalResponse guardarSucursal(SucursalRequest request);

        [OperationContract]
        SucursalResponse cambiarVisibilidadSucursal(SucursalRequest request);

        [OperationContract]
        SucursalResponse verSucursal(SucursalRequest request);
    }

}
