using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;


/*
 * NOTAS:
 * - Routing es como ASP.NET MVC matches (empareja) un URI con un action.
 * - El orden de los router importa, se deben poner del más específico al más general.
 * - Se pueden agregar constrains en el router usando objetos anónimos.
 * - En MVC5 se usa el Attribute Routing permite usar un atributo para definir el router, con esto se evita problemas cuando los custon rounters aumenten.
 */


namespace Vidly
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            
            //Esta linea permite usar el Attribute Routing, por eso se comentó el custom routing de abajo
            routes.MapMvcAttributeRoutes();

            /*
            //el orden importa, los routers se deben poner del más específico al más general
            //Una vez creado el custom router se crea el action en MoviesController.cs
            //Esta es la forma antigua de crear un custom router, en MVC5 se usa el Attribute Routing
            routes.MapRoute(
                "MoviesByReleaseDate", //Router Name -> tiene que ser único
                "movies/released/{year}/{month}", //Patrón del URL, los parámetros se ponen entre {}
                new { controller = "Movies", action = "ByReleaseDate" },//Defaults, se usa un objeto anónimo
                new { year = @"\d{4}", month = @"\d{2}" } //Se agrega un constrain para que el año sea de 4 dígitos y el mes de 2
                //new { year = @"2015|2016", month = @"\d{2}" } //Otro ejemplo de constrain donde se especifica que los años solo pueden ser 2015 o 2016
                );
            */

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
