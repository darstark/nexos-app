//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class autor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public autor()
        {
            this.libro = new HashSet<libro>();
        }
    
        public int id { get; set; }
        public string nombre { get; set; }
        public Nullable<System.DateTime> fecha_nacimiento { get; set; }
        public string ciudad_procedencia { get; set; }
        public string correo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<libro> libro { get; set; }
    }
}