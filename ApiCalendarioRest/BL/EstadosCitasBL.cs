using ApiCalendarioRest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiCalendarioRest.BL
{
    public class EstadosCitasBL
    {
        DB_CitasEntities db = new DB_CitasEntities();

        public List<ConsultarEstados_Result> ConsultarTodasEstadosCitas()
        {
            using (DB_CitasEntities context = new DB_CitasEntities())
            {
                return context.ConsultarEstados().ToList();
            }
        }
    }
}