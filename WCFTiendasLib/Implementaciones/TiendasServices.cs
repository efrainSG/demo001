using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFTiendasLib.Contracts;

namespace WCFTiendasLib
{
    public class TiendasServices : ITiendasServices
    {
        public PropietarioResponse CrearCuenta(RegistrarPropietarioRequest request) {
            throw new NotImplementedException();
        }

        public PropietarioResponse GuardarDatos(RegistrarPropietarioRequest request) {
            throw new NotImplementedException();
        }

        public LoginResponse Login(LoginRequest request) {
            throw new NotImplementedException();
        }

        #region Listados
        public ListarContactosResponse ListarContactos(ListarContactosRequest request) {
            throw new NotImplementedException();
        }

        public ListarFotoResponse ListarFotos(ListarFotoRequest request) {
            throw new NotImplementedException();
        }

        public ListarLocalesResponse ListarLocales(ListarLocalesRequest request) {
            throw new NotImplementedException();
        }

        public ListarOfertasResponse ListarOfertas(ListarOfertasRequest request) {
            ListarOfertasResponse response = new ListarOfertasResponse();

            List<OfertaBreve> ofertas = new List<OfertaBreve>();
            SqlCommand Cmd;
            SqlConnection Conn;
            SqlDataReader dr;
            try {
                using (Conn = new SqlConnection(@"Data Source=DESKTOP-8RJ1OMB\SQLEXPRESS;Initial Catalog=Proyectos;Integrated Security=True;Pooling=False")) {
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

                        Conn.Open();
                        dr = Cmd.ExecuteReader();

                        if (dr.HasRows)
                            while (dr.Read()) {
                                ofertas.Add(new OfertaBreve() {
                                    Id = (int)dr["Id"],
                                    Nombre = dr["Nombre"].ToString(),
                                    Precio = double.Parse(dr["Precio"].ToString()),
                                    DescripcionBreve = dr["DescBreve"].ToString(),
                                    Aceptacion = 0,
                                    Foto = dr["Foto"].ToString()
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

        public ListarTiendasResponse ListarTiendas(ListarTiendasRequest request) {
            ListarTiendasResponse response = new ListarTiendasResponse();
            response.Resultados = new List<ResultadoTienda>();

            SqlCommand Cmd;
            SqlConnection Conn;
            SqlDataReader dr;
            try {
                using (Conn = new SqlConnection(@"Data Source=DESKTOP-8RJ1OMB\SQLEXPRESS;Initial Catalog=Proyectos;Integrated Security=True;Pooling=False")) {
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

        public ListarGirosResponse ListarGiros(ListarGirosRequest request) {
            ListarGirosResponse response = new ListarGirosResponse();
            response.Giros = new Dictionary<int, string>();
            SqlCommand Cmd;
            SqlConnection Conn;
            SqlDataReader dr;
            try {
                using (Conn = new SqlConnection(@"Data Source=DESKTOP-8RJ1OMB\SQLEXPRESS;Initial Catalog=Proyectos;Integrated Security=True;Pooling=False")) {
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
        public ContactoResponse RegistrarContacto(ContactoRequest request) {
            throw new NotImplementedException();
        }

        public FotoResponse RegistrarFoto(FotoRequest request) {
            throw new NotImplementedException();
        }

        public LocalResponse RegistrarLocal(LocalRequest request) {
            throw new NotImplementedException();
        }

        public OfertaResponse RegistrarOferta(OfertaRequest request) {
            throw new NotImplementedException();
        }

        public TiendaResponse RegistrarTienda(TiendaRequest request) {
            throw new NotImplementedException();
        }
        #endregion

        #region Vistas de un elemento
        public VerContactoResponse VerContacto(VerContactoRequest request) {
            throw new NotImplementedException();
        }

        public VerEtiquetasResponse VerEtiquetas(VerEtiquetasRequest request) {
            throw new NotImplementedException();
        }

        public FotoResponse VerFoto(FotoRequest request) {
            throw new NotImplementedException();
        }

        public LocalResponse VerLocal(LocalRequest request) {
            throw new NotImplementedException();
        }

        public OfertaResponse VerOferta(OfertaRequest request) {
            throw new NotImplementedException();
        }

        public VerPropietarioResponse VerPropietario(VerPropietarioRequest request) {
            throw new NotImplementedException();
        }

        public TiendaResponse VerTienda(TiendaRequest request) {
            TiendaResponse response = new TiendaResponse() { Horario = string.Empty };

            SqlCommand Cmd;
            SqlConnection Conn;
            SqlDataReader dr;
            try {
                using (Conn = new SqlConnection(@"Data Source=DESKTOP-8RJ1OMB\SQLEXPRESS;Initial Catalog=Proyectos;Integrated Security=True;Pooling=False")) {
                    using (Cmd = new SqlCommand() {
                        Connection = Conn,
                        CommandText = "Negocio.obtenerDatosTiendaResumen",
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
                        string dia = string.Empty, horario = string.Empty;
                        if (dr.HasRows)
                            while (dr.Read()) {
                                response.Nombre = dr["Nombre"].ToString();
                                response.Direccion = dr["Direccion"].ToString();
                                response.Telefono = dr["Telefono"].ToString();
                                response.Correo = dr["Correo"].ToString();
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
        #endregion
    }
}
