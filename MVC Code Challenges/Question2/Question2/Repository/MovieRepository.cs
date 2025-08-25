using System;
using System.Collections.Generic;
using System.Linq;
using Question2.Models;
using System.Data.Entity;

namespace Question2.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private MoviesDbContext db;

        public MovieRepository()
        {
            db = new MoviesDbContext();
        }

        public IEnumerable<Movies> GetAll()
        {
            return db.Movies.ToList();
        }

        public Movies GetById(int id)
        {
            return db.Movies.Find(id);
        }

        public void Add(Movies movie)
        {
            db.Movies.Add(movie);
            db.SaveChanges();
        }

        public void Update(Movies movie)
        {
            db.Entry(movie).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var movie = db.Movies.Find(id);
            if (movie != null)
            {
                db.Movies.Remove(movie);
                db.SaveChanges();
            }
        }

        public IEnumerable<Movies> GetByYear(int year)
        {
            return db.Movies.Where(m => m.DateofRelease.Year == year).ToList();
        }

        public IEnumerable<Movies> GetByDirector(string director)
        {
            return db.Movies.Where(m => m.DirectorName == director).ToList();
        }
    }
}
