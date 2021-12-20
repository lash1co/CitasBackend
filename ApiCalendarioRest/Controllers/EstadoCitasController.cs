using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using ApiCalendarioRest.BL;
using ApiCalendarioRest.Models;

namespace ApiCalendarioRest.Controllers
{
    [EnableCors(origins: "*", headers: "accept,content-type,origin,x-my-header", methods: "*")]
    public class EstadoCitasController : ApiController
    {
        private DB_CitasEntities db = new DB_CitasEntities();

        EstadosCitasBL estado = new EstadosCitasBL();
        // GET: api/EstadoCitas

        [EnableCors(origins: "*", headers: "accept,content-type,origin,x-my-header", methods: "*")]
        [Route("api/estadocitas/consultarEstados")]
        [HttpGet]
        public List<ConsultarEstados_Result> ConsultarCitas()
        {
            var ListaResult = estado.ConsultarTodasEstadosCitas();
            return ListaResult;
        }

        [EnableCors(origins: "*", headers: "accept,content-type,origin,x-my-header", methods: "*")]
        [Route("api/estadocitas/version")]
        [HttpGet]
        public string ConsultarVersion()
        {
           
            return "version 1000.1";
        }

    }
}