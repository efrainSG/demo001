using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCFClinica.Modelos;

namespace SernaSistemas.Models {
    public class NotaEvolutivaModel {
        public int IdNota { get; set; }
        public int IdHistoria { get; set; }
        public int IdPaciente { get; set; }
        public DateTime Fecha { get; set; }
        public string NombrePaciente { get; set; }
        public string MotivoConsulta { get; set; }
        public string Plan { get; set; }
        /// <summary>
        /// El contenido de esta propiedad no va hacia la tabla de Exploración física, sino a la de
        /// notas evolutivas
        /// </summary>
        public RegistraExploraFisicaReqResp ExploracionFisica { get; set; }
        public string PlanTratamiento { get; set; }
    }
}