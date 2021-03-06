//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LEA_Salón.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Servicio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Servicio()
        {
            this.DetalleVenta = new HashSet<DetalleVenta>();
        }

        [Key]
        public int IdServicio { get; set; }
        [Display(Name = "Servicio")]
        [Required(ErrorMessage = "Campo {0}, Es Requerido")]
        [StringLength(50, ErrorMessage = "Campo {0}, puede contener maximo {1} y minimo {2} Digitos ", MinimumLength = 3)]
        public string Nombre { get; set; }
        [Display(Name = "Precio")]
        [Required(ErrorMessage = "Campo {0}, Es Requerido")]
        public Nullable<double> Precio { get; set; }
        [Display(Name = "Categoria")]
        [StringLength(50, ErrorMessage = "Campo {0}, puede contener maximo {1} y minimo {2} Digitos ", MinimumLength = 0)]
        public string Descripcion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleVenta> DetalleVenta { get; set; }
    }
}
