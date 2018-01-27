using SernaSistemas.Core.Models;
using SernaSistemas.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.ServiceModel;
using System.Text;
using WCFCotedivLib.Contracts;

namespace WCFCotedivLib {
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class CotedivServices : ICotedivServices {

        SernaSistemasDataModelDataContext dtx = new SernaSistemasDataModelDataContext();

        public BoolResponse BorrarEntrada(EntradaRequest request) {
            throw new NotImplementedException();
        }

        public AlumnoResponse CrearCuenta(AlumnoRequest request) {
            throw new NotImplementedException();
        }

        public EntradaResponse EvaluarEntrada(EntradaRequest request) {
            throw new NotImplementedException();
        }

        public EntradaResponse GuardarEntrada(EntradaRequest request) {
            Publicacion _publicacion;
            EntradaResponse response = new EntradaResponse() {
                Contenido = request.Contenido,
                Titulo = request.Titulo
            };
            try {
                var Alumno = dtx.Alumnos.First(a => a.UsuarioSistema.IdUsuario.Equals(request.IdAutor));
                var Status = dtx.StatusSistemas.First(s => s.Id.Equals(1));

                if (request.Id.Equals(0)) {
                    _publicacion = new Publicacion() {
                        Contenido = request.Contenido,
                        Fecha = request.Fecha,
                        Titulo = request.Titulo
                    };
                    Alumno.Publicacions.Add(_publicacion);
                    Status.Publicacions.Add(_publicacion);
                } else {
                    _publicacion = dtx.Publicacions.First(p => p.Id.Equals(request.Id));
                    _publicacion.Contenido = request.Contenido;
                    _publicacion.Titulo = request.Titulo;
                    _publicacion.Fecha = DateTime.Today;
                }
                dtx.SubmitChanges();
                response.Id = _publicacion.Id;
                response.Success = true;
                response.ErrorMsg = string.Empty;
            } catch (Exception ex) {
                response.Success = false;
                response.ErrorMsg = ex.Message;
            }
            return response;
        }

        public PerfilResponse GuardarPerfil(PerfilRequest request) {
            PerfilResponse response;
            var perfil = dtx.UsuarioSistemas.FirstOrDefault(u => u.IdUsuario.Equals(request.IdUsuario));
            var status = dtx.StatusSistemas.FirstOrDefault(s => s.Id.Equals(1));

            switch (perfil.IdRol) {
                case 2:
                    Alumno alumno = perfil.Alumnos.FirstOrDefault();
                    if (alumno == null) {
                        alumno = new Alumno();
                        perfil.Alumnos.Add(alumno);
                    }
                    if (status != null)
                        status.Alumnos.Add(alumno);
                    var institucion = dtx.Institucions.FirstOrDefault();
                    if (institucion != null)
                        institucion.Alumnos.Add(alumno);
                    alumno.Resumen = request.Resumen;
                    break;
                case 3:
                    Experto experto = perfil.Expertos.FirstOrDefault();
                    if (experto == null) {
                        experto = new Experto();
                        perfil.Expertos.Add(experto);
                    }
                    if (status != null)
                        status.Expertos.Add(experto);
                    experto.Resumen = request.Resumen;
                    break;
            }

            Persona persona = perfil.Usuario.Personas.FirstOrDefault();
            if (persona == null) {
                persona = new Persona();
                perfil.Usuario.Personas.Add(persona);
            }
            persona.Correo = request.Correo;
            persona.Nacimiento = request.Nacimiento;
            persona.Telefono = (request.Telefono != null) ? request.Telefono : string.Empty;

            //foreach (var item in request.Direccion) {
            //    var elementodireccion = new Persona_Direccion() {
            //        Valor = item.Valor
            //    };
            //    persona.Persona_Direccions.Add(elementodireccion);
            //    var TipoElemento = dtx.ElementoDireccions.FirstOrDefault(ed=>ed.i)
            //}
            dtx.SubmitChanges();

            response = new PerfilResponse() {
                Nombres = new List<NombreItem>(),
                Direccion = new List<DireccionItem>(),
                Correo = (persona != null) ? persona.Correo : string.Empty,
                Nacimiento = (persona != null) ? (persona.Nacimiento.HasValue ?
                perfil.Usuario.Personas.First().Nacimiento.Value : DateTime.Today) : DateTime.Today,
                Telefono = (persona != null) ? persona.Telefono : string.Empty,
                //Resumen = (alumno != null) ? alumno.Resumen : string.Empty,
                //IdStatus = (alumno != null) ? alumno.IdStatusSistema : 0
            };
            if (persona != null) {
                var Nombres = (from n in persona.Nombres
                               select new NombreItem() {
                                   Id = n.Id,
                                   IdPersona = n.IdPersona,
                                   Orden = n.Orden,
                                   Valor = n.Valor
                               }).ToList();
                var Direcciones = (from d in persona.Persona_Direccions
                                   select new DireccionItem() {
                                       Id = d.Id,
                                       IdPersona = d.IdPersona,
                                       IdTipoElemento = d.IdTipoElemento,
                                       Valor = d.Valor
                                   }).ToList();
                response.Nombres.AddRange(Nombres);
                response.Direccion.AddRange(Direcciones);
            }

            return response;
        }

        public List<TipoElemento> getTipoElementoDireccion() {
            var response = (from ted in dtx.TipoElementos
                            select ted).ToList();
            return response;
        }

        public List<InstitucionModel> getInstituciones() {
            var response = (from i in dtx.Institucions
                            orderby i.Nombre
                            select new InstitucionModel() {
                                Id = i.Id,
                                IdLocacion = i.Locacion.Id,
                                Lat = i.Locacion.Lat,
                                Lon = i.Locacion.Lon,
                                Nombre = i.Nombre
                            }
                            ).ToList();

            return response;
        }

        public ListaResponse ListarEntradas(object request) {
            var response = new ListaResponse();
            List<ConceptoModel> entradas;
            if (request == null) {
                entradas = new List<ConceptoModel>();
                response.Success = false;
            } else if (request is int) {
                entradas = (from p in dtx.Publicacions
                            orderby p.Fecha
                            select new ConceptoModel() {
                                Id = p.Id,
                                Contenido = p.Contenido,
                                Titulo = p.Titulo
                            }).Take((int)request).ToList();
                response.Success = true;
            } else if (request is LoginModel) {
                entradas = (from p in dtx.Publicacions
                            where p.Alumno.UsuarioSistema.IdUsuario.Equals((request as LoginModel).IdUsuario)
                            orderby p.Fecha
                            select new ConceptoModel() {
                                Id = p.Id,
                                Contenido = p.Contenido,
                                Titulo = p.Titulo,
                                Valoracion = ((int?)(p.Valoracions.Average(i => i.IdPublicacion))).HasValue ?
                                ((int?)(p.Valoracions.Average(i => i.IdPublicacion))).Value : 0
                            }).ToList();
                response.Success = true;
            } else if (request is string) {
                entradas = (from p in dtx.Publicacions
                            where p.Contenido.Contains(request as string) || p.Titulo.Contains(request as string)
                            select new ConceptoModel() {
                                Id = p.Id,
                                Contenido = p.Contenido,
                                Titulo = p.Titulo,
                                Evaluacion = (p.Evaluacions.Count > 0) ?
                                p.Evaluacions.OrderByDescending(e => e.Fecha).FirstOrDefault().Valor : 0
                            }
                            ).ToList();
            } else {
                entradas = new List<ConceptoModel>();
                response.Success = false;
            }
            foreach (var item in entradas) {
                response.Resultados.Add(item.Id, item);
            }
            return response;
        }

        public ListaResponse ListarExpertos(object request) {
            throw new NotImplementedException();
        }

        public LoginResponse Login(LoginRequest request) {
            var response = new LoginResponse() {
                Success = false
            };

            if (request.UserId != null) {
                try {
                    var usuario = (from u in dtx.vUsuariosSistemas
                                   where u.Usuario.Equals(request.UserId) &&
                                   u.Passwd.Equals(request.Password) &&
                                   u.IdSistema.Equals(2)
                                   select u).SingleOrDefault();
                    if (usuario != null) {
                        string predigest = request.UserId + "::" + request.Password + "::" + DateTime.Now.ToUniversalTime();
                        UTF32Encoding ASCII_encoding = new UTF32Encoding();
                        SHA256 sha1 = SHA256.Create();
                        byte[] input = ASCII_encoding.GetBytes(predigest);
                        byte[] hash = sha1.ComputeHash(input);

                        StringBuilder sb = new StringBuilder();
                        for (int i = 0; i < hash.Length; i++)
                            sb.AppendFormat("{0:x2}", hash[i]);

                        response.Modelo.IdUsuario = usuario.Id;
                        response.Modelo.UltimoLogin = DateTime.Today;
                        response.Modelo.IdRol = usuario.IdRol;
                        response.Modelo.NombreUsuario = usuario.Usuario;
                        response.Modelo.Hash = sb.ToString();
                        response.ErrorMsg = string.Empty;
                        response.Success = true;
                    }
                } catch (Exception ex) {
                    response.Success = false;
                    response.ErrorMsg = ex.Message;
                }
            }
            return response;
        }

        public BoolResponse Logout(object request) {
            throw new NotImplementedException();
        }

        public EntradaResponse ValorarEntrada(EntradaRequest request) {
            throw new NotImplementedException();
        }

        public EntradaResponse VerEntrada(EntradaRequest request) {
            var entrada = dtx.Publicacions.FirstOrDefault(p => p.Id.Equals(request.Id));
            EntradaResponse response = new EntradaResponse() {
                Id = request.Id,
                Contenido = entrada.Contenido,
                Titulo = entrada.Titulo,
                ErrorMsg = string.Empty,
                Success = true
            };
            return response;
        }

        /// <summary>
        /// (Por el momento) Recupera el perfil del alumno
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public PerfilResponse VerPerfil(PerfilRequest request) {
            var perfil = dtx.UsuarioSistemas.FirstOrDefault(u => u.IdUsuario.Equals(request.IdUsuario));

            var persona = perfil.Usuario.Personas.FirstOrDefault();
            var response = new PerfilResponse() {
                Nombres = new List<NombreItem>(),
                Direccion = new List<DireccionItem>(),
                Correo = (persona != null) ? persona.Correo : string.Empty,
                Nacimiento = (persona != null) ? (persona.Nacimiento.HasValue ?
                perfil.Usuario.Personas.First().Nacimiento.Value : DateTime.Today) : DateTime.Today,
                Telefono = (persona != null) ? persona.Telefono : string.Empty,
            };

            switch (perfil.IdRol) {
                case 2:
                    var alumno = perfil.Alumnos.FirstOrDefault();
                    response.Resumen = (alumno != null) ? alumno.Resumen : string.Empty;
                    response.IdStatus = (alumno != null) ? alumno.IdStatusSistema : 0;
                    response.Institucion = new InstitucionModel() {
                        Id = alumno.Institucion.Id,
                        IdLocacion = alumno.Institucion.Locacion.Id,
                        Lat = alumno.Institucion.Locacion.Lat,
                        Lon = alumno.Institucion.Locacion.Lon,
                        Nombre = alumno.Institucion.Nombre
                    };
                    break;
                case 3:
                    var experto = perfil.Expertos.FirstOrDefault();
                    response.Resumen = (experto != null) ? experto.Resumen : string.Empty;
                    response.IdStatus = (experto != null) ? experto.IdStatusSistema : 0;
                    response.Instituciones = new List<InstitucionModel>();
                    foreach (var item in experto.ExpertoEscuelas) {
                        response.Instituciones.Add(new InstitucionModel() {
                            Id = item.Institucion.Id,
                            IdLocacion = item.Institucion.Locacion.Id,
                            Lat = item.Institucion.Locacion.Lat,
                            Lon = item.Institucion.Locacion.Lon,
                            Nombre = item.Institucion.Nombre
                        });
                    }
                    break;
            }

            if (persona != null) {
                var Nombres = (from n in persona.Nombres
                               select new NombreItem() {
                                   Id = n.Id,
                                   IdPersona = n.IdPersona,
                                   Orden = n.Orden,
                                   Valor = n.Valor
                               }).ToList();
                var Direcciones = (from d in persona.Persona_Direccions
                                   select new DireccionItem() {
                                       Id = d.Id,
                                       IdPersona = d.IdPersona,
                                       IdTipoElemento = d.IdTipoElemento,
                                       Valor = d.Valor
                                   }).ToList();
                response.Nombres.AddRange(Nombres);
                response.Direccion.AddRange(Direcciones);
            }
            return response;
        }
    }
}
