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
    
    public partial class OrdenCompra
    {
        public OrdenCompra()
        {
            this.OrdenCompraDetalle = new HashSet<OrdenCompraDetalle>();
            this.OrdenCompraEnvio = new HashSet<OrdenCompraEnvio>();
        }
    
        public int idOrdenCompra { get; set; }
        public int idUsuario { get; set; }
        public int idSucursal { get; set; }
        public Nullable<int> idCupon { get; set; }
        public int idOrdenCompraEnvio { get; set; }
        public int idPago { get; set; }
        public int idEstadoOrden { get; set; }
    
        public virtual Cupon Cupon { get; set; }
        public virtual OrdenCompraEstado OrdenCompraEstado { get; set; }
        public virtual Pago Pago { get; set; }
        public virtual Sucursal Sucursal { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<OrdenCompraDetalle> OrdenCompraDetalle { get; set; }
        public virtual ICollection<OrdenCompraEnvio> OrdenCompraEnvio { get; set; }
    }
}