//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Datos
{
    using System;
    using System.Collections.Generic;
    
    public partial class CalificacionesAlojamiento
    {
        public int idCalificacion { get; set; }
        public string cedulaArrendatario { get; set; }
        public int idAlojamiento { get; set; }
        public System.DateTime fechaCalificacion { get; set; }
    
        public virtual Alojamientos Alojamientos { get; set; }
        public virtual Arrendatarios Arrendatarios { get; set; }
        public virtual Calificaciones Calificaciones { get; set; }
    }
}
