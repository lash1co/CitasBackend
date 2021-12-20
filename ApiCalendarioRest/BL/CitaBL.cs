using ApiCalendarioRest.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;

namespace ApiCalendarioRest.BL
{
    public class CitaBL
    {
        DB_CitasEntities db = new DB_CitasEntities();

        public List<ConsultarTodasCitas_Result> ConsultarTodasCitas()
        {
            using (DB_CitasEntities context = new DB_CitasEntities())
            {
                return context.ConsultarTodasCitas().ToList();
            }
        }

        public ConsultaCitaXId_Result ConsultarCitaXId(int idCita)
        {
            using (DB_CitasEntities context = new DB_CitasEntities())
            {

                var resul = db.Database.SqlQuery<ConsultaCitaXId_Result>("ConsultaCitaXId @idCita", new SqlParameter("@idCita", idCita)).FirstOrDefault();
                return resul;
            }
        }

        public String ActualizarRegistros(Cita citaId)
        {
            String resultado = "";
            try
            {
                using (DB_CitasEntities context = new DB_CitasEntities())
                {

                    db.ActualizarRegistros(citaId.Id,citaId.IdEstado, citaId.IdEvento, citaId.FechaInicio, citaId.HoraInicio, citaId.FechaFin, citaId.HoraFin,citaId.TituloCita);

                    resultado = "Modificacion Exitosa!!";
                }
            }
            catch (Exception ex)
            {
                resultado = "Modificacion Fallida!!";
                throw new ApplicationException(string.Format("I cannot write the file "), ex);
                
            }
           
            return "resultado";
        }

        public int ValidarRegistro(string FechaIni, string HoraI, string FechaF, string HoraF)
        {
            int resultado = 0;
            
            //string format = "yyyy-MM-dd";
            //DateTime dateTimeFeI = DateTime.ParseExact(FechaIni, format, CultureInfo.InvariantCulture);
            //DateTime dateTimeFef = DateTime.ParseExact(FechaF, format, CultureInfo.InvariantCulture);
            //Console.WriteLine(dateTime);
            try
            {
                using (DB_CitasEntities context = new DB_CitasEntities())
                {
                    
                    var resul = db.Database.SqlQuery<PRC_VALIDAR_AGENDA_CITA_Result>("PRC_VALIDAR_AGENDA_CITA @FECHAI,@HORAI,@FECHAF,@HORAF",
                        new SqlParameter("@FECHAI", FechaIni),
                        new SqlParameter("@HORAI", HoraI),
                        new SqlParameter ("@FECHAF", FechaF),
                         new SqlParameter("@HORAF", HoraF)
                        ).FirstOrDefault();


                    if(string.IsNullOrEmpty(resul.RESULTADO.ToString()))
                    {
                        resultado = 0;
                    }
                    else
                    {
                        if (resul.RESULTADO.ToString().Equals("0"))
                        {
                            resultado = 0;
                        }
                        else { resultado = 1; }
                    }
 
                }
            }
            catch (Exception ex)
            {
                //resultado = "Modificacion Fallida!!";
                throw new ApplicationException(string.Format("I cannot write the file "), ex);

            }

            return resultado;
        }

    }
}