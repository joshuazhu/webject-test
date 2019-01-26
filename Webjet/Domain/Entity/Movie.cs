using System;
using Domain.Enumeration;

namespace Domain.Entity
{
    public class Movie
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public DateTime SessionTime { get; set; }
        public MovieGenre Genre { get; set; }
        public string ImgSrc { get; set; }
    }
}
