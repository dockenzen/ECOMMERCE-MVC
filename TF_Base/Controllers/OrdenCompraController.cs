using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using TF_Base.Models;
using TF_Base.ViewModels;
using WebMatrix.WebData;

namespace TF_Base.Controllers
{
    public class OrdenCompraController : Controller
    {
        private ecommerceEntities db = new ecommerceEntities();

        //
        // GET: /OrdenCompra/
        [Authorize(Roles = "Cliente")]
        public ActionResult ShopBasket()
        {
            OrdenCompra ordencompra = db.OrdenCompra.FirstOrDefault(oc => oc.OrdenCompraEstado.idEstadoOrden == 1
                                                     && oc.idUsuario == WebMatrix.WebData.WebSecurity.CurrentUserId);

            if (ordencompra == null)
                ordencompra = new OrdenCompra();

            ViewBag.ProductosAlAzar = db.Producto.OrderByDescending(p => p.Stock.FirstOrDefault().cantidad).ToList();

            return View(ordencompra.OrdenCompraDetalle);
        }

        //
        // POST: /OrdenCompra/
        [HttpPost]
        [Authorize(Roles = "Cliente")]
        public ActionResult ShopBasket(FormCollection form)
        {
            if (ModelState.IsValid)
            {
                String[] claves = form.AllKeys;
                foreach (string clave in claves)
                {
                    string id = clave.Split('_')[1];
                    string valor = form[clave];
                    OrdenCompraDetalle ocd = db.OrdenCompraDetalle.Find(Convert.ToInt32(id));
                    ocd.cantidad = Convert.ToInt32(valor);
                    db.Entry(ocd).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("ShopBasket");
        }



        [ActionName("DeleteDetalle")]
        public ActionResult DeleteDetalle(int id = 0)
        {
            if (id != 0)
            {
                OrdenCompraDetalle ordenCompraDetalle = db.OrdenCompraDetalle.Find(id);
                db.OrdenCompraDetalle.Remove(ordenCompraDetalle);
                db.SaveChanges();
            }
            return RedirectToAction("ShopBasket");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult ShopCheckoutStep1(int id = 0)
        {
            BuyerDataModelView data = new BuyerDataModelView();

            ViewData.Add("sc", db.Sucursal.ToList());
            ViewData.Add("dp", db.DatosPersonales.FirstOrDefault(d => d.idUsuario == WebMatrix.WebData.WebSecurity.CurrentUserId));

            return View(data);
        }

        [HttpPost]
        public ActionResult ShopCheckoutStep1(BuyerDataModelView data, int idSucursal = 0)
        {
            //if (ModelState.IsValid)
            //{

            OrdenCompra ordencompra = db.OrdenCompra.FirstOrDefault(oc => oc.OrdenCompraEstado.idEstadoOrden == 1
                                                     && oc.idUsuario == WebSecurity.CurrentUserId);

            CargarPago(data, ordencompra);
            CargarEnvio(ordencompra, data, idSucursal);

            return RedirectToAction("ShopCheckoutStep4", "OrdenCompra", new { id = ordencompra.idOrdenCompra });
            //un par de save y creacion de otros objetos, se le cambia el estado a la orden de compra y se pasa a chackout4
            //}

            ModelState.AddModelError("", "Se produjo un error cuando se procesaba la solicitud");

            return View(data);
        }

        private void CargarPago(BuyerDataModelView data, OrdenCompra oc)
        {
            Pago pago = new Pago();
            pago.idEstadoPago = 1;
            pago.tipoPago = (int)data.MetodoDePago;
            pago.total = oc.OrdenCompraDetalle.Sum(detalle => detalle.cantidad * detalle.Producto.precioUnitario);
            pago.OrdenCompra.Add(oc);
        }

        private void CargarEnvio(OrdenCompra ordencompra, BuyerDataModelView data, int idSucursal = 0)
        {
            Envio e = new Envio();
            DatosPersonales dp = db.DatosPersonales.FirstOrDefault(d => d.idUsuario == WebSecurity.CurrentUserId);

            if (data.MetodoEntrega == MetodoEntrega.RetiroEnSucursal)
            {
                e.idDireccion = db.Sucursal.FirstOrDefault(s => s.idSucursal == idSucursal).idDireccion;
            }
            else
            {
                if (data.UsarDireccionDeContacto)
                {
                    e.idDireccion = dp.idDireccion;
                    e.fechaEntrega = new DateTime().AddDays(10);
                    e.costoEnvio = GetCostoEnvio(dp.Direccion.Localidad);
                }
                else
                {
                    e.costoEnvio = GetCostoEnvio(data.Direccion.Ciudad);
                    e.Direccion = new Direccion()
                    {
                        codigoPostal = data.Direccion.CodigoPostal,
                        direccion1 = data.Direccion.Calle + " " + data.Direccion.Numero,
                        Localidad = db.Localidad.FirstOrDefault(ce => ce.localidad1.ToLower() == data.Direccion.Ciudad.ToLower()),

                    };
                    e.fechaEntrega = new DateTime().AddDays(10);
                }
            }
            if (data.UsarDatosDeContacto)
            {
                e.nombre = dp.nombre;
                e.apellido = dp.apellido;
                e.telefono = "21132123"; //todo cambiar x dp.telefono
                e.mail = dp.Usuario.email;
            }
            else
            {
                e.nombre = data.Nombre;
                e.apellido = data.Apellido;
                e.telefono = data.Telefono;
                e.mail = data.Mail;
            }

            OrdenCompraEnvio oce = new OrdenCompraEnvio();
            oce.Envio = e;
            oce.OrdenCompra = ordencompra;

            db.OrdenCompraEnvio.Add(oce);
            db.SaveChanges();
            //cambiar estado a la vaina

        }
        private decimal GetCostoEnvio(Localidad localidad)
        {
            return db.CostoEnvio.FirstOrDefault(ce => ce.idLocalidad == localidad.id).Importe;
        }

        private decimal GetCostoEnvio(string localidad)
        {
            localidad = localidad.ToLower();
            return db.CostoEnvio.FirstOrDefault(ce => ce.Localidad.localidad1.ToLower() == localidad).Importe;
        }


        public ActionResult ShopCheckoutStep4(int id = 0)
        {
            OrdenCompra orden = db.OrdenCompra.Find(id);
            return View(orden);
        }

        private Usuario GetUsuario()
        {
            return db.Usuario.FirstOrDefault(u => u.idUsuario == WebSecurity.CurrentUserId);
        }

        private bool ValidarNumeroTarjetaIngresada(string numero)
        {
            Regex regex = new Regex("/^(?:4[0-9]{12}(?:[0-9]{3})?|[25][1-7][0-9]{14}|6(?:011|5[0-9][0-9])[0-9]{12}|3[47][0-9]{13}|3(?:0[0-5]|[68][0-9])[0-9]{11}|(?:2131|1800|35\\d{3})\\d{11})$/");
            return regex.IsMatch(numero);
        }
    }
}