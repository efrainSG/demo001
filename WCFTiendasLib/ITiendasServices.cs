using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCFTiendasLib {
    [ServiceContract]
    interface ITiendasServices {
        [OperationContract]
        LoginResponse login(loginRequest request);

        [OperationContract]
        PropietarioResponse crearCuenta(RegistrarPropietarioRequest request);
        [OperationContract]
        VerPropietarioResponse verPropietario(VerPropietarioRequest request);
        [OperationContract]
        PropietarioResponse guardarDatos(RegistrarPropietarioRequest request);

        [OperationContract]
        ListarTiendasResponse listarTiendas(ListarTiendasRequest request);
        [OperationContract]
        TiendaResponse registrarTienda(TiendaRequest request);
        [OperationContract]
        TiendaResponse verTienda(TiendaRequest request);

        [OperationContract]
        ListarLocalesResponse listarLocales(ListarLocalesRequest request);
        [OperationContract]
        LocalResponse registrarLocal(LocalRequest request);
        [OperationContract]
        LocalResponse verLocal(LocalRequest request);

        [OperationContract]
        ListarOfertasResponse listarOfertas(ListarOfertasRequest request);
        [OperationContract]
        OfertaResponse registrarOferta(OfertaRequest request);
        [OperationContract]
        OfertaResponse verOferta(OfertaRequest request);

        [OperationContract]
        ListarFotoResponse listarFotos(ListarFotoRequest request);
        [OperationContract]
        FotoResponse registrarFoto(FotoRequest request);
        [OperationContract]
        FotoResponse verFoto(FotoRequest request);

        [OperationContract]
        ListarContactosResponse listarContactos(ListarContactosRequest request);
        [OperationContract]
        ContactoResponse registrarContacto(ContactoRequest request);
        [OperationContract]
        VerContactoResponse verContacto(VerContactoRequest request);
    }

}
