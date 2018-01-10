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
        [OperationContract]
        LoginResponse Login(LoginRequest request);

        [OperationContract]
        PropietarioResponse CrearCuenta(RegistrarPropietarioRequest request);
        [OperationContract]
        VerPropietarioResponse VerPropietario(VerPropietarioRequest request);
        [OperationContract]
        PropietarioResponse GuardarDatos(RegistrarPropietarioRequest request);

        [OperationContract]
        ListarTiendasResponse ListarTiendas(ListarTiendasRequest request);
        [OperationContract]
        TiendaResponse RegistrarTienda(TiendaRequest request);
        [OperationContract]
        TiendaResponse VerTienda(TiendaRequest request);

        [OperationContract]
        ListarLocalesResponse ListarLocales(ListarLocalesRequest request);
        [OperationContract]
        LocalResponse RegistrarLocal(LocalRequest request);
        [OperationContract]
        LocalResponse VerLocal(LocalRequest request);

        [OperationContract]
        ListarOfertasResponse ListarOfertas(ListarOfertasRequest request);
        [OperationContract]
        OfertaResponse RegistrarOferta(OfertaRequest request);
        [OperationContract]
        OfertaResponse VerOferta(OfertaRequest request);

        [OperationContract]
        ListarFotoResponse ListarFotos(ListarFotoRequest request);
        [OperationContract]
        FotoResponse RegistrarFoto(FotoRequest request);
        [OperationContract]
        FotoResponse VerFoto(FotoRequest request);

        [OperationContract]
        ListarContactosResponse ListarContactos(ListarContactosRequest request);
        [OperationContract]
        ContactoResponse RegistrarContacto(ContactoRequest request);
        [OperationContract]
        VerContactoResponse VerContacto(VerContactoRequest request);
        [OperationContract]
        VerEtiquetasResponse VerEtiquetas(VerEtiquetasRequest request);
    }

}
