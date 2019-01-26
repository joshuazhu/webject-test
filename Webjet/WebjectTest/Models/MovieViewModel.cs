using System;

namespace WebjectTest.Models
{
    public class MoviewViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string SessionTime { get; set; }
        public string Date { get; set; }
        public string Genre { get; set; }
        public string ImgSrc { get; set; }
        public string Source { get; set; }
    }
}
