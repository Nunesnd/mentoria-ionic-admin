
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace adminMeuApp.Models.Infraestrutura.Autenticacao
{
    public class LogadoAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (string.IsNullOrEmpty(filterContext.HttpContext.Request.Cookies["adm_cms"]))
            {
                filterContext.HttpContext.Response.Redirect("/login");
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }
}