//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace tiendas.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class localidad
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public localidad()
        {
            this.localidad1 = new HashSet<localidad>();
        }
    
        public int id { get; set; }
        public string nombre { get; set; }
        public int idtipolocalidad { get; set; }
        public Nullable<int> idlocalidad { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<localidad> localidad1 { get; set; }
        public virtual localidad localidad2 { get; set; }
        public virtual tipolocalidad tipolocalidad { get; set; }
    }
}
