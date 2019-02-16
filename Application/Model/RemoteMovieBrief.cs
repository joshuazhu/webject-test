namespace Application.Model
{
    /// <summary>
    /// Model that represents the brief movie from movies API
    /// </summary>
    public class RemoteMovieBrief
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string Id { get; set; }
        public string Type { get; set; }
        public string Poster { get; set; }
    }
}
