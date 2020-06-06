using SernaSistemas.Core.Bases;
using System;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace WCFSernaSistemasLib
{
    [ServiceContract]
    public interface ISernaSistemasServices
    {
        [OperationContract]
        ContactoResponse registrarContacto(ContactoRequest request);
        [OperationContract]
        ConsultaProyectoResponse consultaProyecto(ConsultaProyectoRequest consultaProyectoRequest);
    }

    [DataContract]
    public class ContactoRequest
    {
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
        [DataMember]
        public int Id { get; set; }
    }
    [DataContract]
    public class ContactoResponse : ResponseBase
    {

    }

    [DataContract]
    public class ConsultaProyectoRequest
    {
        [DataMember]
        public int Folio { get; set; }
    }
    [DataContract]
    public class ConsultaProyectoResponse : ResponseBase
    {
        [DataMember]
        public string NombreProyecto { get; set; }
        [DataMember]
        public string Plataforma { get; set; }
        [DataMember]
        public byte Sprint { get; set; }
        [DataMember]
        public byte ActividadesRestantes { get; set; }
        [DataMember]
        public DateTime FechaTermino { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember]
        public string Actividad { get; set; }
    }
}
