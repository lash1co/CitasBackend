//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ApiCalendarioRest.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuario()
        {
            this.Cita = new HashSet<Cita>();
        }
    
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Password { get; set; }
        public Nullable<System.DateTime> FechaIngreso { get; set; }
        public int IdRol { get; set; }
        public int IdSistema { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public Nullable<int> IdEstadoUsuario { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cita> Cita { get; set; }
    }
}
