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
    
    public partial class Usuario
    {
        public Usuario()
        {
            this.BlackList = new HashSet<BlackList>();
            this.DatosPersonales = new HashSet<DatosPersonales>();
            this.OrdenCompra = new HashSet<OrdenCompra>();
            this.webpages_Roles = new HashSet<webpages_Roles>();
            this.Producto = new HashSet<Producto>();
        }
    
        public int idUsuario { get; set; }
        public string userName { get; set; }
        public string email { get; set; }
        public Nullable<int> cantidadPenalizacion { get; set; }
        public int idEstadoUsuario { get; set; }
    
        public virtual ICollection<BlackList> BlackList { get; set; }
        public virtual ICollection<DatosPersonales> DatosPersonales { get; set; }
        public virtual ICollection<OrdenCompra> OrdenCompra { get; set; }
        public virtual UsuarioEstado UsuarioEstado { get; set; }
        public virtual ICollection<webpages_Roles> webpages_Roles { get; set; }
        public virtual ICollection<Producto> Producto { get; set; }
    }
}