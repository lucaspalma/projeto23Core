using blog.Extensions;
using blog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;

namespace blog.Filtro
{
    public class AutorizacaoFilterAttribute : ActionFilterAttribute
    {
        
        public override void OnActionExecuting(ActionExecutingContext context) {
            Usuario usuario = context.HttpContext.Session.Get<Usuario>("usuario");
            if(usuario == null) {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new {
                                    area = "",
	                                controller = "Usuario",
	                                action = "Login"
                                }));
            }
        }

    }
}