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

    public partial class Producto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Producto()
        {
            this.Compra = new HashSet<Compra>();
            this.DetalleVenta = new HashSet<DetalleVenta>();
        }

        [Key]
        public int IdProducto { get; set; }

        [Display(Name = "Producto")]
        [Required(ErrorMessage = "Campo {0}, Es Requerido")]
        [StringLength(50, ErrorMessage = "Campo {0}, puede contener maximo {1} y minimo {2} Digitos ", MinimumLength = 3)]
        public string Nombre { get; set; }

        [Display(Name = "Marca")]
        [StringLength(50, ErrorMessage = "Campo {0}, puede contener maximo {1} y minimo {2} Digitos ", MinimumLength = 0)]
        public string Marca { get; set; }

        [Display(Name = "Ubicación")]
        [StringLength(50, ErrorMessage = "Campo {0}, puede contener maximo {1} y minimo {2} Digitos ", MinimumLength = 0)]
        public string Ubicacion { get; set; }

        [Display(Name = "Descripción")]
        [StringLength(100, ErrorMessage = "Campo {0}, puede contener maximo {1} y minimo {2} Digitos ", MinimumLength = 0)]
        public string Descripcion { get; set; }

        [Display(Name = "Precio")]
        [Required(ErrorMessage = "Campo {0}, Es Requerido")]
        public double Precio { get; set; }

        [Display(Name = "Categoria")]
        [Required(ErrorMessage = "Campo {0}, Es Requerido")]
        public Nullable<int> IdCategoria { get; set; }

        [Display(Name = "Producto")]
        [StringLength(100, ErrorMessage = "Campo {0}, puede contener maximo {1} y minimo {2} Digitos ", MinimumLength = 0)]
        public string Presentacion { get; set; }
        public bool Estado { get; set; }
        public Nullable<int> Existencia { get; set; }

        [Display(Name = "Fecha Vencimiento")]
        [Required(ErrorMessage = "Campo {0}, Es Requerido")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> FechaVencimiento { get; set; }

        [Display(Name = "Código Barra")]
        [StringLength(20, ErrorMessage = "Campo {0}, puede contener maximo {1} y minimo {2} Digitos ", MinimumLength = 0)]
        public string BarCodi { get; set; }
        [Display(Name = "Precio Venta")]
        [Required(ErrorMessage = "Campo {0}, Es Requerido")]
        public Nullable<double> PrecioVenta { get; set; }
    
        public virtual Categoria Categoria { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Compra> Compra { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleVenta> DetalleVenta { get; set; }
    }
}
