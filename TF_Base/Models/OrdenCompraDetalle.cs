//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TF_Base.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class OrdenCompraDetalle
    {
        public int idDetalleOrden { get; set; }
        public int idOrdenCompra { get; set; }
        public int idProducto { get; set; }
        public int cantidad { get; set; }
    
        public virtual OrdenCompra OrdenCompra { get; set; }
        public virtual Producto Producto { get; set; }
    }
}
