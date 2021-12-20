using ApiCalendarioRest.BL;
using ApiCalendarioRest.Dto;
using ApiCalendarioRest.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ApiCalendarioRest.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*", exposedHeaders: "X-My-Header")]
    public class CitasController : ApiController
    {
        DB_CitasEntities db = new DB_CitasEntities();

        CitaBL cita = new CitaBL();

        [EnableCors(origins: "*", headers: "accept,content-type,origin,x-my-header", methods: "*")]
        [HttpGet]
        [Route ("api/citas/ConsultarCitas")]
        public List<ConsultarTodasCitas_Result> ConsultarCitas()
        {
           var ListaResult= cita.ConsultarTodasCitas();
           return ListaResult;
        }

        [EnableCors(origins: "*", headers: "accept,content-type,origin,x-my-header", methods: "*")]
        [HttpPost]
        [Route("api/citas/CrearCita")]
        public string CrearCita(Cita cita)
        {
            string result = "";
            string idUsuario = cita.IdUsuario.ToString();
            string FechaIni = cita.FechaInicio.ToString();
            string FechaFi = cita.FechaFin.ToString();
            string FechaInio = "";
            string FechaFin = "";
            DateTime FechaInic = Convert.ToDateTime(FechaIni);
            DateTime FechaF = Convert.ToDateTime(FechaFi);
            FechaInio = (FechaInic.ToString("yyyy-MM-dd"));
            FechaFin = (FechaF.ToString("yyyy-MM-dd"));
            var resultado = this.cita.ValidarRegistro(FechaInio, cita.HoraInicio.ToString(), FechaFin, cita.HoraFin.ToString());
            
            if (!string.IsNullOrEmpty(idUsuario))
            {
                if(resultado.ToString().Equals("0"))
                { 
                db.Cita.Add(cita);
                db.SaveChanges();

                result = "Cita creada exitosamente";
                }
                else
                {
                    result = "No se pudo crear su cita debido a que este espacio ya ha sido agendado ";
                }
            }
            else
                result = "No se pudo crear su cita";
            return result;
        }

        [EnableCors(origins: "*", headers: "accept,content-type,origin,x-my-header", methods: "*")]
        [Route("api/citas/EliminarCita")]
        [HttpPost]
        
        public string EliminarCita(Cita cita)
        {

            string result = "";

            var citaEliminar = db.Cita.FirstOrDefault(d => d.Id.Equals(cita.Id));
            if (citaEliminar != null)
            {
                db.Cita.Remove(citaEliminar);
                db.SaveChanges();
                result = "Cita eliminada exitosamente";
            }
            else
                result = "Ocurrio un error inesperado su cita no es posible de eliminar";
            return result;
        }

        [EnableCors(origins: "*", headers: "accept,content-type,origin,x-my-header", methods: "*")]
        [Route("api/citas/ConsultarxId")]
        [HttpPost]

        public ConsultaCitaXId_Result ConsultarxId(Cita citas)
        {
            Cita miCita = new Cita();

            string result = "";

            var resul = cita.ConsultarCitaXId(citas.Id);


            return resul;
        }

        [EnableCors(origins: "*", headers: "accept,content-type,origin,x-my-header", methods: "*")]
        [Route("api/citas/UpdateCitaxId")]
        [HttpPost]

        public string UpdateCitaxId(Cita citas)
        {
    
            Cita user = new Cita();

            var resul = cita.ActualizarRegistros( citas);
            if(string.IsNullOrEmpty(resul))
            {
                resul = "Modificacion Fallida";
            }

            return resul;
        }
    }
}
