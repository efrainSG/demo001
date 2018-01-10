using SernaSistemas.Core.Bases;
using System.Runtime.Serialization;

namespace WCFTiendasLib.Contracts {

    [DataContract]
    public class FotoResponse : ResponseBase {
    }

    [DataContract]
    public class FotoRequest : RequestBase {
    }

    [DataContract]
    public class ListarFotoRequest:RequestBase {
    }

    [DataContract]
    public class ListarFotoResponse : ResponseBase {
    }
}