using SernaSistemas.Core.Bases;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WCFTiendasLib.Contracts
{

    [DataContract]
    public class FotoResponse : ResponseBase
    {
        [DataMember]
        public object Foto { get; set; }
    }

    [DataContract]
    public class FotoRequest : RequestBase
    {
        [DataMember]
        public int IdFoto { get; set; }
    }

    [DataContract]
    public class ListarFotoRequest : RequestBase
    {
        [DataMember]
        public int IdNegocio { get; set; }
    }

    [DataContract]
    public class ListarFotoResponse : ResponseBase
    {
        [DataMember]
        public Dictionary<int, string> Fotos { get; set; }
    }
}