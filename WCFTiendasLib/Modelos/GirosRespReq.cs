using SernaSistemas.Core.Bases;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WCFTiendasLib.Contracts
{

    [DataContract]
    public class GiroResponse : ResponseBase
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Giro { get; set; }
    }

    [DataContract]
    public class GiroRequest : RequestBase
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Giro { get; set; }
    }

    [DataContract]
    public class ListarGirosRequest : RequestBase
    {
        [DataMember]
        public int Id { get; set; }
    }

    [DataContract]
    public class ListarGirosResponse : ResponseBase
    {
        [DataMember]
        public Dictionary<int,string> Giros { get; set; }
    }
    [DataContract]
    public class EliminarObjetoRequest : RequestBase
    {
        [DataMember]
        public eEntidad Objeto { get; set; }
        [DataMember]
        public int Id { get; set; }
    }
    [DataContract]
    public class EliminarObjetoResponse : ResponseBase
    {
        [DataMember]
        public int Id { get; set; }

    }
}