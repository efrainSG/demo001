using SernaSistemas.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tiendas.Models {
    public class TiendaModel {
        public LoginModel usuario {
            get; set;
        }
        public int Id {
            get; set;
        }
        public string Nombre {
            get; set;
        }
        public string Direccion {
            get; set;
        }
        public string Telefono {
            get; set;
        }
        public string Correo {
            get; set;
        }
        public Dictionary<string,string> Horario {
            get; set;
        }
        public TiendaModel() {
            Id = 0;
            Nombre = "Nombre de la tienda";
            Telefono = "(###) ###-####";
            Direccion = string.Empty;
            Correo = "correo@dominio.ext";
            Horario = new Dictionary<string, string>();
            Horario.Add("Lunes", "08:00 - 17:00");
            Horario.Add("Martes", "08:00 - 17:00");
            Horario.Add("Miércoles", "08:00 - 17:00");
            Horario.Add("Jueves", "08:00 - 17:00");
            Horario.Add("Viernes", "08:00 - 17:00");
            usuario = new LoginModel();
        }
    }
}