using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SernaSistemas.Core.Models {
    public class ContactoModel {
        [Required(ErrorMessage = "Requiero saber con quién ponerme en contacto")]
        public string Nombre {
            get; set;
        }

        [Phone(ErrorMessage = "No es un número telefónico válido")]
        public string Telefono {
            get; set;
        }

        [Required(ErrorMessage = "Necesito tu dirección para enviarte la respuesta"),
            EmailAddress(ErrorMessage = "Debe ser algo como tunombre@dominio.ext")]
        public string Email {
            get; set;
        }

        [Required(ErrorMessage = "Te falto decirme en qué necesitas mi ayuda"),
            MaxLength(250, ErrorMessage = "El largo máximo son 250 caracteres"),
            MinLength(10, ErrorMessage = "Mínimo debes escribir 10 caracteres")]
        public string Comentario {
            get; set;
        }

        public DateTime Registrado {
            get; set;
        }

        public string mensaje {
            get; set;
        }
    }
}