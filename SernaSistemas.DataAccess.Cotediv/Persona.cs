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
    
    public partial class Persona
    {
        public System.Guid Id { get; set; }
        public string usr { get; set; }
        public byte[] pass { get; set; }
        public string Nombre { get; set; }
        public System.DateTime Registro { get; set; }
    
        public virtual Alumno Alumno { get; set; }
        public virtual Experto Experto { get; set; }
        public virtual PersonaDetalle PersonaDetalle { get; set; }
    }
}