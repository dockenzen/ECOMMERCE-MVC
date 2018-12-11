using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TF_Base.ViewModels
{
    public class BuyerDataModelView
    {
        public MetodoEntrega MetodoEntrega { get; set; }
        public bool UsarDireccionDeContacto { get; set; }

        public MetodoPago MetodoDePago { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }

        [Required]
        public string Telefono { get; set; }

        [Required]
        public string Mail { get; set; }

        public DireccionEntregaViewModel Direccion { get; set; }
    }

    public enum MetodoEntrega
    {
        RetiroEnSucursal,
        EnvioDomicilio
    }

    public enum MetodoPago
    {
        Efectivo,
        Credito
    }
}