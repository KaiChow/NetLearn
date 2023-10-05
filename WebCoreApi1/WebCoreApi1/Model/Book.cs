namespace WebCoreApi1.Model
{
    public class Book
    {
        public long Id { get; set; }
        public string? Title { get; set; }
        public DateTime PubTime { get; set; }
        public double Price { get; set; }
        public string AuthorName { get; set; }
    }
}
