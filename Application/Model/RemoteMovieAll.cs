using System.Collections.Generic;

namespace Application.Model
{
    /// <summary>
    /// Model that represents the data from movies API
    /// </summary>
    public class RemoteMovieAll
    {
        public List<RemoteMovieBrief> Movies { get; set; }
    }
}
