using SernaSistemas.Core.Bases;
using System;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace WCFSernaSistemasLib {
    [ServiceContract]
    public interface ISernaSistemasServices {
        [OperationContract]
        ContactoResponse registrarContacto(ContactoRequest request);
    }

    [DataContract]
    public class ContactoRequest {
        [DataMember]
        public string Nombre {
            get; set;
        }
        [DataMember]
        public string Telefono {
            get; set;
        }
        [DataMember]
        public string eMail {
            get; set;
        }
        [DataMember]
        public string Comentario {
            get; set;
        }
        [DataMember]
        public DateTime FechaContacto {
            get; set;
        }
    }
    [DataContract]
    public class ContactoResponse : ResponseBase {

    }
}
