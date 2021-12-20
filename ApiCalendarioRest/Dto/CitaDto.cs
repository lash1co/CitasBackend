using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiCalendarioRest.Dto
{
    public class CitaDto
    {
        public int Id { get; set; }
        public int IdEvento { get; set; }
        public DateTime FechaInicio { get; set; }
        public string HoraInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string HoraFin { get; set; }
        public int IdUsuario { get; set; }
        public string TituloCita { get; set; }
        public int IdEstado { get; set; }

        public int EstadoCita { get; set; }
        public int Evento { get; set; }
        public int Usuario { get; set; }
    }
}