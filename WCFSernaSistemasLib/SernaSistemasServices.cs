using System;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;

namespace WCFSernaSistemasLib
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class SernaSistemasServices : ISernaSistemasServices
    {
        public string ConnString { get; set; }
        public ContactoResponse registrarContacto(ContactoRequest request) {
            var response = new ContactoResponse();
            NetworkCredential credenciales = new NetworkCredential() {
                UserName = "",
                Password = ""
            };
            SmtpClient cliente = new SmtpClient() {
                Host = "smtp-mail.outlook.com",
                Port = 587,
                UseDefaultCredentials = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                EnableSsl = true,
            };
            cliente.Credentials = credenciales;

            try {
                var mensaje = new MailMessage(new MailAddress(credenciales.UserName), new MailAddress(credenciales.UserName)) {
                    Body = "<table>" +
                    "<tr><td><strong>Nombre:</strong></td><td><em>" + request.Nombre + "</em></td></tr>" +
                    "<tr><td><strong>Teléfono:</strong></td><td><em>" + request.Telefono + "</em></td></tr>" +
                    "<tr><td><strong>Correo de contacto:</strong></td><td><em>" + request.eMail + "</em></td></tr>" +
                    "<tr><td><strong>Comentario:</strong></td><td><em>" + request.Comentario + "</em></td></tr>",
                    Subject = "Solicitud de contacto",
                    IsBodyHtml = true
                };
                mensaje.ReplyToList.Add(request.eMail);
                cliente.Send(mensaje);
                mensaje = new MailMessage(new MailAddress(credenciales.UserName), new MailAddress(request.eMail)) {
                    Body = "<p><strong>Muchas gracias por ponerte en contacto conmigo.</strong></p> " +
                    "<p>En breve me pondré en contacto a tu número telefónico " +
                    "(en caso de haberlo proporcionado) o a tu dirección de correo electrónico.<br />" +
                    "<em>Este correo es una confirmación que recibí tu información.</em> " +
                    "Los siguientes correos llevan por título <strong>CONTACTO SERNA-SISTEMAS</strong> " +
                    "y servirá para dar un seguimiento más sencillo a tu inquietud, por lo que te sugiero no cambiar " +
                    "el asunto de esos correos.</p>" +
                    "<p>Nuevamente, muchas gracias por tu contacto.</p>",
                    Subject = "Solicitud de contacto",
                    IsBodyHtml = true
                };
                cliente.Send(mensaje);
                response.tieneError = false;
                response.Mensaje = "Correo enviado";
            } catch (Exception ex) {
                response.Error = ex.HResult;
                response.Mensaje = ex.Message;
                response.tieneError = true;
            }
            return response;
        }

        public ConsultaProyectoResponse consultaProyecto(ConsultaProyectoRequest consultaProyectoRequest) {
            ConsultaProyectoResponse response = new ConsultaProyectoResponse();
            SqlCommand Cmd;
            SqlConnection Conn;
            SqlDataReader dr;
            try {
                using (Conn = new SqlConnection(ConnString)) {
                    using (Cmd = new SqlCommand() {
                        Connection = Conn,
                        CommandText = "Proyecto.selStatusActual",
                        CommandType = System.Data.CommandType.StoredProcedure
                    }) {
                        Cmd.Parameters.Add(new SqlParameter() {
                            DbType = System.Data.DbType.Int32,
                            Direction = System.Data.ParameterDirection.Input,
                            ParameterName = "IdProyecto",
                            Value = consultaProyectoRequest.Folio
                        });
                        Conn.Open();
                        dr = Cmd.ExecuteReader();
                        if (dr.HasRows) {
                            while (dr.Read()) {
                                
                                response.ActividadesRestantes = 1;
                                response.Descripcion = dr["Descripcion"].ToString();
                                response.Error = 0;
                                response.FechaTermino = DateTime.Today;
                                response.Mensaje = string.Empty;
                                response.NombreProyecto = dr["Proyecto"].ToString();
                                response.Plataforma = dr["Plataforma"].ToString();
                                response.Sprint = 1;
                                response.tieneError = false;
                            }
                        }
                        Conn.Close();
                    }
                }
            } catch (Exception ex) {
                response.Error = 1;
                response.tieneError = true;
                response.Mensaje = ex.Source;
            }
            return response;
        }
    }
}
