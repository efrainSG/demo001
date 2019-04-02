using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using WCFClinica.Clases;

namespace WCFClinica.Modelos {
    [DataContract]
    public class LoginRequest : ReqRespBase {
        [DataMember, Display(Name = "Nombre de usuario")]
        public string Usuario { get; set; }
        [DataMember, Display(Name = "Contraseña")]
        public string Password { get; set; }
    }

    [DataContract]
    public class LoginResponse : ReqRespBase {
        [DataMember]
        public int Resultado { get; set; }
        [DataMember]
        public int Id { get; set; }
    }
}
