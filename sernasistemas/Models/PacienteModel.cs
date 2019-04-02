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
                return new DateTime(DateTime.Today.Subtract(FechaNacimiento).Ticks).Year;
            }
        }
        public IEnumerable<SelectListItem> dicSexo { get; set; }
        public IEnumerable<SelectListItem> dicTipoSangre { get; set; }
        public IEnumerable<SelectListItem> dicTipoTelefono { get; set; }
        public IEnumerable<SelectListItem> dicLugarResidencia { get; set; }
    }
}