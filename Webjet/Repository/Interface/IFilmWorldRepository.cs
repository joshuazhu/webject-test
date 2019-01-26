using System;
using System.Collections.Generic;
using Domain.Entity;

namespace Repository.Interface
{
    public interface IFilmWorldRepository
    {
        IEnumerable<Movie> Get();

        Movie Get(Guid id);
    }
}
