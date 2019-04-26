using SernaSistemas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WCFClinica.Clases;

namespace SernaSistemas.Controllers {
    public class HistoriaClinicaController : Controller {
        private static WCFClinica.Modelos.CatalogoReqResp obtenerCatalogo(string catalogo) {
            WCFClinica.ClinicaService _servicio = new WCFClinica.ClinicaService();
            var resutados = _servicio.obtenerCatalogo(new WCFClinica.Modelos.CatalogoReqResp() {
                Catalogo = catalogo
            });
            return resutados;
        }

        // GET: HistoriaClinica
        public ActionResult Index() {
            return View();
        }

        public ActionResult Login() {
            var model = new LoginModel() {
                Request = new WCFClinica.Modelos.LoginRequest()
            };
            return View("_login");
        }
        [HttpPost]
        public RedirectToRouteResult hazLogin(LoginModel model) {
            WCFClinica.ClinicaService servicio = new WCFClinica.ClinicaService();
            var response = servicio.hazLogin(new WCFClinica.Modelos.LoginRequest() {
                Usuario = model.Request.Usuario,
                Password = model.Request.Password
            });
            if (response.Resultado == 1) {
                var modelvista = new buscarHistoriasModel();
                Session.Remove("UsrHC");
                Session.Remove("UsrKey");
                Session.Remove("UsrHCId");
                Session.Add("UsrHC", model.Request.Usuario);
                Session.Add("UsrKey", response.Mensaje);
                Session.Add("UsrHCId", response.Id);
                return RedirectToAction("BuscarHistorias");
            } else {
                return RedirectToAction("Login");
            }
        }

        public ActionResult verPaciente(int IdPaciente) {
            if (Session["UsrHC"] == null)
                return RedirectToAction("Login");
            if (string.IsNullOrEmpty(Session["UsrHC"].ToString())) {
                return RedirectToAction("Login");
            }
            WCFClinica.ClinicaService servicio = new WCFClinica.ClinicaService();
            var response = servicio.selPaciente(new WCFClinica.Modelos.selPacienteReqResp() {
                IdPaciente = IdPaciente
            });
            var tiposexo = obtenerCatalogo("Sexo");
            var tiposangre = obtenerCatalogo("TipoSangre");
            var tipotelefono = obtenerCatalogo("TipoTelefono");
            var Estados = servicio.obtenerEstados(new WCFClinica.Modelos.EstadosReqResp() { Datos = new WCFClinica.Modelos.EstadosReqRespItem() { Nombre = string.Empty, Id = 0 } });

            PacienteModel modelo = new PacienteModel() {
                Alcohol = response.Alcohol,
                CiudadNacimiento = response.CiudadNacimiento,
                CiudadResidencia = response.CiudadResidencia,
                dicTipoTelefono = tipotelefono.items.Select(i => new SelectListItem { Text = i.Value, Value = i.Key.ToString() }),
                dicTipoSangre = tiposangre.items.Select(i => new SelectListItem { Text = i.Value, Value = i.Key.ToString() }),
                dicSexo = tiposexo.items.Select(i => new SelectListItem { Text = i.Value, Value = i.Key.ToString() }),
                dicLugarResidencia = Estados.Items.Select(i => new SelectListItem { Text = i.Nombre, Value = i.Id.ToString() }),
                Domicilio = response.Domicilio,
                ErrNum = response.ErrNum,
                FechaNacimiento = response.FechaNacimiento,
                IdLugarNacimiento = response.IdLugarNacimiento,
                IdLugarResidencia = response.IdLugarResidencia,
                IdPaciente = response.IdPaciente,
                IdPersona = response.IdPersona,
                IdSexo = response.IdSexo,
                IdTipoSangre = response.IdTipoSangre,
                IdTipoNumero = response.IdTipoNumero,
                LugarNacimiento = response.LugarNacimiento,
                LugarResidencia = response.LugarResidencia,
                Mensaje = response.Mensaje,
                Nombre = response.Nombre,
                Numero = response.Numero,
                Rh = response.Rh,
                Sexo = response.Sexo,
                Tabaco = response.Tabaco,
                tieneError = response.tieneError,
                TipoSangre = response.TipoSangre
            };
            return View("_Paciente", modelo);
        }
        public ActionResult Paciente(PacienteModel model) {
            if (Session["UsrHC"] == null)
                return RedirectToAction("Login");
            if (string.IsNullOrEmpty(Session["UsrHC"].ToString())) {
                return RedirectToAction("Login");
            }
            WCFClinica.ClinicaService servicio = new WCFClinica.ClinicaService();
            if (model == null)
                model = new PacienteModel();

            var tiposexo = obtenerCatalogo("Sexo");
            var tiposangre = obtenerCatalogo("TipoSangre");
            var tipotelefono = obtenerCatalogo("TipoTelefono");
            var Estados = servicio.obtenerEstados(new WCFClinica.Modelos.EstadosReqResp() { Datos = new WCFClinica.Modelos.EstadosReqRespItem() { Nombre = string.Empty, Id = 0 } });

            model.dicTipoTelefono = tipotelefono.items.Select(i => new SelectListItem { Text = i.Value, Value = i.Key.ToString() });
            model.dicTipoSangre = tiposangre.items.Select(i => new SelectListItem { Text = i.Value, Value = i.Key.ToString() });
            model.dicSexo = tiposexo.items.Select(i => new SelectListItem { Text = i.Value, Value = i.Key.ToString() });
            model.dicLugarResidencia = Estados.Items.Select(i => new SelectListItem { Text = i.Nombre, Value = i.Id.ToString() });
            return View("_paciente", model);
        }
        [HttpPost]
        public ActionResult postPaciente(PacienteModel modelo) {
            if (Session["UsrHC"] == null)
                return RedirectToAction("Login");
            if (string.IsNullOrEmpty(Session["UsrHC"].ToString())) {
                return RedirectToAction("Login");
            }

            WCFClinica.ClinicaService servicio = new WCFClinica.ClinicaService();
            modelo.dicSexo = obtenerCatalogo("Sexo").items.Select(i => new SelectListItem { Text = i.Value, Value = i.Key.ToString() });
            modelo.dicTipoSangre = obtenerCatalogo("TipoSangre").items.Select(i => new SelectListItem { Text = i.Value, Value = i.Key.ToString() });
            modelo.dicTipoTelefono = obtenerCatalogo("TipoTelefono").items.Select(i => new SelectListItem { Text = i.Value, Value = i.Key.ToString() });

            var request = new WCFClinica.Modelos.RegistraPacienteReqResp() {
                Alcohol = modelo.Alcohol,
                CiudadNacimiento = modelo.CiudadNacimiento,
                CiudadResidencia = modelo.CiudadResidencia,
                Domicilio = modelo.Domicilio,
                FechaNacimiento = modelo.FechaNacimiento,
                IdPaciente = modelo.IdPaciente,
                IdPersona = modelo.IdPersona,
                LugarNacimiento = modelo.LugarNacimiento,
                LugarResidencia = modelo.LugarResidencia,
                Nombre = modelo.Nombre,
                Rh = modelo.Rh,
                IdSexo = modelo.IdSexo,
                Tabaco = modelo.Tabaco,
                IdLugarNacimiento = modelo.IdLugarNacimiento,
                IdLugarResidencia = modelo.IdLugarResidencia,
                IdTipoSangre = modelo.IdTipoSangre,
                IdTipoNumero = modelo.IdTipoNumero,
                Numero = modelo.Numero
            };
            var response = servicio.registraPaciente(request);
            return RedirectToAction("Paciente", modelo);
        }

        /// <summary>
        /// con IdHistoria abre esa historia
        /// con IdPaciente crea nueva historia para ese paciente
        /// sin Ids crea nueva historia
        /// con Ids abre la historia
        /// </summary>
        /// <param name="IdHistoria"></param>
        /// <param name="idPaciente"></param>
        /// <returns></returns>
        public ActionResult Historia(int? IdHistoria, int? idPaciente) {
            if (Session["UsrHC"] == null)
                return RedirectToAction("Login");
            if (string.IsNullOrEmpty(Session["UsrHC"].ToString())) {
                return RedirectToAction("Login");
            }

            WCFClinica.ClinicaService servicio = new WCFClinica.ClinicaService();
            var Estados = servicio.obtenerEstados(new WCFClinica.Modelos.EstadosReqResp() { Datos = new WCFClinica.Modelos.EstadosReqRespItem() { Nombre = string.Empty, Id = 0 } });
            var model = new HistoriaModel() {
                AntecedentesGinecoObstetricios = new WCFClinica.Modelos.RegistaAntGinecoReqResp(),
                AntecedentesHereditarios = new WCFClinica.Modelos.selAntHeredReqResp() {
                    Items = new List<WCFClinica.Modelos.AntHeredItem>()
                },
                AntecedentesPatologicos = new WCFClinica.Modelos.selAntPersonalPatReqResp() {
                    Items = new List<WCFClinica.Modelos.AntPersonalPatItem>()
                },
                HistoriaClinica = new WCFClinica.Modelos.selHistoriaReqResp() {
                    FechaHistoria = DateTime.Today
                },
                MedicacionActual = new WCFClinica.Modelos.selMedicacionActualReqResp() {
                    Items = new List<WCFClinica.Modelos.MedicacionActualItem>()
                },
                Paciente = new PacienteModel() {
                    dicSexo = obtenerCatalogo("Sexo").items.Select(i => new SelectListItem { Text = i.Value, Value = i.Key.ToString() }),
                    dicTipoSangre = obtenerCatalogo("TipoSangre").items.Select(i => new SelectListItem { Text = i.Value, Value = i.Key.ToString() }),
                    dicTipoTelefono = obtenerCatalogo("TipoTelefono").items.Select(i => new SelectListItem { Text = i.Value, Value = i.Key.ToString() }),
                    dicLugarResidencia = Estados.Items.Select(i => new SelectListItem { Text = i.Nombre, Value = i.Id.ToString() })
                },
                ExploracionSistemas = new WCFClinica.Modelos.selExploraSistemaReqResp() {
                    Items = new List<WCFClinica.Modelos.ExploraSistemaItem>()
                },
                ExploracionFisica = new WCFClinica.Modelos.RegistraExploraFisicaReqResp(),
                AntecedenteHereditario = new WCFClinica.Modelos.AntHeredItem(),
                AntecedentePatologico = new WCFClinica.Modelos.RegistraAntPersonalPat(),
                Exploracion = new WCFClinica.Modelos.ExploraSistemaItem(),
                Medicacion = new WCFClinica.Modelos.MedicacionActualItem(),
                dicAnticonceptivos = obtenerCatalogo("Anticonceptivo").items.Select(i => new SelectListItem { Text = i.Value, Value = i.Key.ToString() }),
                dicFamiliar = obtenerCatalogo("Familiar").items.Select(i => new SelectListItem { Text = i.Value, Value = i.Key.ToString() }),
                dicMedicos = obtenerCatalogo("Medico").items.Select(i => new SelectListItem { Text = i.Value, Value = i.Key.ToString() }),
                dicSistemas = obtenerCatalogo("Sistema").items.Select(i => new SelectListItem { Text = i.Value, Value = i.Key.ToString() })
            };
            if (idPaciente.HasValue && idPaciente != 0) {
                var response = servicio.selPaciente(new WCFClinica.Modelos.selPacienteReqResp() {
                    IdPaciente = idPaciente.Value
                });
                model.Paciente.Alcohol = response.Alcohol;
                model.Paciente.CiudadNacimiento = response.CiudadNacimiento;
                model.Paciente.CiudadResidencia = response.CiudadResidencia;
                model.Paciente.Domicilio = response.Domicilio;
                model.Paciente.FechaNacimiento = response.FechaNacimiento;
                model.Paciente.IdLugarNacimiento = response.IdLugarNacimiento;
                model.Paciente.IdLugarResidencia = response.IdLugarResidencia;
                model.Paciente.IdPaciente = response.IdPaciente;
                model.Paciente.IdPersona = response.IdPersona;
                model.Paciente.IdSexo = response.IdSexo;
                model.Paciente.IdTipoNumero = response.IdTipoNumero;
                model.Paciente.IdTipoSangre = response.IdTipoSangre;
                model.Paciente.LugarNacimiento = response.LugarNacimiento;
                model.Paciente.LugarResidencia = response.LugarResidencia;
                model.Paciente.Nombre = response.Nombre;
                model.Paciente.Numero = response.Numero;
                model.Paciente.Rh = response.Rh;
                model.Paciente.Sexo = response.Sexo;
                model.Paciente.Tabaco = response.Tabaco;
                model.Paciente.TipoSangre = response.TipoSangre;
            }

            return View("_historiaClinica", model);
        }
        [HttpPost]
        public ActionResult postHistoria(HistoriaModel modelo, object hidData) {
            if (Session["UsrHC"] == null)
                return RedirectToAction("Login");
            if (string.IsNullOrEmpty(Session["UsrHC"].ToString())) {
                return RedirectToAction("Login");
            }

            WCFClinica.ClinicaService servicio = new WCFClinica.ClinicaService();
            var colecciones = (new JavaScriptSerializer()).Deserialize
                <List<Dictionary<string, List<Dictionary<string, string>>>>>(
                ((string[])modelo.colecciones)[0]
                );

            List<ReqRespBase> reqResp = new List<ReqRespBase>();
            var paciente = servicio.registraPaciente(new WCFClinica.Modelos.RegistraPacienteReqResp() {
                Alcohol = modelo.Paciente.Alcohol,
                CiudadNacimiento = modelo.Paciente.CiudadNacimiento,
                CiudadResidencia = modelo.Paciente.CiudadResidencia,
                Domicilio = modelo.Paciente.Domicilio,
                FechaNacimiento = modelo.Paciente.FechaNacimiento,
                IdLugarNacimiento = modelo.Paciente.IdLugarNacimiento,
                IdLugarResidencia = modelo.Paciente.IdLugarResidencia,
                IdPaciente = modelo.Paciente.IdPaciente,
                IdPersona = modelo.Paciente.IdPersona,
                IdSexo = modelo.Paciente.IdSexo,
                IdTipoNumero = modelo.Paciente.IdTipoNumero,
                IdTipoSangre = modelo.Paciente.IdTipoSangre,
                Nombre = modelo.Paciente.Nombre,
                Numero = modelo.Paciente.Numero,
                Rh = modelo.Paciente.Rh,
                Tabaco = modelo.Paciente.Tabaco,
                TipoSangre = modelo.Paciente.TipoSangre
            });
            var historia = servicio.GuardaHistoriaClinica(new WCFClinica.Modelos.RegistraHistoriaReqResp() {
                Analisis = modelo.HistoriaClinica.Analisis,
                FechaHistoria = modelo.HistoriaClinica.FechaHistoria,
                Id = modelo.HistoriaClinica.Id,
                IdHistoria = modelo.HistoriaClinica.Id,
                IdMedico = modelo.HistoriaClinica.IdMedico,
                IdPaciente = paciente.IdPaciente,
                ImpresionDiagnostica = modelo.HistoriaClinica.ImpresionDiagnostica,
                MotivoConsulta = modelo.HistoriaClinica.MotivoConsulta,
                PlanTerapeutico = modelo.HistoriaClinica.PlanTerapeutico
            });
            reqResp.Add(paciente);
            reqResp.Add(historia);
            reqResp.Add(servicio.GuardaExploracionFisica(new WCFClinica.Modelos.RegistraExploraFisicaReqResp() {
                Descripcion = modelo.ExploracionFisica.Descripcion,
                Estatura = modelo.ExploracionFisica.Estatura,
                FC = modelo.ExploracionFisica.FC,
                FR = modelo.ExploracionFisica.FR,
                Id = modelo.ExploracionFisica.Id,
                IdHistoria = historia.Id,
                Peso = modelo.ExploracionFisica.Peso,
                Pulso = modelo.ExploracionFisica.Pulso,
                TA = modelo.ExploracionFisica.TA,
                Temperatura = modelo.ExploracionFisica.Temperatura
            }));

            if (paciente.Sexo.Equals("Femenino")) {
                reqResp.Add(servicio.GuardaAntGineco(new WCFClinica.Modelos.RegistaAntGinecoReqResp() {
                    A = modelo.AntecedentesGinecoObstetricios.A,
                    C = modelo.AntecedentesGinecoObstetricios.C,
                    FUR = modelo.AntecedentesGinecoObstetricios.FUR,
                    G = modelo.AntecedentesGinecoObstetricios.G,
                    Id = modelo.AntecedentesGinecoObstetricios.Id,
                    IdAnticonceptivo = modelo.AntecedentesGinecoObstetricios.IdAnticonceptivo,
                    IdPaciente = paciente.IdPaciente,
                    Mastografia = modelo.AntecedentesGinecoObstetricios.Mastografia,
                    Menarca = modelo.AntecedentesGinecoObstetricios.Menarca,
                    P = modelo.AntecedentesGinecoObstetricios.P,
                    Papanicolaou = modelo.AntecedentesGinecoObstetricios.Papanicolaou
                }));
            }

            for (int i = 0; i < colecciones.Count(); i++) {
                var arreglo = (colecciones[i] as Dictionary<string, List<Dictionary<string, string>>>);
                if (arreglo.ContainsKey("Antecedentes")) {
                    foreach (var item in arreglo["Antecedentes"]) {
                        servicio.GuardaAntHered(new WCFClinica.Modelos.RegistraAntHeredReqResp() {
                            IdFamiliar = int.Parse(item["IdFamiliar"]),
                            IdPaciente = paciente.IdPaciente,
                            Padecimiento = item["Padecimiento"],
                            Id = 0
                        });
                    }
                } else if (arreglo.ContainsKey("Enfermedades")) {
                    foreach (var item in arreglo["Enfermedades"]) {
                        reqResp.Add(servicio.GuardaAntPersonalPatologico(new WCFClinica.Modelos.RegistraAntPersonalPat() {
                            Enfermedad = item["Enfermedad"],
                            FechaInicio = DateTime.Parse(item["FechaInicio"]),
                            IdStatus = int.Parse(item["IdStatus"]),
                            IdPaciente = paciente.IdPaciente,
                            Id = 0
                        }));
                    }
                } else if (arreglo.ContainsKey("Sistemas")) {
                    foreach (var item in arreglo["Sistemas"]) {
                        reqResp.Add(servicio.GuardaExploracionSistema(new WCFClinica.Modelos.RegistraExploraSistemaReqResp() {
                            IdHistoria = historia.Id,
                            IdSistema = int.Parse(item["IdSistema"]),
                            Descripcion = item["Descripcion"],
                            Id = 0
                        }));
                    }
                } else if (arreglo.ContainsKey("Medicacion")) {
                    foreach (var item in arreglo["Medicacion"]) {
                        reqResp.Add(servicio.GuardaMedicacionActual(new WCFClinica.Modelos.RegistraMedicacionActualReqResp() {
                            IdHistoria = historia.Id,
                            Dosis = item["Dosis"],
                            FechaInicio = DateTime.Parse(item["FechaInicio"]),
                            Medicamento = item["Medicacion"],
                            Id = 0
                        }));
                    }
                }
            }
            var mensajes = reqResp.Select(r => new { r.ErrNum, r.Mensaje, r.tieneError }).ToList();

            return RedirectToAction("Historia", new { IdHistoria = modelo.HistoriaClinica.Id });
        }

        public ActionResult BuscarHistorias() {
            if (Session["UsrHC"] == null)
                return RedirectToAction("Login");
            if (string.IsNullOrEmpty(Session["UsrHC"].ToString())) {
                return RedirectToAction("Login");
            }

            var model = new buscarHistoriasModel() {
                Historias = new List<WCFClinica.Modelos.buscarHistoriasItem>()
            };
            return View("_buscarHistorias", model);
        }
        public ActionResult BuscarPacientes() {
            if (Session["UsrHC"] == null)
                return RedirectToAction("Login");
            if (string.IsNullOrEmpty(Session["UsrHC"].ToString())) {
                return RedirectToAction("Login");
            }

            WCFClinica.ClinicaService servicio = new WCFClinica.ClinicaService();
            var modelo = new ListaPacientesModel() {
                Pacientes = new WCFClinica.Modelos.buscarPacienteResponse() {
                    Items = new List<WCFClinica.Modelos.buscarPacienteItem>()
                }
            };
            modelo.Pacientes = servicio.buscarPaciente(new WCFClinica.Modelos.buscarPacienteRequest() {
            });

            return View("_listaPacientes", modelo);
        }
        public ActionResult ListadoHistorias() {
            if (Session["UsrHC"] == null)
                return RedirectToAction("Login");
            if (string.IsNullOrEmpty(Session["UsrHC"].ToString())) {
                return RedirectToAction("Login");
            }

            var model = new ListaHistorias() {
                Historias = new List<WCFClinica.Modelos.selHistoriaReqResp>()
            };
            return View("_listaHistorias", model);
        }
        public ActionResult ListadoPacientes(string txtBuscar) {
            if (Session["UsrHC"] == null)
                return RedirectToAction("Login");
            if (string.IsNullOrEmpty(Session["UsrHC"].ToString())) {
                return RedirectToAction("Login");
            }

            WCFClinica.ClinicaService servicio = new WCFClinica.ClinicaService();
            var modelo = new ListaPacientesModel() {
                Pacientes = new WCFClinica.Modelos.buscarPacienteResponse() {
                    Items = new List<WCFClinica.Modelos.buscarPacienteItem>()
                }
            };
            modelo.Pacientes = servicio.buscarPaciente(new WCFClinica.Modelos.buscarPacienteRequest() {
                Nombre = txtBuscar
            });

            return View("_listaPacientes", modelo);
        }

        public ActionResult Medico() {
            if (Session["UsrHC"] == null)
                return RedirectToAction("Login");
            if (!string.IsNullOrEmpty(Session["UsrHC"].ToString())) {
                WCFClinica.ClinicaService servicio = new WCFClinica.ClinicaService();
                var response = servicio.verMedico(new WCFClinica.Modelos.RegistraMedicoReqResp() {
                    Id = int.Parse(Session["UsrHCId"].ToString())
                });
                var Estados = servicio.obtenerEstados(new WCFClinica.Modelos.EstadosReqResp() { Datos = new WCFClinica.Modelos.EstadosReqRespItem() { Nombre = string.Empty, Id = 0 } });
                var model = new MedicoModel() {
                    Perfil = new WCFClinica.Modelos.RegistraMedicoReqResp() {
                        CiudadNacimiento = response.CiudadNacimiento,
                        FechaNacimiento = response.FechaNacimiento,
                        Id = response.Id,
                        IdLugarNacimiento = response.IdLugarNacimiento,
                        IdSexo = response.IdSexo,
                        IdTipoSangre = response.IdTipoSangre,
                        LugarNacimiento = response.LugarNacimiento,
                        Nombre = response.Nombre,
                        Rh = response.Rh,
                        Sexo = response.Sexo,
                        TipoSangre = response.TipoSangre,
                        Usuario = response.Usuario
                    },
                    dicTipoTelefono = obtenerCatalogo("TipoTelefono").items.Select(i => new SelectListItem { Text = i.Value, Value = i.Key.ToString() }),
                    dicTipoSangre = obtenerCatalogo("TipoSangre").items.Select(i => new SelectListItem { Text = i.Value, Value = i.Key.ToString() }),
                    dicSexo = obtenerCatalogo("Sexo").items.Select(i => new SelectListItem { Text = i.Value, Value = i.Key.ToString() }),
                    dicLugar = Estados.Items.Select(i => new SelectListItem { Text = i.Nombre, Value = i.Id.ToString() })
                };

                return View("_medico", model);
            } else {
                return RedirectToAction("Login");
            }
        }
        [HttpPost]
        public ActionResult postMedico(MedicoModel modelo) {
            if (Session["UsrHC"] == null)
                return RedirectToAction("Login");
            if (string.IsNullOrEmpty(Session["UsrHC"].ToString())) {
                return RedirectToAction("Login");
            }

            WCFClinica.ClinicaService servicio = new WCFClinica.ClinicaService();
            var response = servicio.registraMedico(new WCFClinica.Modelos.RegistraMedicoReqResp() {
                CiudadNacimiento = modelo.Perfil.CiudadNacimiento,
                FechaNacimiento = modelo.Perfil.FechaNacimiento,
                Id = modelo.Perfil.Id,
                IdLugarNacimiento = modelo.Perfil.IdLugarNacimiento,
                IdSexo = modelo.Perfil.IdSexo,
                IdTipoSangre = modelo.Perfil.IdTipoSangre,
                LugarNacimiento = modelo.Perfil.LugarNacimiento,
                Nombre = modelo.Perfil.Nombre,
                Rh = modelo.Perfil.Rh,
                Sexo = modelo.Perfil.Sexo,
                TipoSangre = modelo.Perfil.TipoSangre,
                Usuario = modelo.Perfil.Usuario,
                Constrasenia = modelo.Perfil.Constrasenia
            });

            return RedirectToAction("Medico");
        }
    }
}
