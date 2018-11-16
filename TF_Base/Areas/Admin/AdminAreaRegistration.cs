using System.Web.Mvc;

namespace TF_Base.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { controller = "Shared", action = "Home", id = UrlParameter.Optional },
                new string [] { "TF_Base.Areas.Admin.Controllers" }
            );
        }
    }
}