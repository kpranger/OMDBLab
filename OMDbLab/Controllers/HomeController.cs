using Microsoft.AspNetCore.Mvc;
using OMDbLab.Models;
using System.Diagnostics;

namespace OMDbLab.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public MovieDAL movieDAL { get; set; } = new MovieDAL();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]     //run when you first go to page
        public IActionResult MovieSearch()
        {
            return View();
        }

        [HttpPost]     //run when you submit your form
        public IActionResult MovieSearch(string title)
        {
            MovieModel movie = movieDAL.GetMovie(title);
            return View(movie);
        }

        [HttpGet]     //run when you first go to page
        public IActionResult MovieNightForm()
        {
            return View();
        }

        [HttpPost]     //run when you submit your form
        public IActionResult MovieNightResults(string title1, string title2, string title3)
        {
            List<MovieModel> results = new List<MovieModel>
            {
                movieDAL.GetMovie(title1),
                movieDAL.GetMovie(title2),
                movieDAL.GetMovie(title3)
            };
            return View(results);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}