using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCFClinica.Modelos;

namespace SernaSistemas.Models {
    public class MedicoModel {
        public RegistraMedicoReqResp Perfil { get; set; }
        public IEnumerable<SelectListItem> dicSexo { get; set; }
        public IEnumerable<SelectListItem> dicTipoSangre { get; set; }
        public IEnumerable<SelectListItem> dicTipoTelefono { get; set; }
        public IEnumerable<SelectListItem> dicLugar { get; set; }
        public SelectListItem SexoItem { get; set; }
        public SelectListItem TipoSangreItem { get; set; }
        public SelectListItem TipoTelefonoItem { get; set; }
        public SelectListItem LugarNacimientoItem { get; set; }
    }
}