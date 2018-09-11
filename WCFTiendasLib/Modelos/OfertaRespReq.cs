using SernaSistemas.Core.Bases;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WCFTiendasLib.Contracts
{

    [DataContract]
    public class OfertaResponse : ResponseBase
    {
        public Oferta Producto { get; set; }
        public Oferta Servicio { get; set; }
    }

    [DataContract]
    public class OfertaRequest : RequestBase
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public Oferta Oferta { get; set; }
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

    [DataContract]
    public class ListarNovedadesRequest : RequestBase
    {
        [DataMember]
        public int IdNegocio { get; set; }
    }

    [DataContract]
    public class ListarNovedadesResponse : ResponseBase
    {
        [DataMember]
        public List<OfertaBreve> Novedades { get; set; }
    }
}