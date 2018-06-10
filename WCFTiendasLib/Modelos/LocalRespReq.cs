using SernaSistemas.Core.Bases;
using System.Runtime.Serialization;

namespace WCFTiendasLib.Contracts {

    [DataContract]
    public class LocalResponse : ResponseBase {
    }

    [DataContract]
    public class LocalRequest : RequestBase {
    }

    [DataContract]
    public class ListarLocalesRequest : RequestBase {
    }

    [DataContract]
    public class ListarLocalesResponse : ResponseBase {
    }
}