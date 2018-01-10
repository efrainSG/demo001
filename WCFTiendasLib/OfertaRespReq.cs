using SernaSistemas.Core.Bases;
using System.Runtime.Serialization;

namespace WCFTiendasLib.Contracts {

    [DataContract]
    public class OfertaResponse : ResponseBase {
    }

    [DataContract]
    public class OfertaRequest : RequestBase {
    }

    [DataContract]
    public class ListarOfertasRequest : RequestBase {
    }

    [DataContract]
    public class ListarOfertasResponse : ResponseBase {
    }
}