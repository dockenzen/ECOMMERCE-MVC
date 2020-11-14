﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ecommerceEntities : DbContext
    {
        public ecommerceEntities()
            : base("name=ecommerceEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Banco> Banco { get; set; }
        public virtual DbSet<BlackList> BlackList { get; set; }
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Color> Color { get; set; }
        public virtual DbSet<CostoEnvio> CostoEnvio { get; set; }
        public virtual DbSet<Cupon> Cupon { get; set; }
        public virtual DbSet<DatosPersonales> DatosPersonales { get; set; }
        public virtual DbSet<Direccion> Direccion { get; set; }
        public virtual DbSet<Envio> Envio { get; set; }
        public virtual DbSet<EstadoPago> EstadoPago { get; set; }
        public virtual DbSet<Factura> Factura { get; set; }
        public virtual DbSet<Garantia> Garantia { get; set; }
        public virtual DbSet<ImagenProducto> ImagenProducto { get; set; }
        public virtual DbSet<Localidad> Localidad { get; set; }
        public virtual DbSet<OrdenCompra> OrdenCompra { get; set; }
        public virtual DbSet<OrdenCompraDetalle> OrdenCompraDetalle { get; set; }
        public virtual DbSet<OrdenCompraEnvio> OrdenCompraEnvio { get; set; }
        public virtual DbSet<OrdenCompraEstado> OrdenCompraEstado { get; set; }
        public virtual DbSet<Pago> Pago { get; set; }
        public virtual DbSet<Pais> Pais { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Provincia> Provincia { get; set; }
        public virtual DbSet<Stock> Stock { get; set; }
        public virtual DbSet<SubCategoria> SubCategoria { get; set; }
        public virtual DbSet<Sucursal> Sucursal { get; set; }
        public virtual DbSet<Talle> Talle { get; set; }
        public virtual DbSet<Tarjeta> Tarjeta { get; set; }
        public virtual DbSet<TarjetaUsuario> TarjetaUsuario { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<UsuarioEstado> UsuarioEstado { get; set; }
        public virtual DbSet<webpages_Membership> webpages_Membership { get; set; }
        public virtual DbSet<webpages_OAuthMembership> webpages_OAuthMembership { get; set; }
        public virtual DbSet<webpages_Roles> webpages_Roles { get; set; }
        public virtual DbSet<WishList> WishList { get; set; }
    }
}