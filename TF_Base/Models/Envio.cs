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
    
    public partial class Envio
    {
        public Envio()
        {
            this.OrdenCompraEnvio = new HashSet<OrdenCompraEnvio>();
        }
    
        public int idEnvio { get; set; }
        public System.DateTime fechaEntrega { get; set; }
        public decimal costoEnvio { get; set; }
    
        public virtual ICollection<OrdenCompraEnvio> OrdenCompraEnvio { get; set; }
    }
}