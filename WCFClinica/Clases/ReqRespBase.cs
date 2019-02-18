using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WCFClinica.Clases {
    [DataContract]
    public class ReqRespBase {
        [DataMember]
        public bool tieneError { get; set; }
        [DataMember]
        public int ErrNum { get; set; }
        [DataMember]
        public string Mensaje { get; set; }
    }
}
