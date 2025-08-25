using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Question2.Models;
using Question2.Repository;

namespace Question2.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieRepository _repo;

        public MovieController()
        {
            _repo = new MovieRepository();
        }

        // GET: Movie
        public ActionResult Index()
        {
            var movies = _repo.GetAll();
            return View(movies);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Movies movie)
        {
            if (ModelState.IsValid)
            {
                _repo.Add(movie);
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        public ActionResult Edit(int id)
        {
            var movie = _repo.GetById(id);
            if (movie == null)
                return HttpNotFound();
            return View(movie);
        }

        [HttpPost]
        public ActionResult Edit(Movies movie)
        {
            if (ModelState.IsValid)
            {
                _repo.Update(movie);
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        public ActionResult Delete(int id)
        {
            var movie = _repo.GetById(id);
            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _repo.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult ByYear(int? year)
        {
            if (year == null)
                return View(); 

            var movies = _repo.GetByYear(year.Value);
            return View(movies);
        }


        public ActionResult ByDirector(string director)
        {
            var movies = _repo.GetByDirector(director);
            return View(movies);
        }
    }
}
