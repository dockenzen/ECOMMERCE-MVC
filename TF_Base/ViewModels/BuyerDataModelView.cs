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
        public bool UsarDatosDeContacto { get; set; }

        public MetodoPago MetodoDePago { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Telefono { get; set; }

        public string Mail { get; set; }

        public DireccionEntregaViewModel Direccion { get; set; }
    }

    public enum MetodoEntrega
    {
        RetiroEnSucursal = 1,
        EnvioDomicilio = 2
    }

    public enum MetodoPago
    {
        Efectivo = 1,
        Credito = 2
    }
}