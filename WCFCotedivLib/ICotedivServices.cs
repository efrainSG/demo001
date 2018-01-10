using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCFCotedivLib.Contracts;

namespace WCFCotedivLib {
    [ServiceContract]
    public interface ICotedivServices {
        [OperationContract]
        LoginResponse Login(LoginRequest request);

        [OperationContract]
        BoolResponse Logout(object request);

        [OperationContract]
        EntradaResponse GuardarEntrada(EntradaRequest request);

        [OperationContract]
        EntradaResponse VerEntrada(EntradaRequest request);

        [OperationContract]
        BoolResponse BorrarEntrada(EntradaRequest request);
        /// <summary>
        /// Si el "request" es cadena de consulta, recupera las entradas que cumplen con la condición de búsqueda.
        /// Si el "request" es entero, recupera las entradas cuyo Id de autor sea igual al valor del request
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [OperationContract]
        ListaResponse ListarEntradas(object request);

        [OperationContract]
        EntradaResponse ValorarEntrada(EntradaRequest request);

        [OperationContract]
        EntradaResponse EvaluarEntrada(EntradaRequest request);

        [OperationContract]
        PerfilResponse GuardarPerfil(PerfilRequest request);

        [OperationContract]
        PerfilResponse VerPerfil(PerfilRequest request);

        [OperationContract]
        ListaResponse ListarExpertos(object request);

        [OperationContract]
        AlumnoResponse CrearCuenta(AlumnoRequest request);
    }
}
