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
                var Status = dtx.Status.First(s => s.Id.Equals(1));

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
            throw new NotImplementedException();
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
                                Titulo = p.Titulo
                            }).ToList();
                response.Success = true;
            } else if (request is string) {
                entradas = (from p in dtx.Publicacions
                            where p.Contenido.Contains(request as string) || p.Titulo.Contains(request as string)
                            select new ConceptoModel() {
                                Id = p.Id,
                                Contenido = p.Contenido,
                                Titulo = p.Titulo
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

        public PerfilResponse VerPerfil(PerfilRequest request) {
            var response = new PerfilResponse() {
                Nombres = new List<NombreItem>()
            };
            var perfil = dtx.UsuarioSistemas.FirstOrDefault(u => u.IdUsuario.Equals(request.IdUsuario));

            var Nombres = (from n in perfil.Usuario.Personas.First(p => p.IdUsuario.Equals(perfil.IdUsuario)).Nombres
                           select new NombreItem() {
                               Id = n.Id,
                               IdPersona = n.IdPersona,
                               Orden = n.Orden,
                               Valor = n.Valor
                           }).ToList();
            response.Nombres.AddRange(Nombres);
            response.Correo = perfil.Usuario.Personas.First().Correo;
            response.Nacimiento = perfil.Usuario.Personas.First().Nacimiento.HasValue ?
                perfil.Usuario.Personas.First().Nacimiento.Value : DateTime.Today;
            response.Telefono = perfil.Usuario.Personas.First().Telefono;
            return response;
        }
    }
}
