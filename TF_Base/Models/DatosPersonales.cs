//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TF_Base.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DatosPersonales
    {
        public int datosPersonalesId { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string dni { get; set; }
        public int idDireccion { get; set; }
        public int idUsuario { get; set; }
    
        public virtual Direccion Direccion { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
