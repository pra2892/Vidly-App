using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        [Route("movies")]
        public ActionResult Random()
        {
            var movies = getMovieList();
            return View(movies);
        }

        [Route("movies/details/{Id}")]
        public ActionResult Details(int Id)
        {
            var movie = getMovieList().SingleOrDefault(item => item.Id == Id);
            if (movie == null) { return HttpNotFound(); }
            return View(movie);
        }

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year +"/"+ month);
        }

        private IEnumerable<Movie> getMovieList() {
            return new List<Movie>
            {
                new Movie { Id = 1, Name = "Pushpa" },
                new Movie { Id = 2, Name = "KGF" }
            };
        }

    }
}