using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using WCFClinica.Clases;

namespace WCFClinica.Modelos {
    [DataContract]
    public class NotaEvolutivaReqResp : ReqRespBase {
        [DataMember]
        public int IdNota { get; set; }
        [DataMember]
        public int IdHistoria { get; set; }
        [DataMember]
        public string PlanTratamiento { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public RegistraExploraFisicaReqResp ExploracionFisica { get; set; }
        [DataMember]
        public int IdPaciente { get; set; }
    }
    [DataContract]
    public class ListaNotasEvolutivasResponse : ReqRespBase {
        [DataMember]
        public List<NotaEvolutivaReqResp> Items { get; set; }
    }
}