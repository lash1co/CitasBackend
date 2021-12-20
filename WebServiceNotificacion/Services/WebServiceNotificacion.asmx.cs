using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Services;
using WebServiceNotificacion.Dto;

namespace WebServiceNotificacion.Services
{
    /// <summary>
    /// Descripción breve de WebServiceNotificacion
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceNotificacion : System.Web.Services.WebService
    {
        const string API_KEY = "Twilio_Api_Key";
        const string HASH = "Un_Hash";
        public string Email_From = "tucorreo@dominio.com";

        [WebMethod]
        public async Task<string> NotificarAsync(NotificacionDTO notificacion)
        {
            string resultado = "KO";
            if (notificacion != null && notificacion.hash == HASH)
            {
                var client = new SendGridClient(API_KEY);
                var from = new EmailAddress(Email_From, "APPCalendario");
                var subject = notificacion.asunto;
                var to = new EmailAddress(notificacion.destinatario, notificacion.destinatario);
                var plainTextContent = notificacion.mensaje;
                var htmlContent = "<strong>" + notificacion.mensaje + "</strong>";
                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
                try
                {
                    var response = await client.SendEmailAsync(msg);
                    if (response != null && response.IsSuccessStatusCode)
                    {
                        resultado = "OK!";
                    }
                }
                catch
                {
                    resultado = "KO";
                }

            }
            //var apiKey = Environment.GetEnvironmentVariable("NAME_OF_THE_ENVIRONMENT_VARIABLE_FOR_YOUR_SENDGRID_KEY");
            return resultado;
        }
    }
}
