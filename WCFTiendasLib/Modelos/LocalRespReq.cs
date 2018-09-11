using SernaSistemas.Core.Bases;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WCFTiendasLib.Contracts {

    [DataContract]
    public class LocalResponse : ResponseBase {
        [DataMember]
        public Sucursal Sucursal { get; set; }
    }

    [DataContract]
    public class LocalRequest : RequestBase {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public Sucursal Sucursal { get; set; }
    }

    [DataContract]
    public class ListarLocalesRequest : RequestBase {
        [DataMember]
        public int IdTienda { get; set; }
    }

    [DataContract]
    public class ListarLocalesResponse : ResponseBase {
        [DataMember]
        public List<Sucursal> Sucursales { get; set; }

        public ListarLocalesResponse() {
            Sucursales = new List<Sucursal>();
        }
    }
}