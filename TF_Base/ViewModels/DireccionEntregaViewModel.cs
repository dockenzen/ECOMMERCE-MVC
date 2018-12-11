using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TF_Base.ViewModels
{
    public class DireccionEntregaViewModel
    {
        public string Autocomplete { get; set; }
        public string Calle { get; set; }
        public int Numero { get; set; }
        public string Ciudad { get; set; }
        public string Provincia { get; set; }
        public string CodigoPostal { get; set; }
        public string Pais { get; set; }
    }
}