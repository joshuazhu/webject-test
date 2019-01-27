using Domain.Entity;
using Domain.Enumeration;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class FilmWorldRepository : IFilmWorldRepository
    {
        private static List<Movie> _movies = new List<Movie>();

        public FilmWorldRepository()
        {
            PopulateDummyMovies();
        }

        public IEnumerable<Movie> Get()
        {
            return _movies;
        }

        public Movie Get(Guid id)
        {
            return _movies.FirstOrDefault(x => x.Id == id);
        }

        private static void PopulateDummyMovies()
        {
            var rnd = new Random(DateTime.Now.Millisecond);

            _movies.Add(new Movie
            {
                Id = Guid.NewGuid(),
                Price = (decimal)(rnd.Next(12, 25) + 0.25),
                SessionTime = DateTime.Today,
                Title = "A STAR IS BORN",
                ImgSrc = "https://s3-cdn.hoyts.com.au/movies/AU/HO00005808/poster.jpg",
                Genre = MovieGenre.Musical

            });

            _movies.Add(new Movie
            {
                Id = Guid.NewGuid(),
                Price = (decimal)(rnd.Next(12, 25) + 0.25),
                SessionTime = DateTime.Today.AddDays(1),
                Title = "THE ACCIDENTAL PRIME MINISTER",
                ImgSrc = "https://s3-cdn.hoyts.com.au/movies/AU/HO00006312/poster.jpg",
                Genre = MovieGenre.Drama
            });

            _movies.Add(new Movie
            {
                Id = Guid.NewGuid(),
                Price = (decimal)(rnd.Next(12, 25) + 0.25),
                SessionTime = DateTime.Today.AddDays(2),
                Title = "AQUAMAN",
                ImgSrc = "https://s3-cdn.hoyts.com.au/movies/AU/HO00005123/poster.jpg",
                Genre = MovieGenre.Action
            });
        }
    }
}
