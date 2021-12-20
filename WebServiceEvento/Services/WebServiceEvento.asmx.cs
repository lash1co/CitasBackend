using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using WebServiceEvento.Modelo;

namespace WebServiceEvento.Services
{
    /// <summary>
    /// Descripción breve de WebServiceEvento
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceEvento : System.Web.Services.WebService
    {
        DB_CitasEntities db = new DB_CitasEntities();

        [WebMethod]
        public List<Evento> ListarEventos()
        {
            return db.Evento.ToList();
        }

        [WebMethod]
        public string CrearEvento(string evento, int estado) 
        {
            Evento ev = new Evento();
            String resultado = null;
            if (!string.IsNullOrEmpty(evento))
            {
                ev.Nom_Evento = evento;
                ev.IdEstado = estado;
                db.Evento.Add(ev);
                db.SaveChanges();
                resultado = "El evento ha sido creado.";
            }
            else 
            {
                resultado = "El evento no se pudo crear.";
            }
            return resultado;
        }

        [WebMethod]
        public Evento SeleccionarEvento(int id)
        {
            Evento seleccion = new Evento();
            var eventoseleccionado = db.Evento.Find(id);
            if (eventoseleccionado != null)
            {
                seleccion.Id = eventoseleccionado.Id;
                seleccion.Nom_Evento = eventoseleccionado.Nom_Evento;
                seleccion.IdEstado = eventoseleccionado.IdEstado;
            }
            return seleccion;
        }

        [WebMethod]
        public string ActualizarEvento(int id, string evento, int estado) 
        {
            string resultado = "El evento no se pudo actualizar.";
            if (!string.IsNullOrEmpty(evento)) 
            {
                Evento ev = new Evento();
                var actualizarEvento = db.Evento.Find(id);
                if(actualizarEvento != null) 
                {
                    ev.Nom_Evento = evento;
                    ev.IdEstado = estado;
                    db.SaveChanges();
                    resultado = "El evento fue actualizado.";
                }
                else 
                {
                    resultado = "No se encontro evento a actualizar.";
                }
            }
            return resultado;
        }
    }
}
