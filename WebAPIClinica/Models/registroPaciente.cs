using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAPIClinica.Models {
    public class datosPaciente {
        [Required]
        public int IdSexo { get; set; }

        [Required]
        public string Nombre { get; set; }

        public int IdTipoSangre { get; set; }

        public string Rh { get; set; }

        [Required]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        public int IdLugarNacimiento { get; set; }

        public string CiudadNacimiento { get; set; }

        public int IdLugarResidencia { get; set; }

        public string Domicilio { get; set; }

        public bool Tabaco { get; set; }

        public bool Alcohol { get; set; }

        public string CiudadResidencia { get; set; }

    }
}