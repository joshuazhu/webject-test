using System.Collections.Generic;

namespace Application.Model
{
    /// <summary>
    /// Model that represents movies that are grouped by movie title
    /// sample:
    /// {
    ///     "movieTitle": 
    ///     {
    ///         "source": 
    ///         {
    ///             "CinemaWorldMoviesBreBriefs": {},
    ///             "FilmWorldMovieBriefs": {}
    ///         }
    ///     }
    /// }
    /// </summary>
    public class MovieGroupsByTitle
    {
        public Dictionary<string, MoviesBriefInSources> Sources { get; set; }
    }
}
