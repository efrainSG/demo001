using SernaSistemas.Core.Bases;
using System.Runtime.Serialization;

namespace WCFTiendasLib.Contracts {

    [DataContract]
    public class ContactoResponse:ResponseBase {
    }

    [DataContract]
    public class ListarContactosResponse : ResponseBase {
    }

    [DataContract]
    public class VerContactoRequest : RequestBase {
    }

    [DataContract]
    public class VerContactoResponse : ResponseBase {
    }

    [DataContract]
    public class ContactoRequest : RequestBase {
    }

    [DataContract]
    public class ListarContactosRequest : RequestBase {
    }
}