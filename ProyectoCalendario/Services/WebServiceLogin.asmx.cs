using Microsoft.AspNetCore.Cors;
using ProyectoCalendario.Dto;
using ProyectoCalendario.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace ProyectoCalendario.Services
{
    /// <summary>
    /// Descripción breve de WebServiceLogin
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
   
    public class WebServiceLogin : System.Web.Services.WebService
    {

        DB_CitasEntities db = new DB_CitasEntities();

       

        [WebMethod]
        public UsuarioDTO Login(String usuario, string contrasenia, int idSistema)
        {
            UsuarioDTO usuarios = new UsuarioDTO();

            var usuExistente = db.Usuario.FirstOrDefault(u =>
                                u.Nombre.Equals(usuario)
                                && u.Password.Equals(contrasenia) && u.IdSistema.Equals(idSistema));

            if (usuExistente != null)
            {
                usuarios.Id = usuExistente.Id;
                usuarios.Nombre = usuExistente.Nombre;
                usuarios.Rol = usuExistente.IdRol;
                usuarios.IdSistema = usuExistente.IdSistema;
                usuarios.IdEstado = (int)usuExistente.IdEstadoUsuario;
                usuarios.Telefono = usuExistente.Telefono;
                usuarios.Email = usuExistente.Correo;

            }

            return usuarios;
        }
       
        [WebMethod]
        public string CrearUsuario(String usuario, string contrasenia, int rol, int idSistema, string telefono, string correo)
        {
            Usuario user = new Usuario();
            String resultado = null;

            if (!(string.IsNullOrEmpty(usuario)) || !(string.IsNullOrEmpty(contrasenia)))
            {
                user.Nombre = usuario;
                user.Password = contrasenia;
                user.FechaIngreso = DateTime.Today;
                user.IdRol = rol;
                user.IdSistema = idSistema;
                user.IdEstadoUsuario = Constants.EstadoCreacion;
                user.Telefono = telefono;
                user.Correo = correo;

            }
            else
            {
                resultado = "Los campos usuario y constraseña son obligatorios";
                return resultado;
            }
            if (string.IsNullOrEmpty(contrasenia))
            {
                resultado = "El campo  constraseña es obligatorio";
                return resultado;
            }
            if (string.IsNullOrEmpty(usuario))
            {
                resultado = "El campo  usuario es obligatorio";
                return resultado;
            }

            var usuExistente = db.Usuario.FirstOrDefault(u =>
                                u.Nombre.Equals(usuario)
                                && u.IdSistema.Equals(idSistema));

            if (usuExistente != null)
            {
                resultado = "Usuario existente";
                return resultado;
            }
            else
            {
                db.Usuario.Add(user);
                db.SaveChanges();
                resultado = "Usuario creado exitosamente";
            }

            return resultado;
        }

        [WebMethod]
        public string UpdateUsuario(String usuario, int rol, int idSistema, string contresenia ,string telefono, string correo, int idEstado)
        {
            string resultado = "";
           
            var usuExistente = db.Usuario.FirstOrDefault(u =>
                                u.Nombre.Equals(usuario)
                                && u.IdSistema.Equals(idSistema));

            if (usuExistente != null)
            {
                if(!string.IsNullOrEmpty(usuario))
                {
                    usuExistente.Nombre = usuario;
                }
                if (!string.IsNullOrEmpty(telefono))
                {
                    usuExistente.Telefono = telefono;
                }
                if (!string.IsNullOrEmpty(contresenia))
                {
                    usuExistente.Password = contresenia;
                }
                if (!string.IsNullOrEmpty(correo))
                {
                    usuExistente.Correo = correo;
                }
                if(!string.IsNullOrEmpty(rol.ToString()))
                {
                    usuExistente.IdRol = rol;
                }
                if (!string.IsNullOrEmpty(idEstado.ToString()))
                {
                    usuExistente.IdEstadoUsuario = idEstado;
                }

                db.SaveChanges();
                

                resultado = "Modificacion exiosa";
            }
            return resultado;
        }

    }

}


static class Constants
    {      
        public const int EstadoCreacion = 1; 
    }

