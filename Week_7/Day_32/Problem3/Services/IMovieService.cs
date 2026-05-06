using System.Collections.Generic;
using MyWebApplication3.Models;

namespace MyWebApplication3.Services
{
    public interface IMovieService
    {
        List<Movie> GetMovies();
        Movie GetMovie(int id);
        void AddMovie(Movie movie);
        void UpdateMovie(Movie movie);
        void DeleteMovie(int id);
    }
}