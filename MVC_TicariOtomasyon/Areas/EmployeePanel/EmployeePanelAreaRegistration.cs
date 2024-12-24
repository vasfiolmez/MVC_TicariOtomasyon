using System.Web.Mvc;

namespace MVC_TicariOtomasyon.Areas.EmployeePanel
{
    public class EmployeePanelAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "EmployeePanel";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "EmployeePanel_default",
                "EmployeePanel/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}