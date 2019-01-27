using System;
using System.Collections.Generic;
using Domain.Entity;

namespace Repository.Interface
{
    public interface ICinemaWorldRepository
    {
        IEnumerable<Movie> Get();

        Movie Get(Guid id);
    }
}
