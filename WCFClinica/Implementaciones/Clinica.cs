using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using WCFClinica.Modelos;

namespace WCFClinica {
    public class ClinicaService : IClinica {

        public string Connstring { get; set; } = ConfigurationManager.ConnectionStrings["WCFTiendasLib.Properties.Settings.SernaConnStr"].ConnectionString;

        /// <summary>
        /// Clinica.buscarPaciente
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public buscarPacienteResponse buscarPaciente(buscarPacienteRequest request) {
            SqlCommand Cmd;
            SqlConnection Conn;
            buscarPacienteResponse response = new buscarPacienteResponse();
            try {
                using (Conn = new SqlConnection(Connstring)) {
                    using (Cmd = new SqlCommand() {
                        Connection = Conn,
                        CommandType = System.Data.CommandType.StoredProcedure,
                        CommandText = "Clinica.buscarPaciente"
                    }) {
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "IdLugarResidencia",
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.IdLugarResidencia
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "IdLugarNacimiento",
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.IdLugarNacimiento
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "IdTipoSangre",
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.IdTipoSangre
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "IdSexo",
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.IdSexo
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "Nombre",
                            DbType = System.Data.DbType.String,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.Nombre
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "Domicilio",
                            DbType = System.Data.DbType.String,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.Domicilio
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "CiudadResidencia",
                            DbType = System.Data.DbType.String,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.CiudadResidencia
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "CiudadNacimiento",
                            DbType = System.Data.DbType.String,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.CiudadNacimiento
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "Rh",
                            DbType = System.Data.DbType.String,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.Rh
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "Tabaco",
                            DbType = System.Data.DbType.Boolean,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.Tabaco
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "Alcohol",
                            DbType = System.Data.DbType.Boolean,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.Alcohol
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "FechaNacimiento",
                            DbType = System.Data.DbType.Date,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.FechaNacimiento
                        });
                        Conn.Open();
                        var dr = Cmd.ExecuteReader();
                        if (dr.HasRows) {
                            response.Items = new List<buscarPacienteItem>();
                            while (dr.Read()) {
                                response.Items.Add(new buscarPacienteItem() {
                                    IdPaciente = (int)dr["IdPaciente"],
                                    TipoSangre = dr["TipoSangre"].ToString(),
                                    Nombre = dr["Nombre"].ToString(),
                                    Sexo = dr["Sexo"].ToString()
                                });
                            }
                        }
                        Conn.Close();
                    }
                }
            } catch (Exception ex) {
                response.ErrNum = ex.HResult;
                response.tieneError = true;
                response.Mensaje = ex.Message;
            }
            return response;
        }
        /// <summary>
        /// Administacion.loginMedico
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public LoginResponse hazLogin(LoginRequest request) {
            SqlCommand Cmd;
            SqlConnection Conn;
            LoginResponse response = new LoginResponse();
            try {
                using (Conn = new SqlConnection(Connstring)) {
                    using (Cmd = new SqlCommand() {
                        Connection = Conn,
                        CommandType = System.Data.CommandType.StoredProcedure,
                        CommandText = "Administracion.loginMedico"
                    }) {
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "Usuario",
                            DbType = System.Data.DbType.String,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.Usuario
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "Passwd",
                            DbType = System.Data.DbType.String,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.Password
                        });
                        Conn.Open();
                        var dr = Cmd.ExecuteReader();
                        if (dr.HasRows) {
                            dr.Read();
                            response.Resultado = (int)dr["Resultado"];
                            response.Mensaje = dr["Mensaje"].ToString();
                        }
                        Conn.Close();

                    }
                }
            } catch (Exception ex) {
                response.ErrNum = ex.HResult;
                response.tieneError = true;
                response.Mensaje = ex.Message;
            }
            return response;
        }
        /// <summary>
        /// Administracion.registraMedico
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public RegistraMedicoReqResp registraMedico(RegistraMedicoReqResp request) {
            SqlCommand Cmd;
            SqlConnection Conn;
            RegistraMedicoReqResp response = new RegistraMedicoReqResp();
            try {
                using (Conn = new SqlConnection(Connstring)) {
                    using (Cmd = new SqlCommand() {
                        Connection = Conn,
                        CommandType = System.Data.CommandType.StoredProcedure,
                        CommandText = "Administracion.registraMedico"
                    }) {
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "IdSexo",
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.IdSexo
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "Nombre",
                            DbType = System.Data.DbType.String,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.Nombre
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "IdTipoSangre",
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.IdTipoSangre
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "Rh",
                            DbType = System.Data.DbType.String,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.Rh
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "FechaNacimiento",
                            DbType = System.Data.DbType.Date,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.FechaNacimiento
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "IdLugarNacimiento",
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.IdLugarNacimiento
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "CiudadNacimiento",
                            DbType = System.Data.DbType.String,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.CiudadNacimiento
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "Usuario",
                            DbType = System.Data.DbType.String,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.Usuario
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "Contrasenia",
                            DbType = System.Data.DbType.String,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.Constrasenia
                        });
                        Conn.Open();
                        var dr = Cmd.ExecuteReader();
                        if (dr.HasRows) {
                            dr.Read();
                            response.Id = (int)dr["Id"];
                            response.FechaNacimiento = (DateTime)dr["FechaNacimiento"];
                            response.CiudadNacimiento = dr["CiudadNacimiento"].ToString();
                            response.Nombre = dr["Nombre"].ToString();
                            response.Rh = dr["Rh"].ToString()[0];
                            response.Sexo = dr["Sexo"].ToString();
                            response.TipoSangre = dr["TipoSangre"].ToString();
                            response.LugarNacimiento = dr["LugarNacimiento"].ToString();
                            response.Usuario = dr["Usuario"].ToString();
                        }
                        Conn.Close();
                    }
                }
            } catch (Exception ex) {
                response.ErrNum = ex.HResult;
                response.tieneError = true;
                response.Mensaje = ex.Message;
            }
            return response;
        }
        /// <summary>
        /// clinica.registraPaciente
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public RegistraPacienteReqResp registraPaciente(RegistraPacienteReqResp request) {
            SqlCommand Cmd;
            SqlConnection Conn;
            RegistraPacienteReqResp response = new RegistraPacienteReqResp();
            try {
                using (Conn = new SqlConnection(Connstring)) {
                    using (Cmd = new SqlCommand() {
                        Connection = Conn,
                        CommandType = System.Data.CommandType.StoredProcedure,
                        CommandText = "Clinica.registraPaciente"
                    }) {
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "IdSexo",
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.IdSexo
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "Nombre",
                            DbType = System.Data.DbType.String,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.Nombre
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "IdTipoSangre",
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.IdTipoSangre
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "Rh",
                            DbType = System.Data.DbType.String,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.Rh
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "FechaNacimiento",
                            DbType = System.Data.DbType.Date,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.FechaNacimiento
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "IdLugarNacimiento",
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.IdLugarNacimiento
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "CiudadNacimiento",
                            DbType = System.Data.DbType.String,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.CiudadNacimiento
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "IdLugarResidencia",
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.IdLugarResidencia
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "Domicilio",
                            DbType = System.Data.DbType.String,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.Domicilio
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "Tabaco",
                            DbType = System.Data.DbType.Boolean,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.Tabaco
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "Alcohol",
                            DbType = System.Data.DbType.Boolean,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.Alcohol
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "CiudadResidencia",
                            DbType = System.Data.DbType.String,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.CiudadResidencia
                        });
                        Conn.Open();
                        var dr = Cmd.ExecuteReader();
                        if (dr.HasRows) {
                            dr.Read();
                            response.IdPersona = (int)dr["IdPersona"];
                            response.Sexo = dr["Sexo"].ToString();
                            response.Nombre = dr["Nombre"].ToString();
                            response.TipoSangre = dr["TipoSangre"].ToString();
                            response.Rh = dr["Rh"].ToString()[0];
                            response.FechaNacimiento = (DateTime)dr["FechaNacimiento"];
                            response.LugarNacimiento = dr["LugarNacimiento"].ToString();
                            response.CiudadNacimiento = dr["CiudadNacimiento"].ToString();
                            response.IdPaciente = (int)dr["IdPaciente"];
                            response.LugarResidencia = dr["LugarResidencia"].ToString();
                            response.Domicilio = dr["Domicilio"].ToString();
                            response.Tabaco = (bool)dr["Tabaco"];
                            response.Alcohol = (bool)dr["Alcohol"];
                            response.CiudadResidencia = dr["CiudadResidencia"].ToString();
                        }
                        Conn.Close();
                    }
                }
            } catch (Exception ex) {
                response.ErrNum = ex.HResult;
                response.tieneError = true;
                response.Mensaje = ex.Message;
            }
            return response;
        }
        /// <summary>
        /// Administracion.registraTelefono
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public RegistraTelefonoReqResp registraTelefono(RegistraTelefonoReqResp request) {
            SqlCommand Cmd;
            SqlConnection Conn;
            RegistraTelefonoReqResp response = new RegistraTelefonoReqResp();
            try {
                using (Conn = new SqlConnection(Connstring)) {
                    using (Cmd = new SqlCommand() {
                        Connection = Conn,
                        CommandType = System.Data.CommandType.StoredProcedure,
                        CommandText = "Administracion.registraTelefono"
                    }) {
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "IdPersona",
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.IdPersona
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "IdTipoTelefono",
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.IdTipoTelefono
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "Numero",
                            DbType = System.Data.DbType.String,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.Numero
                        });
                        Conn.Open();
                        var dr = Cmd.ExecuteReader();
                        if (dr.HasRows) {
                            dr.Read();
                            response.Id = (int)dr["Id"];
                            response.IdPersona = (int)dr["IdPersona"];
                            response.Numero = dr["NumeroTelefono"].ToString();
                        }
                        Conn.Close();
                    }
                }
            } catch (Exception ex) {
                response.ErrNum = ex.HResult;
                response.tieneError = true;
                response.Mensaje = ex.Message;
            }
            return response;
        }
        /// <summary>
        /// Clinica.selPaciente
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public RegistraPacienteReqResp selPaciente(selPacienteReqResp request) {
            SqlCommand Cmd;
            SqlConnection Conn;
            RegistraPacienteReqResp response = new RegistraPacienteReqResp();
            try {
                using (Conn = new SqlConnection(Connstring)) {
                    using (Cmd = new SqlCommand() {
                        Connection = Conn,
                        CommandType = System.Data.CommandType.StoredProcedure,
                        CommandText = "Clinica.selPaciente"
                    }) {
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "IdPaciente",
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.IdPaciente
                        });
                        Conn.Open();
                        var dr = Cmd.ExecuteReader();
                        if (dr.HasRows) {
                            dr.Read();
                            response.Alcohol = (bool)dr["Alcohol"];
                            response.CiudadNacimiento = dr["CiudadNacimiento"].ToString();
                            response.CiudadResidencia = dr["CiudadResidencia"].ToString();
                            response.Domicilio = dr["Domicilio"].ToString();
                            response.FechaNacimiento = (DateTime)dr["FechaNacimiento"];
                            response.IdLugarNacimiento = (int)dr["IdLugarNacimiento"];
                            response.IdLugarResidencia = (int)dr["IdLugarResidencia"];
                            response.IdPaciente = (int)dr["IdPaciente"];
                            response.IdPersona = (int)dr["IdPersona"];
                            response.IdSexo = (int)dr["IdSexo"];
                            response.IdTipoSangre = (int)dr["IdTipoSangre"];
                            response.LugarNacimiento = dr["LugarNacimiento"].ToString();
                            response.LugarResidencia = dr["LugarResidencia"].ToString();
                            response.Nombre = dr["Nombre"].ToString();
                            response.Rh = dr["Rh"].ToString().ToCharArray()[0];
                            response.Sexo = dr["Sexo"].ToString();
                            response.Tabaco = (bool)dr["Tabaco"];
                            response.TipoSangre = dr["TipoSangre"].ToString();
                        }
                        Conn.Close();

                    }
                }
            } catch (Exception ex) {
                response.ErrNum = ex.HResult;
                response.tieneError = true;
                response.Mensaje = ex.Message;
            }
            return response;
        }

        public RegistaAntGinecoReqResp ObtenerAntGineco(RegistaAntGinecoReqResp request) {
            SqlCommand Cmd;
            SqlConnection Conn;
            var response = new RegistaAntGinecoReqResp();
            try {
                using (Conn = new SqlConnection(Connstring)) {
                    using (Cmd = new SqlCommand() {
                        Connection = Conn,
                        CommandType = System.Data.CommandType.StoredProcedure,
                        CommandText = "Clinica.spCargarAntGineco"
                    }) {
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "A",
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.A
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "C",
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.C
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "FUR",
                            DbType = System.Data.DbType.Date,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.FUR
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "G",
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.G
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "Id",
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.Id
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "IdAnticonceptivo",
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.IdAnticonceptivo
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "IdPaciente",
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.IdPaciente
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "Mastografia",
                            DbType = System.Data.DbType.Date,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.Mastografia
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "Menarca",
                            DbType = System.Data.DbType.Date,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.Menarca
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "P",
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.P
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "Papanicolaou",
                            DbType = System.Data.DbType.Date,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.Papanicolaou
                        });
                        Conn.Open();
                        var dr = Cmd.ExecuteReader();
                        if (dr.HasRows) {
                            dr.Read();
                            response.A = (int)dr["A"];
                            response.C = (int)dr["C"];
                            response.FUR = (DateTime)dr["FUR"];
                            response.G = (int)dr["G"];
                            response.Id = (int)dr["Id"];
                            response.IdAnticonceptivo = (int)dr["IdAnticonceptivo"];
                            response.IdPaciente = (int)dr["IdPaciente"];
                            response.Mastografia = (DateTime)dr["Mastografia"];
                            response.Menarca = (DateTime)dr["Menarca"];
                            response.P = (int)dr["P"];
                            response.Papanicolaou = (DateTime)dr["Papanicolaou"];
                        }
                        Conn.Close();
                    }
                }
            } catch (Exception ex) {
                response.ErrNum = ex.HResult;
                response.tieneError = true;
                response.Mensaje = ex.Message;
            }
            return response;
        }

        public selAntHeredReqResp ObtenerAntHered(selAntHeredReqResp request) {
            SqlCommand Cmd;
            SqlConnection Conn;
            var response = new selAntHeredReqResp();
            try {
                using (Conn = new SqlConnection(Connstring)) {
                    using (Cmd = new SqlCommand() {
                        Connection = Conn,
                        CommandType = System.Data.CommandType.StoredProcedure,
                        CommandText = "Clinica.spCargarAntHered"
                    }) {
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "IdPaciente",
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.IdPaciente
                        });
                        Conn.Open();
                        var dr = Cmd.ExecuteReader();
                        if (dr.HasRows) {
                            response.Items = new List<AntHeredItem>();
                            while (dr.Read()) {
                                response.Items.Add(new AntHeredItem() {
                                    Id = (int)dr["Id"],
                                    IdFamiliar = (int)dr["IdFamiliar"],
                                    Padecimiento = dr["Padecimiento"].ToString()
                                });
                            }
                        }
                        Conn.Close();
                    }
                }
            } catch (Exception ex) {
                response.ErrNum = ex.HResult;
                response.tieneError = true;
                response.Mensaje = ex.Message;
            }
            return response;
        }

        public selAntPersonalNoPatReqResp ObtenerAntPersonalNoPatologico(selAntPersonalNoPatReqResp request) {
            SqlCommand Cmd;
            SqlConnection Conn;
            var response = new selAntPersonalNoPatReqResp();
            try {
                using (Conn = new SqlConnection(Connstring)) {
                    using (Cmd = new SqlCommand() {
                        Connection = Conn,
                        CommandType = System.Data.CommandType.StoredProcedure,
                        CommandText = "Clinica.spCargarAntPersonalNoPatologico"
                    }) {
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "IdPaciente",
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.IdPaciente
                        });
                        Conn.Open();
                        var dr = Cmd.ExecuteReader();
                        if (dr.HasRows) {
                            dr.Read();
                        }
                        Conn.Close();
                    }
                }
            } catch (Exception ex) {
                response.ErrNum = ex.HResult;
                response.tieneError = true;
                response.Mensaje = ex.Message;
            }
            return response;
        }

        public selAntPersonalPatReqResp ObtenerAntPersonalPatologico(selAntPersonalPatReqResp request) {
            SqlCommand Cmd;
            SqlConnection Conn;
            var response = new selAntPersonalPatReqResp();
            try {
                using (Conn = new SqlConnection(Connstring)) {
                    using (Cmd = new SqlCommand() {
                        Connection = Conn,
                        CommandType = System.Data.CommandType.StoredProcedure,
                        CommandText = "Clinica.spCargarAntPersonalPatologico"
                    }) {
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "IdPaciente",
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.IdPaciente
                        });
                        Conn.Open();
                        var dr = Cmd.ExecuteReader();
                        if (dr.HasRows) {
                            response.Items = new List<AntPersonalPatItem>();
                            while (dr.Read()) {
                                response.Items.Add(new AntPersonalPatItem() {
                                    Enfermedad = dr["Enfermedad"].ToString(),
                                    FechaInicio = (DateTime)dr["FechaInicio"],
                                    Id = (int)dr["Id"],
                                    IdStatus = (int)dr["IdStatus"]
                                });
                            }
                        }
                        Conn.Close();
                    }
                }
            } catch (Exception ex) {
                response.ErrNum = ex.HResult;
                response.tieneError = true;
                response.Mensaje = ex.Message;
            }
            return response;
        }

        public RegistraExploraFisicaReqResp ObtenerExploracionFisica(RegistraExploraFisicaReqResp request) {
            SqlCommand Cmd;
            SqlConnection Conn;
            var response = new RegistraExploraFisicaReqResp();
            try {
                using (Conn = new SqlConnection(Connstring)) {
                    using (Cmd = new SqlCommand() {
                        Connection = Conn,
                        CommandType = System.Data.CommandType.StoredProcedure,
                        CommandText = "Clinica.spCargarExploracionFisica"
                    }) {
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "IdHistoria",
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.IdHistoria
                        });
                        Conn.Open();
                        var dr = Cmd.ExecuteReader();
                        if (dr.HasRows) {
                            dr.Read();
                            response.Descripcion = dr["Descripcion"].ToString();
                            response.Estatura = dr["Estatura"].ToString();
                            response.FC = dr["FC"].ToString();
                            response.FR = dr["FR"].ToString();
                            response.Id = (int)dr["Id"];
                            response.IdHistoria = (int)dr["IdHistoria"];
                            response.Peso = dr["Peso"].ToString();
                            response.Pulso = dr["Pulso"].ToString();
                            response.TA = dr["TA"].ToString();
                            response.Temperatura = dr["Temperatura"].ToString();
                        }
                        Conn.Close();
                    }
                }
            } catch (Exception ex) {
                response.ErrNum = ex.HResult;
                response.tieneError = true;
                response.Mensaje = ex.Message;
            }
            return response;
        }

        public selExploraSistemaReqResp ObtenerExploracionSistema(selExploraSistemaReqResp request) {
            SqlCommand Cmd;
            SqlConnection Conn;
            var response = new selExploraSistemaReqResp();
            try {
                using (Conn = new SqlConnection(Connstring)) {
                    using (Cmd = new SqlCommand() {
                        Connection = Conn,
                        CommandType = System.Data.CommandType.StoredProcedure,
                        CommandText = "Clinica.spCargarExploracionSistema"
                    }) {
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "IdHistoria",
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.IdHistoria
                        });
                        Conn.Open();
                        var dr = Cmd.ExecuteReader();
                        if (dr.HasRows) {
                            response.Items = new List<ExploraSistemaItem>();
                            while (dr.Read()) {
                                response.Items.Add(new ExploraSistemaItem {
                                    Descripcion = dr["Descripcion"].ToString(),
                                    Id = (int)dr["Id"],
                                    IdSistema = (int)dr["IdSistema"]
                                });
                            }
                        }
                        Conn.Close();
                    }
                }
            } catch (Exception ex) {
                response.ErrNum = ex.HResult;
                response.tieneError = true;
                response.Mensaje = ex.Message;
            }
            return response;
        }

        public RegistraHistoriaReqResp ObtenerHistoriaClinica(RegistraHistoriaReqResp request) {
            SqlCommand Cmd;
            SqlConnection Conn;
            var response = new RegistraHistoriaReqResp();
            try {
                using (Conn = new SqlConnection(Connstring)) {
                    using (Cmd = new SqlCommand() {
                        Connection = Conn,
                        CommandType = System.Data.CommandType.StoredProcedure,
                        CommandText = "Clinica.spCargarHistoriaClinica"
                    }) {
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "IdPaciente",
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.IdPaciente
                        });
                        Conn.Open();

                        Conn.Close();
                    }
                }
            } catch (Exception ex) {
                response.ErrNum = ex.HResult;
                response.tieneError = true;
                response.Mensaje = ex.Message;
            }
            return response;
        }

        public selMedicacionActualReqResp ObtenerMedicacionActual(selMedicacionActualReqResp request) {
            SqlCommand Cmd;
            SqlConnection Conn;
            var response = new selMedicacionActualReqResp();
            try {
                using (Conn = new SqlConnection(Connstring)) {
                    using (Cmd = new SqlCommand() {
                        Connection = Conn,
                        CommandType = System.Data.CommandType.StoredProcedure,
                        CommandText = "Clinica.spCargarMedicacionActual"
                    }) {
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "IdHistoria",
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.IdHistoria
                        });
                        Conn.Open();
                        Conn.Close();
                    }
                }
            } catch (Exception ex) {
                response.ErrNum = ex.HResult;
                response.tieneError = true;
                response.Mensaje = ex.Message;
            }
            return response;
        }
        /// <summary>
        /// Clinica.spGuardaAntGineco
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public RegistaAntGinecoReqResp GuardaAntGineco(RegistaAntGinecoReqResp request) {
            SqlCommand Cmd;
            SqlConnection Conn;
            var response = new RegistaAntGinecoReqResp();
            try {
                using (Conn = new SqlConnection(Connstring)) {
                    using (Cmd = new SqlCommand() {
                        Connection = Conn,
                        CommandType = System.Data.CommandType.StoredProcedure,
                        CommandText = "Clinica.spGuardaAntGineco"
                    }) {
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "IdPaciente",
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.IdPaciente
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "Id",
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.Id
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "A",
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.A
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "C",
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.C
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "FUR",
                            DbType = System.Data.DbType.DateTime,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.FUR
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "G",
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.G
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "IdAnticonceptivo",
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.IdAnticonceptivo
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "Mastografia",
                            DbType = System.Data.DbType.DateTime,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.Mastografia
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "Menarca",
                            DbType = System.Data.DbType.DateTime,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.Menarca
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "P",
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.P
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "Papanicolaou",
                            DbType = System.Data.DbType.DateTime,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.Papanicolaou
                        });
                        Conn.Open();
                        var dr = Cmd.ExecuteReader();
                        if (dr.HasRows) {
                            response.A = (int)dr["A"];
                            response.C = (int)dr["C"];
                            response.FUR = (DateTime)dr["FUR"];
                            response.G = (int)dr["G"];
                            response.Id = (int)dr["Id"];
                            response.IdAnticonceptivo = (int)dr["IdAnticonceptivo"];
                            response.IdPaciente = (int)dr["IdPaciente"];
                            response.Mastografia = (DateTime)dr["Mastografia"];
                            response.Menarca = (DateTime)dr["Menarca"];
                            response.P = (int)dr["P"];
                            response.Papanicolaou = (DateTime)dr["Papanicolaou"];
                        }
                        Conn.Close();
                    }
                }
            } catch (Exception ex) {
                response.ErrNum = ex.HResult;
                response.tieneError = true;
                response.Mensaje = ex.Message;
            }
            return response;
        }
        /// <summary>
        /// Clinica.spGuardaAntHered
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public selAntHeredReqResp GuardaAntHered(RegistraAntHeredReqResp request) {
            SqlCommand Cmd;
            SqlConnection Conn;
            var response = new selAntHeredReqResp() {
                Items = new List<AntHeredItem>()
            };
            try {
                using (Conn = new SqlConnection(Connstring)) {
                    using (Cmd = new SqlCommand() {
                        Connection = Conn,
                        CommandType = System.Data.CommandType.StoredProcedure,
                        CommandText = "Clinica.spGuardaAntHered"
                    }) {
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "IdPaciente",
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.IdPaciente
                        });
                        Conn.Open();
                        var dr = Cmd.ExecuteReader();
                        if (dr.HasRows) {
                            dr.Read();
                            response.IdPaciente = (int)dr["IdPaciente"];
                            response.Items.Add(new AntHeredItem() {
                                Id = (int)dr["Id"],
                                IdFamiliar = (int)dr["IdFamiliar"],
                                Padecimiento = dr["Padecimiento"].ToString()
                            });
                        }
                        Conn.Close();
                    }
                }
            } catch (Exception ex) {
                response.ErrNum = ex.HResult;
                response.tieneError = true;
                response.Mensaje = ex.Message;
            }
            return response;
        }

        public RegistraAntPersonalNoPatReqResp GuardaAntPersonalNoPatologico(RegistraAntPersonalNoPatReqResp request) {
            SqlCommand Cmd;
            SqlConnection Conn;
            var response = new RegistraAntPersonalNoPatReqResp();
            try {
                using (Conn = new SqlConnection(Connstring)) {
                    using (Cmd = new SqlCommand() {
                        Connection = Conn,
                        CommandType = System.Data.CommandType.StoredProcedure,
                        CommandText = "Clinica.spGuardaAntPersonalNoPatologico"
                    }) {
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "IdPaciente",
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = 0
                        });
                        Conn.Open();
                        Conn.Close();
                    }
                }
            } catch (Exception ex) {
                response.ErrNum = ex.HResult;
                response.tieneError = true;
                response.Mensaje = ex.Message;
            }
            return response;
        }
        /// <summary>
        /// Clinica.spGuardaAntPersonalPatologico
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public RegistraAntPersonalPat GuardaAntPersonalPatologico(RegistraAntPersonalPat request) {
            SqlCommand Cmd;
            SqlConnection Conn;
            var response = new RegistraAntPersonalPat();
            try {
                using (Conn = new SqlConnection(Connstring)) {
                    using (Cmd = new SqlCommand() {
                        Connection = Conn,
                        CommandType = System.Data.CommandType.StoredProcedure,
                        CommandText = "Clinica.spGuardaAntPersonalPatologico"
                    }) {
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "IdPaciente",
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.IdPaciente
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "Enfermedad",
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.Enfermedad
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "FechaInicio",
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.FechaInicio
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "IdStatus",
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.IdStatus
                        });
                        Conn.Open();
                        var dr = Cmd.ExecuteReader();
                        if (dr.HasRows) {
                            dr.Read();
                            response.Enfermedad = dr["Enfermedad"].ToString();
                            response.FechaInicio = (DateTime)dr["FechaInicio"];
                            response.Id = (int)dr["Id"];
                            response.IdPaciente = (int)dr["IdPaciente"];
                            response.IdStatus = (int)dr["IdStatus"];
                        }
                        Conn.Close();
                    }
                }
            } catch (Exception ex) {
                response.ErrNum = ex.HResult;
                response.tieneError = true;
                response.Mensaje = ex.Message;
            }
            return response;
        }
        /// <summary>
        /// Clinica.spGuardaEsploracionFisica
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public RegistraExploraFisicaReqResp GuardaEsploracionFisica(RegistraExploraFisicaReqResp request) {
            SqlCommand Cmd;
            SqlConnection Conn;
            var response = new RegistraExploraFisicaReqResp();
            try {
                using (Conn = new SqlConnection(Connstring)) {
                    using (Cmd = new SqlCommand() {
                        Connection = Conn,
                        CommandType = System.Data.CommandType.StoredProcedure,
                        CommandText = "Clinica.spGuardaEsploracionFisica"
                    }) {
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "IdHistoria",
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.IdHistoria
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "Descripcion",
                            DbType = System.Data.DbType.String,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.Descripcion
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "Estatura",
                            DbType = System.Data.DbType.String,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.Estatura
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "FC",
                            DbType = System.Data.DbType.String,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.FC
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "FR",
                            DbType = System.Data.DbType.String,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.FR
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "Peso",
                            DbType = System.Data.DbType.String,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.Peso
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "Pulso",
                            DbType = System.Data.DbType.String,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.Pulso
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "TA",
                            DbType = System.Data.DbType.String,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.TA
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "Temperatura",
                            DbType = System.Data.DbType.String,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.Temperatura
                        });
                        Conn.Open();
                        var dr = Cmd.ExecuteReader();
                        if (dr.HasRows) {
                            dr.Read();
                            response.Descripcion = dr["Descripcion"].ToString();
                            response.Estatura = dr["Estatura"].ToString();
                            response.FC = dr["FC"].ToString();
                            response.FR = dr["FR"].ToString();
                            response.Peso = dr["Peso"].ToString();
                            response.Pulso = dr["Pulso"].ToString();
                            response.TA = dr["TA"].ToString();
                            response.Temperatura = dr["Temperatura"].ToString();
                            response.Id = (int)dr["Id"];
                            response.IdHistoria = (int)dr["IdHistoria"];
                        }
                        Conn.Close();
                    }
                }
            } catch (Exception ex) {
                response.ErrNum = ex.HResult;
                response.tieneError = true;
                response.Mensaje = ex.Message;
            }
            return response;
        }
        /// <summary>
        /// Clinica.spGuardaExploracionSistema
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public RegistraExploraSistemaReqResp GuardaExploracionSistema(RegistraExploraSistemaReqResp request) {
            SqlCommand Cmd;
            SqlConnection Conn;
            var response = new RegistraExploraSistemaReqResp();
            try {
                using (Conn = new SqlConnection(Connstring)) {
                    using (Cmd = new SqlCommand() {
                        Connection = Conn,
                        CommandType = System.Data.CommandType.StoredProcedure,
                        CommandText = "Clinica.spGuardaExploracionSistema"
                    }) {
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "IdHistoria",
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.IdHistoria
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "Descripcion",
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.Descripcion
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "IdSistema",
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.IdSistema
                        });
                        Conn.Open();
                        var dr = Cmd.ExecuteReader();
                        if (dr.HasRows) {
                            response.Descripcion = dr["Descripcion"].ToString();
                            response.Id = (int)dr["Id"];
                            response.IdHistoria = (int)dr["IdHistoria"];
                            response.IdSistema = (int)dr["IdSistema"];
                        }
                        Conn.Close();
                    }
                }
            } catch (Exception ex) {
                response.ErrNum = ex.HResult;
                response.tieneError = true;
                response.Mensaje = ex.Message;
            }
            return response;
        }

        public selHistoriaReqResp GuardaHistoriaClinica(RegistraHistoriaReqResp request) {
            SqlCommand Cmd;
            SqlConnection Conn;
            var response = new selHistoriaReqResp();
            try {
                using (Conn = new SqlConnection(Connstring)) {
                    using (Cmd = new SqlCommand() {
                        Connection = Conn,
                        CommandType = System.Data.CommandType.StoredProcedure,
                        CommandText = "Clinica.spGuardaHistoriaClinica"
                    }) {
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "IdPaciente",
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.IdPaciente
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "IdPaciente",
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.IdHistoria
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "IdPaciente",
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.IdMedico
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "IdPaciente",
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.IdPaciente
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "IdPaciente",
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.ImpresionDiagnostica
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "IdPaciente",
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.MotivoConsulta
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "IdPaciente",
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.PlanTerapeutico
                        });
                        Conn.Open();
                        Conn.Close();
                    }
                }
            } catch (Exception ex) {
                response.ErrNum = ex.HResult;
                response.tieneError = true;
                response.Mensaje = ex.Message;
            }
            return response;
        }

        public RegistraMedicacionActualReqResp GuardaMedicacionActual(RegistraMedicacionActualReqResp request) {
            SqlCommand Cmd;
            SqlConnection Conn;
            var response = new RegistraMedicacionActualReqResp();
            try {
                using (Conn = new SqlConnection(Connstring)) {
                    using (Cmd = new SqlCommand() {
                        Connection = Conn,
                        CommandType = System.Data.CommandType.StoredProcedure,
                        CommandText = "Clinica.spGuardaMedicacionActual"
                    }) {
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "IdHistoria",
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.IdHistoria
                        });
                        Conn.Open();
                        Conn.Close();
                    }
                }
            } catch (Exception ex) {
                response.ErrNum = ex.HResult;
                response.tieneError = true;
                response.Mensaje = ex.Message;
            }
            return response;
        }

        public listaHistoriasPacienteReqResp ListarHistoriasPaciente(selPacienteReqResp request) {
            SqlCommand Cmd;
            SqlConnection Conn;
            var response = new listaHistoriasPacienteReqResp();
            try {
                using (Conn = new SqlConnection(Connstring)) {
                    using (Cmd = new SqlCommand() {
                        Connection = Conn,
                        CommandType = System.Data.CommandType.StoredProcedure,
                        CommandText = "Clinica.spListarHistoriasPaciente"
                    }) {
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "IdPaciente",
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.IdPaciente
                        });
                        Conn.Open();
                        Conn.Close();
                    }
                }
            } catch (Exception ex) {
                response.ErrNum = ex.HResult;
                response.tieneError = true;
                response.Mensaje = ex.Message;
            }
            return response;
        }

        public selHistoriaReqResp ObtenerHistoria(selHistoriaReqResp request) {
            SqlCommand Cmd;
            SqlConnection Conn;
            var response = new selHistoriaReqResp();
            try {
                using (Conn = new SqlConnection(Connstring)) {
                    using (Cmd = new SqlCommand() {
                        Connection = Conn,
                        CommandType = System.Data.CommandType.StoredProcedure,
                        CommandText = "Clinica.spObtenerHistoria"
                    }) {
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "IdPaciente",
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = 0
                        });
                        Conn.Open();
                        Conn.Close();
                    }
                }
            } catch (Exception ex) {
                response.ErrNum = ex.HResult;
                response.tieneError = true;
                response.Mensaje = ex.Message;
            }
            return response;
        }
        /// <summary>
        /// Administracion.verMedico
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public RegistraMedicoReqResp verMedico(RegistraMedicoReqResp request) {
            SqlCommand Cmd;
            SqlConnection Conn;
            RegistraMedicoReqResp response = new RegistraMedicoReqResp();
            try {
                using (Conn = new SqlConnection(Connstring)) {
                    using (Cmd = new SqlCommand() {
                        Connection = Conn,
                        CommandType = System.Data.CommandType.StoredProcedure,
                        CommandText = "Administracion.verMedico"
                    }) {
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "Id",
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.Id
                        });
                        Conn.Open();
                        var dr = Cmd.ExecuteReader();
                        if (dr.HasRows) {
                            dr.Read();
                            response.Id = (int)dr["Id"];
                            response.FechaNacimiento = (DateTime)dr["FechaNacimiento"];
                            response.CiudadNacimiento = dr["CiudadNacimiento"].ToString();
                            response.Nombre = dr["Nombre"].ToString();
                            response.Rh = dr["Rh"].ToString()[0];
                            response.Sexo = dr["Sexo"].ToString();
                            response.TipoSangre = dr["TipoSangre"].ToString();
                            response.LugarNacimiento = dr["LugarNacimiento"].ToString();
                            response.Usuario = dr["Usuario"].ToString();
                        }
                        Conn.Close();
                    }
                }
            } catch (Exception ex) {
                response.ErrNum = ex.HResult;
                response.tieneError = true;
                response.Mensaje = ex.Message;
            }
            return response;
        }

        public CatalogoReqResp obtenerCatalogo(CatalogoReqResp request) {
            CatalogoReqResp response = new CatalogoReqResp() {
                items = new Dictionary<int, string>()
            };
            return response;
        }

        public selHistoriaReqResp buscarHistorias(selHistoriaReqResp request) {
            SqlCommand Cmd;
            SqlConnection Conn;
            var response = new selHistoriaReqResp();
            try {
                using (Conn = new SqlConnection(Connstring)) {
                    using (Cmd = new SqlCommand() {
                        Connection = Conn,
                        CommandType = System.Data.CommandType.StoredProcedure,
                        CommandText = "Clinica.buscarHistorias"
                    }) {
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "IdPaciente",
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = 0
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "IdMedico",
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = 0
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "FechaHistoria",
                            DbType = System.Data.DbType.Date,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = 0
                        });
                        Conn.Open();
                        var dr = Cmd.ExecuteReader();
                        if (dr.HasRows)
                            while (dr.Read()) {

                            }
                        Conn.Close();
                    }
                }
            } catch (Exception ex) {
                response.ErrNum = ex.HResult;
                response.tieneError = true;
                response.Mensaje = ex.Message;
            }
            return response;
        }
    }
}
