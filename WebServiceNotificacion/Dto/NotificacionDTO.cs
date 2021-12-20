using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceNotificacion.Dto
{
    public class NotificacionDTO
    {
        public string hash { get; set; }
        public string destinatario { get; set; }
        public string asunto { get; set; }
        public string mensaje { get; set; }
    }
}