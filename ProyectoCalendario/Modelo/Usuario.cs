//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoCalendario.Modelo
{
    using System;
    using System.Collections.Generic;
    
    public partial class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Password { get; set; }
        public Nullable<System.DateTime> FechaIngreso { get; set; }
        public int IdRol { get; set; }
        public int IdSistema { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public Nullable<int> IdEstadoUsuario { get; set; }
    }
}
