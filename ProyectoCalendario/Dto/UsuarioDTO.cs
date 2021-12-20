using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoCalendario.Dto
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Password { get; set; }
        public int Rol { get; set; }
        public int IdSistema { get; set; }
        public int IdEstado { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
    }
}