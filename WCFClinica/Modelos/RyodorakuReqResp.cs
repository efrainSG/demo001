using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using WCFClinica.Clases;

namespace WCFClinica.Modelos {
    [DataContract]
    public class RyodorakuResponse : ReqRespBase {
        [DataMember]
        public int Resultado { get; set; }
        [DataMember]
        public string Mensaje { get; set; }
    }
    [DataContract]
    public class RyodorakuRequest : ReqRespBase {
        [DataMember]
        public int IdHistoriaClinica { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public float TaiYuan { get; set; }
        [DataMember]
        public float TaLing { get; set; }
        [DataMember]
        public float ShenMen { get; set; }
        [DataMember]
        public float YangKu { get; set; }
        [DataMember]
        public float YangChih { get; set; }
        [DataMember]
        public float YangXi { get; set; }
        [DataMember]
        public float TajPai { get; set; }
        [DataMember]
        public float TaiYung { get; set; }
        [DataMember]
        public float TaiChi { get; set; }
        [DataMember]
        public float ShuKu { get; set; }
        [DataMember]
        public float ChiuChu { get; set; }
        [DataMember]
        public float HsienKu { get; set; }
    }
}