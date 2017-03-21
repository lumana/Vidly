using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;


/*
 * Notas:
 * - Un Action puede retornar diferentes cosas
 *          -> return Content("Hello World!"); //retorna un texto plano
 *          -> return HttpNotFound(); //retorna el error estandar 404
 *          -> return new EmptyResult();// para un empy result no hay un helper method
 *          -> return RedirectToAction("Index", "Home", new {page = 1, sortBy = "name"});
 * - Se pueden pasar datos a una vista usando:
 *          -> Un ViewData["MagicString"] pero tiene el problema para accesar a las propiedades (hay que hacer un cast) y si se cambia el magic string hay que tener el cuidado de ir a cambiarlo al View
 *          -> También está el ViewBag que tiene el mismo problema
 */

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek" };
            return View(movie);

            /* No usar ViewData ni ViewBag
             * ViewData["Movie"] = movie;
            ViewBag.Movie = movie;
            return View();
             */

            //return Content("Hello World!"); //retorna un texto plano
            //return HttpNotFound(); //retorna el error estandar 404
            //return new EmptyResult();// para un empy result no hay un helper method
            //return RedirectToAction("Index", "Home", new {page = 1, sortBy = "name"});
        }

        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        // movies -- con paramétros opcionales
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;

            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            return Content(string.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }


        //El nombre del action se definio en el RouterConfig
        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1, 12)}")] //Usando el Route Attribute
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

    }
}