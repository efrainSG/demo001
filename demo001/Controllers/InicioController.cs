using demo001.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Web.Mvc;
using demo001.Domains;
using System.Text;

namespace demo001.Controllers {
    public class InicioController : Controller {

        // GET: Inicio
        public ActionResult Index() {
            return View();
        }

        [HttpPost]
        public ActionResult registraContacto(Contacto contacto) {
            var entidades = new contactosEntities();
            contacto.Registro = DateTime.Today;
            entidades.Contactoes.Add(contacto);
            entidades.SaveChanges();
            try {
                MailMessage correo = new MailMessage();
                SmtpClient cliente = new SmtpClient(Correos.getSmtpServer(Correos.EFRAIN_HOTMAIL));
                correo.From = new MailAddress(Correos.getCorreo(Correos.EFRAIN_HOTMAIL));
                correo.To.Add(contacto.Correo);
                correo.Bcc.Add(correo.From);
                correo.Subject = "Gracias por contactarme";
                correo.BodyEncoding = Encoding.UTF8;
                correo.IsBodyHtml = true;
                StringBuilder sb = new StringBuilder("<p><strong>" + contacto.Nombre + ": </strong></p>");
                sb.Append("<p>Pronto me pondré en contacto contigo al número <em>");
                sb.Append(contacto.Telefono);
                sb.Append("</em> o a este correo con relación a tu comentario:</p>");
                sb.Append("<blockquote>" + contacto.Comentario + "</blockquote>");
                correo.Body = sb.ToString();
                cliente.Port = Correos.getPuertoEnviar(Correos.EFRAIN_HOTMAIL);
                cliente.Credentials = new System.Net.NetworkCredential(Correos.getCorreo(Correos.EFRAIN_HOTMAIL), "Joshua2005");
                cliente.EnableSsl = true;
                cliente.Send(correo);
                contacto = new Contacto();
            }
            catch (Exception ex) {
                throw ex;
            }
            return View("Index",contacto);
        }
    }
}