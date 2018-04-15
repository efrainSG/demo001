using System;
using System.Net;
using System.Net.Mail;

namespace WCFSernaSistemasLib {
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class SernaSistemasServices : ISernaSistemasServices {
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
            var response = new ConsultaProyectoResponse() {
                ActividadesRestantes = 1,
                Descripcion = "desarrollo de proyecto demo en sitio web propio",
                Error = 0,
                FechaTermino = DateTime.Today,
                Mensaje = string.Empty,
                NombreProyecto = "Serna Sistemas Web",
                Plataforma = "Serna Sistemas Web",
                Sprint = 1,
                tieneError = false
            };
            return response;
        }
    }
}
