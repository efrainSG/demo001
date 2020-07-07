//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SernaSistemas.DataAccess.Cotediv
{
    using System;
    using System.Collections.Generic;
    
    public partial class Catalogo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Catalogo()
        {
            this.Escuela = new HashSet<Escuela>();
            this.EscuelaUbicacion = new HashSet<EscuelaUbicacion>();
            this.EscuelaUbicacion1 = new HashSet<EscuelaUbicacion>();
            this.PersonaDetalle = new HashSet<PersonaDetalle>();
            this.PersonaDetalle1 = new HashSet<PersonaDetalle>();
            this.PersonaDetalle2 = new HashSet<PersonaDetalle>();
            this.PersonaDetalle3 = new HashSet<PersonaDetalle>();
            this.Publicaciones = new HashSet<Publicaciones>();
            this.Publicaciones1 = new HashSet<Publicaciones>();
            this.EvaluacionPublicaciones = new HashSet<EvaluacionPublicaciones>();
            this.Opiniones = new HashSet<Opiniones>();
            this.Experto = new HashSet<Experto>();
        }
    
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Valor { get; set; }
        public string TipoDato { get; set; }
        public int IdTipoCatalogo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Escuela> Escuela { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EscuelaUbicacion> EscuelaUbicacion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EscuelaUbicacion> EscuelaUbicacion1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonaDetalle> PersonaDetalle { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonaDetalle> PersonaDetalle1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonaDetalle> PersonaDetalle2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonaDetalle> PersonaDetalle3 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Publicaciones> Publicaciones { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Publicaciones> Publicaciones1 { get; set; }
        public virtual TipoCatalogo TipoCatalogo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EvaluacionPublicaciones> EvaluacionPublicaciones { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Opiniones> Opiniones { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Experto> Experto { get; set; }
    }
}