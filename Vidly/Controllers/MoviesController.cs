using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Route("movies")]
        public ActionResult Random()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();
            return View(movies);
        }

        [Route("movies/details/{Id}")]
        public ActionResult Details(int Id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(item => item.Id == Id);
            if (movie == null) { return HttpNotFound(); }
            return View(movie);
        }

        [Route("movies/new")]
        public ActionResult New() {

            ViewBag.pageTitle = "New Movie";

            var genres = _context.Genres.ToList();

            var viewModel = new MovieWithGenre { 
                Genres = genres
            };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Movie movie) {
            if (movie.Id == 0) {
                _context.Movies.Add(movie);
            }
            else
            {
                var MovieInDB = _context.Movies.Single(m => m.Id == movie.Id);
                MovieInDB.Name = movie.Name;
                MovieInDB.ReleaseDate = movie.ReleaseDate;
                MovieInDB.NumberInStock = movie.NumberInStock;
                MovieInDB.GenreId = movie.GenreId;
            }

            _context.SaveChanges();

            return RedirectToAction("Random", "Movies");
        }

        [Route("movies/edit/{Id}")]
        public ActionResult Edit(int Id) {
            ViewBag.pageTitle = "Edit Movie";

            var movies = _context.Movies.SingleOrDefault(m => m.Id == Id);
            if (movies == null)
            {
                return HttpNotFound();
            }

            var viewModel = new MovieWithGenre
            {
                movie = movies,
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", viewModel);
        }
    }
}