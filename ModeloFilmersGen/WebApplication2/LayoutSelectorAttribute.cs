using Microsoft.AspNetCore.Mvc.Filters;

public class LayoutSelectorAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        var usuario = // Aquí obtienes tu usuario (dependiendo de tu lógica de autenticación)

        if (usuario == null)
        {
            filterContext.Controller.ViewData["Layout"] = "~/Views/Shared/LayoutSinLogin.cshtml";
        }
        else
        {
            filterContext.BasicController.ViewData["Layout"] = "~/Views/Shared/TuLayoutNormal.cshtml";
        }

        base.OnActionExecuting(filterContext);
    }
}
