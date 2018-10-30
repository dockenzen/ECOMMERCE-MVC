using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TF_Base.Models;
using WebMatrix.WebData;

namespace TF_Base.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/Login
        public ActionResult Login()
        {
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        public ActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                bool res = WebSecurity.Login(login.UserName, login.Password, login.RememberMe);
                if (res)
                {
                    return RedirectToAction("Index", "Producto");
                }
            }

            ModelState.AddModelError("", "Datos incorrectos");
            return View(login);
        }

        //
        // GET: /Account/Logout
        public ActionResult Logout()
        {
            WebSecurity.Logout();
            return RedirectToAction("Index", "Producto");
        }

        //
        // GET: /Account/Register

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult CustomerRegister()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Registro registro)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    WebSecurity.CreateUserAndAccount(registro.UserName, registro.Password, new { Email = registro.UserEmail, idEstadoUsuario = 1 });
                    if (WebSecurity.Login(registro.UserName, registro.Password))
                        return RedirectToAction("OrdenCompra", "ShopBasket");
                    else
                        return RedirectToAction("Index", "Producto");
                }
                catch (MembershipCreateUserException e)
                {
                    ModelState.AddModelError("", e.StatusCode.ToString());
                }
            }
            return View();
        }

    }
}
