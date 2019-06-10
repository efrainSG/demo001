using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCFClinica.Modelos;

namespace SernaSistemas.Models {
    public class HistoriaModel {
        public PacienteModel Paciente { get; set; }
        public selAntHeredReqResp AntecedentesHereditarios { get; set; }
        public AntHeredItem AntecedenteHereditario { get; set; }
        public selAntPersonalPatReqResp AntecedentesPatologicos { get; set; }
        public RegistraAntPersonalPat AntecedentePatologico { get; set; }
        public RegistaAntGinecoReqResp AntecedentesGinecoObstetricios { get; set; }
        public selMedicacionActualReqResp MedicacionActual { get; set; }
        public MedicacionActualItem Medicacion { get; set; }
        public selHistoriaReqResp HistoriaClinica { get; set; }
        public selExploraSistemaReqResp ExploracionSistemas { get; set; }
        public ExploraSistemaItem Sistema { get; set; }
        public ExploraSistemaItem Exploracion { get; set; }
        public RegistraExploraFisicaReqResp ExploracionFisica { get; set; }

        public IEnumerable<SelectListItem> dicMedicos { get; set; }
        public IEnumerable<SelectListItem> dicFamiliar { get; set; }
        public IEnumerable<SelectListItem> dicAnticonceptivos { get; set; }
        public IEnumerable<SelectListItem> dicSistemas { get; set; }

        public object colecciones { get; set; }
        public List<NotaEvolutivaModel> Notas { get; set; }
    }
}