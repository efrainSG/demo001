using SernaSistemas.Core.Bases;
using System.Runtime.Serialization;

namespace WCFTiendasLib.Contracts {

    [DataContract]
    public class PropietarioResponse : ResponseBase
    {
        [DataMember]
        public Propietario Datos { get; internal set; }
    }

    [DataContract]
    public class VerPropietarioRequest : RequestBase {
        [DataMember]
        public int Id { get; set; }
    }

    [DataContract]
    public class RegistrarPropietarioRequest : RequestBase
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Usuario { get; set; }
        [DataMember]
        public string Token { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Correo { get; set; }
        [DataMember]
        public string Telefono { get; set; }
        [DataMember]
        public string Password { get; set; }
    }

    [DataContract]
    public class VerPropietarioResponse : ResponseBase {
        [DataMember]
        public Propietario Propietario { get; set; }
    }
}