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
        ecommerceEntities db = new ecommerceEntities();
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
                    String[] roles = Roles.GetRolesForUser(login.UserName);

                    if (roles.FirstOrDefault(r => r.Equals("Admin")) != null)
                        return RedirectToAction("Home", "Admin/Shared");
                    else
                        return RedirectToAction("ShopCategory", "Producto");
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
            return RedirectToAction("Home", "Shared");
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

                    if (WebSecurity.UserExists(registro.UserName))
                        Roles.AddUserToRole(registro.UserName, "Cliente");

                    if (WebSecurity.Login(registro.UserName, registro.Password))
                        return RedirectToAction("ShopCategory", "Producto");
                    else
                        return RedirectToAction("Home", "Shared");
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
