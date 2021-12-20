using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NotificacionWebService
{
    public class Modelnotificacion
    {
        public string hash { get; set; }
        public string destinatario { get; set; }
        public string asunto { get; set; }
        public string mensaje { get; set; }
    }
}