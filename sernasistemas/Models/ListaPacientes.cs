using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCFClinica.Modelos;

namespace SernaSistemas.Models {
    public class ListaPacientesModel {
        public int IdMedico { get; set; }
        public buscarPacienteResponse Pacientes { get; set; }
    }
}