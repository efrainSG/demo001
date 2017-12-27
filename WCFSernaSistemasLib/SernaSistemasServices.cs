using System;
using System.Net;
using System.Net.Mail;

namespace WCFSernaSistemasLib {
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class SernaSistemasServices : ISernaSistemasServices {
        public ContactoResponse registrarContacto(ContactoRequest request) {
            var response = new ContactoResponse();
            NetworkCredential credenciales = new NetworkCredential() {
                UserName = "efrain_serna@hotmail.com",
                Password = "Joshua2005"
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
                response.tieneError = false;
                response.Mensaje = "Correo enviado";
            } catch (Exception ex) {
                response.Error = ex.HResult;
                response.Mensaje = ex.Message;
                response.tieneError = true;
            }
            return response;
        }
    }
}
