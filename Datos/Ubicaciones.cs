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
    
    public partial class Ubicaciones
    {
        public Ubicaciones()
        {
            this.Alojamientos = new HashSet<Alojamientos>();
        }
    
        public int idUbicacion { get; set; }
        public string nombreCiudad { get; set; }
        public string nombreDepartamento { get; set; }
        public string direccion { get; set; }
        public string descripcion { get; set; }
    
        public virtual ICollection<Alojamientos> Alojamientos { get; set; }
    }
}
