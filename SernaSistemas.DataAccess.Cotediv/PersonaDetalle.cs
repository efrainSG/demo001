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
    
    public partial class PersonaDetalle
    {
        public System.Guid IdPersona { get; set; }
        public int IdPais { get; set; }
        public int IdCiudad { get; set; }
        public int IdEstado { get; set; }
        public int IdSexo { get; set; }
    
        public virtual Persona Persona { get; set; }
        public virtual Catalogo Catalogo { get; set; }
        public virtual Catalogo Catalogo1 { get; set; }
        public virtual Catalogo Catalogo2 { get; set; }
        public virtual Catalogo Catalogo3 { get; set; }
    }
}