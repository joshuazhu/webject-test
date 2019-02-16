namespace Application.Model
{
    public class MovieBrief
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string Id { get; set; }
        public string Type { get; set; }
        public string Poster { get; set; }
        public decimal Price { get; set; }
        public SourceEnum? Source { get; set; }
    }
}
