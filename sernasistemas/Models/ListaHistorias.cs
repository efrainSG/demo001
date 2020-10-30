using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCFClinica.Modelos;

namespace SernaSistemas.Models {
    public class ListaHistorias {
        public List<selHistoriaReqResp> Historias { get; set; }
    }
    public class buscarHistoriasModel {
        public List<buscarHistoriasItem> Historias { get; set; }
    }
}