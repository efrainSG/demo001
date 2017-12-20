using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SernaSistemas.Core.Models {
    public class LoginModel {
        public int idUsuario {
            get; set;
        }
        public int IdNivel {
            get; set;
        }
        public string NombreUsuario {
            get; set;
        }
        public string LoginPass {

            get;set;
        }
        public DateTime UltimoLogin {
            get; set;
        }
        public int IdRol {
            get; set;
        }
        public List<int> Permisos {
            get; set;
        }
        public bool Nuevo {
            get; set;
        } = false;

        public LoginModel() {
            Permisos = new List<int>();
        }
        public LoginModel(string nombre, string passwd, string hash) {
            NombreUsuario = nombre;
            UltimoLogin = DateTime.Now;
            Permisos = new List<int>();
        }
    }
}
