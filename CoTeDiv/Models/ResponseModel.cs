using SernaSistemas.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using WCFCotedivLib.Contracts;

namespace CoTeDiv.Models {
    public class ResponseModel {
        public Dictionary<int, ConceptoModel> Posts {
            get; set;
        }
        public LoginModel LoginData {
            get; set;
        }
        public ConceptoModel Concepto {
            get; set;
        }
        public ValoracionModel Valoracion {
            get; set;
        }
        public EvaluacionModel Evaluacion {
            get; set;
        }
        public PerfilModel Perfil {
            get; set;
        }
        public ResponseModel() {
        }
    }
    public class InstitucionModel {
        public int Id {
            get; set;
        }
        public string Nombre {
            get; set;
        }
        public string Lat {
            get; set;
        }
        public string Lon {
            get; set;
        }
        public int IdLocacion {
            get; set;
        }
    }

    public class ValoracionModel {
        public int Id {
            get; set;
        }
        public int Valor {
            get; set;
        }
        public AlumnoModel Alumno {
            get; set;
        }
    }
    public class EvaluacionModel {
        public int Id {
            get; set;
        }
        public int Valor {
            get; set;
        }
        public ExpertoModel Experto {
            get; set;
        }
    }
    public class AlumnoModel {
        public int Id {
            get; set;
        }
    }
    public class ExpertoModel {
        public int Id {
            get; set;
        }
    }
    public class ConceptoModel {
        public int Id {
            get; set;
        }
        public string Titulo {
            get; set;
        }
        public string Contenido {
            get; set;
        }
        public DateTime Fecha {
            get;
            internal set;
        }
        public int Valor {
            get;
            internal set;
        }
        public int Evaluacion {
            get;set;
        }
    }
    public class PerfilModel {
        public int Id {
            get; set;
        }
        public string Usuario {
            get; set;
        }
        public string NuevoPassword {
            get; set;
        }
        public string Correo {
            get; set;
        }
        public string Telefono {
            get; set;
        }
        public DateTime Nacimiento {
            get; set;
        }
        public string Resumen {
            get; set;
        }
        public int IdStatus {
            get; set;
        }
        public int IdInstitucion {
            get; set;
        }
        public InstitucionModel Institucion {
            get; set;
        }
        public List<NombreItem> Nombres {
            get; set;
        }
        public string NombreCompleto {
            get {
                StringBuilder sb = new StringBuilder();
                foreach (var item in Nombres.OrderBy(n=>n.Orden)) {
                    sb.Append(item.Valor + " ");
                }
                return sb.ToString().Trim();
            }
        }
        public List<DireccionItem> Direccion {
            get; set;
        }
        public string DireccionCompleta {
            get {
                StringBuilder sb = new StringBuilder();
                foreach (var item in Direccion.OrderBy(n => n.IdTipoElemento)) {
                    sb.Append(item.Valor + " ");
                }
                return sb.ToString().Trim();
            }
        }
        public List<InstitucionModel> Instituciones {
            get; set;
        }
    }
}