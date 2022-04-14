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
    using System.ComponentModel.DataAnnotations;

    public partial class libro
    {
        public int id { get; set; }
        [Required]
        public string titulo { get; set; }
        [DataType(DataType.Date)]
        public System.DateTime fecha { get; set; }
        public string genero { get; set; }
        public int paginas { get; set; }
        [Required(ErrorMessage = "escribe un autor")]
        //[DataType(DataType.MultilineText)]
        [Display(Name ="Autor")]
        public int id_autor { get; set; }
    
        public virtual autor autor { get; set; }
    }
}
