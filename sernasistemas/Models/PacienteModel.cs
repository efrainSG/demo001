using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCFClinica.Modelos;

namespace SernaSistemas.Models {
    public class PacienteModel : RegistraPacienteReqResp {
        [Display(Name="Edad")]
        public int Edad {
            get {
                int edad = new DateTime(DateTime.Today.Subtract(FechaNacimiento).Ticks).Year;
                return edad > 150 ? -1 : edad;
            }
        }
        public IEnumerable<SelectListItem> dicSexo { get; set; }
        public IEnumerable<SelectListItem> dicTipoSangre { get; set; }
        public IEnumerable<SelectListItem> dicTipoTelefono { get; set; }
        public IEnumerable<SelectListItem> dicLugarResidencia { get; set; }
    }
}