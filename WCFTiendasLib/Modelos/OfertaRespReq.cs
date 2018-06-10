using SernaSistemas.Core.Bases;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WCFTiendasLib.Contracts
{

    [DataContract]
    public class OfertaResponse : ResponseBase
    {
        public object Producto { get; set; }
        public object Servicio { get; set; }
    }

    [DataContract]
    public class OfertaRequest : RequestBase
    {
        [DataMember]
        public int IdProducto { get; set; }
        [DataMember]
        public int IdServicio { get; set; }
    }

    [DataContract]
    public class ListarOfertasRequest : RequestBase
    {
        [DataMember]
        public int IdNegocio { get; set; }
        [DataMember]
        public string TipoOferta { get; set; }
    }

    [DataContract]
    public class ListarOfertasResponse : ResponseBase
    {
        [DataMember]
        public List<OfertaBreve> Productos { get; set; }

        [DataMember]
        public List<OfertaBreve> Servicios { get; set; }
    }
}