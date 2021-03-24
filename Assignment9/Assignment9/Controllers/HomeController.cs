using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Assignment9.Models;

namespace Assignment9.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private MoviesContext _context { get; set; }

        public HomeController(ILogger<HomeController> logger, MoviesContext context)
        {
            _logger = logger;
            _context = context;
        }

        // Point to the index view
        public IActionResult Index()
        {
            return View();
        }

        // Point to the Podcasts view
        public IActionResult Podcasts()
        {
            return View();
        }

        // On Get for AddMovies this is where we go
        [HttpGet]
        public IActionResult AddMovies()
        {
            return View();
        }

        // On Post for AddMovies this is where we go (cannot show independence day)
        [HttpPost]
        public IActionResult AddMovies(Movie m)
        {

            if (ModelState.IsValid)
            {
                _context.Movies.Add(m);
                _context.SaveChanges();
                return View("ViewMovies", _context.Movies.Where(x => x.Title != "Independence Day"));
            }
            else
            {
                return View();
            }

        }

        // Return view for ViewMovies (cannot show independence day)
        public IActionResult ViewMovies()
        {
            return View(_context.Movies.Where(x => x.Title != "Independence Day"));
        }

        // OnPost for Remove Movie, the following is called, and returns the RemoveConfirmation Page
        [HttpPost]
        public IActionResult RemoveMovie(int movieId)
        {
            _context.Movies.Remove(_context.Movies.Where(x => x.MovieId == movieId).FirstOrDefault());
            _context.SaveChanges();

            return View("RemoveConfirmation");
        }

        // OnGet for EditMovie, the following occurs
        [HttpGet]
        public IActionResult EditMovie(int movieId)
        {
            return View(_context.Movies.Where(x => x.MovieId == movieId).FirstOrDefault());
        }

        // OnPost for EditMovie, the following happens and return the user to the view of movies
        [HttpPost]
        public IActionResult EditMovie(Movie m)
        {
            _context.Movies.Update(m);

            _context.SaveChanges();

            return View("ViewMovies", _context.Movies.Where(x => x.Title != "Independence Day"));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
