using Microsoft.AspNetCore.Mvc;
using MyWebApplication3.Data;
using MyWebApplication3.Models;
using System.Linq;

namespace MyWebApplication3.Controllers
{
    public class MoviesController : Controller
    {
        private readonly AppDbContext _context;

        public MoviesController(AppDbContext context)
        {
            _context = context;
        }

        // READ → List all movies
        public IActionResult Index()
        {
            var movies = _context.Movies.ToList();
            return View(movies);
        }

        // CREATE → GET
        public IActionResult Create()
        {
            return View();
        }

        // CREATE → POST
        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // EDIT → GET
        public IActionResult Edit(int id)
        {
            var movie = _context.Movies.Find(id);
            return View(movie);
        }

        // EDIT → POST
        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            _context.Movies.Update(movie);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // DELETE → GET
        public IActionResult Delete(int id)
        {
            var movie = _context.Movies.Find(id);
            return View(movie);
        }

        // DELETE → POST
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var movie = _context.Movies.Find(id);
            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // DETAILS
        public IActionResult Details(int id)
        {
            var movie = _context.Movies.Find(id);
            return View(movie);
        }
    }
}