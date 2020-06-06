using SernaSistemas.Core.Bases;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WCFTiendasLib.Contracts
{

    [DataContract]
    public class ContactoResponse : ResponseBase
    {
        [DataMember]
        public Contacto Contacto { get; set; }
        public ContactoResponse() {
            Contacto = new Contacto() {
                Id = 0,
                Correo = string.Empty,
                IdTienda = 0,
                Nombre = string.Empty,
                Telefono = string.Empty
            };
        }
    }

    [DataContract]
    public class ListarContactosResponse : ResponseBase
    {
        [DataMember]
        public List<Contacto> Contactos { get; set; }

        public ListarContactosResponse() {
            Contactos = new List<Contacto>();
        }
    }

    [DataContract]
    public class VerContactoRequest : RequestBase
    {
    }

    [DataContract]
    public class VerContactoResponse : ResponseBase
    {
    }

    [DataContract]
    public class ContactoRequest : RequestBase
    {
        public Contacto Contacto { get; set; }
        public ContactoRequest() {
            Contacto = new Contacto() {
                Id = 0,
                Correo = string.Empty,
                IdTienda = 0,
                Nombre = string.Empty,
                Telefono = string.Empty
            };
        }
    }

    [DataContract]
    public class ListarContactosRequest : RequestBase
    {
        [DataMember]
        public int IdTienda { get; set; }
    }
}