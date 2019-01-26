using System;
using System.Collections.Generic;
using Domain.Entity;

namespace Application.Interface
{
    public interface IFilmWorldService
    {
        IEnumerable<Movie> Get();

        Movie Get(Guid id);
    }
}
