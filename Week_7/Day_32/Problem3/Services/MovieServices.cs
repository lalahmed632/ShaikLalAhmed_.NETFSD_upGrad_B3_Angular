using System.Collections.Generic;
using MyWebApplication3.Models;
using MyWebApplication3.Repositories;

namespace MyWebApplication3.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _repo;

        public MovieService(IMovieRepository repo)
        {
            _repo = repo;
        }

        public List<Movie> GetMovies()
        {
            return _repo.GetAll();
        }

        public Movie GetMovie(int id)
        {
            return _repo.GetById(id);
        }

        public void AddMovie(Movie movie)
        {
            _repo.Add(movie);
        }

        public void UpdateMovie(Movie movie)
        {
            _repo.Update(movie);
        }

        public void DeleteMovie(int id)
        {
            _repo.Delete(id);
        }
    }
}