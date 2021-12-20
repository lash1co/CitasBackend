using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace NotificacionWebService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "notificacion" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione notificacion.svc o notificacion.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class notificacion : Inotificacion
    {
        const string API_KEY = "SG.uCxrN_OHQ_yHOQd-vwCnmw.dWVln1UdZgQAxfL3Mr5RxCOOWAMSFmmU-KZtGrvHxmU";
        const string HASH = "MicroServicios";
        public string Email_From = "lash1co@gmail.com";
        public async Task<string> NotificarAsync(Modelnotificacion notificacion)
        {
            string resultado = "KO";
            if(notificacion!=null && notificacion.hash == HASH) 
            {
                var client = new SendGridClient(API_KEY);
                var from = new EmailAddress(Email_From, "APPCalendario");
                var subject = notificacion.asunto;
                var to = new EmailAddress(notificacion.destinatario, notificacion.destinatario);
                var plainTextContent = notificacion.mensaje;
                var htmlContent = "<strong>"+notificacion.mensaje+"</strong>";
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
