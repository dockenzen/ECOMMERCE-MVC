using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TF_Base.Models
{
    public class Registro
    {
        [Display(Name = "Nombre de usuario")]
        [Required]
        public string UserName { get; set; }

        [Display(Name = "Nombre de pila")]
        [Required]
        public string Nombre { get; set; }

        [Display(Name = "Apellido")]
        [Required]
        public string Apellido { get; set; }

        [Display(Name = "DNI")]
        [Required]
        public string DNI { get; set; }

        [Display(Name = "Telefono")]
        [Required]
        public string Telefono { get; set; }

        [Display(Name = "Email")]
        [Required]
        public string UserEmail { get; set; }

        [Display(Name = "Direccion")]
        [Required]
        public string Direccion { get; set; }

        [Display(Name = "CodigoPostal")]
        [Required]
        public string CodigoPostal { get; set; }

        [Required]
        public int idLocalidad { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        [StringLength(25, ErrorMessage = "La contraseña es muy corta o muy larga", MinimumLength = 6)]
        [Required]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Repita su contraseña")]
        [Required]
        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden.")]
        public string PasswordConfirmation { get; set; }
    }

    public class Login
    {
        [Display(Name = "Nombre de usuario")]
        [Required]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        [Required]
        public string Password { get; set; }

        [Display(Name = "Mantener sesion iniciada")]
        public bool RememberMe { get; set; }
    }
}