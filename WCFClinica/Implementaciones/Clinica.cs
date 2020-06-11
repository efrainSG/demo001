using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using WCFClinica.Modelos;

namespace WCFClinica {
    public class ClinicaService : IClinica {

        public string Connstring { get; set; } = ConfigurationManager.ConnectionStrings["WCFClinica.Properties.Settings.SernaConnStr"].ConnectionString;

        /// <summary>
        /// Clinica.buscarPaciente: hecho
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
                        if (request.FechaNacimiento >= new DateTime(1850, 01, 01))
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
                                    Sexo = dr["Sexo"].ToString(),
                                    NumeroTelefono = dr["NumeroTelefono"].ToString()
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
        /// Administacion.loginMedico: hecho
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
                            response.Id = (int)dr["Id"];
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
        /// Administracion.registraMedico: hecho
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
                            ParameterName = "Id",
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.Id
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
        /// clinica.registraPaciente: hecho
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
                            ParameterName = "Id",
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.IdPaciente
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
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "IdTipoNumero",
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.IdTipoNumero
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "Numero",
                            DbType = System.Data.DbType.String,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.Numero
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "AnioResidencia",
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.AnioResidencia
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "Ocupacion",
                            DbType = System.Data.DbType.String,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.Ocupacion
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "Alergias",
                            DbType = System.Data.DbType.String,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.Alergias
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "Adicciones",
                            DbType = System.Data.DbType.String,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.Adicciones
                        });
                        Conn.Open();
                        var dr = Cmd.ExecuteReader();
                        if (dr.HasRows) {
                            dr.Read();
                            response = new RegistraPacienteReqResp() {
                                IdPersona = (int)dr["IdPersona"],
                                Sexo = dr["Sexo"].ToString(),
                                Nombre = dr["Nombre"].ToString(),
                                TipoSangre = dr["TipoSangre"].ToString(),
                                Rh = dr["Rh"].ToString()[0],
                                FechaNacimiento = (DateTime)dr["Nacimiento"],
                                LugarNacimiento = dr["LugarNacimiento"].ToString(),
                                CiudadNacimiento = dr["CiudadNacimiento"].ToString(),
                                IdPaciente = (int)dr["IdPaciente"],
                                LugarResidencia = dr["LugarResidencia"].ToString(),
                                Domicilio = dr["Domicilio"].ToString(),
                                Tabaco = (bool)dr["Tabaco"],
                                Alcohol = (bool)dr["Alcohol"],
                                CiudadResidencia = dr["CiudadResidencia"].ToString(),
                                IdLugarNacimiento = (int)dr["IdLugarNacimiento"],
                                IdLugarResidencia = (int)dr["IdLugarResidencia"],
                                IdSexo = (int)dr["IdSexo"],
                                IdTipoNumero = (int)dr["IdTipoTelefono"],
                                IdTipoSangre = (int)dr["IdTipoSangre"],
                                Numero = dr["Numero"].ToString(),
                                AnioResidencia = (int)dr["AnioResidencia"],
                                Ocupacion = dr["ocupacion"].ToString(),
                                Adicciones = dr["Adicciones"].ToString(),
                                Alergias = dr["Alergias"].ToString()
                            };
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
        /// Administracion.registraTelefono: hecho
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
        /// Clinica.spGuardaAntGineco: hecho
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
                            response.A = int.Parse(dr["A"].ToString());
                            response.C = int.Parse(dr["C"].ToString());
                            response.FUR = DateTime.Parse(dr["FUR"].ToString());
                            response.G = int.Parse(dr["G"].ToString());
                            response.Id = int.Parse(dr["Id"].ToString());
                            response.IdAnticonceptivo = int.Parse(dr["IdAnticonceptivo"].ToString());
                            response.IdPaciente = int.Parse(dr["IdPaciente"].ToString());
                            response.Mastografia = DateTime.Parse(dr["Mastografia"].ToString());
                            response.Menarca = DateTime.Parse(dr["Menarca"].ToString());
                            response.P = int.Parse(dr["P"].ToString());
                            response.Papanicolaou = DateTime.Parse(dr["Papanicolaou"].ToString());
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
        /// Clinica.spGuardaAntHered: hecho
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
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "IdFamiliar",
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.IdFamiliar
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "Padecimiento",
                            DbType = System.Data.DbType.String,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.Padecimiento
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

        public NotaEvolutivaReqResp guardarNotaEvolutiva(NotaEvolutivaReqResp request) {
            SqlCommand Cmd;
            SqlConnection Conn;
            var response = new NotaEvolutivaReqResp {
                ExploracionFisica = new RegistraExploraFisicaReqResp()
            };
            try {
                using (Conn = new SqlConnection(Connstring)) {
                    using (Cmd = new SqlCommand() {
                        Connection = Conn,
                        CommandType = System.Data.CommandType.StoredProcedure,
                        CommandText = "Clinica.spGuardaNotaEvolutiva"
                    }) {
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "Id",
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.IdNota
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "IdHistoria",
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.IdHistoria
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "Fecha",
                            DbType = System.Data.DbType.Date,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.Fecha
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "Descripcion",
                            DbType = System.Data.DbType.String,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.ExploracionFisica.Descripcion
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "PlanTratamiento",
                            DbType = System.Data.DbType.String,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.PlanTratamiento
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "TA",
                            DbType = System.Data.DbType.String,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.ExploracionFisica.TA
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "Pulso",
                            DbType = System.Data.DbType.Byte,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.ExploracionFisica.Pulso
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "FR",
                            DbType = System.Data.DbType.Byte,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.ExploracionFisica.FR
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "FC",
                            DbType = System.Data.DbType.Byte,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.ExploracionFisica.FC
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "Temperatura",
                            DbType = System.Data.DbType.Decimal,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.ExploracionFisica.Temperatura
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "Peso",
                            DbType = System.Data.DbType.Decimal,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.ExploracionFisica.Peso
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "Estatura",
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.ExploracionFisica.Estatura
                        });
                        Conn.Open();
                        var dr = Cmd.ExecuteReader();
                        if (dr.HasRows) {
                            dr.Read();
                            response.ExploracionFisica.Descripcion = dr["Descripcion"].ToString();
                            response.ExploracionFisica.Estatura = int.Parse(dr["Estatura"].ToString());
                            response.ExploracionFisica.FC = byte.Parse(dr["FC"].ToString());
                            response.ExploracionFisica.FR = byte.Parse(dr["FR"].ToString());
                            response.ExploracionFisica.Peso = decimal.Parse(dr["Peso"].ToString());
                            response.ExploracionFisica.Pulso = byte.Parse(dr["Pulso"].ToString());
                            response.ExploracionFisica.TA = dr["TA"].ToString();
                            response.ExploracionFisica.Temperatura = decimal.Parse(dr["Temperatura"].ToString());
                            response.Fecha = DateTime.Parse(dr["Fecha"].ToString());
                            response.IdHistoria = int.Parse(dr["IdHistoria"].ToString());
                            response.IdNota = int.Parse(dr["Id"].ToString());
                            response.PlanTratamiento = dr["PlanTratamiento"].ToString();
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
        /// Clinica.spGuardaAntPersonalPatologico: hecho
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
                            DbType = System.Data.DbType.String,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.Enfermedad
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "FechaInicio",
                            DbType = System.Data.DbType.Date,
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
        /// Clinica.spGuardaExploracionFisica: hecho
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public RegistraExploraFisicaReqResp GuardaExploracionFisica(RegistraExploraFisicaReqResp request) {
            SqlCommand Cmd;
            SqlConnection Conn;
            var response = new RegistraExploraFisicaReqResp();
            try {
                using (Conn = new SqlConnection(Connstring)) {
                    using (Cmd = new SqlCommand() {
                        Connection = Conn,
                        CommandType = System.Data.CommandType.StoredProcedure,
                        CommandText = "Clinica.spGuardaExploracionFisica"
                    }) {
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "Id",
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.Id
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "IdHistoriaClinica",
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
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.Estatura
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "FC",
                            DbType = System.Data.DbType.Byte,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.FC
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "FR",
                            DbType = System.Data.DbType.Byte,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.FR
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "Peso",
                            DbType = System.Data.DbType.Decimal,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.Peso
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "Pulso",
                            DbType = System.Data.DbType.Byte,
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
                            DbType = System.Data.DbType.Decimal,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.Temperatura
                        });
                        Conn.Open();
                        var dr = Cmd.ExecuteReader();
                        if (dr.HasRows) {
                            dr.Read();
                            response.Descripcion = dr["Descripcion"].ToString();
                            response.Estatura = (int)dr["Estatura"];
                            response.FC = (byte)dr["FC"];
                            response.FR = (byte)dr["FR"];
                            response.Peso = (decimal)dr["Peso"];
                            response.Pulso = (byte)dr["Pulso"];
                            response.TA = dr["TA"].ToString();
                            response.Temperatura = (decimal)dr["Temperatura"];
                            response.Id = (int)dr["Id"];
                            response.IdHistoria = (int)dr["IdHistoriaClinica"];
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
        /// Clinica.spGuardaExploracionSistema: hecho
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
                            DbType = System.Data.DbType.String,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.Descripcion
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "IdSistema",
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.IdSistema
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "Id",
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.Id
                        });
                        Conn.Open();
                        var dr = Cmd.ExecuteReader();
                        if (dr.HasRows) {
                            response.Id = (int)dr["Id"];
                            response.IdHistoria = (int)dr["IdHistoria"];
                            response.IdSistema = (int)dr["IdSistema"];
                            response.Descripcion = dr["Descripcion"].ToString();
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
        /// Clinica.spGuardaHistoriaClinica: hecho
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
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
                            ParameterName = "Id",
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.IdHistoria
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "IdPaciente",
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.IdPaciente
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "IdMedico",
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.IdMedico
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "FechaHistoria",
                            DbType = System.Data.DbType.Date,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.FechaHistoria
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "MotivoConsulta",
                            DbType = System.Data.DbType.String,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.MotivoConsulta
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "Analisis",
                            DbType = System.Data.DbType.String,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.Analisis
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "ImpresionDiagnostica",
                            DbType = System.Data.DbType.String,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.ImpresionDiagnostica
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "PlanTerapeutico",
                            DbType = System.Data.DbType.String,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.PlanTerapeutico
                        });
                        Conn.Open();
                        var dr = Cmd.ExecuteReader();
                        if (dr.HasRows) {
                            dr.Read();
                            response.Id = (int)dr["Id"];
                            response.IdMedico = (int)dr["IdMedico"];
                            response.IdPaciente = (int)dr["IdPaciente"];
                            response.FechaHistoria = (DateTime)dr["FechaHistoria"];
                            response.Analisis = dr["Analisis"].ToString();
                            response.MotivoConsulta = dr["MotivoConsulta"].ToString();
                            response.PlanTerapeutico = dr["PlanTerapeutico"].ToString();
                            response.ImpresionDiagnostica = dr["ImpresionDiagnostica"].ToString();
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
        /// Clinica.spGuardaMedicacionActual: hecho
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
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
                            ParameterName = "Id",
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.Id
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "IdHistoria",
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.IdHistoria
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "Dosis",
                            DbType = System.Data.DbType.String,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.Dosis
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "FechaInicio",
                            DbType = System.Data.DbType.Date,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.FechaInicio
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "Medicamento",
                            DbType = System.Data.DbType.String,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.Medicamento
                        });
                        Conn.Open();
                        var dr = Cmd.ExecuteReader();
                        if (dr.HasRows) {
                            dr.Read();
                            response.Dosis = dr["Dosis"].ToString();
                            response.FechaInicio = (DateTime)dr["FechaInicio"];
                            response.Id = (int)dr["Id"];
                            response.IdHistoria = (int)dr["IdHistoria"];
                            response.Medicamento = dr["Medicamento"].ToString();
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
        /// Clinica.selPaciente: hecho
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
                            response.TipoSangre = dr["TipoSangre"].ToString();
                            response.LugarNacimiento = dr["LugarNacimiento"].ToString();
                            response.LugarResidencia = dr["LugarResidencia"].ToString();
                            response.Nombre = dr["Nombre"].ToString();
                            response.Rh = dr["Rh"].ToString().ToCharArray()[0];
                            response.Sexo = dr["Sexo"].ToString();
                            response.Tabaco = (bool)dr["Tabaco"];
                            response.IdTipoNumero = (int)dr["IdTipoTelefono"];
                            response.Numero = dr["NumeroTelefono"].ToString();
                            response.Alergias = dr["Alergias"].ToString();
                            response.Adicciones = dr["Adicciones"].ToString();
                            response.AnioResidencia = (int)dr["AnioResidencia"];
                            response.Ocupacion = dr["ocupacion"].ToString();
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
        /// Clinica.spCargarAntGineco: hecho
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
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
                            ParameterName = "Id",
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.IdPaciente
                        });
                        Conn.Open();
                        var dr = Cmd.ExecuteReader();
                        if (dr.HasRows) {
                            dr.Read();
                            response.A = int.Parse(dr["A"].ToString());
                            response.C = int.Parse(dr["C"].ToString());
                            response.G = int.Parse(dr["G"].ToString());
                            response.Id = int.Parse(dr["Id"].ToString());
                            response.IdAnticonceptivo = int.Parse(dr["IdAnticonceptivo"].ToString());
                            response.IdPaciente = int.Parse(dr["IdPaciente"].ToString());
                            response.P = int.Parse(dr["P"].ToString());

                            response.FUR = DateTime.Parse(dr["FUR"].ToString());
                            response.Mastografia = DateTime.Parse(dr["Mastografia"].ToString());
                            response.Menarca = DateTime.Parse(dr["Menarca"].ToString());
                            response.Papanicolaou = DateTime.Parse(dr["Papanicolaou"].ToString());
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
        /// Clinica.spCargarAntHered: hecho
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
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
                        response.Items = new List<AntHeredItem>();
                        if (dr.HasRows) {
                            while (dr.Read()) {
                                response.Items.Add(new AntHeredItem() {
                                    Id = int.Parse(dr["Id"].ToString()),
                                    IdFamiliar = int.Parse(dr["IdFamiliar"].ToString()),
                                    Padecimiento = dr["Padecimiento"].ToString(),
                                    Familiar = dr["Familiar"].ToString()
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
        /// Clinica.spGuardaAntPersonalNoPatologico: Por construir tabla y SP, y actualizar método
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Clinica.spCargarAntPersonalPatologico: hecho
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
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
                        response.Items = new List<AntPersonalPatItem>();
                        if (dr.HasRows) {
                            while (dr.Read()) {
                                response.Items.Add(new AntPersonalPatItem() {
                                    Enfermedad = dr["Enfermedad"].ToString(),
                                    FechaInicio = (DateTime)dr["FechaInicio"],
                                    Id = (int)dr["Id"],
                                    IdStatus = (int)dr["IdStatus"],
                                    Status = dr["Status"].ToString()
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
        /// Clinica.spCargarExploracionFisica: hecho
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
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
                            response.Estatura = byte.Parse(dr["Estatura"].ToString());
                            response.FC = byte.Parse(dr["FC"].ToString());
                            response.FR = byte.Parse(dr["FR"].ToString());
                            response.Id = int.Parse(dr["Id"].ToString());
                            response.IdHistoria = int.Parse(dr["IdHistoriaClinica"].ToString());
                            response.Peso = decimal.Parse(dr["Peso"].ToString());
                            response.Pulso = byte.Parse(dr["Pulso"].ToString());
                            response.TA = dr["TA"].ToString();
                            response.Temperatura = decimal.Parse(dr["Temperatura"].ToString());
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
        /// Clinica.spCargarExploracionSistema: hecho
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
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
                        response.Items = new List<ExploraSistemaItem>();
                        if (dr.HasRows) {
                            while (dr.Read()) {
                                response.Items.Add(new ExploraSistemaItem {
                                    Descripcion = dr["Descripcion"].ToString(),
                                    Id = int.Parse(dr["Id"].ToString()),
                                    IdSistema = int.Parse(dr["IdSistema"].ToString()),
                                    Sistema = dr["Sistema"].ToString()
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
        /// Clinica.spCargarHistoriaClinica: hecho
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public RegistraHistoriaReqResp ObtenerHistoria(RegistraHistoriaReqResp request) {
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
                            ParameterName = "IdHistoria",
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.IdHistoria
                        });
                        Conn.Open();
                        var dr = Cmd.ExecuteReader();
                        if (dr.HasRows) {
                            dr.Read();
                            response.Analisis = dr["Analisis"].ToString();
                            response.FechaHistoria = (DateTime)dr["FechaHistoria"];
                            response.Id = (int)dr["Id"];
                            response.IdMedico = (int)dr["IdMedico"];
                            response.IdPaciente = (int)dr["IdPaciente"];
                            response.ImpresionDiagnostica = dr["ImpresionDiagnostica"].ToString();
                            response.MotivoConsulta = dr["MotivoConsulta"].ToString();
                            response.PlanTerapeutico = dr["PlanTerapeutico"].ToString();
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
        /// Clinica.spCargarMedicacionActual: hecho
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
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
                        var dr = Cmd.ExecuteReader();
                        if (dr.HasRows) {
                            response.IdHistoria = request.IdHistoria;
                            response.Items = new List<MedicacionActualItem>();
                            while (dr.Read()) {
                                response.Items.Add(new MedicacionActualItem() {
                                    Dosis = dr["Dosis"].ToString(),
                                    FechaInicio = (DateTime)dr["FechaInicio"],
                                    Id = (int)dr["Id"],
                                    Medicamento = dr["Medicamento"].ToString()
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
        /// Clinica.spListarHistoriasPaciente: hecho
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
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
                        var dr = Cmd.ExecuteReader();
                        if (dr.HasRows) {
                            response.Items = new List<RegistraHistoriaReqResp>();
                            response.IdPaciente = response.IdPaciente;
                            while (dr.Read()) {
                                response.Items.Add(new RegistraHistoriaReqResp() {
                                    Analisis = dr["Analisis"].ToString(),
                                    ImpresionDiagnostica = dr["ImpresionDiagnostica"].ToString(),
                                    MotivoConsulta = dr["MotivoConsulta"].ToString(),
                                    PlanTerapeutico = dr["PlanTerapeutico"].ToString(),
                                    Id = (int)dr["Id"],
                                    IdHistoria = (int)dr["IdHistoria"],
                                    IdMedico = (int)dr["IdMedico"],
                                    IdPaciente = (int)dr["IdPaciente"],
                                    FechaHistoria = (DateTime)dr["FechaHistoria"]
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
        /// Administracion.verMedico: hecho
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
                            response.IdLugarNacimiento = (int)dr["IdLugarNacimiento"];
                            response.FechaNacimiento = (DateTime)dr["FechaNacimiento"];
                            response.CiudadNacimiento = dr["CiudadNacimiento"].ToString();
                            response.Nombre = dr["Nombre"].ToString();
                            response.Rh = dr["Rh"].ToString()[0];
                            response.Sexo = dr["Sexo"].ToString();
                            response.IdSexo = (int)dr["IdSexo"];
                            response.TipoSangre = dr["TipoSangre"].ToString();
                            response.IdTipoSangre = (int)dr["IdTipoSangre"];
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
        /// Configuracion.spCatalogo: hecho
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public CatalogoReqResp obtenerCatalogo(CatalogoReqResp request) {
            SqlCommand Cmd;
            SqlConnection Conn;
            CatalogoReqResp response = new CatalogoReqResp() {
                items = new Dictionary<int, string>()
            };
            try {
                using (Conn = new SqlConnection(Connstring)) {
                    using (Cmd = new SqlCommand() {
                        Connection = Conn,
                        CommandType = System.Data.CommandType.StoredProcedure,
                        CommandText = "Configuracion.spCatalogo"
                    }) {
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "Catalogo",
                            DbType = System.Data.DbType.String,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.Catalogo
                        });
                        Conn.Open();
                        var dr = Cmd.ExecuteReader();
                        if (dr.HasRows) {
                            while (dr.Read()) {
                                response.items.Add((int)dr["Id"], dr["Nombre"].ToString());
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
        /// Clinica.buscarHistorias: hecho
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public buscarHistoriaResponse buscarHistorias(buscarHistoriasRequest request) {
            SqlCommand Cmd;
            SqlConnection Conn;
            var response = new buscarHistoriaResponse();
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
                            Value = request.IdPaciente
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "Paciente",
                            DbType = System.Data.DbType.String,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.Paciente
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "IdMedico",
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.IdMedico
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "FechaHistoria",
                            DbType = System.Data.DbType.Date,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.FechaHistoria
                        });
                        Conn.Open();
                        var dr = Cmd.ExecuteReader();
                        if (dr.HasRows) {
                            response.Items = new List<buscarHistoriasItem>();
                            while (dr.Read()) {
                                response.Items.Add(new buscarHistoriasItem() {
                                    Id = (int)dr["Id"],
                                    IdPaciente = (int)dr["IdPaciente"],
                                    Medico = dr["Medico"].ToString(),
                                    MotivoConsulta = dr["MotivoConsulta"].ToString(),
                                    Paciente = dr["Paciente"].ToString(),
                                    FechaHistoria = (DateTime)dr["FechaHistoria"]
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

        public EstadosReqResp obtenerEstados(EstadosReqResp request) {
            SqlCommand Cmd;
            SqlConnection Conn;
            var response = new EstadosReqResp();
            try {
                using (Conn = new SqlConnection(Connstring)) {
                    using (Cmd = new SqlCommand() {
                        Connection = Conn,
                        CommandType = System.Data.CommandType.StoredProcedure,
                        CommandText = "Configuracion.obtenerEstados"
                    }) {
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "id",
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.Datos.Id
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "nombre",
                            DbType = System.Data.DbType.String,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = request.Datos.Nombre
                        });
                        Conn.Open();
                        var dr = Cmd.ExecuteReader();
                        if (dr.HasRows) {
                            response.Items = new List<EstadosReqRespItem>();
                            while (dr.Read()) {
                                response.Items.Add(new EstadosReqRespItem() {
                                    Id = (int)dr["Id"],
                                    Nombre = dr["Nombre"].ToString()
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

        public ListaNotasEvolutivasResponse ListaNotasEvolutivas(NotaEvolutivaReqResp notaEvolutivaReq) {
            SqlCommand Cmd;
            SqlConnection Conn;
            var response = new ListaNotasEvolutivasResponse();
            try {
                using (Conn = new SqlConnection(Connstring)) {
                    using (Cmd = new SqlCommand() {
                        Connection = Conn,
                        CommandType = System.Data.CommandType.StoredProcedure,
                        CommandText = "Clinica.selNotaEvolutiva"
                    }) {
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "Id",
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = notaEvolutivaReq.IdNota
                        });
                        Cmd.Parameters.Add(new SqlParameter() {
                            ParameterName = "idhistoria",
                            DbType = System.Data.DbType.Int16,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = notaEvolutivaReq.IdHistoria
                        });
                        Conn.Open();
                        var dr = Cmd.ExecuteReader();
                        if (dr.HasRows) {
                            response.Items = new List<NotaEvolutivaReqResp>();
                            while (dr.Read()) {
                                response.Items.Add(new NotaEvolutivaReqResp() {
                                    IdNota = int.Parse(dr["Id"].ToString()),
                                    IdHistoria = int.Parse(dr["IdHistoria"].ToString()),
                                    Fecha = DateTime.Parse(dr["Fecha"].ToString()),
                                    PlanTratamiento = dr["PlanTratamiento"].ToString(),
                                    ExploracionFisica = new RegistraExploraFisicaReqResp {
                                        Descripcion = dr["Descripcion"].ToString(),
                                        Estatura = byte.Parse(dr["Estatura"].ToString()),
                                        FC = byte.Parse(dr["FC"].ToString()),
                                        FR = byte.Parse(dr["FR"].ToString()),
                                        Peso = decimal.Parse(dr["Peso"].ToString()),
                                        Pulso = byte.Parse(dr["Pulso"].ToString()),
                                        TA = dr["TA"].ToString(),
                                        Temperatura = decimal.Parse(dr["Temperatura"].ToString())
                                    },
                                    IdPaciente = int.Parse(dr["IdPaciente"].ToString())
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
    }
}