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
    
    public partial class CuentasUsuarios
    {
        public string email { get; set; }
        public string contrasena { get; set; }
        public string cedulaUsuario { get; set; }
    
        public virtual Administradores Administradores { get; set; }
        public virtual Usuarios Usuarios { get; set; }
    }
}
