﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WCFTiendasLib.Contracts;

namespace WCFTiendasLib {

    public class TiendasServices : ITiendasServices {
        public const string K_CONTACTO_REGISTRADO = "EL CONTACTO FUE REGISTRADO";
        public const string K_NOMBRE_CONTACTO_REGISTRADO = "EL NOMBRE DE CONTACTO YA EXISTE";
        public const string K_TELEFONO_CONTACTO_REGISTRADO = "EL TELÉFONO DE CONTACTO YA EXISTE";
        public const string K_CORREO_CONTACTO_REGISTRADO = "EL CORREO ELECTRÓNICO DE CONTACTO YA EXISTE";
        public const string K_REGISTRO_NO_ENCONTRADO = "El registro no fue encontrado. Verifica tus datos";

        public string connstring { get; set; } = ConfigurationManager.ConnectionStrings["WCFTiendasLib.Properties.Settings.SernaConnStr"].ConnectionString;

        public PropietarioResponse CrearCuenta(RegistrarPropietarioRequest request) {
            throw new NotImplementedException();
        }

        public PropietarioResponse GuardarDatos(RegistrarPropietarioRequest request) {
            SqlCommand Cmd;
            SqlConnection Conn;
            int r;

            var response = new PropietarioResponse() {
                tieneError = false,
                Error = 0,
                Mensaje = string.Empty
            };

            try {
                using (Conn = new SqlConnection(connstring)) {
                    using (Cmd = new SqlCommand() {
                        Connection = Conn,
                        CommandText = "Negocio.UpdAdministrador",
                        CommandType = System.Data.CommandType.StoredProcedure
                    }) {
                        Cmd.Parameters.Add(new SqlParameter() {
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            ParameterName = "Id",
                            Value = request.Id
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            DbType = System.Data.DbType.String,
                            Direction = System.Data.ParameterDirection.Input,
                            ParameterName = "Usuario",
                            Value = request.Usuario
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            DbType = System.Data.DbType.String,
                            Direction = System.Data.ParameterDirection.Input,
                            ParameterName = "Password",
                            Value = request.Password
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            DbType = System.Data.DbType.String,
                            Direction = System.Data.ParameterDirection.Input,
                            ParameterName = "Nombre",
                            Value = request.Nombre
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            DbType = System.Data.DbType.String,
                            Direction = System.Data.ParameterDirection.Input,
                            ParameterName = "Telefono",
                            Value = request.Telefono
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            DbType = System.Data.DbType.String,
                            Direction = System.Data.ParameterDirection.Input,
                            ParameterName = "Correo",
                            Value = request.Correo
                        });

                        Conn.Open();
                        r = Cmd.ExecuteNonQuery();
                    }
                }
                response.Error = 0;
                response.Mensaje = string.Empty;
                response.tieneError = false;
            } catch (Exception ex) {
                response.Error = ex.HResult;
                response.Mensaje = ex.Message;
                response.tieneError = true;
            }
            response.Datos = new Propietario() {
                Id = request.Id,
                Correo = request.Correo,
                Nombre = request.Nombre,
                Telefono = request.Telefono,
                Usuario = request.Usuario
            };
            return response;
        }
        /// <summary>
        /// Inicia sesión en la plataforma de negocios
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public LoginResponse Login(LoginRequest request) {
            var response = new LoginResponse() {
                Error = 0,
                Mensaje = string.Empty,
                tieneError = false
            };
            SqlCommand Cmd;
            SqlConnection Conn;
            SqlDataReader dr;

            var _Hash = SHA1.Create();
            byte[] stream = Encoding.ASCII.GetBytes(request.loginModel.NombreUsuario);
            string _hash = Encoding.ASCII.GetString(_Hash.ComputeHash(stream));
            request.loginModel.Hash = _hash;
            try {
                using (Conn = new SqlConnection(connstring)) {
                    using (Cmd = new SqlCommand() {
                        Connection = Conn,
                        CommandText = "Negocio.hazLogin",
                        CommandType = System.Data.CommandType.StoredProcedure
                    }) {
                        Cmd.Parameters.Add(new SqlParameter() {
                            DbType = System.Data.DbType.String,
                            Direction = System.Data.ParameterDirection.Input,
                            ParameterName = "IdUsuario",
                            Value = request.loginModel.NombreUsuario
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            DbType = System.Data.DbType.String,
                            Direction = System.Data.ParameterDirection.Input,
                            ParameterName = "IdPass",
                            Value = request.loginModel.LoginPass
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            DbType = System.Data.DbType.String,
                            Direction = System.Data.ParameterDirection.Input,
                            ParameterName = "IdToken",
                            Value = request.loginModel.Hash
                        });
                        Conn.Open();
                        dr = Cmd.ExecuteReader();

                        if (dr.HasRows)
                            while (dr.Read())
                                if (dr["Resultado"].ToString().Equals("Hecho")) {
                                    response.loginModel = new SernaSistemas.Core.Models.LoginModel() {
                                        Hash = _hash,
                                        UltimoLogin = DateTime.Now,
                                        IdUsuario = (int)dr["IdUsuario"],
                                        NombreUsuario = request.loginModel.NombreUsuario
                                    };
                                    response.Mensaje = dr["Resultado"].ToString() + dr["IdTienda"].ToString();
                                } else {
                                    throw new Exception(dr["Resultado"].ToString());
                                }
                    }
                }
            } catch (Exception ex) {
                response.Error = 1;
                response.Mensaje = ex.Message;
                response.tieneError = true;
            }
            return response;
        }

        #region Listados
        /// <summary>
        /// Despliega un listado de contactos con base en el Id de la tienda en la cual se registraron
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ListarContactosResponse ListarContactos(ListarContactosRequest request) {
            ListarContactosResponse response = new ListarContactosResponse();
            SqlCommand Cmd;
            SqlConnection Conn;
            SqlDataReader dr;
            try {
                using (Conn = new SqlConnection(connstring)) {
                    using (Cmd = new SqlCommand() {
                        Connection = Conn,
                        CommandText = "Negocio.listarContactos",
                        CommandType = System.Data.CommandType.StoredProcedure
                    }) {
                        Cmd.Parameters.Add(new SqlParameter() {
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            ParameterName = "IdTienda",
                            Value = request.IdTienda
                        });
                        Conn.Open();
                        dr = Cmd.ExecuteReader();

                        if (dr.HasRows)
                            while (dr.Read())
                                response.Contactos.Add(new Contacto() {
                                    Id = (int)dr["Id"],
                                    IdTienda = (int)dr["IdTienda"],
                                    Correo = dr["Correo"].ToString(),
                                    Nombre = dr["Nombre"].ToString(),
                                    Telefono = dr["Telefono"].ToString()
                                });
                    }
                }
            } catch (Exception ex) {
                response.Error = ex.HResult;
                response.Mensaje = ex.Message;
                response.tieneError = true;
            }
            return response;
        }
        /// <summary>
        /// Despliega un listado de fotografías con base en el Id de la tienda a la que pertenecen
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ListarFotoResponse ListarFotos(ListarFotoRequest request) {
            ListarFotoResponse response = new ListarFotoResponse();
            response.Fotos = new Dictionary<int, string>();
            SqlCommand Cmd;
            SqlConnection Conn;
            SqlDataReader dr;
            try {
                using (Conn = new SqlConnection(connstring)) {
                    using (Cmd = new SqlCommand() {
                        Connection = Conn,
                        CommandText = "Negocio.obtenerFotos",
                        CommandType = System.Data.CommandType.StoredProcedure
                    }) {
                        Cmd.Parameters.Add(new SqlParameter() {
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            ParameterName = "IdTienda",
                            Value = request.IdNegocio
                        });
                        Conn.Open();
                        dr = Cmd.ExecuteReader();

                        if (dr.HasRows)
                            while (dr.Read())
                                response.Fotos.Add((int)dr["Id"], dr["Foto"].ToString());
                    }
                }
            } catch (Exception ex) {
                response.Error = ex.HResult;
                response.Mensaje = ex.Message;
                response.tieneError = true;
            }
            return response;
        }
        /// <summary>
        /// Despliega un listado de sucursales con base en el Id de la tienda a la que pertenecen
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ListarLocalesResponse ListarLocales(ListarLocalesRequest request) {
            ListarLocalesResponse response = new ListarLocalesResponse();
            SqlCommand Cmd;
            SqlConnection Conn;
            SqlDataReader dr;
            try {
                using (Conn = new SqlConnection(connstring)) {
                    using (Cmd = new SqlCommand() {
                        Connection = Conn,
                        CommandText = "Negocio.listarSucursales",
                        CommandType = System.Data.CommandType.StoredProcedure
                    }) {
                        Cmd.Parameters.Add(new SqlParameter() {
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            ParameterName = "IdTienda",
                            Value = request.IdTienda
                        });
                        Conn.Open();
                        dr = Cmd.ExecuteReader();

                        if (dr.HasRows)
                            while (dr.Read())
                                response.Sucursales.Add(new Sucursal() {
                                    Id = (int)dr["Id"],
                                    IdTienda = (int)dr["IdTienda"],
                                    Direccion = dr["Direccion"].ToString(),
                                    Correo = dr["Correo"].ToString(),
                                    Telefono = dr["Telefono"].ToString(),
                                    Latitud = dr["Latitud"].ToString(),
                                    Longitud = dr["Longitud"].ToString(),
                                    IdTipo = (int)dr["IdTipo"],
                                    Tipo = dr["Tipo"].ToString(),
                                    Status = (int)dr["Status"],
                                    Visible = (bool)dr["Visible"]
                                });
                    }
                }
            } catch (Exception ex) {
                response.Error = ex.HResult;
                response.Mensaje = ex.Message;
                response.tieneError = true;
            }
            return response;
        }

        public SeccionResponse guardarSeccion(SeccionRequest request) {
            SqlCommand Cmd;
            SqlConnection Conn;
            int r;

            var response = new SeccionResponse() {
                tieneError = false,
                Error = 0,
                Mensaje = string.Empty
            };

            try {
                using (Conn = new SqlConnection(connstring)) {
                    using (Cmd = new SqlCommand() {
                        Connection = Conn,
                        CommandText = "Negocio.UpdSeccionTienda",
                        CommandType = System.Data.CommandType.StoredProcedure
                    }) {
                        Cmd.Parameters.Add(new SqlParameter() {
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            ParameterName = "IdTienda",
                            Value = request.idTienda
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            ParameterName = "IdSeccion",
                            Value = request.idSeccion
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            DbType = System.Data.DbType.String,
                            Direction = System.Data.ParameterDirection.Input,
                            ParameterName = "Titulo",
                            Value = request.titulo
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            DbType = System.Data.DbType.String,
                            Direction = System.Data.ParameterDirection.Input,
                            ParameterName = "Contenido",
                            Value = request.descripcion
                        });
                        Conn.Open();
                        r = Cmd.ExecuteNonQuery();
                    }
                }
                response.Error = 0;
                response.Mensaje = string.Empty;
                response.tieneError = false;
                response.idTienda = request.idTienda;
                response.idSeccion = request.idSeccion;
                response.descripcion = request.descripcion;
            } catch (Exception ex) {
                response.Error = ex.HResult;
                response.Mensaje = ex.Message;
                response.tieneError = true;
            }
            return response;
        }

        /// <summary>
        /// Despliega un listado de productos/servicios con base en la tienda a la que pertenecen y el tipo
        /// del que se trata (producto o servicio)
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ListarOfertasResponse ListarOfertas(ListarOfertasRequest request) {
            ListarOfertasResponse response = new ListarOfertasResponse();

            List<OfertaBreve> ofertas = new List<OfertaBreve>();
            SqlCommand Cmd;
            SqlConnection Conn;
            SqlDataReader dr;
            try {
                using (Conn = new SqlConnection(connstring)) {
                    using (Cmd = new SqlCommand() {
                        Connection = Conn,
                        CommandText = "Negocio.obtenerOfertas",
                        CommandType = System.Data.CommandType.StoredProcedure
                    }) {
                        Cmd.Parameters.Add(new SqlParameter() {
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            ParameterName = "IdTienda",
                            Value = request.IdNegocio
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            ParameterName = "IdTipo",
                            Value = request.TipoOferta.Equals("PRODUCTO") ? 4 : 5
                        });
                        if (request.Visible.HasValue)
                            Cmd.Parameters.Add(new SqlParameter() {
                                DbType = System.Data.DbType.Boolean,
                                Direction = System.Data.ParameterDirection.Input,
                                ParameterName = "Visible",
                                Value = request.Visible.Value
                            });

                        Conn.Open();
                        dr = Cmd.ExecuteReader();

                        if (dr.HasRows)
                            while (dr.Read()) {
                                ofertas.Add(new OfertaBreve() {
                                    Id = (int)dr["Id"],
                                    Nombre = dr["Nombre"].ToString(),
                                    Precio = double.Parse(dr["Precio"].ToString()),
                                    DescripcionBreve = dr["DescBreve"].ToString(),
                                    Descripcion = dr["Descripcion"].ToString(),
                                    Aceptacion = 0,
                                    Foto = dr["Foto"].ToString(),
                                    Tipo = dr["Tipo"].ToString(),
                                    Visible = (bool)dr["Visible"]
                                });
                            }
                    }
                }
                if (request.TipoOferta.Equals("PRODUCTO"))
                    response.Productos = ofertas.ToList();
                if (request.TipoOferta.Equals("SERVICIO"))
                    response.Servicios = ofertas.ToList();


                response.Error = 0;
                response.Mensaje = string.Empty;
                response.tieneError = false;
            } catch (Exception ex) {
                response.Error = ex.HResult;
                response.Mensaje = ex.Message;
                response.tieneError = true;
            }
            return response;
        }

        public TiendaResponse guardarDatosTienda(RegistroTiendaRequest request) {
            SqlCommand Cmd;
            SqlConnection Conn;
            int r;

            var response = new TiendaResponse() {
                tieneError = false,
                Error = 0,
                Mensaje = string.Empty
            };

            try {
                using (Conn = new SqlConnection(connstring)) {
                    using (Cmd = new SqlCommand() {
                        Connection = Conn,
                        CommandText = "Negocio.UpdTienda",
                        CommandType = System.Data.CommandType.StoredProcedure
                    }) {
                        Cmd.Parameters.Add(new SqlParameter() {
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            ParameterName = "Id",
                            Value = request.Datos.Id
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            DbType = System.Data.DbType.String,
                            Direction = System.Data.ParameterDirection.Input,
                            ParameterName = "Correo",
                            Value = request.Datos.CorreoElectronico
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            DbType = System.Data.DbType.String,
                            Direction = System.Data.ParameterDirection.Input,
                            ParameterName = "Direccion",
                            Value = request.Datos.Direccion
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            ParameterName = "IdGiro",
                            Value = request.Datos.Giro
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            DbType = System.Data.DbType.String,
                            Direction = System.Data.ParameterDirection.Input,
                            ParameterName = "Latitud",
                            Value = request.Datos.Latitud
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            DbType = System.Data.DbType.String,
                            Direction = System.Data.ParameterDirection.Input,
                            ParameterName = "Longitud",
                            Value = request.Datos.Longitud
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            DbType = System.Data.DbType.String,
                            Direction = System.Data.ParameterDirection.Input,
                            ParameterName = "Nombre",
                            Value = request.Datos.Nombre
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            DbType = System.Data.DbType.String,
                            Direction = System.Data.ParameterDirection.Input,
                            ParameterName = "RazonSocial",
                            Value = request.Datos.RazonSocial
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            DbType = System.Data.DbType.String,
                            Direction = System.Data.ParameterDirection.Input,
                            ParameterName = "Telefono",
                            Value = request.Datos.Telefono
                        });

                        Conn.Open();
                        r = Cmd.ExecuteNonQuery();
                    }
                }
                response.Error = 0;
                response.Mensaje = string.Empty;
                response.tieneError = false;
            } catch (Exception ex) {
                response.Error = ex.HResult;
                response.Mensaje = ex.Message;
                response.tieneError = true;
            }
            response.Correo = request.Datos.CorreoElectronico;
            response.Direccion = request.Datos.Direccion;
            response.IdGiro = request.Datos.Giro;
            response.Nombre = request.Datos.Nombre;
            response.Telefono = request.Datos.Telefono;
            return response;
        }

        /// <summary>
        /// Despliega un listado de novedades (ofertas recien registradas) con base en el Id de la tienda a la
        /// que pertenecen
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ListarNovedadesResponse ListarNovedades(ListarNovedadesRequest request) {
            ListarNovedadesResponse response = new ListarNovedadesResponse();
            List<OfertaBreve> ofertas = new List<OfertaBreve>();
            SqlCommand Cmd;
            SqlConnection Conn;
            SqlDataReader dr;

            try {
                using (Conn = new SqlConnection(connstring)) {
                    using (Cmd = new SqlCommand() {
                        Connection = Conn,
                        CommandText = "Negocio.obtenerNovedades",
                        CommandType = System.Data.CommandType.StoredProcedure
                    }) {
                        Cmd.Parameters.Add(new SqlParameter() {
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            ParameterName = "IdTienda",
                            Value = request.IdNegocio
                        });
                        Conn.Open();
                        dr = Cmd.ExecuteReader();

                        if (dr.HasRows)
                            while (dr.Read()) {
                                ofertas.Add(new OfertaBreve() {
                                    Id = (int)dr["Id"],
                                    Nombre = dr["Nombre"].ToString(),
                                    Precio = double.Parse(dr["Precio"].ToString()),
                                    DescripcionBreve = dr["DescBreve"].ToString(),
                                    Descripcion = dr["Descripcion"].ToString(),
                                    Aceptacion = 0,
                                    Foto = dr["Foto"].ToString(),
                                    Tipo = dr["Tipo"].ToString()
                                });
                            }
                    }
                }
                response.Novedades = ofertas.ToList();
                response.Error = 0;
                response.Mensaje = string.Empty;
                response.tieneError = false;
            } catch (Exception ex) {
                response.Error = ex.HResult;
                response.Mensaje = ex.Message;
                response.tieneError = true;
            }

            return response;
        }
        /// <summary>
        /// Despliega un listado de tiendas con base en el nombre o parte del mismo y, opcionalmente, el giro
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ListarTiendasResponse ListarTiendas(ListarTiendasRequest request) {
            ListarTiendasResponse response = new ListarTiendasResponse();
            response.Resultados = new List<ResultadoTienda>();

            SqlCommand Cmd;
            SqlConnection Conn;
            SqlDataReader dr;
            try {
                using (Conn = new SqlConnection(connstring)) {
                    using (Cmd = new SqlCommand() {
                        Connection = Conn,
                        CommandText = "Negocio.obtenerNegocios",
                        CommandType = System.Data.CommandType.StoredProcedure
                    }) {
                        Cmd.Parameters.Add(new SqlParameter() {
                            DbType = System.Data.DbType.String,
                            Direction = System.Data.ParameterDirection.Input,
                            ParameterName = "nombre",
                            Value = request.Consulta
                        });
                        if (!string.IsNullOrEmpty(request.Giro))
                            Cmd.Parameters.Add(new SqlParameter() {
                                DbType = System.Data.DbType.Int32,
                                Direction = System.Data.ParameterDirection.Input,
                                ParameterName = "IdGiro",
                                Value = int.Parse(request.Giro)
                            });
                        Conn.Open();

                        dr = Cmd.ExecuteReader();
                        if (dr.HasRows) {
                            while (dr.Read()) {
                                response.Resultados.Add(new ResultadoTienda() {
                                    Id = (int)dr["Id"],
                                    Nombre = dr["RazonSocial"].ToString(),
                                    Direccion = dr["Direccion"].ToString(),
                                    Telefono = dr["Telefono"].ToString(),
                                    Latitud = dr["Latitud"].ToString(),
                                    Longitud = dr["Longitud"].ToString()
                                });
                            }
                        }
                    }
                    Conn.Close();
                }
                response.Error = 0;
                response.Mensaje = string.Empty;
                response.tieneError = false;
            } catch (Exception ex) {
                response.Error = 1;
                response.tieneError = true;
                response.Mensaje = ex.Message;
            }
            return response;
        }
        /// <summary>
        /// Despliega un listado de giros registrados en el sistema
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ListarGirosResponse ListarGiros(ListarGirosRequest request) {
            ListarGirosResponse response = new ListarGirosResponse();
            response.Giros = new Dictionary<int, string>();
            SqlCommand Cmd;
            SqlConnection Conn;
            SqlDataReader dr;
            try {
                using (Conn = new SqlConnection(connstring)) {
                    using (Cmd = new SqlCommand() {
                        Connection = Conn,
                        CommandText = "SELECT Id, Nombre FROM Configuracion.Giro",
                        CommandType = System.Data.CommandType.Text
                    }) {
                        Conn.Open();
                        dr = Cmd.ExecuteReader();
                        if (dr.HasRows)
                            while (dr.Read())
                                response.Giros.Add((int)dr["Id"], dr["Nombre"].ToString());
                    }
                    Conn.Close();
                }
                response.Error = 0;
                response.Mensaje = string.Empty;
                response.tieneError = false;
            } catch (Exception ex) {
                response.Error = 1;
                response.tieneError = true;
                response.Mensaje = ex.Message;
            }
            return response;
        }
        #endregion

        #region Registros
        /// <summary>
        /// Registra un contacto en la base de datos asociandolo a una tienda en particular
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ContactoResponse RegistrarContacto(ContactoRequest request) {
            ContactoResponse response = new ContactoResponse() {
                Error = 0,
                Mensaje = string.Empty,
                tieneError = false
            };
            SqlCommand Cmd;
            SqlConnection Conn;
            string Msg = string.Empty;
            try {
                using (Conn = new SqlConnection(connstring)) {
                    using (Cmd = new SqlCommand() {
                        Connection = Conn,
                        CommandText = "Negocio.guardarContacto",
                        CommandType = System.Data.CommandType.StoredProcedure
                    }) {
                        Cmd.Parameters.Add(new SqlParameter() {
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            ParameterName = "Id",
                            Value = request.Contacto.Id
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            ParameterName = "IdTienda",
                            Value = request.Contacto.IdTienda
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            DbType = System.Data.DbType.String,
                            Direction = System.Data.ParameterDirection.Input,
                            ParameterName = "Nombre",
                            Value = request.Contacto.Nombre
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            DbType = System.Data.DbType.String,
                            Direction = System.Data.ParameterDirection.Input,
                            ParameterName = "Telefono",
                            Value = request.Contacto.Telefono
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            DbType = System.Data.DbType.String,
                            Direction = System.Data.ParameterDirection.Input,
                            ParameterName = "Correo",
                            Value = request.Contacto.Correo
                        });
                        SqlParameter MsgParam = new SqlParameter() {
                            DbType = System.Data.DbType.String,
                            Size = 255,
                            Direction = System.Data.ParameterDirection.Output,
                            ParameterName = "Msg"
                        };
                        Cmd.Parameters.Add(MsgParam);
                        SqlParameter RetParam = new SqlParameter() {
                            SqlDbType = System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.ReturnValue,
                            ParameterName = "R"
                        };
                        Cmd.Parameters.Add(RetParam);
                        Conn.Open();

                        Cmd.ExecuteNonQuery();

                        string[] MsgArr = Cmd.Parameters["Msg"].Value.ToString().Split('|');
                        response.Error = (int)Cmd.Parameters["R"].Value;
                        response.Mensaje = MsgArr[1].Split(':')[1];
                        response.tieneError = !response.Mensaje.Equals(K_CONTACTO_REGISTRADO);

                        Conn.Close();
                    }
                }
            } catch (Exception ex) {
                response.Error = 1;
                response.tieneError = true;
                response.Mensaje = ex.Message;
            }
            return response;
        }

        public FotoResponse RegistrarFoto(FotoRequest request) {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Hace el registro de una sucursal o la actualización de la misma
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public LocalResponse RegistrarLocal(LocalRequest request) {
            SqlCommand Cmd;
            SqlConnection Conn;
            string Msg = string.Empty;
            LocalResponse response = new LocalResponse() {
                Error = 0,
                Mensaje = string.Empty,
                tieneError = false
            };
            try {
                using (Conn = new SqlConnection(connstring)) {
                    using (Cmd = new SqlCommand() {
                        Connection = Conn,
                        CommandType = System.Data.CommandType.StoredProcedure
                    }) {
                        SqlParameter paramId = new SqlParameter() {
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            ParameterName = "Id",
                            Value = request.Id
                        };
                        if (request.Id.Equals(0)) {
                            Cmd.CommandText = "Negocio.InsSucursal";
                        } else {
                            Cmd.CommandText = "Negocio.UpdSucursal";
                        }
                        Cmd.Parameters.Add(paramId);
                        Cmd.Parameters.Add(new SqlParameter() {
                            DbType = System.Data.DbType.String,
                            Direction = System.Data.ParameterDirection.Input,
                            ParameterName = "Correo",
                            Value = request.Sucursal.Correo
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            DbType = System.Data.DbType.String,
                            Direction = System.Data.ParameterDirection.Input,
                            ParameterName = "Direccion",
                            Value = request.Sucursal.Direccion
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            ParameterName = "IdTienda",
                            Value = request.Sucursal.IdTienda
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            ParameterName = "IdTipo",
                            Value = request.Sucursal.IdTipo
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            DbType = System.Data.DbType.String,
                            Direction = System.Data.ParameterDirection.Input,
                            ParameterName = "Latitud",
                            Value = request.Sucursal.Latitud
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            DbType = System.Data.DbType.String,
                            Direction = System.Data.ParameterDirection.Input,
                            ParameterName = "Longitud",
                            Value = request.Sucursal.Longitud
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            DbType = System.Data.DbType.String,
                            Direction = System.Data.ParameterDirection.Input,
                            ParameterName = "Telefono",
                            Value = request.Sucursal.Telefono
                        });
                        Conn.Open();

                        Cmd.ExecuteNonQuery();
                        Conn.Close();
                    }
                }
            } catch (Exception ex) {
                response.Error = 1;
                response.tieneError = true;
                response.Mensaje = ex.Message;
            }
            return response;
        }
        /// <summary>
        /// Hace el registro de una oferta o la actualización de la misma
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public OfertaResponse RegistrarOferta(OfertaRequest request) {
            SqlCommand Cmd;
            SqlConnection Conn;
            string Msg = string.Empty;
            OfertaResponse response = new OfertaResponse() {
                Error = 0,
                Mensaje = string.Empty,
                tieneError = false
            };
            try {
                using (Conn = new SqlConnection(connstring)) {
                    using (Cmd = new SqlCommand() {
                        Connection = Conn,
                        CommandType = System.Data.CommandType.StoredProcedure
                    }) {
                        SqlParameter paramId = new SqlParameter() {
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            ParameterName = "Id",
                            Value = request.Oferta.Id
                        };
                        if (request.Oferta.Id.Equals(0)) {
                            Cmd.CommandText = "Negocio.InsOferta";
                        } else {
                            Cmd.CommandText = "Negocio.UpdOferta";
                        }
                        Cmd.Parameters.Add(paramId);
                        Cmd.Parameters.Add(new SqlParameter() {
                            DbType = System.Data.DbType.String,
                            Direction = System.Data.ParameterDirection.Input,
                            ParameterName = "Nombre",
                            Value = request.Oferta.Nombre
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            DbType = System.Data.DbType.String,
                            Direction = System.Data.ParameterDirection.Input,
                            ParameterName = "Descripcion",
                            Value = request.Oferta.Descripcion
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            DbType = System.Data.DbType.String,
                            Direction = System.Data.ParameterDirection.Input,
                            ParameterName = "DescBreve",
                            Value = request.Oferta.DescripcionBreve
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            DbType = System.Data.DbType.String,
                            Direction = System.Data.ParameterDirection.Input,
                            ParameterName = "Unidad",
                            Value = request.Oferta.Unidad
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            ParameterName = "IdTienda",
                            Value = request.Oferta.IdTienda
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            ParameterName = "IdTipo",
                            Value = request.Oferta.IdTipo
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            DbType = System.Data.DbType.Decimal,
                            Direction = System.Data.ParameterDirection.Input,
                            ParameterName = "Precio",
                            Value = request.Oferta.Precio
                        });
                        Conn.Open();
                        Cmd.ExecuteNonQuery();
                        Conn.Close();
                        if (request.Oferta.IdOS.Equals(0))
                            Cmd.CommandText = "Negocio.InsOfertaSucursal";
                        else {
                            Cmd.CommandText = "Negocio.UpdOfertaSucursal";
                        }
                        Cmd.Parameters.Clear();
                        paramId.Value = request.Oferta.IdOS;
                        Cmd.Parameters.Add(paramId);
                        Cmd.Parameters.Add(new SqlParameter() {
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            ParameterName = "IdSucursal",
                            Value = request.Oferta.IdSucursal
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            ParameterName = "IdOferta",
                            Value = request.Oferta.Id
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            DbType = System.Data.DbType.Boolean,
                            Direction = System.Data.ParameterDirection.Input,
                            ParameterName = "Activa",
                            Value = true
                        });
                        Conn.Open();
                        Cmd.ExecuteNonQuery();
                        Conn.Close();
                    }
                }
            } catch (Exception ex) {
                response.Error = 1;
                response.tieneError = true;
                response.Mensaje = ex.Message;
            }
            return response;
        }
        public OfertaResponse cambiarVisibilidadOferta(OfertaRequest request) {
            SqlCommand Cmd;
            SqlConnection Conn;
            string Msg = string.Empty;
            OfertaResponse response = new OfertaResponse() {
                Error = 0,
                Mensaje = string.Empty,
                tieneError = false
            };
            try {
                using (Conn = new SqlConnection(connstring)) {
                    using (Cmd = new SqlCommand() {
                        Connection = Conn,
                        CommandType = System.Data.CommandType.StoredProcedure
                    }) {
                        bool visible = true;
                        SqlParameter paramId = new SqlParameter() {
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            ParameterName = "Id",
                            Value = request.Oferta.Id
                        };
                        SqlParameter paramVisible = new SqlParameter() {
                            DbType = System.Data.DbType.Boolean,
                            Direction = System.Data.ParameterDirection.Output,
                            ParameterName = "rVisible",
                            Value = visible
                        };
                        Cmd.CommandText = "Negocio.updOfertaVisible";
                        Cmd.Parameters.Add(paramId);
                        Cmd.Parameters.Add(paramVisible);
                        Conn.Open();
                        Cmd.ExecuteNonQuery();
                        visible = (bool)paramVisible.Value;
                        Conn.Close();
                        if (request.Oferta.IdTipo.Equals(4))
                            response.Producto = new Oferta() {
                                Id = request.Oferta.Id,
                                Visible = visible
                            };
                        else
                            response.Servicio = new Oferta() {
                                Id = request.Oferta.Id,
                                Visible = visible
                            };
                    }
                }
            } catch (Exception ex) {
                response.Error = 1;
                response.tieneError = true;
                response.Mensaje = ex.Message;
            }
            return response;
        }

        public TiendaResponse RegistrarTienda(TiendaRequest request) {
            TiendaResponse response = new TiendaResponse();
            if (request.Id.Equals(0)) {

            } else {
            }
            return response;
        }
        #endregion

        #region Vistas de un elemento
        /// <summary>
        /// Despliega la información de un contacto con base en el Id que tiene asociado en el sistema
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ContactoResponse VerContacto(ContactoRequest request) {
            ContactoResponse response = new ContactoResponse() {
                Contacto = new Contacto()
            };

            SqlCommand Cmd;
            SqlConnection Conn;
            SqlDataReader dr;
            try {
                using (Conn = new SqlConnection(connstring)) {
                    using (Cmd = new SqlCommand() {
                        Connection = Conn,
                        CommandText = "Negocio.obtenerContacto",
                        CommandType = System.Data.CommandType.StoredProcedure
                    }) {
                        Cmd.Parameters.Add(new SqlParameter() {
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            ParameterName = "Id",
                            Value = request.Contacto.Id
                        });
                        Conn.Open();
                        dr = Cmd.ExecuteReader();
                        string dia = string.Empty, horario = string.Empty;
                        if (dr.HasRows)
                            while (dr.Read()) {
                                response.Contacto = new Contacto() {
                                    Id = (int)dr["Id"],
                                    Telefono = dr["Telefono"].ToString(),
                                    Correo = dr["Correo"].ToString(),
                                    IdTienda = (int)dr["IdTienda"]
                                };
                            }
                        Conn.Close();
                    }
                    response.Error = 0;
                    response.Mensaje = string.Empty;
                    response.tieneError = false;
                }
            } catch (Exception ex) {
                response.Error = 1;
                response.tieneError = true;
                response.Mensaje = ex.Message;
            }
            return response;
        }

        public VerEtiquetasResponse VerEtiquetas(VerEtiquetasRequest request) {
            throw new NotImplementedException();
        }

        public FotoResponse VerFoto(FotoRequest request) {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Despliega la información de una sucursal con base en el id que tiene asociado en el sistema
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public LocalResponse VerLocal(LocalRequest request) {
            LocalResponse response = new LocalResponse();

            SqlCommand Cmd;
            SqlConnection Conn;
            SqlDataReader dr;
            try {
                using (Conn = new SqlConnection(connstring)) {
                    using (Cmd = new SqlCommand() {
                        Connection = Conn,
                        CommandText = "Negocio.obtenerSucursal",
                        CommandType = System.Data.CommandType.StoredProcedure
                    }) {
                        Cmd.Parameters.Add(new SqlParameter() {
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            ParameterName = "Id",
                            Value = request.Id
                        });
                        Conn.Open();
                        dr = Cmd.ExecuteReader();
                        string dia = string.Empty, horario = string.Empty;
                        if (dr.HasRows)
                            while (dr.Read()) {
                                response.Sucursal = new Sucursal() {
                                    Id = (int)dr["Id"],
                                    Direccion = dr["Direccion"].ToString(),
                                    Telefono = dr["Telefono"].ToString(),
                                    Correo = dr["Correo"].ToString(),
                                    IdTienda = (int)dr["IdTienda"],
                                    IdTipo = (int)dr["IdTipo"],
                                    Latitud = dr["Latitud"].ToString(),
                                    Longitud = dr["Longitud"].ToString(),
                                    Tipo = dr["Tipo"].ToString()
                                };
                            }
                        Conn.Close();
                    }
                    response.Error = 0;
                    response.Mensaje = string.Empty;
                    response.tieneError = false;
                }
            } catch (Exception ex) {
                response.Error = 1;
                response.tieneError = true;
                response.Mensaje = ex.Message;
            }
            return response;
        }
        /// <summary>
        /// Si se proporciona Id de producto, este es utilizado para recuperar los datos de la ofreta,
        /// Si se proporciona como Id de Producto un cero, toma el Id de servicio.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public OfertaResponse VerOferta(OfertaRequest request) {
            OfertaResponse response = new OfertaResponse() {
                Producto = new Oferta(),
                Servicio = new Oferta()
            };

            SqlCommand Cmd;
            SqlConnection Conn;
            SqlDataReader dr;
            try {
                using (Conn = new SqlConnection(connstring)) {
                    using (Cmd = new SqlCommand() {
                        Connection = Conn,
                        CommandText = "Negocio.obtenerOferta",
                        CommandType = System.Data.CommandType.StoredProcedure
                    }) {
                        Cmd.Parameters.Add(new SqlParameter() {
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            ParameterName = "ID",
                            Value = (request.Id)
                        });
                        Conn.Open();
                        dr = Cmd.ExecuteReader();
                        string dia = string.Empty, horario = string.Empty;
                        if (dr.HasRows) {
                            while (dr.Read()) {
                                if (request.Id != 0)
                                    response.Producto = new Oferta() {
                                        Nombre = dr["Nombre"].ToString(),
                                        Descripcion = dr["Descripcion"].ToString(),
                                        DescripcionBreve = dr["DescBreve"].ToString(),
                                        Unidad = dr["Unidad"].ToString(),
                                        IdTienda = (int)dr["IdTienda"],
                                        IdTipo = (int)dr["IdTipo"],
                                        Id = request.Id,
                                        Precio = double.Parse(dr["Precio"].ToString()),
                                        IdSucursal = (int)dr["IdSucursal"],
                                        IdOS = (int)dr["IdOS"]
                                    };
                                else
                                    response.Servicio = new Oferta() {
                                        Nombre = dr["Nombre"].ToString(),
                                        Descripcion = dr["Descripcion"].ToString(),
                                        DescripcionBreve = dr["DescBreve"].ToString(),
                                        Unidad = dr["Unidad"].ToString(),
                                        IdTienda = (int)dr["IdTienda"],
                                        IdTipo = (int)dr["IdTipo"],
                                        Id = request.Id,
                                        Precio = double.Parse(dr["Precio"].ToString()),
                                        IdSucursal = (int)dr["IdSucursal"],
                                        IdOS = (int)dr["IdOS"]
                                    };

                            }
                            response.Error = 0;
                            response.Mensaje = string.Empty;
                            response.tieneError = false;
                        } else {
                            response.Error = 1;
                            response.Mensaje = K_REGISTRO_NO_ENCONTRADO;
                            response.tieneError = false;
                        }
                        Conn.Close();
                    }
                }
            } catch (Exception ex) {
                response.Error = 1;
                response.tieneError = true;
                response.Mensaje = ex.Message;
            }
            return response;
        }
        /// <summary>
        /// Despliega la información del propietario con base en el Id que tiene asociado en el sistema
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public VerPropietarioResponse VerPropietario(VerPropietarioRequest request) {
            VerPropietarioResponse response = new VerPropietarioResponse();

            SqlCommand Cmd;
            SqlConnection Conn;
            SqlDataReader dr;
            try {
                using (Conn = new SqlConnection(connstring)) {
                    using (Cmd = new SqlCommand() {
                        Connection = Conn,
                        CommandText = "Negocio.obtenerDatosPropietario",
                        CommandType = System.Data.CommandType.StoredProcedure
                    }) {
                        Cmd.Parameters.Add(new SqlParameter() {
                            DbType = System.Data.DbType.String,
                            Direction = System.Data.ParameterDirection.Input,
                            ParameterName = "Id",
                            Value = request.Id
                        });
                        Conn.Open();

                        dr = Cmd.ExecuteReader();
                        if (dr.HasRows) {
                            while (dr.Read()) {
                                response.Propietario = new Propietario() {
                                    Id = (int)dr["Id"],
                                    Nombre = dr["Nombre"].ToString(),
                                    Telefono = dr["Telefono"].ToString(),
                                    Correo = dr["Correo"].ToString(),
                                    Usuario = dr["Usuario"].ToString()
                                };
                            }
                        }
                    }
                    Conn.Close();
                }
                response.Error = 0;
                response.Mensaje = string.Empty;
                response.tieneError = false;
            } catch (Exception ex) {
                response.Error = 1;
                response.tieneError = true;
                response.Mensaje = ex.Message;
            }
            return response;
        }
        /// <summary>
        /// Despliega la información de la tienda con base en el Id que tiene asociado en el sistema
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public TiendaResponse VerTienda(TiendaRequest request) {
            TiendaResponse response = new TiendaResponse() { Horario = string.Empty };

            SqlCommand Cmd;
            SqlConnection Conn;
            SqlDataReader dr;
            try {
                using (Conn = new SqlConnection(connstring)) {
                    using (Cmd = new SqlCommand() {
                        Connection = Conn,
                        CommandText = "Negocio.obtenerDatosTiendaResumen",
                        CommandType = System.Data.CommandType.StoredProcedure
                    }) {
                        Cmd.Parameters.Add(new SqlParameter() {
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            ParameterName = "IdTienda",
                            Value = request.Id
                        });
                        Conn.Open();
                        dr = Cmd.ExecuteReader();
                        string dia = string.Empty, horario = string.Empty;
                        if (dr.HasRows)
                            while (dr.Read()) {
                                response.Nombre = dr["Nombre"].ToString();
                                response.Direccion = dr["Direccion"].ToString();
                                response.Telefono = dr["Telefono"].ToString();
                                response.Correo = dr["Correo"].ToString();
                                response.IdGiro = (int)dr["IdGiro"];
                                if (dia != dr["Dia"].ToString()) {
                                    if (!string.IsNullOrEmpty(horario))
                                        response.Horario += horario + ". ";
                                    horario = dr["Dia"].ToString() + " :: " + dr["Horario"].ToString();
                                    dia = dr["Dia"].ToString();
                                } else {
                                    horario += ", " + dr["Horario"].ToString();
                                }

                            }
                        Conn.Close();
                    }
                    response.Error = 0;
                    response.Mensaje = string.Empty;
                    response.tieneError = false;
                }
            } catch (Exception ex) {
                response.Error = 1;
                response.tieneError = true;
                response.Mensaje = ex.Message;
            }
            return response;
        }
        /// <summary>
        /// Despliega la información de una sección con base en el Id del tipo de sección y la tienda a la que
        /// pertenece.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public TiendaResponse VerSeccion(TiendaRequest request) {
            TiendaResponse response = new TiendaResponse() { Horario = string.Empty };

            SqlCommand Cmd;
            SqlConnection Conn;
            SqlDataReader dr;
            try {
                using (Conn = new SqlConnection(connstring)) {
                    using (Cmd = new SqlCommand() {
                        Connection = Conn,
                        CommandText = "Negocio.obtenerSeccion",
                        CommandType = System.Data.CommandType.StoredProcedure
                    }) {
                        Cmd.Parameters.Add(new SqlParameter() {
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            ParameterName = "IdTienda",
                            Value = request.Id
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            ParameterName = "IdSeccion",
                            Value = request.IdSeccion
                        });
                        Conn.Open();
                        dr = Cmd.ExecuteReader();
                        string dia = string.Empty, horario = string.Empty;
                        if (dr.HasRows)
                            while (dr.Read()) {
                                response.Titulo = dr["Titulo"].ToString();
                                response.Seccion = dr["Contenido"].ToString();
                            }
                        Conn.Close();
                    }
                    response.Error = 0;
                    response.Mensaje = string.Empty;
                    response.tieneError = false;
                }
            } catch (Exception ex) {
                response.Error = 1;
                response.tieneError = true;
                response.Mensaje = ex.Message;
            }
            return response;
        }

        public InfoTiendaResponse obtenerInfoNegocio(InfoTiendaRequest request) {
            InfoTiendaResponse response = new InfoTiendaResponse();

            SqlCommand Cmd;
            SqlConnection Conn;
            SqlDataReader dr;
            try {
                using (Conn = new SqlConnection(connstring)) {
                    using (Cmd = new SqlCommand() {
                        Connection = Conn,
                        CommandText = "Negocio.obtenerDatosTienda",
                        CommandType = System.Data.CommandType.StoredProcedure
                    }) {
                        Cmd.Parameters.Add(new SqlParameter() {
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            ParameterName = "Id",
                            Value = request.IdTienda
                        });
                        Conn.Open();
                        dr = Cmd.ExecuteReader();
                        string dia = string.Empty, horario = string.Empty;
                        if (dr.HasRows)
                            while (dr.Read()) {
                                response.Resultado = new InfoTienda() {
                                    Id = (int)dr["Id"],
                                    Nombre = dr["Nombre"].ToString(),
                                    Direccion = dr["Direccion"].ToString(),
                                    Telefono = dr["Telefono"].ToString(),
                                    CorreoElectronico = dr["Correo"].ToString(),
                                    Latitud = dr["Latitud"].ToString(),
                                    Longitud = dr["Longitud"].ToString(),
                                    RazonSocial = dr["RazonSocial"].ToString(),
                                    Giro = (int)dr["IdGiro"]
                                };
                            }
                        Conn.Close();
                    }
                    response.Error = 0;
                    response.Mensaje = string.Empty;
                    response.tieneError = false;
                }
            } catch (Exception ex) {
                response.Error = 1;
                response.tieneError = true;
                response.Mensaje = ex.Message;
            }
            return response;
        }

        #endregion

        #region EliminarElementos
        /// <summary>
        /// Realiza la eliminación de un objeto de la base de datos con base en el Id que tiene asociado
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public EliminarObjetoResponse eliminarRegistro(EliminarObjetoRequest request) {
            EliminarObjetoResponse response = new EliminarObjetoResponse();

            SqlCommand Cmd;
            SqlConnection Conn;
            int resultado;
            try {
                using (Conn = new SqlConnection(connstring)) {
                    using (Cmd = new SqlCommand() {
                        Connection = Conn,
                        CommandType = System.Data.CommandType.StoredProcedure
                    }) {
                        Cmd.Parameters.Add(new SqlParameter() {
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            ParameterName = "Id",
                            Value = request.Id
                        });
                        switch (request.Objeto) {
                            case eEntidad.Configuracion_TipoStatus:
                                Cmd.CommandText = "Configuracion.delTipoStatus";
                                break;
                            case eEntidad.Configuracion_Status:
                                Cmd.CommandText = "Configuracion.delStatus";
                                break;
                            case eEntidad.Proyecto_Cliente:
                                Cmd.CommandText = "Proyecto.delCliente";
                                break;
                            case eEntidad.Proyecto_Contacto:
                                Cmd.CommandText = "Proyecto.delContacto";
                                break;
                            case eEntidad.Proyecto_Proyecto:
                                Cmd.CommandText = "Proyecto.delProyecto";
                                break;
                            case eEntidad.Proyecto_Actividad:
                                Cmd.CommandText = "Proyecto.delActividad";
                                break;
                            case eEntidad.Configuracion_Plataforma:
                                Cmd.CommandText = "Configuracion.delPlataforma";
                                break;
                            case eEntidad.Configuracion_Giro:
                                Cmd.CommandText = "Configuracion.delGiro";
                                break;
                            case eEntidad.Negocio_Sesiones:
                                Cmd.CommandText = "";
                                break;
                            case eEntidad.Configuracion_Clasificacion:
                                Cmd.CommandText = "Configuracion.delClasificacion";
                                break;
                            case eEntidad.Configuracion_Tipo:
                                Cmd.CommandText = "Configuracion.delTipo";
                                break;
                            case eEntidad.Configuracion_Seccion:
                                Cmd.CommandText = "Configuracion.delSeccion";
                                break;
                            case eEntidad.Negocio_Administrador:
                                Cmd.CommandText = "Negocio.delAdministrador";
                                break;
                            case eEntidad.Negocio_Tienda:
                                Cmd.CommandText = "Negocio.delTienda";
                                break;
                            case eEntidad.Negocio_Sucursal:
                                Cmd.CommandText = "Negocio.delSucursal";
                                break;
                            case eEntidad.Negocio_Horario:
                                Cmd.CommandText = "Negocio.delHorario";
                                break;
                            case eEntidad.Negocio_Oferta:
                                Cmd.CommandText = "Negocio.delOferta";
                                break;
                            case eEntidad.Negocio_OfertaSucursal:
                                Cmd.CommandText = "Negocio.delOfertaSucursal";
                                break;
                            case eEntidad.Negocio_Foto:
                                Cmd.CommandText = "Negocio.delFoto";
                                break;
                            case eEntidad.Negocio_FotoOferta:
                                Cmd.CommandText = "Negocio.delFotoOferta";
                                break;
                            case eEntidad.Negocio_DescripcionTienda:
                                Cmd.CommandText = "Negocio.delDescripcionTienda";
                                break;
                            case eEntidad.Negocio_Contacto:
                                Cmd.CommandText = "Negocio.delContacto";
                                break;
                            default:
                                throw new Exception("Opcion incorrecta");
                                break;
                        }
                        Conn.Open();
                        resultado = Cmd.ExecuteNonQuery();
                        string dia = string.Empty, horario = string.Empty;
                        Conn.Close();
                    }
                    response.Error = resultado;
                    response.Mensaje = (resultado == 1) ? string.Empty : "Ocurrió un error al intentar eliminar";
                    response.tieneError = resultado == 1;
                }
            } catch (Exception ex) {
                response.Error = 1;
                response.tieneError = true;
                response.Mensaje = ex.Message;
            }
            return response;
        }

        public ListarSeccionesResponse ListarSecciones(ListarSeccionesRequest request) {
            ListarSeccionesResponse response = new ListarSeccionesResponse() {
                Secciones = new Dictionary<int, string>()
            };
            SqlCommand Cmd;
            SqlConnection Conn;
            SqlDataReader dr;
            try {
                using (Conn = new SqlConnection(connstring)) {
                    using (Cmd = new SqlCommand() {
                        Connection = Conn,
                        CommandText = "SELECT Id IdSeccion, Nombre, '' Titulo, '' Contenido, Id FROM Configuracion.Seccion",
                        CommandType = System.Data.CommandType.Text
                    }) {
                        if (request.Id != 0)
                            Cmd.CommandText = "SELECT DT.Id, DT.Titulo, DT.Contenido, S.Id IdSeccion, S.Nombre FROM Negocio.DescripcionTienda DT JOIN Configuracion.Seccion S ON DT.IdSeccion = S.Id WHERE DT.IdTienda = " + request.Id.ToString();
                        Conn.Open();
                        dr = Cmd.ExecuteReader();
                        if (dr.HasRows)
                            while (dr.Read())
                                response.Secciones.Add((int)dr["IdSeccion"],
                                    string.Format("{0}|{1}|{2}|{3}",
                                    dr["Id"].ToString(),
                                    dr["Nombre"].ToString(),
                                    dr["Titulo"].ToString(),
                                    dr["Contenido"].ToString()));
                    }
                    Conn.Close();
                }
                response.Error = 0;
                response.Mensaje = string.Empty;
                response.tieneError = false;
            } catch (Exception ex) {
                response.Error = 1;
                response.tieneError = true;
                response.Mensaje = ex.Message;
            }
            return response;
        }

        public ListarTiposSucursalesResponse ListarTiposSucursales(ListarGirosRequest request) {
            ListarTiposSucursalesResponse response = new ListarTiposSucursalesResponse();
            response.TiposSucursales = new Dictionary<int, string>();
            SqlCommand Cmd;
            SqlConnection Conn;
            SqlDataReader dr;
            try {
                using (Conn = new SqlConnection(connstring)) {
                    using (Cmd = new SqlCommand() {
                        Connection = Conn,
                        CommandText = "select Id, Nombre from Configuracion.Tipo where IdClasificacion = 1",
                        CommandType = System.Data.CommandType.Text
                    }) {
                        Conn.Open();
                        dr = Cmd.ExecuteReader();
                        if (dr.HasRows)
                            while (dr.Read())
                                response.TiposSucursales.Add((int)dr["Id"], dr["Nombre"].ToString());
                    }
                    Conn.Close();
                }
                response.Error = 0;
                response.Mensaje = string.Empty;
                response.tieneError = false;
            } catch (Exception ex) {
                response.Error = 1;
                response.tieneError = true;
                response.Mensaje = ex.Message;
            }
            return response;

        }

        public SucursalResponse guardarSucursal(SucursalRequest request) {
            SqlCommand Cmd;
            SqlConnection Conn;

            var response = new SucursalResponse() {
                tieneError = false,
                Error = 0,
                Mensaje = string.Empty
            };

            try {
                using (Conn = new SqlConnection(connstring)) {
                    using (Cmd = new SqlCommand() {
                        Connection = Conn,
                        CommandText = "Negocio.UpdSucursal",
                        CommandType = System.Data.CommandType.StoredProcedure
                    }) {
                        Cmd.Parameters.Add(new SqlParameter() {
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            ParameterName = "Id",
                            Value = request.Id
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            ParameterName = "IdTienda",
                            Value = request.IdTienda
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            ParameterName = "IdTipo",
                            Value = request.IdTipo
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            ParameterName = "Status",
                            Value = request.Status
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            DbType = System.Data.DbType.String,
                            Direction = System.Data.ParameterDirection.Input,
                            ParameterName = "Direccion",
                            Value = request.Direccion
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            DbType = System.Data.DbType.String,
                            Direction = System.Data.ParameterDirection.Input,
                            ParameterName = "Correo",
                            Value = request.Correo
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            DbType = System.Data.DbType.String,
                            Direction = System.Data.ParameterDirection.Input,
                            ParameterName = "Telefono",
                            Value = request.Telefono
                        });
                        Conn.Open();
                        Cmd.ExecuteNonQuery();
                    }
                }
                response.Error = 0;
                response.Mensaje = string.Empty;
                response.tieneError = false;
                response.Sucursal = new Sucursal() {
                    Id = request.Id,
                    IdTienda = request.IdTienda,
                    IdTipo = request.IdTipo,
                    Status = request.Status,
                    Direccion = request.Direccion,
                    Telefono = request.Telefono,
                    Correo = request.Correo,
                    Latitud = string.Empty,
                    Longitud = string.Empty
                };
            } catch (Exception ex) {
                response.Error = ex.HResult;
                response.Mensaje = ex.Message;
                response.tieneError = true;
            }
            return response;
        }

        public SucursalResponse cambiarVisibilidadSucursal(SucursalRequest request) {
            SqlCommand Cmd;
            SqlConnection Conn;
            string Msg = string.Empty;
            SucursalResponse response = new SucursalResponse() {
                Error = 0,
                Mensaje = string.Empty,
                tieneError = false
            };
            try {
                using (Conn = new SqlConnection(connstring)) {
                    using (Cmd = new SqlCommand() {
                        Connection = Conn,
                        CommandType = System.Data.CommandType.StoredProcedure
                    }) {
                        bool visible = true;
                        SqlParameter paramId = new SqlParameter() {
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            ParameterName = "Id",
                            Value = request.Id
                        };
                        SqlParameter paramVisible = new SqlParameter() {
                            DbType = System.Data.DbType.Boolean,
                            Direction = System.Data.ParameterDirection.Output,
                            ParameterName = "rVisible",
                            Value = visible
                        };
                        Cmd.CommandText = "Negocio.updSucursalVisible";
                        Cmd.Parameters.Add(paramId);
                        Cmd.Parameters.Add(paramVisible);
                        Conn.Open();
                        Cmd.ExecuteNonQuery();
                        visible = (bool)paramVisible.Value;
                        Conn.Close();
                        response.Sucursal = new Sucursal() {
                            Id = request.Id,
                            Visible = visible
                        };
                    }
                }
            } catch (Exception ex) {
                response.Error = 1;
                response.tieneError = true;
                response.Mensaje = ex.Message;
            }
            return response;
        }

        public SucursalResponse verSucursal(SucursalRequest request) {
            SucursalResponse response = new SucursalResponse() {
                Error = 0,
                tieneError = false,
                Sucursal = new Sucursal()
            };
            SqlCommand Cmd;
            SqlConnection Conn;
            SqlDataReader dr;
            try {
                using (Conn = new SqlConnection(connstring)) {
                    using (Cmd = new SqlCommand() {
                        Connection = Conn,
                        CommandText = "Negocio.obtenerDatosSucursal",
                        CommandType = System.Data.CommandType.StoredProcedure
                    }) {
                        Cmd.Parameters.Add(new SqlParameter() {
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            ParameterName = "Id",
                            Value = request.Id
                        });
                        Conn.Open();
                        dr = Cmd.ExecuteReader();
                        string dia = string.Empty, horario = string.Empty;
                        if (dr.HasRows)
                            dr.Read();
                        response.Sucursal = new Sucursal() {
                            Direccion = dr["Direccion"].ToString(),
                            Telefono = dr["Telefono"].ToString(),
                            Correo = dr["Correo"].ToString(),
                            IdTienda = (int)dr["IdTienda"],
                            IdTipo = (int)dr["IdTipo"],
                            Status = (int)dr["Status"],
                            Tipo = dr["Tipo"].ToString(),
                            Visible = (bool)dr["Visible"]
                        };
                        Conn.Close();
                    }
                    response.Error = 0;
                    response.Mensaje = string.Empty;
                    response.tieneError = false;
                }
            } catch (Exception ex) {
                response.Error = 1;
                response.tieneError = true;
                response.Mensaje = ex.Message;
            }
            return response;
        }

        #endregion
    }
}
