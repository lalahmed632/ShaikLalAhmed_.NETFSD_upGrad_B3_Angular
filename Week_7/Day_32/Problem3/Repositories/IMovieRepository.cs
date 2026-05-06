using System.Collections.Generic;
using MyWebApplication3.Models;

namespace MyWebApplication3.Repositories
{
    public interface IMovieRepository
    {
        List<Movie> GetAll();
        Movie GetById(int id);
        void Add(Movie movie);
        void Update(Movie movie);
        void Delete(int id);
    }
}