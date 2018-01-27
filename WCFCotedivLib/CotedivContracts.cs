using SernaSistemas.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WCFCotedivLib.Contracts {
    [DataContract]
    public abstract class BaseRequest {
        public int Id {
            get; set;
        }
        public string StringProperty {
            get; set;
        }
        public BaseRequest() {
            Id = int.MinValue;
            StringProperty = string.Empty;
        }
    }

    [DataContract]
    public abstract class BaseResponse {
        public bool Success {
            get; set;
        }
        public string ErrorMsg {
            get; set;
        }
        public BaseResponse() {
            Success = true;
            ErrorMsg = string.Empty;
        }
    }

    [DataContract]
    public class LoginRequest : BaseRequest {
        public string UserId {
            get; set;
        }
        public string Password {
            get; set;
        }
        public DateTime LoginDate {
            get; set;
        }
        public string Hash {
            get; set;
        }
        public LoginRequest() {
            LoginDate = DateTime.Now;
        }
    }

    [DataContract]
    public class EntradaRequest : BaseRequest {
        public int IdAutor {
            get; set;
        }
        public string Titulo {
            get; set;
        }
        public string Contenido {
            get; set;
        }
        public DateTime Fecha {
            get; set;
        }
        public int IdStatus {
            get; set;
        }
        public int Valor {
            get; set;
        }
        public EntradaRequest() {
            Fecha = DateTime.Today;
            IdStatus = 1;
        }
    }

    [DataContract]
    public class PerfilRequest : BaseRequest {
        public int IdUsuario {
            get; set;
        }
        public int IdInstitucion {
            get; set;
        }
        public int IdStatus {
            get; set;
        }
        public string Resumen {
            get; set;
        }
        public string Correo {
            get; set;
        }
        public string Telefono {
            get; set;
        }
        public DateTime Nacimiento {
            get; set;
        }
        public List<NombreItem> Nombres {
            get; set;
        }
        public List<DireccionItem> Direccion {
            get; set;
        }
        public string Usuario {
            get; set;
        }
        public string NuevoPassword {
            get; set;
        }
        public InstitucionModel Institucion {
            get; set;
        }

        public PerfilRequest() {
            Direccion = new List<DireccionItem>();
            Nombres = new List<NombreItem>();
        }
    }

    [DataContract]
    public class AlumnoRequest : BaseRequest {
    }

    [DataContract]
    public class LoginResponse : BaseResponse {
        public LoginModel Modelo {
            get; set;
        }
        public LoginResponse() {
            Modelo = new LoginModel();
        }
    }

    [DataContract]
    public class BoolResponse : BaseResponse {
    }

    [DataContract]
    public class EntradaResponse : BaseResponse {
        public int Id {
            get; set;
        }
        public string Titulo {
            get; set;
        }
        public string Contenido {
            get; set;
        }
    }

    [DataContract]
    public class PerfilResponse : BaseResponse {
        public int Id {
            get; set;
        }
        public string Usuario {
            get; set;
        }
        public string NuevoPassword {
            get; set;
        }
        public string Correo {
            get; set;
        }
        public string Telefono {
            get; set;
        }
        public DateTime Nacimiento {
            get; set;
        }
        public string Resumen {
            get; set;
        }
        public int IdStatus {
            get; set;
        }
        public InstitucionModel Institucion {
            get; set;
        }
        public List<NombreItem> Nombres {
            get; set;
        }
        public List<DireccionItem> Direccion {
            get; set;
        }
        public List<InstitucionModel> Instituciones {
            get; set;
        }
    }

    [DataContract]
    public class ListaResponse : BaseResponse {
        public Dictionary<int, ConceptoModel> Resultados {
            get; set;
        }
        public ListaResponse() {
            Resultados = new Dictionary<int, ConceptoModel>();
        }
    }

    [DataContract]
    public class AlumnoResponse : BaseResponse {
    }

    [DataContract]
    public class DireccionItem {
        public int Id {
            get; set;
        }
        public int IdPersona {
            get; set;
        }
        public int IdTipoElemento {
            get; set;
        }
        public string Valor {
            get; set;
        }
    }

    [DataContract]
    public class NombreItem {
        public int Id {
            get; set;
        }
        public int IdPersona {
            get; set;
        }
        public int Orden {
            get; set;
        }
        public string Valor {
            get; set;
        }
    }

    [DataContract]
    public class ConceptoModel {
        public int Id {
            get; set;
        }
        public string Titulo {
            get; set;
        }
        public string Contenido {
            get; set;
        }
        public int Valoracion {
            get; set;
        }
        public int? Evaluacion {
            get; set;
        }
    }

    [DataContract]
    public class InstitucionModel {
        public int Id {
            get; set;
        }
        public string Nombre {
            get; set;
        }
        public string Lat {
            get; set;
        }
        public string Lon {
            get; set;
        }
        public int IdLocacion {
            get; set;
        }
    }

    [DataContract]
    public class BusquedaResponse : BaseResponse {
        public List<ConceptoModel> Resultados {
            get; set;
        }
        public BusquedaResponse() {
            Resultados = new List<ConceptoModel>();
        }
    }

    [DataContract]
    public class BusquedaRequest:BaseRequest {
        public string Query {
            get; set;
        }
    }
}
