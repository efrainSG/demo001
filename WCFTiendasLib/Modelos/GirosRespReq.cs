using SernaSistemas.Core.Bases;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WCFTiendasLib.Contracts {

    [DataContract]
    public class GiroResponse : ResponseBase {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Giro { get; set; }
    }

    [DataContract]
    public class GiroRequest : RequestBase {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Giro { get; set; }
    }

    [DataContract]
    public class ListarGirosRequest : RequestBase {
        [DataMember]
        public int Id { get; set; }
    }

    [DataContract]
    public class ListarGirosResponse : ResponseBase {
        [DataMember]
        public Dictionary<int, string> Giros { get; set; }
    }

    [DataContract]
    public class ListarSeccionesRequest : RequestBase {
        [DataMember]
        public int Id { get; set; }
    }

    [DataContract]
    public class ListarSeccionesResponse : ResponseBase {
        [DataMember]
        public Dictionary<int, string> Secciones { get; set; }
    }

    [DataContract]
    public class ListarTiposSucursalesResponse : ResponseBase {
        [DataMember]
        public Dictionary<int, string> TiposSucursales { get; set; }
    }
    [DataContract]
    public class SeccionRequest : RequestBase {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public int idSeccion { get; set; }
        [DataMember]
        public int idTienda { get; set; }
        [DataMember]
        public string titulo { get; set; }
        [DataMember]
        public string descripcion { get; set; }
    }

    [DataContract]
    public class SeccionResponse : ResponseBase {
        [DataMember]
        public int idSeccion { get; set; }
        [DataMember]
        public int idTienda { get; set; }
        [DataMember]
        public string descripcion { get; set; }
    }

    [DataContract]
    public class SeccionesResponse : ResponseBase {
        [DataMember]
        public List<SeccionesResponse> Secciones { get; set; }
    }

    [DataContract]
    public class EliminarObjetoRequest : RequestBase {
        [DataMember]
        public eEntidad Objeto { get; set; }
        [DataMember]
        public int Id { get; set; }
    }
    [DataContract]
    public class EliminarObjetoResponse : ResponseBase {
        [DataMember]
        public int Id { get; set; }

    }

    [DataContract]
    public class SucursalRequest : RequestBase {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int IdTienda { get; set; }
        [DataMember]
        public int IdTipo { get; set; }
        [DataMember]
        public int Status { get; set; }
        [DataMember]
        public string Direccion { get; set; }
        [DataMember]
        public string Telefono { get; set; }
        [DataMember]
        public string Correo { get; set; }
    }
    [DataContract]
    public class SucursalResponse:ResponseBase {
        [DataMember]
        public Sucursal Sucursal { get; set; }
    }
}