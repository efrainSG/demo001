using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SernaSistemas.Core.Bases {
    [DataContract]
    public class ResponseBase {
        [DataMember]
        public int Error {
            get; set;
        }

        [DataMember]
        public string Mensaje {
            get; set;
        }

        [DataMember]
        public bool tieneError {
            get; set;
        }

        public ResponseBase() {
            Mensaje = string.Empty;
            tieneError = false;
            Error = 0;
        }
    }

    [DataContract]
    public class RequestBase {
        [DataMember]
        public int Error {
            get; set;
        }

        [DataMember]
        public string Mensaje {
            get; set;
        }

        [DataMember]
        public bool tieneError {
            get; set;
        }
        public RequestBase() {
            Mensaje = string.Empty;
            tieneError = false;
            Error = 0;
        }
    }
}
