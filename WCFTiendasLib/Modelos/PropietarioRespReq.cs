using SernaSistemas.Core.Bases;
using System.Runtime.Serialization;

namespace WCFTiendasLib.Contracts {

    [DataContract]
    public class PropietarioResponse : ResponseBase {
    }

    [DataContract]
    public class VerPropietarioRequest : RequestBase {
        [DataMember]
        public int Id { get; set; }
    }

    [DataContract]
    public class RegistrarPropietarioRequest : RequestBase {
    }

    [DataContract]
    public class VerPropietarioResponse : ResponseBase {
        [DataMember]
        public Propietario Propietario { get; set; }
    }
}